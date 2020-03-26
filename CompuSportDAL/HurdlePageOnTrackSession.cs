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

namespace CompuSportDAL
{

    public class HurdlePageOnTrackSession
    {
        public CustomerProfile customerprofile;
        public CustomerProfile customerprofile1;
        public int _onTrackSessionlessonId;
        IList<HurdlePageSessionData> _sessionDataList = new List<HurdlePageSessionData>();
        int _onTrackSessionID = 0;
        int _initialCount = 0;
        int _finalCount = 0;
        int _modelCount = 0;

        HurdleData _sessionSummary = new HurdleData();
        HurdleData _initialSummary = new HurdleData();
        HurdleData _finalSummary = new HurdleData();
        HurdleData _modelSummary = new HurdleData();
        Movie movieSide;
        Movie movieBack;
        Movie CurrentMovieSide;
        Movie CurrentMovieBack;
        bool isMovieClipsExist = false;
        Customer customer;

        CompuSportDAL.SprintAthleteEdit sae = new CompuSportDAL.SprintAthleteEdit();
        CompuSportDAL.HurdleData _HurdleData = new CompuSportDAL.HurdleData();

        DataSet dsSessions = new DataSet();
        DataTable dtSession = new DataTable();

        public void HurdlePageOnTrackSessionData(int athleteSelected)
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
                    if ((location != "On-Track Sesssion Summary" && lesson.LessonTypeId != 2 && lesson.LessonTypeId != 1))
                    {
                        if (!location.Contains('(') && lesson.LessonTypeId.Equals(3))
                        {
                            //DataSet dsSession = new DataSet();
                            var dsSession = sae.GetAllHurdleAthleteData(lesson.LessonId);
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
                        if (location == "On-Track Sesssion Summary" && lesson.LessonTypeId.Equals(3))
                        {
                            _onTrackSessionlessonId = lesson.LessonId;
                        }
                    }
                }

                avgVariableDataValues(athleteSelected);
                missingVariable.Clear();
                string missingVairableInitialList = anyVairableDataZero(_initialSummary, _initialCount, "_initial");
                string missingVairableFinalList = anyVairableDataZero(_finalSummary, _finalCount, "_final");

                if (missingVairableInitialList == string.Empty || missingVairableFinalList == string.Empty)
                {
                    if (_initialCount > 1 || _finalCount > 1)
                    {
                        createOnTrackSprintSession(athleteSelected);
                    }
                    else if (missingVariable.Count > 0)
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
            HurdlePageSessionData sessionData = new HurdlePageSessionData();
            if (dsSession.Tables[0].Rows.Count > 0)
            {
                if (variableDataExists(dsSession.Tables[0].Rows[0]) == true)
                {
                    _initialCount++;
                    sessionData.SetHurdleInitialData(dsSession.Tables[0].Rows[0]);
                }
            }
            if (dsSession.Tables[1].Rows.Count > 0)
            {
                if (variableDataExists(dsSession.Tables[1].Rows[0]) == true)
                {
                    _modelCount++;
                    sessionData.SetHurdleModelData(dsSession.Tables[1].Rows[0]);
                }
            }

            if (dsSession.Tables[2].Rows.Count > 0)
            {
                if (variableDataExists(dsSession.Tables[2].Rows[0]) == true)
                {
                    _finalCount++;
                    sessionData.SetHurdleFinalData(dsSession.Tables[2].Rows[0]);
                }
            }
            _sessionDataList.Add(sessionData);
        }

        void avgVariableDataValues(int athleteSelected)
        {
            foreach (HurdlePageSessionData sessionData in _sessionDataList)
            {
                _initialSummary = addSessionData(_initialSummary, sessionData.HurdleInitialData);
                _finalSummary = addSessionData(_finalSummary, sessionData.HurdleFinalData);
                _modelSummary = addSessionData(_modelSummary, sessionData.HurdleModelData);
            }
            _initialSummary = avgVairableData(_initialSummary, _initialCount);
            _finalSummary = avgVairableData(_finalSummary, _finalCount);
            _modelSummary = avgVairableData(_modelSummary, _modelCount);
        }

