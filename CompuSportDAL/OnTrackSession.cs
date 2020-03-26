using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using SwingModel.Data;
using SwingModel.Entities;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Web.Security;
using System.Collections;

namespace CompuSportDAL
{

    public class OnTrackSession
    {
        public CustomerProfile customerprofile;
        public CustomerProfile customerprofile1;
        public int _onTrackSessionlessonId;
        IList<SessionData> _sessionDataList = new List<SessionData>();
        int _onTrackSessionID = 0;
        int _initialCount = 0;
        int _finalCount = 0;
        int _modelCount = 0;
        SprintData _sessionSummary = new SprintData();
        SprintData _initialSummary = new SprintData();
        SprintData _finalSummary = new SprintData();
        SprintData _modelSummary = new SprintData();
        Movie movieSide;
        Movie movieBack;
        Movie CurrentMovieSide;
        Movie CurrentMovieBack;
        bool isMovieClipsExist = false;

        string variableDeatils;
        Customer customer;


        CompuSportDAL.SprintAthleteEdit sae = new CompuSportDAL.SprintAthleteEdit();
        CompuSportDAL.SprintData _SprintData = new CompuSportDAL.SprintData();

        DataSet dsSessions = new DataSet();
        DataTable dtSession = new DataTable();



        public void OnTrackSessionData(int athleteSelected)
        {
            string message = string.Empty;
            // var isLessonExists = sae.FindOnTrackSession();
            //if (isLessonExists == false)
            {
                var custmer = customer = DataRepository.CustomerProvider.GetByCustomerId(athleteSelected);

                var lessonlist = DataRepository.LessonProvider.GetByCustomerId(athleteSelected);
                var cust = DataRepository.CustomerProvider.GetByCustomerId(athleteSelected);

                if (cust != null)
                {
                    Lesson lessonid = DataRepository.LessonProvider.GetByCustomerId(cust.CustomerId)[0];
                    string athletelessonid = lessonid.LessonId.ToString();
                }
                lessonlist.Sort("LessonDate DESC");

                foreach (Lesson lesson in lessonlist)
                {
                    string location = sae.SelectLessonlocation(lesson.LessonId.ToString());
                    if ((location != "On-Track Sesssion Summary" && lesson.LessonTypeId != 1))
                    {
                        if (!location.Contains('(') && lesson.LessonTypeId.Equals(2))
                        {
                            var dsSession = sae.GetAllSprintAthletesData(lesson.LessonId);
                            if (dsSession != null)
                            {
                                if (dsSession.Tables.Count > 0)
                                {
                                    LoadSession(dsSession);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (location == "On-Track Sesssion Summary" && lesson.LessonTypeId.Equals(2))
                        {
                            _onTrackSessionlessonId = lesson.LessonId;
                        }
                    }
                }

                avgVariableDataValues(athleteSelected);
                missingVariable.Clear();
                string missingVairableInitialList = anyVairableDataZero(_initialSummary, _initialCount, "_initial");
                string missingVairableFinalList = anyVairableDataZero(_finalSummary, _finalCount, "_final");
                //string missingVairableModelList = anyVairableDataZero(_modelSummary, _initialCount + _finalCount);

                if (missingVairableInitialList == string.Empty || missingVairableFinalList == string.Empty)
                {
                    if (_initialCount > 1 || _finalCount > 1)
                    {
                        createOnTrackSprintSession(athleteSelected);
                    }
                    else if(missingVariable.Count >0)
                    {
                        sendNotFoundEmail();
                    }
                }
            }
        }

        void sendNotFoundEmail()
        {
            var _initialMessage = "This initial  variable has 0 values = ";
            var _finalMessage = "This final variable has 0 values = ";
            var message = "";
            for (int i = 0; i < missingVariable.Count; i++)
            {
                if (missingVariable[i].type == "_initial")
                {
                    _initialMessage += missingVariable[i].variableName + ", ";
                    message = _initialMessage;
                }
                else
                {
                    _finalMessage += missingVariable[i].variableName + ", ";
                    message = _finalMessage;
                }
            }
            //var message = _initialMessage + _finalMessage;
            var email = Membership.GetUser().Email;
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            msg.From = new System.Net.Mail.MailAddress(email);
            msg.To.Add("dev@Compusport.com");
            msg.Body = message;
            msg.Subject = "Compusport : " + customer.FirstName + "" + customer.LastName + " File Missing";
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
            smtp.Host = "198.143.141.120";
            smtp.Port = 25;
            smtp.Credentials = new System.Net.NetworkCredential("dev@compusport.com", "develop!?");
            smtp.Send(msg);

        }

        bool variableDataExists(DataRow drData)
        {
            bool dataExists = true;
            foreach (object data in drData.ItemArray)
            {
                if (!data.Equals(0)) continue;
                else
                {
                    dataExists = false;
                    break;
                }
            }
            return dataExists;
        }

        private decimal convertDecimal(string value)
        {
            decimal convertedVal = 0;
            if (!string.IsNullOrEmpty(value))
            {
                convertedVal = roundDecimal(Convert.ToDecimal(value));
            }

            return convertedVal;
        }

        private decimal roundDecimal(decimal value)
        {
            return Math.Round(Convert.ToDecimal(value), 3);
        }

        private int roundInteger(decimal value)
        {
            if (value < 0)
            {
                return Convert.ToInt32(Math.Floor(value));
            }
            else
            {
                return Convert.ToInt32(Math.Ceiling(value));
            }
        }

        void LoadSession(DataSet dsSession)
        {
            SessionData sessionData = new SessionData();
            if (dsSession.Tables[0].Rows.Count > 0)
            {
                if (variableDataExists(dsSession.Tables[0].Rows[0]) == true)
                {
                    _initialCount++;
                    sessionData.SetInitialData(dsSession.Tables[0].Rows[0]);
                }
            }
            if (dsSession.Tables[2].Rows.Count > 0)
            {
                if (variableDataExists(dsSession.Tables[2].Rows[0]) == true)
                {
                    _finalCount++;
                    sessionData.SetFinalData(dsSession.Tables[2].Rows[0]);
                }
            }

            if (dsSession.Tables[1].Rows.Count > 0)
            {
                if (variableDataExists(dsSession.Tables[1].Rows[0]) == true)
                {
                    _modelCount++;
                    sessionData.SetModelData(dsSession.Tables[1].Rows[0]);
                }
            }


            _sessionDataList.Add(sessionData);
        }

        void avgVariableDataValues(int athleteSelected)
        {
            foreach (SessionData sessionData in _sessionDataList)
            {
                _initialSummary = addSessionData(_initialSummary, sessionData.InitialData);
                _finalSummary = addSessionData(_finalSummary, sessionData.FinalData);
                _modelSummary = addSessionData(_modelSummary, sessionData.ModelData);
            }
            _initialSummary = avgVairableData(_initialSummary, _initialCount);
            _finalSummary = avgVairableData(_finalSummary, _finalCount);
            _modelSummary = avgVairableData(_modelSummary, _modelCount);
        }

        SprintData addSessionData(SprintData inVariableData, SprintData newVariableData)
        {
            inVariableData.GroundTimeLeft += newVariableData.GroundTimeLeft;
            inVariableData.GroundTimeRight += newVariableData.GroundTimeRight;
            inVariableData.AirTimeLeftToRight += newVariableData.AirTimeLeftToRight;
            inVariableData.AirTimeRightToLeft += newVariableData.AirTimeRightToLeft;
            inVariableData.FullFlexionTimeLeft += newVariableData.FullFlexionTimeLeft;
            inVariableData.FullFlexionTimeRight += newVariableData.FullFlexionTimeRight;
            inVariableData.StrideLengthLeftToRight += newVariableData.StrideLengthLeftToRight;
            inVariableData.StrideLengthRightToLeft += newVariableData.StrideLengthRightToLeft;
            inVariableData.COGDistanceLeft += newVariableData.COGDistanceLeft;
            inVariableData.COGDistanceRight += newVariableData.COGDistanceRight;
            inVariableData.ULFullExtensionAngleLeft += newVariableData.ULFullExtensionAngleLeft;
            inVariableData.ULFullExtensionAngleRight += newVariableData.ULFullExtensionAngleRight;
            inVariableData.LLAngleTakeoffLeft += newVariableData.LLAngleTakeoffLeft;
            inVariableData.LLAAngleTakeoffRight += newVariableData.LLAAngleTakeoffRight;
            inVariableData.LLAngleACLeft += newVariableData.LLAngleACLeft;
            inVariableData.LLAngleACRight += newVariableData.LLAngleACRight;
            inVariableData.ULFullFlexionAngleLeft += newVariableData.ULFullFlexionAngleLeft;
            inVariableData.ULFullFlexionAngleRight += newVariableData.ULFullFlexionAngleRight;
            inVariableData.LLFullFlexionAngleLeft += newVariableData.LLFullFlexionAngleLeft;
            inVariableData.LLFullFlexionAngleRight += newVariableData.LLFullFlexionAngleRight;
            inVariableData.TAATouchDownLeft += newVariableData.TAATouchDownLeft;
            inVariableData.TAATouchDownRight += newVariableData.TAATouchDownRight;

            inVariableData.KSATouchDownLeft += newVariableData.KSATouchDownLeft;
            inVariableData.KSATouchDownRight += newVariableData.KSATouchDownRight;

            return inVariableData;
        }

        SprintData avgVairableData(SprintData inVariableData, int totalCount)
        {
            if (totalCount > 1)
            {
                inVariableData.GroundTimeLeft = roundDecimal(inVariableData.GroundTimeLeft / totalCount);
                inVariableData.GroundTimeRight = roundDecimal(inVariableData.GroundTimeRight / totalCount);
                inVariableData.AirTimeLeftToRight = roundDecimal(inVariableData.AirTimeLeftToRight / totalCount);
                inVariableData.AirTimeRightToLeft = roundDecimal(inVariableData.AirTimeRightToLeft / totalCount);
                inVariableData.FullFlexionTimeLeft = roundDecimal(inVariableData.FullFlexionTimeLeft / totalCount);
                inVariableData.FullFlexionTimeRight = roundDecimal(inVariableData.FullFlexionTimeRight / totalCount);
                inVariableData.StrideLengthLeftToRight = roundDecimal(inVariableData.StrideLengthLeftToRight / totalCount);
                inVariableData.StrideLengthRightToLeft = roundDecimal(inVariableData.StrideLengthRightToLeft / totalCount);
                inVariableData.COGDistanceLeft = roundDecimal(inVariableData.COGDistanceLeft / totalCount);
                inVariableData.COGDistanceRight = roundDecimal(inVariableData.COGDistanceRight / totalCount);
                inVariableData.KSATouchDownLeft = roundDecimal(inVariableData.KSATouchDownLeft / totalCount);
                inVariableData.KSATouchDownRight = roundDecimal(inVariableData.KSATouchDownRight / totalCount);

                inVariableData.ULFullExtensionAngleLeft = roundInteger((decimal)inVariableData.ULFullExtensionAngleLeft / totalCount);
                inVariableData.ULFullExtensionAngleRight = roundInteger((decimal)inVariableData.ULFullExtensionAngleRight / totalCount);
                inVariableData.LLAngleTakeoffLeft = roundInteger((decimal)inVariableData.LLAngleTakeoffLeft / totalCount);
                inVariableData.LLAAngleTakeoffRight = roundInteger((decimal)inVariableData.LLAAngleTakeoffRight / totalCount);
                inVariableData.LLAngleACLeft = roundInteger((decimal)inVariableData.LLAngleACLeft / totalCount);
                inVariableData.LLAngleACRight = roundInteger((decimal)inVariableData.LLAngleACRight / totalCount);
                inVariableData.ULFullFlexionAngleLeft = roundInteger((decimal)inVariableData.ULFullFlexionAngleLeft / totalCount);
                inVariableData.ULFullFlexionAngleRight = roundInteger((decimal)inVariableData.ULFullFlexionAngleRight / totalCount);
                inVariableData.LLFullFlexionAngleLeft = roundInteger((decimal)inVariableData.LLFullFlexionAngleLeft / totalCount);
                inVariableData.LLFullFlexionAngleRight = roundInteger((decimal)inVariableData.LLFullFlexionAngleRight / totalCount);
                inVariableData.TAATouchDownLeft = roundInteger((decimal)inVariableData.TAATouchDownLeft / totalCount);
                inVariableData.TAATouchDownRight = roundInteger((decimal)inVariableData.TAATouchDownRight / totalCount);

            }
            else
            {
                inVariableData.GroundTimeLeft = 0;
                inVariableData.GroundTimeRight = 0;
                inVariableData.AirTimeLeftToRight = 0;
                inVariableData.AirTimeRightToLeft = 0;
                inVariableData.FullFlexionTimeLeft = 0;
                inVariableData.FullFlexionTimeRight = 0;
                inVariableData.StrideLengthLeftToRight = 0;
                inVariableData.StrideLengthRightToLeft = 0;
                inVariableData.COGDistanceLeft = 0;
                inVariableData.COGDistanceRight = 0;
                inVariableData.KSATouchDownLeft = 0;
                inVariableData.KSATouchDownRight = 0;

                inVariableData.ULFullExtensionAngleLeft = 0;
                inVariableData.ULFullExtensionAngleRight = 0;
                inVariableData.LLAngleTakeoffLeft = 0;
                inVariableData.LLAAngleTakeoffRight = 0;
                inVariableData.LLAngleACLeft = 0;
                inVariableData.LLAngleACRight = 0;
                inVariableData.ULFullFlexionAngleLeft = 0;
                inVariableData.ULFullFlexionAngleRight = 0;
                inVariableData.LLFullFlexionAngleLeft = 0;
                inVariableData.LLFullFlexionAngleRight = 0;
                inVariableData.TAATouchDownLeft = 0;
                inVariableData.TAATouchDownRight = 0;


            }
            return inVariableData;

        }

        List<MissingVariable> missingVariable = new List<MissingVariable>();

        string anyVairableDataZero(SprintData inVarirableData, int totalCount, string _type)
        {
            MissingVariable misv = new MissingVariable();
            string listOfVariableWithZero = "";
            if (totalCount > 1)
            {
                if (inVarirableData.GroundTimeLeft == 0)
                {
                    //listOfVariableWithZero = "GroundTimeLeft";
                    misv.type = _type;
                    misv.variableName = "GroundTimeLeft";
                    missingVariable.Add(misv);
                    //sendNotFoundEmail("This varibale has 0 value ...!" + listOfVariableWithZero, listOfVariableWithZero);
                }
                if (inVarirableData.GroundTimeRight == 0)
                {
                    //listOfVariableWithZero = ", GroundTimeRight";
                    misv.type = _type;
                    misv.variableName = "GroundTimeRight";
                    missingVariable.Add(misv);
                    //sendNotFoundEmail("This varibale has 0 value ...!" + listOfVariableWithZero, listOfVariableWithZero);
                }
                if (inVarirableData.AirTimeLeftToRight == 0)
                {

                    misv.type = _type;
                    misv.variableName = "airTimeRightToLeft";
                    missingVariable.Add(misv);
                    //sendNotFoundEmail("This varibale has 0 value ...!" + listOfVariableWithZero, listOfVariableWithZero);
                }
                if (inVarirableData.AirTimeRightToLeft == 0)
                {

                    misv.type = _type;
                    misv.variableName = "timeToUpperLegFullFlexionLeft";
                    missingVariable.Add(misv);
                    //  sendNotFoundEmail("This varibale has 0 value ...!" + listOfVariableWithZero, listOfVariableWithZero);
                }
                if (inVarirableData.FullFlexionTimeLeft == 0)
                {

                    misv.type = _type;
                    misv.variableName = "timeToUpperLegFullFlexionRight";
                    missingVariable.Add(misv);
                    //sendNotFoundEmail("This varibale has 0 value ...!" + listOfVariableWithZero, listOfVariableWithZero);
                }
                if (inVarirableData.FullFlexionTimeRight == 0)
                {

                    misv.type = _type;
                    misv.variableName = "strideLengthLeftToRight";
                    missingVariable.Add(misv);
                    //sendNotFoundEmail("This varibale has 0 value ...!" + listOfVariableWithZero, listOfVariableWithZero);
                }
                if (inVarirableData.StrideLengthLeftToRight == 0)
                {

                    misv.type = _type;
                    misv.variableName = "strideLengthRightToLeft";
                    missingVariable.Add(misv);
                    //sendNotFoundEmail("This varibale has 0 value ...!" + listOfVariableWithZero, listOfVariableWithZero);
                }
                if (inVarirableData.StrideLengthRightToLeft == 0)
                {

                    misv.type = _type;
                    misv.variableName = "touchDownDistanceLeft";
                    missingVariable.Add(misv);
                    //sendNotFoundEmail("This varibale has 0 value ...!" + listOfVariableWithZero, listOfVariableWithZero);
                }
                if (inVarirableData.COGDistanceLeft == 0)
                {

                    misv.type = _type;
                    misv.variableName = "touchDownDistanceRight";
                    missingVariable.Add(misv);
                    //sendNotFoundEmail("This varibale has 0 value ...!" + listOfVariableWithZero, listOfVariableWithZero);
                }
                if (inVarirableData.COGDistanceRight == 0)
                {

                    misv.type = _type;
                    misv.variableName = "upperLegFullExtentionAngleLeft";
                    missingVariable.Add(misv);
                    // sendNotFoundEmail("This varibale has 0 value ...!" + listOfVariableWithZero, listOfVariableWithZero);
                }
                if (inVarirableData.ULFullExtensionAngleLeft == 0)
                {

                    misv.type = _type;
                    misv.variableName = "upperLegFullExtentionAngleRight";
                    missingVariable.Add(misv);
                    // sendNotFoundEmail("This varibale has 0 value ...!" + listOfVariableWithZero, listOfVariableWithZero);
                }
                if (inVarirableData.ULFullExtensionAngleRight == 0)
                {

                    misv.type = _type;
                    misv.variableName = "lowerLegAngleAtTakeOfLeft";
                    missingVariable.Add(misv);
                    // sendNotFoundEmail("This varibale has 0 value ...!" + listOfVariableWithZero, listOfVariableWithZero);
                }
                if (inVarirableData.LLAngleTakeoffLeft == 0)
                {

                    misv.type = _type;
                    misv.variableName = "lowerLegAngleAtTakeOfRight";
                    missingVariable.Add(misv);
                    // sendNotFoundEmail("This varibale has 0 value ...!" + listOfVariableWithZero, listOfVariableWithZero);
                }
                if (inVarirableData.LLAAngleTakeoffRight == 0)
                {

                    misv.type = _type;
                    misv.variableName = "lowerLegFullFlexionAngleLeft";
                    missingVariable.Add(misv);
                    // sendNotFoundEmail("This varibale has 0 value ...!" + listOfVariableWithZero, listOfVariableWithZero);
                }
                //if (inVarirableData.LLAngleACLeft == 0) 
                //{
                //    listOfVariableWithZero = ", lowerLegFullFlexionAngleRight ";
                // missingVariable.Add(listOfVariableWithZero);
                //    sendNotFoundEmail("This varibale has 0 value ...!" + listOfVariableWithZero, listOfVariableWithZero);
                //}
                //if (inVarirableData.LLAngleACRight == 0) 
                //{
                //    listOfVariableWithZero = ", trunkAngleAtTouchdownLeft ";
                //    sendNotFoundEmail("This varibale has 0 value ...!" + listOfVariableWithZero, listOfVariableWithZero);
                //}
                if (inVarirableData.ULFullFlexionAngleLeft == 0)
                {

                    misv.type = _type;
                    misv.variableName = "trunkAngleAtTouchdownRight";
                    missingVariable.Add(misv);
                    //sendNotFoundEmail("This varibale has 0 value ...!" + listOfVariableWithZero, listOfVariableWithZero);
                }
                if (inVarirableData.ULFullFlexionAngleRight == 0)
                {

                    misv.type = _type;
                    misv.variableName = "kneeSeperationAtTouchdownLeft";
                    missingVariable.Add(misv);
                    // sendNotFoundEmail("This varibale has 0 value ...!" + listOfVariableWithZero, listOfVariableWithZero);
                }
                if (inVarirableData.LLFullFlexionAngleLeft == 0)
                {

                    misv.type = _type;
                    misv.variableName = "kneeSeperationAtTouchdownRight";
                    missingVariable.Add(misv);
                    // sendNotFoundEmail("This varibale has 0 value ...!" + listOfVariableWithZero, listOfVariableWithZero);
                }
                if (inVarirableData.LLFullFlexionAngleRight == 0)
                {

                    misv.type = _type;
                    misv.variableName = "upperLegFullFlexionAngleLeft";
                    missingVariable.Add(misv);
                    // sendNotFoundEmail("This varibale has 0 value ...!" + listOfVariableWithZero, listOfVariableWithZero);
                }
                if (inVarirableData.TAATouchDownLeft == 0)
                {

                    misv.type = _type;
                    misv.variableName = "upperLegFullFlexionAngleRight";
                    missingVariable.Add(misv);
                    //sendNotFoundEmail("This varibale has 0 value ...!" + listOfVariableWithZero, listOfVariableWithZero);
                }
                if (inVarirableData.TAATouchDownRight == 0)
                {

                    misv.type = _type;
                    misv.variableName = "upperLegFullFlexionAngleRight";
                    missingVariable.Add(misv);
                    // sendNotFoundEmail("This varibale has 0 value ...!" + listOfVariableWithZero, listOfVariableWithZero);
                }
                if (inVarirableData.KSATouchDownLeft == 0)
                {

                    misv.type = _type;
                    misv.variableName = "upperLegFullFlexionAngleRight";
                    missingVariable.Add(misv);
                    //sendNotFoundEmail("This varibale has 0 value ...!" + listOfVariableWithZero, listOfVariableWithZero);
                }
                if (inVarirableData.KSATouchDownRight == 0)
                {
                    misv.type = _type;
                    misv.variableName = "upperLegFullFlexionAngleRight";
                    missingVariable.Add(misv);
                    // sendNotFoundEmail("This varibale has 0 value ...!" + listOfVariableWithZero, listOfVariableWithZero);
                }
            }

            return listOfVariableWithZero;
        }

        void createOnTrackSprintSession(int athleteSelected)
        {
            Lesson lesson = new Lesson();
            string location = "On-Track Sesssion Summary";
            lesson.LessonDate = System.DateTime.Now;
            Movie movie = new Movie();
            movie.DateRecorded = System.DateTime.Now;
            MovieClip moviclip = new MovieClip();

            bool customerprofileisexist = false;
            Customer custmer = DataRepository.CustomerProvider.GetByCustomerId(athleteSelected);
            try
            {
                customerprofile1 = DataRepository.CustomerProfileProvider.GetByCustomerId(custmer.CustomerId)[0];
                customerprofileisexist = true;
            }
            catch
            {
                customerprofile1 = new CustomerProfile();
            }
            DataSet dstecher = sae.GetPrimaryCoach(custmer.CustomerId);
            if (dstecher != null)
            {
                if (dstecher.Tables[0].Rows.Count > 0)
                {
                    lesson.TeacherId = Convert.ToInt32(dstecher.Tables[0].Rows[0]["TeacherId"].ToString());
                }
                else
                {
                    lesson.TeacherId = 7;
                }
            }
            else
            {
                lesson.TeacherId = 7;
            }
            if (customerprofileisexist)
            {
                lesson.SiteId = customerprofile1.CustomerSite;
            }
            else
            {
                lesson.SiteId = 11;
            }
            lesson.CustomerId = custmer.CustomerId;
            lesson.LessonTypeId = 2;
            lesson.MachineNumber = 1;


            string sprint_InitialDataId = string.Empty;
            string sprint_FinalDataId = string.Empty;
            string sprint_modelSummary = string.Empty;
            if (_onTrackSessionlessonId == 0)
            {
                DataRepository.LessonProvider.Insert(lesson);
                sae.UpdateLessonLocation(location, lesson.LessonId);
                if (sprint_InitialDataId == string.Empty && _initialCount > 1)
                {
                    int MovieIdInitialSide = sae.InsertMovieOnTrack(0, movie.DateRecorded, "Users/MovieFiles/ModelSprint-Initial-Side.mp4", lesson.LessonId);
                    InsertMovieClip(MovieIdInitialSide);
                    int MovieIdInitialBack = sae.InsertMovieOnTrack(1, movie.DateRecorded, "Users/MovieFiles/ModelSprint-Initial-Back.mp4", lesson.LessonId);
                    InsertMovieClip(MovieIdInitialBack);
                }
                if (sprint_FinalDataId == string.Empty && _finalCount > 1)
                {
                    int MovieIdCurrentSide = sae.InsertMovieOnTrack(2, movie.DateRecorded, "Users/MovieFiles/ModelSprint-Current-Side.mp4", lesson.LessonId);
                    InsertMovieClip(MovieIdCurrentSide);
                    int MovieIdCurrentBack = sae.InsertMovieOnTrack(3, movie.DateRecorded, "Users/MovieFiles/ModelSprint-Current-Back.mp4", lesson.LessonId);
                    InsertMovieClip(MovieIdCurrentBack);
                }
            }
            else
            {
                sae.UpdateOntrackLessonLocation(location, _onTrackSessionlessonId, DateTime.Now);
                if (sprint_InitialDataId == string.Empty && _initialCount > 1)
                {
                    int MovieIdInitialSide = sae.UpdateMovieOnTrack(0, DateTime.Now, "Users/MovieFiles/ModelSprint-Initial-Side.mp4", _onTrackSessionlessonId);
                    int MovieIdInitialBack = sae.UpdateMovieOnTrack(1, DateTime.Now, "Users/MovieFiles/ModelSprint-Initial-Back.mp4", _onTrackSessionlessonId);
                }
                if (sprint_FinalDataId == string.Empty && _finalCount > 1)
                {
                    int MovieIdCurrentSide = sae.UpdateMovieOnTrack(2, DateTime.Now, "Users/MovieFiles/ModelSprint-Current-Side.mp4", _onTrackSessionlessonId);
                    int MovieIdCurrentBack = sae.UpdateMovieOnTrack(3, DateTime.Now, "Users/MovieFiles/ModelSprint-Current-Back.mp4", _onTrackSessionlessonId);
                }
                sprint_InitialDataId = sae.SelectSprintInitialDataid(_onTrackSessionlessonId.ToString());
                sprint_FinalDataId = sae.SelectSprintCurrentDataid(_onTrackSessionlessonId.ToString());
                sprint_modelSummary = sae.SelectSprintModelDataid(_onTrackSessionlessonId.ToString());
            }
            if (sprint_InitialDataId == string.Empty && _initialCount > 1)
            {
                _initialSummary.LessonId = lesson.LessonId;
                _initialSummary.InsertIntoSprintInitialData();
            }
            else
            {
                _initialSummary.LessonId = _onTrackSessionlessonId;
                _initialSummary.UpdateSprinttInitialData();
            }
            if (sprint_FinalDataId == string.Empty && _finalCount > 1)
            {
                _finalSummary.LessonId = lesson.LessonId;
                _finalSummary.InsertIntoSprintCurrentData();
            }
            else
            {
                _finalSummary.LessonId = _onTrackSessionlessonId;
                _finalSummary.UpdateSprintCurrentData();

            }
            if (sprint_modelSummary == string.Empty && _modelCount > 1)
            {
                _modelSummary.LessonId = lesson.LessonId;
                _modelSummary.InsertIntoSprintModelData();
                // _modelSummary.InsertIntoSprintOntrackModelData();
            }
            else
            {
                _modelSummary.LessonId = _onTrackSessionlessonId;
                _modelSummary.UpdateSprintModelData();
                // _modelSummary.UpadteIntoSprintOntrackModelData();
            }

        }

        void InsertMovieClip(int MovieId)
        {
            sae.InsertMovieClip(MovieId, 1, 1);
            sae.InsertMovieClip(MovieId, 1, 16);
            sae.InsertMovieClip(MovieId, 16, 42);
            sae.InsertMovieClip(MovieId, 42, 58);
            sae.InsertMovieClip(MovieId, 58, 84);
            sae.InsertMovieClip(MovieId, 84, 100);
            sae.InsertMovieClip(MovieId, 100, 125);
            sae.InsertMovieClip(MovieId, 125, 126);
        }
    }

    public class MissingVariable
    {
        public string type { get; set; }
        public string variableName { get; set; }
    }
}