        HurdleData addSessionData(HurdleData inVariableData, HurdleData newVariableData)
        {
            inVariableData.GroundTimeInto += newVariableData.GroundTimeInto;
            inVariableData.GroundTimeOff += newVariableData.GroundTimeOff;
            inVariableData.AirTimeOver += newVariableData.AirTimeOver;
            inVariableData.StrideLengthInto += newVariableData.StrideLengthInto;
            inVariableData.StrideLengthOff += newVariableData.StrideLengthOff;
            inVariableData.StrideLengthTotal += newVariableData.StrideLengthTotal;
            inVariableData.Velocity += newVariableData.Velocity;
            inVariableData.COGDistanceInto += newVariableData.COGDistanceInto;
            inVariableData.COGDistanceOff += newVariableData.COGDistanceOff;
            inVariableData.ULAngleTDInto += newVariableData.ULAngleTDInto;
            inVariableData.ULMAngleOver += newVariableData.ULMAngleOver;
            inVariableData.ULAngleTOInto += newVariableData.ULAngleTOInto;
            inVariableData.ULAngleTDOff += newVariableData.ULAngleTDOff;
            inVariableData.ULAngleTOOff += newVariableData.ULAngleTOOff;
            inVariableData.KAMSeparationOver += newVariableData.KAMSeparationOver;
            inVariableData.LeadLegMinimumAngle += newVariableData.LeadLegMinimumAngle;
            inVariableData.LeadLegAngleAC += newVariableData.LeadLegAngleAC;
            inVariableData.LLMAngleOver += newVariableData.LLMAngleOver;
            inVariableData.LLAngleTDOff += newVariableData.LLAngleTDOff;
            inVariableData.LLAngleTOOff += newVariableData.LLAngleTOOff;
            inVariableData.KSTouchDownInto += newVariableData.KSTouchDownInto;
            inVariableData.KSTouchDownOff += newVariableData.KSTouchDownOff;
            inVariableData.TTDAngleInto += newVariableData.TTDAngleInto;
            inVariableData.TTAngleInto += newVariableData.TTAngleInto;
            inVariableData.TMAngleOver += newVariableData.TMAngleOver;
            inVariableData.TTDAngleOff += newVariableData.TTDAngleOff;
            inVariableData.TTAngleOff += newVariableData.TTAngleOff;
            return inVariableData;
        }

        HurdleData avgVairableData(HurdleData inVariableData, int totalCount)
        {
            if (totalCount > 1)
            {


                inVariableData.GroundTimeInto = roundDecimal(inVariableData.GroundTimeInto / totalCount);
                inVariableData.GroundTimeOff = roundDecimal(inVariableData.GroundTimeOff / totalCount);
                inVariableData.AirTimeOver = roundDecimal(inVariableData.AirTimeOver / totalCount);
                inVariableData.StrideLengthInto = roundDecimal(inVariableData.StrideLengthInto / totalCount);
                inVariableData.StrideLengthOff = roundDecimal(inVariableData.StrideLengthOff / totalCount);
                inVariableData.StrideLengthTotal = roundDecimal(inVariableData.StrideLengthTotal / totalCount);
                inVariableData.Velocity = roundDecimal(inVariableData.Velocity / totalCount);
                inVariableData.COGDistanceInto = roundDecimal(inVariableData.COGDistanceInto / totalCount);
                inVariableData.COGDistanceOff = roundDecimal(inVariableData.COGDistanceOff / totalCount);
                inVariableData.ULAngleTDInto = roundInteger((decimal)inVariableData.ULAngleTDInto / totalCount);
                inVariableData.ULMAngleOver = roundInteger((decimal)inVariableData.ULMAngleOver / totalCount);
                inVariableData.ULAngleTOInto = roundInteger((decimal)inVariableData.ULAngleTOInto / totalCount);
                inVariableData.ULAngleTDOff = roundInteger((decimal)inVariableData.ULAngleTDOff / totalCount);
                inVariableData.ULAngleTOOff = roundInteger((decimal)inVariableData.ULAngleTOOff / totalCount);
                inVariableData.KAMSeparationOver = roundDecimal(inVariableData.KAMSeparationOver / totalCount);
                inVariableData.LeadLegMinimumAngle = roundInteger((decimal)inVariableData.LeadLegMinimumAngle / totalCount);
                inVariableData.LeadLegAngleAC = roundInteger((decimal)inVariableData.LeadLegAngleAC / totalCount);
                inVariableData.LLMAngleOver = roundInteger((decimal)inVariableData.LLMAngleOver / totalCount);
                inVariableData.LLAngleTDOff = roundInteger((decimal)inVariableData.LLAngleTDOff / totalCount);
                inVariableData.LLAngleTOOff = roundInteger((decimal)inVariableData.LLAngleTOOff / totalCount);
                inVariableData.KSTouchDownInto = roundDecimal(inVariableData.KSTouchDownInto / totalCount);
                inVariableData.KSTouchDownOff = roundDecimal(inVariableData.KSTouchDownOff / totalCount);
                inVariableData.TTDAngleInto = roundDecimal(inVariableData.TTDAngleInto / totalCount);
                inVariableData.TTAngleInto = roundDecimal(inVariableData.TTAngleInto / totalCount);
                inVariableData.TMAngleOver = roundDecimal(inVariableData.TMAngleOver / totalCount);
                inVariableData.TTDAngleOff = roundDecimal(inVariableData.TTDAngleOff / totalCount);
                inVariableData.TTAngleOff = roundDecimal(inVariableData.TTAngleOff / totalCount);


            }
            else
            {
                inVariableData.GroundTimeInto = 0;
                inVariableData.GroundTimeOff = 0;
                inVariableData.AirTimeOver = 0;
                inVariableData.StrideLengthInto = 0;
                inVariableData.StrideLengthOff = 0;
                inVariableData.StrideLengthTotal = 0;
                inVariableData.Velocity = 0;
                inVariableData.COGDistanceInto = 0;
                inVariableData.COGDistanceOff = 0;
                inVariableData.ULAngleTDInto = 0;
                inVariableData.ULMAngleOver = 0;
                inVariableData.ULAngleTOInto = 0;
                inVariableData.ULAngleTDOff = 0;
                inVariableData.ULAngleTOOff = 0;
                inVariableData.KAMSeparationOver = 0;
                inVariableData.LeadLegMinimumAngle = 0;
                inVariableData.LeadLegAngleAC = 0;
                inVariableData.LLMAngleOver = 0;
                inVariableData.LLAngleTDOff = 0;
                inVariableData.LLAngleTOOff = 0;
                inVariableData.KSTouchDownInto = 0;
                inVariableData.KSTouchDownOff = 0;
                inVariableData.TTDAngleInto = 0;
                inVariableData.TTAngleInto = 0;
                inVariableData.TMAngleOver = 0;
                inVariableData.TTDAngleOff = 0;
                inVariableData.TTAngleOff = 0;
                return inVariableData;

            }
            return inVariableData;

        }

        List<MissingVariable> missingVariable = new List<MissingVariable>();

        string anyVairableDataZero(HurdleData inVarirableData, int totalCount, string _type)
        {
            MissingVariable misv = new MissingVariable();
            string listOfVariableWithZero = "";
            if (totalCount > 1)
            {
                if (inVarirableData.GroundTimeInto == 0)
                {
                        misv.type = _type;
                        missingVariable.Add(misv);
                        listOfVariableWithZero = "GroundTimeInto";
                }
                if (inVarirableData.GroundTimeOff == 0)
                {
                    misv.type = _type;
                    missingVariable.Add(misv);
                    listOfVariableWithZero = "GroundTimeOff";
                }
                if (inVarirableData.AirTimeOver == 0)
                {
                    misv.type = _type;
                    missingVariable.Add(misv);
                    listOfVariableWithZero = "AirTimeOver";
                }
                if (inVarirableData.StrideLengthInto == 0)
                {
                    misv.type = _type;
                    missingVariable.Add(misv);
                    listOfVariableWithZero = "StrideLengthInto";
                }
                if (inVarirableData.StrideLengthOff == 0)
                {
                    misv.type = _type;
                    missingVariable.Add(misv);
                    listOfVariableWithZero = "StrideLengthOff";
                }
                if (inVarirableData.StrideLengthTotal == 0)
                {
                    misv.type = _type;
                    missingVariable.Add(misv);
                    listOfVariableWithZero = "StrideLengthTotal";
                }
                if (inVarirableData.Velocity == 0)
                {
                    misv.type = _type;
                    missingVariable.Add(misv);
                    listOfVariableWithZero = "Velocity";
                }
                if (inVarirableData.COGDistanceInto == 0)
                {
                    misv.type = _type;
                    missingVariable.Add(misv);
                    listOfVariableWithZero = "COGDistanceInto";
                }
                if (inVarirableData.COGDistanceOff == 0)
                {
                    misv.type = _type;
                    missingVariable.Add(misv);
                    listOfVariableWithZero = "COGDistanceOff";
                }
                if (inVarirableData.ULAngleTDInto == 0)
                {
                    misv.type = _type;
                    missingVariable.Add(misv);
                    listOfVariableWithZero = "ULAngleTDInto";
                }
                if (inVarirableData.ULMAngleOver == 0)
                {
                    misv.type = _type;
                    missingVariable.Add(misv);
                    listOfVariableWithZero = "ULMAngleOver";
                }
                if (inVarirableData.ULAngleTOInto == 0)
                {
                    misv.type = _type;
                    missingVariable.Add(misv);
                    listOfVariableWithZero = "ULAngleTOInto";
                }
                if (inVarirableData.ULAngleTDOff == 0)
                {
                    misv.type = _type;
                    missingVariable.Add(misv);
                    listOfVariableWithZero = "ULAngleTDOff";
                }
                if (inVarirableData.ULAngleTOOff == 0)
                {
                    misv.type = _type;
                    missingVariable.Add(misv);
                    listOfVariableWithZero = "ULAngleTOOff";
                }
                if (inVarirableData.KAMSeparationOver == 0)
                {
                    misv.type = _type;
                    missingVariable.Add(misv);
                    listOfVariableWithZero = "KAMSeparationOver";
                }
                if (inVarirableData.LeadLegMinimumAngle == 0)
                {
                    misv.type = _type;
                    missingVariable.Add(misv);
                    listOfVariableWithZero = "LeadLegMinimumAngle";
                }
                if (inVarirableData.LeadLegAngleAC == 0)
                {
                    misv.type = _type;
                    missingVariable.Add(misv);
                    listOfVariableWithZero = "LeadLegAngleAC";
                }
                if (inVarirableData.LLMAngleOver == 0)
                {
                    misv.type = _type;
                    missingVariable.Add(misv);
                    listOfVariableWithZero = "LLMAngleOver";
                }
                if (inVarirableData.LLAngleTDOff == 0)
                {
                    misv.type = _type;
                    missingVariable.Add(misv);
                    listOfVariableWithZero = "LLAngleTDOff";
                }
                if (inVarirableData.LLAngleTOOff == 0)
                {
                    misv.type = _type;
                    missingVariable.Add(misv);
                    listOfVariableWithZero = "LLAngleTOOff";
                }
                if (inVarirableData.KSTouchDownInto == 0)
                {
                    misv.type = _type;
                    missingVariable.Add(misv);
                    listOfVariableWithZero = "KSTouchDownInto";
                }
                if (inVarirableData.KSTouchDownOff == 0)
                {
                    misv.type = _type;
                    missingVariable.Add(misv);
                    listOfVariableWithZero = "KSTouchDownOff";
                }
                if (inVarirableData.TTDAngleInto == 0)
                {
                    misv.type = _type;
                    missingVariable.Add(misv);
                    listOfVariableWithZero = "TTDAngleInto";
                }
                if (inVarirableData.TTAngleInto == 0)
                {
                    misv.type = _type;
                    missingVariable.Add(misv);
                    listOfVariableWithZero = "TTAngleInto";
                }
                if (inVarirableData.TMAngleOver == 0)
                {
                    misv.type = _type;
                    missingVariable.Add(misv);
                    listOfVariableWithZero = "TMAngleOver";
                }
                if (inVarirableData.TTDAngleOff == 0)
                {
                    misv.type = _type;
                    missingVariable.Add(misv);
                    listOfVariableWithZero = "TTDAngleOff";
                }
                if (inVarirableData.TTAngleOff == 0)
                {
                    misv.type = _type;
                    missingVariable.Add(misv);
                    listOfVariableWithZero = "TTAngleOff";
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
                lesson.SiteId = 11;//defualt site for customer is Baylor
            }
            lesson.CustomerId = custmer.CustomerId;
            lesson.LessonTypeId = 3;
            lesson.MachineNumber = 1;

            string Hurdle_InitialDataId = string.Empty;
            string Hurdle_FinalDataId = string.Empty;
            string Hurdle_modelSummary = string.Empty;
            if (_onTrackSessionlessonId == 0)
            {
                DataRepository.LessonProvider.Insert(lesson);
                sae.UpdateLessonLocation(location, lesson.LessonId);
                if (Hurdle_InitialDataId == string.Empty && _initialCount > 1)
                {
                    int MovieIdInitialSide = sae.InsertMovieOnTrack(0, movie.DateRecorded, "Users/MovieFiles/ModelHurdle-Initial-Side.mp4", lesson.LessonId);
                    InsertMovieClip(MovieIdInitialSide);
                    int MovieIdInitialBack = sae.InsertMovieOnTrack(1, movie.DateRecorded, "Users/MovieFiles/ModelHurdle-Initial-Back.mp4", lesson.LessonId);
                    InsertMovieClip(MovieIdInitialBack);
                }
                if (Hurdle_FinalDataId == string.Empty && _finalCount > 1)
                {
                    int MovieIdCurrentSide = sae.InsertMovieOnTrack(2, movie.DateRecorded, "Users/MovieFiles/ModelHurdle-Current-Side.mp4", lesson.LessonId);
                    InsertMovieClip(MovieIdCurrentSide);
                    int MovieIdCurrentBack = sae.InsertMovieOnTrack(3, movie.DateRecorded, "Users/MovieFiles/ModelHurdle-Current-Back.mp4", lesson.LessonId);
                    InsertMovieClip(MovieIdCurrentBack);
                }

            }
            else
            {
                sae.UpdateOntrackLessonLocation(location, _onTrackSessionlessonId, DateTime.Now);
                int MovieIdInitialSide = sae.UpdateMovieOnTrack(0, DateTime.Now, "Users/MovieFiles/ModelHurdle-Initial-Side.mp4", _onTrackSessionlessonId);
                int MovieIdInitialBack = sae.UpdateMovieOnTrack(1, DateTime.Now, "Users/MovieFiles/ModelHurdle-Initial-Back.mp4", _onTrackSessionlessonId);
                int MovieIdCurrentSide = sae.UpdateMovieOnTrack(2, DateTime.Now, "Users/MovieFiles/ModelHurdle-Current-Side.mp4", _onTrackSessionlessonId);
                int MovieIdCurrentBack = sae.UpdateMovieOnTrack(3, DateTime.Now, "Users/MovieFiles/ModelHurdle-Current-Back.mp4", _onTrackSessionlessonId);
                Hurdle_InitialDataId = _HurdleData.SelectHurdleInitialDataid(_onTrackSessionlessonId.ToString());
                Hurdle_FinalDataId = _HurdleData.SelectHurdleCurrentDataid(_onTrackSessionlessonId.ToString());
                Hurdle_modelSummary = _HurdleData.SelectHurdleModelDataid(_onTrackSessionlessonId.ToString());
            }
            if (Hurdle_InitialDataId == string.Empty && _initialCount > 1)
            {
                _initialSummary.LessonId = lesson.LessonId;
                _initialSummary.InsertIntoHurdleInitialData();
            }
            else
            {
                _initialSummary.LessonId = _onTrackSessionlessonId;
                _initialSummary.UpdateHurdleInitialData();
            }
            if (Hurdle_FinalDataId == string.Empty && _finalCount > 1)
            {
                _finalSummary.LessonId = lesson.LessonId;
                //_finalSummary.LessonId = _onTrackSessionlessonId;
                _finalSummary.InsertIntoHurdleCurrentData();
            }
            else
            {
                _finalSummary.LessonId = _onTrackSessionlessonId;
                _finalSummary.UpdateHurdleCurrentData();

            }
            if (Hurdle_modelSummary == string.Empty && _modelCount > 1)
            {
                _modelSummary.LessonId = lesson.LessonId;
                //_modelSummary.LessonId = _onTrackSessionlessonId;
                _modelSummary.InsertIntoHurdleModelData();
            }
            else
            {
                _modelSummary.LessonId = _onTrackSessionlessonId;
                _modelSummary.UpdateHurdleModelData();
            }

        }

        void InsertMovieClip(int MovieId)
        {
            sae.InsertMovieClip(MovieId, 1, 1);
            sae.InsertMovieClip(MovieId, 1, 13);
            sae.InsertMovieClip(MovieId, 13, 34);
            sae.InsertMovieClip(MovieId, 34, 97);
            sae.InsertMovieClip(MovieId, 97, 110);
            sae.InsertMovieClip(MovieId, 110, 114);
            sae.InsertMovieClip(MovieId, 114, 115);
            sae.InsertMovieClip(MovieId, 115, 116);
        }
    }
}
