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

    public class HurdleStepsPageOnTrackSessi
    {
        public CustomerProfile customerprofile;
        public CustomerProfile customerprofile1;
        public int _onTrackSessionlessonId;
        IList<HurdleStepsPageSessionData> _sessionDataList = new List<HurdleStepsPageSessionData>();
        int _onTrackSessionID = 0;
        int _initialCount = 0;
        int _finalCount = 0;
        int _modelCount = 0;

        HurdleStepsData _sessionSummary = new HurdleStepsData();
        HurdleStepsData _initialSummary = new HurdleStepsData();
        HurdleStepsData _finalSummary = new HurdleStepsData();
        HurdleStepsData _modelSummary = new HurdleStepsData();
        Movie movieSide;
        Movie movieBack;
        Movie CurrentMovieSide;
        Movie CurrentMovieBack;
        bool isMovieClipsExist = false;
        Customer customer;
        CompuSportDAL.SprintAthleteEdit sae = new CompuSportDAL.SprintAthleteEdit();
        CompuSportDAL.HurdleStepsData _HurdleData = new CompuSportDAL.HurdleStepsData();

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
                    if ((location != "On-Track Sesssion Summary" && lesson.LessonTypeId != 2 && lesson.LessonTypeId != 1 && lesson.LessonTypeId != 3))
                    {
                        if (!location.Contains('(') && lesson.LessonTypeId.Equals(6))
                        {
                            //DataSet dsSession = new DataSet();
                            var dsSession = sae.GetAllHurdleStepsAthletesData(lesson.LessonId);
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
                        if (location == "On-Track Sesssion Summary" && lesson.LessonTypeId.Equals(6))
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
            HurdleStepsPageSessionData sessionData = new HurdleStepsPageSessionData();
            if (dsSession.Tables[0].Rows.Count > 0)
            {
                if (variableDataExists(dsSession.Tables[0].Rows[0]) == true)
                {
                    _initialCount++;
                    sessionData.SetHurdleStepsInitialData(dsSession.Tables[0].Rows[0]);
                }
            }
            if (dsSession.Tables[2].Rows.Count > 0)
            {
                if (variableDataExists(dsSession.Tables[2].Rows[0]) == true)
                {
                    _finalCount++;
                    sessionData.SetHurdleStepsFinalData(dsSession.Tables[2].Rows[0]);
                }
            }

            if (dsSession.Tables[1].Rows.Count > 0)
            {
                if (variableDataExists(dsSession.Tables[1].Rows[0]) == true)
                {
                    _modelCount++;
                    sessionData.SetHurdleStepsModelData(dsSession.Tables[1].Rows[0]);
                }
            }


            _sessionDataList.Add(sessionData);
        }

        void avgVariableDataValues(int athleteSelected)
        {
            foreach (HurdleStepsPageSessionData sessionData in _sessionDataList)
            {
                _initialSummary = addSessionData(_initialSummary, sessionData.HurdleStepsInitialData);
                _finalSummary = addSessionData(_finalSummary, sessionData.HurdleStepsFinalData);
                _modelSummary = addSessionData(_modelSummary, sessionData.HurdleStepsModelData);
            }
            _initialSummary = avgVairableData(_initialSummary, _initialCount);
            _finalSummary = avgVairableData(_finalSummary, _finalCount);
            _modelSummary = avgVairableData(_modelSummary, _modelCount);
        }

        HurdleStepsData addSessionData(HurdleStepsData inVariableData, HurdleStepsData newVariableData)
        {

            inVariableData.SetDistanceBetweenHurdleSteps += newVariableData.SetDistanceBetweenHurdleSteps;
            inVariableData.SetDistanceIntoHurdleSteps += newVariableData.SetDistanceIntoHurdleSteps;
            inVariableData.SetDistanceOffHurdleSteps += newVariableData.SetDistanceOffHurdleSteps;
            //Step1
            inVariableData.Step1GroundTime += newVariableData.Step1GroundTime;
            inVariableData.Step1AirTime += newVariableData.Step1AirTime;
            inVariableData.Step1StrideLength += newVariableData.Step1StrideLength;
            inVariableData.Step1TouchdownDistance += newVariableData.Step1TouchdownDistance;
            inVariableData.Step1KneeSeperationatTouchdown += newVariableData.Step1KneeSeperationatTouchdown;
            inVariableData.Step1TrunkTouchdownAngle += newVariableData.Step1TrunkTouchdownAngle;
            inVariableData.Step1TrunkTakeoffAngle += newVariableData.Step1TrunkTakeoffAngle;


            inVariableData.Step1ULAtFullExtension += newVariableData.Step1ULAtFullExtension;
            inVariableData.Step1LLAtTakeoff += newVariableData.Step1LLAtTakeoff;
            inVariableData.Step1ULAtFullFlexion += newVariableData.Step1ULAtFullFlexion;
            //Step2
            inVariableData.Step2GroundTime += newVariableData.Step2GroundTime;
            inVariableData.Step2AirTime += newVariableData.Step2AirTime;
            inVariableData.Step2StrideLength += newVariableData.Step2StrideLength;
            inVariableData.Step2TouchdownDistance += newVariableData.Step2TouchdownDistance;
            inVariableData.Step2KneeSeperationatTouchdown += newVariableData.Step2KneeSeperationatTouchdown;
            inVariableData.Step2TrunkTouchdownAngle += newVariableData.Step2TrunkTouchdownAngle;
            inVariableData.Step2TrunkTakeoffAngle += newVariableData.Step2TrunkTakeoffAngle;

            inVariableData.Step2ULAtFullExtension += newVariableData.Step2ULAtFullExtension;
            inVariableData.Step2LLAtTakeoff += newVariableData.Step2LLAtTakeoff;
            inVariableData.Step2LLAtFullFlexion += newVariableData.Step2LLAtFullFlexion;
            inVariableData.Step2ULAtFullFlexion += newVariableData.Step2ULAtFullFlexion;


            //Step3
            inVariableData.Step3GroundTime += newVariableData.Step3GroundTime;
            inVariableData.Step3AirTime += newVariableData.Step3AirTime;
            inVariableData.Step3StrideLength += newVariableData.Step3StrideLength;
            inVariableData.Step3TouchdownDistance += newVariableData.Step3TouchdownDistance;
            inVariableData.Step3KneeSeperationatTouchdown += newVariableData.Step3KneeSeperationatTouchdown;
            inVariableData.Step3TrunkTouchdownAngle += newVariableData.Step3TrunkTouchdownAngle;
            inVariableData.Step3TrunkTakeoffAngle += newVariableData.Step3TrunkTakeoffAngle;

            inVariableData.Step3ULAtFullExtension += newVariableData.Step3ULAtFullExtension;
            inVariableData.Step3LLAtTakeoff += newVariableData.Step3LLAtTakeoff;
            inVariableData.Step3LLAtFullFlexion += newVariableData.Step3LLAtFullFlexion;
            inVariableData.Step3ULAtFullFlexion += newVariableData.Step3ULAtFullFlexion;

            //intoHurdleSteps
            inVariableData.SetTouchdownDistanceIntoTheHurdle += newVariableData.SetTouchdownDistanceIntoTheHurdle;
            inVariableData.SetKneeSeperationatTouchdownIntoTheHurdle += newVariableData.SetKneeSeperationatTouchdownIntoTheHurdle;
            inVariableData.SetTrunkTouchdownAngleIntoTheHurdle += newVariableData.SetTrunkTouchdownAngleIntoTheHurdle;
            inVariableData.SetLLAtTouchdownIntoTheHurdle += newVariableData.SetLLAtTouchdownIntoTheHurdle;




            return inVariableData;
        }

        HurdleStepsData avgVairableData(HurdleStepsData inVariableData, int totalCount)
        {
            if (totalCount > 1)
            {
                inVariableData.SetDistanceBetweenHurdleSteps = roundDecimal(inVariableData.SetDistanceBetweenHurdleSteps / totalCount);
                inVariableData.SetDistanceIntoHurdleSteps = roundDecimal(inVariableData.SetDistanceIntoHurdleSteps / totalCount);
                inVariableData.SetDistanceOffHurdleSteps = roundDecimal(inVariableData.SetDistanceOffHurdleSteps / totalCount);
                //Step1
                inVariableData.Step1GroundTime = roundDecimal(inVariableData.Step1GroundTime / totalCount);
                inVariableData.Step1AirTime = roundDecimal(inVariableData.Step1AirTime / totalCount);
                inVariableData.Step1StrideLength = roundDecimal(inVariableData.Step1StrideLength / totalCount);
                inVariableData.Step1TouchdownDistance = roundDecimal(inVariableData.Step1TouchdownDistance / totalCount);
                inVariableData.Step1KneeSeperationatTouchdown = roundDecimal(inVariableData.Step1KneeSeperationatTouchdown / totalCount);
                inVariableData.Step1TrunkTouchdownAngle = roundInteger((decimal)inVariableData.Step1TrunkTouchdownAngle / totalCount);
                inVariableData.Step1TrunkTakeoffAngle = roundInteger((decimal)inVariableData.Step1TrunkTakeoffAngle / totalCount);


                inVariableData.Step1ULAtFullExtension = roundInteger((decimal)inVariableData.Step1ULAtFullExtension / totalCount);
                inVariableData.Step1LLAtTakeoff = roundInteger((decimal)inVariableData.Step1LLAtTakeoff / totalCount);
                inVariableData.Step1ULAtFullFlexion = roundInteger((decimal)inVariableData.Step1ULAtFullFlexion / totalCount);
                //Step2
                inVariableData.Step2GroundTime = roundDecimal(inVariableData.Step2GroundTime / totalCount);
                inVariableData.Step2AirTime = roundDecimal(inVariableData.Step2AirTime / totalCount);
                inVariableData.Step2StrideLength = roundDecimal(inVariableData.Step2StrideLength / totalCount);
                inVariableData.Step2TouchdownDistance = roundDecimal(inVariableData.Step2TouchdownDistance / totalCount);
                inVariableData.Step2KneeSeperationatTouchdown = roundDecimal(inVariableData.Step2KneeSeperationatTouchdown / totalCount);
                inVariableData.Step2TrunkTouchdownAngle = roundInteger((decimal)inVariableData.Step2TrunkTouchdownAngle / totalCount);
                inVariableData.Step2TrunkTakeoffAngle = roundInteger((decimal)inVariableData.Step2TrunkTakeoffAngle / totalCount);

                inVariableData.Step2ULAtFullExtension = roundInteger((decimal)inVariableData.Step2ULAtFullExtension / totalCount);
                inVariableData.Step2LLAtTakeoff = roundInteger((decimal)inVariableData.Step2LLAtTakeoff / totalCount);
                inVariableData.Step2LLAtFullFlexion = roundInteger((decimal)inVariableData.Step2LLAtFullFlexion / totalCount);
                inVariableData.Step2ULAtFullFlexion = roundInteger((decimal)inVariableData.Step2ULAtFullFlexion / totalCount);


                //Step3
                inVariableData.Step3GroundTime = roundDecimal(inVariableData.Step3GroundTime / totalCount);
                inVariableData.Step3AirTime = roundDecimal(inVariableData.Step3AirTime / totalCount);
                inVariableData.Step3StrideLength = roundDecimal(inVariableData.Step3StrideLength / totalCount);
                inVariableData.Step3TouchdownDistance = roundDecimal(inVariableData.Step3TouchdownDistance / totalCount);
                inVariableData.Step3KneeSeperationatTouchdown = roundDecimal(inVariableData.Step3KneeSeperationatTouchdown / totalCount);
                inVariableData.Step3TrunkTouchdownAngle = roundInteger((decimal)inVariableData.Step3TrunkTouchdownAngle / totalCount);
                inVariableData.Step3TrunkTakeoffAngle = roundInteger((decimal)inVariableData.Step3TrunkTakeoffAngle / totalCount);

                inVariableData.Step3ULAtFullExtension = roundInteger((decimal)inVariableData.Step3ULAtFullExtension / totalCount);
                inVariableData.Step3LLAtTakeoff = roundInteger((decimal)inVariableData.Step3LLAtTakeoff / totalCount);
                inVariableData.Step3LLAtFullFlexion = roundInteger((decimal)inVariableData.Step3LLAtFullFlexion / totalCount);
                inVariableData.Step3ULAtFullFlexion = roundInteger((decimal)inVariableData.Step3ULAtFullFlexion / totalCount);

                //intoHurdleSteps
                inVariableData.SetTouchdownDistanceIntoTheHurdle = roundDecimal(inVariableData.SetTouchdownDistanceIntoTheHurdle / totalCount);
                inVariableData.SetKneeSeperationatTouchdownIntoTheHurdle = roundDecimal(inVariableData.SetKneeSeperationatTouchdownIntoTheHurdle / totalCount);
                inVariableData.SetTrunkTouchdownAngleIntoTheHurdle = roundInteger((decimal)inVariableData.SetTrunkTouchdownAngleIntoTheHurdle / totalCount);
                inVariableData.SetLLAtTouchdownIntoTheHurdle = roundInteger((decimal)inVariableData.SetLLAtTouchdownIntoTheHurdle / totalCount);


            }
            else
            {
                inVariableData.SetDistanceBetweenHurdleSteps = 0;
                return inVariableData;

            }
            return inVariableData;

        }

        List<MissingVariable> missingVariable = new List<MissingVariable>();

        string anyVairableDataZero(HurdleStepsData inVarirableData, int totalCount, string _type)
        {
            MissingVariable misv = new MissingVariable();
            string listOfVariableWithZero = "";
            if (totalCount > 1)
            {
                if (inVarirableData.SetDistanceBetweenHurdleSteps == 0)
                {
                    misv.type = _type;
                    missingVariable.Add(misv);
                    listOfVariableWithZero = "SetDistanceBetweenHurdleSteps  ";
                    //sendNotFoundEmail("This varibale has 0 value ...!" + listOfVariableWithZero, listOfVariableWithZero);
                }
                if (inVarirableData.SetDistanceIntoHurdleSteps == 0)
                {
                    misv.type = _type;
                    missingVariable.Add(misv);
                    listOfVariableWithZero = "SetDistanceIntoHurdleSteps  ";
                    //sendNotFoundEmail("This varibale has 0 value ...!" + listOfVariableWithZero, listOfVariableWithZero);
                }
                if (inVarirableData.SetDistanceOffHurdleSteps == 0)
                {
                    misv.type = _type;
                    missingVariable.Add(misv);
                    listOfVariableWithZero = "SetDistanceOffHurdleSteps  ";
                   // sendNotFoundEmail("This varibale has 0 value ...!" + listOfVariableWithZero, listOfVariableWithZero);
                }
                //if (inVarirableData.Velocity == 0)
                //{
                //    listOfVariableWithZero = "Velocity  ";
                //    //sendNotFoundEmail("This varibale has 0 value ...!" + listOfVariableWithZero, listOfVariableWithZero);
                //}
                if (inVarirableData.Step1GroundTime == 0)
                {
                    misv.type = _type;
                    missingVariable.Add(misv);
                    listOfVariableWithZero = "Step1GroundTime  ";
                   // sendNotFoundEmail("This varibale has 0 value ...!" + listOfVariableWithZero, listOfVariableWithZero);
                }
                if (inVarirableData.Step1AirTime == 0)
                {
                    misv.type = _type;
                    missingVariable.Add(misv);
                    listOfVariableWithZero = "Step1AirTime  ";
                   // sendNotFoundEmail("This varibale has 0 value ...!" + listOfVariableWithZero, listOfVariableWithZero);
                }
                //if (inVarirableData.Step1StrideRate == 0)
                //{
                //    listOfVariableWithZero = "Step1StrideRate  ";
                //    sendNotFoundEmail("This varibale has 0 value ...!" + listOfVariableWithZero, listOfVariableWithZero);
                //}
                if (inVarirableData.Step1StrideLength == 0)
                {
                    misv.type = _type;
                    missingVariable.Add(misv);
                    listOfVariableWithZero = "Step1StrideLength  ";
                   // sendNotFoundEmail("This varibale has 0 value ...!" + listOfVariableWithZero, listOfVariableWithZero);
                }
                if (inVarirableData.Step1TouchdownDistance == 0)
                {
                    misv.type = _type;
                    missingVariable.Add(misv);
                    listOfVariableWithZero = "Step1TouchdownDistance  ";
                   // sendNotFoundEmail("This varibale has 0 value ...!" + listOfVariableWithZero, listOfVariableWithZero);
                }
                if (inVarirableData.Step1KneeSeperationatTouchdown == 0)
                {
                    misv.type = _type;
                    missingVariable.Add(misv);
                    listOfVariableWithZero = "Step1KneeSeperationatTouchdown  ";
                   // sendNotFoundEmail("This varibale has 0 value ...!" + listOfVariableWithZero, listOfVariableWithZero);
                }
                if (inVarirableData.Step1TrunkTouchdownAngle == 0)
                {
                    misv.type = _type;
                    missingVariable.Add(misv);
                    listOfVariableWithZero = "Step1TrunkTouchdownAngle  ";
                   // sendNotFoundEmail("This varibale has 0 value ...!" + listOfVariableWithZero, listOfVariableWithZero);
                }
                if (inVarirableData.Step1TrunkTakeoffAngle == 0)
                {
                    misv.type = _type;
                    missingVariable.Add(misv);
                    listOfVariableWithZero = "Step1TrunkTakeoffAngle  ";
                   // sendNotFoundEmail("This varibale has 0 value ...!" + listOfVariableWithZero, listOfVariableWithZero);
                }
                if (inVarirableData.Step1ULAtFullExtension == 0)
                {
                    misv.type = _type;
                    missingVariable.Add(misv);
                    listOfVariableWithZero = "Step1ULAtFullExtension  ";
                   // sendNotFoundEmail("This varibale has 0 value ...!" + listOfVariableWithZero, listOfVariableWithZero);
                }
                if (inVarirableData.Step1LLAtTakeoff == 0)
                {
                    misv.type = _type;
                    missingVariable.Add(misv);
                    listOfVariableWithZero = "Step1LLAtTakeoff  ";
                    //sendNotFoundEmail("This varibale has 0 value ...!" + listOfVariableWithZero, listOfVariableWithZero);
                }
                if (inVarirableData.Step1ULAtFullFlexion == 0)
                {
                    misv.type = _type;
                    missingVariable.Add(misv);
                    listOfVariableWithZero = "Step1ULAtFullFlexion  ";
                   // sendNotFoundEmail("This varibale has 0 value ...!" + listOfVariableWithZero, listOfVariableWithZero);
                }
                if (inVarirableData.Step2GroundTime == 0)
                {
                    misv.type = _type;
                    missingVariable.Add(misv);
                    listOfVariableWithZero = "Step2GroundTime  ";
                   // sendNotFoundEmail("This varibale has 0 value ...!" + listOfVariableWithZero, listOfVariableWithZero);
                }
                if (inVarirableData.Step2AirTime == 0)
                {
                    misv.type = _type;
                    missingVariable.Add(misv);
                    listOfVariableWithZero = "Step2AirTime  ";
                    //sendNotFoundEmail("This varibale has 0 value ...!" + listOfVariableWithZero, listOfVariableWithZero);
                }
                //if (inVarirableData.Step2StrideRate == 0)
                //{
                //    listOfVariableWithZero = "Step2StrideRate  ";
                //    sendNotFoundEmail("This varibale has 0 value ...!" + listOfVariableWithZero, listOfVariableWithZero);
                //}
                if (inVarirableData.Step2StrideLength == 0)
                {
                    misv.type = _type;
                    missingVariable.Add(misv);
                    listOfVariableWithZero = "Step2StrideLength  ";
                   // sendNotFoundEmail("This varibale has 0 value ...!" + listOfVariableWithZero, listOfVariableWithZero);
                }
                if (inVarirableData.Step2TouchdownDistance == 0)
                {
                    misv.type = _type;
                    missingVariable.Add(misv);
                    listOfVariableWithZero = "Step2TouchdownDistance  ";
                    //sendNotFoundEmail("This varibale has 0 value ...!" + listOfVariableWithZero, listOfVariableWithZero);
                }
                if (inVarirableData.Step2KneeSeperationatTouchdown == 0)
                {
                    misv.type = _type;
                    missingVariable.Add(misv);
                    listOfVariableWithZero = "Step2KneeSeperationatTouchdown  ";
                    //sendNotFoundEmail("This varibale has 0 value ...!" + listOfVariableWithZero, listOfVariableWithZero);
                }
                if (inVarirableData.Step2TrunkTouchdownAngle == 0)
                {
                    misv.type = _type;
                    missingVariable.Add(misv);
                    listOfVariableWithZero = "Step2TrunkTouchdownAngle  ";
                    //sendNotFoundEmail("This varibale has 0 value ...!" + listOfVariableWithZero, listOfVariableWithZero);
                }
                if (inVarirableData.Step2TrunkTakeoffAngle == 0)
                {
                    misv.type = _type;
                    missingVariable.Add(misv);
                    listOfVariableWithZero = "Step2TrunkTakeoffAngle  ";
                    //sendNotFoundEmail("This varibale has 0 value ...!" + listOfVariableWithZero, listOfVariableWithZero);
                }
                if (inVarirableData.Step2ULAtFullExtension == 0)
                {
                    misv.type = _type;
                    missingVariable.Add(misv);
                    listOfVariableWithZero = "Step2ULAtFullExtension  ";
                   // sendNotFoundEmail("This varibale has 0 value ...!" + listOfVariableWithZero, listOfVariableWithZero);
                }
                if (inVarirableData.Step2LLAtTakeoff == 0)
                {
                    misv.type = _type;
                    missingVariable.Add(misv);
                    listOfVariableWithZero = "Step2LLAtTakeoff  ";
                  //  sendNotFoundEmail("This varibale has 0 value ...!" + listOfVariableWithZero, listOfVariableWithZero);
                }
                if (inVarirableData.Step2LLAtFullFlexion == 0)
                {
                    misv.type = _type;
                    missingVariable.Add(misv);
                    listOfVariableWithZero = "Step2LLAtFullFlexion  ";
                    //sendNotFoundEmail("This varibale has 0 value ...!" + listOfVariableWithZero, listOfVariableWithZero);
                }
                //if (inVarirableData.Step2LLAtatAnkleCross == 0)
                //{
                //    listOfVariableWithZero = "Step2LLAtatAnkleCross  ";
                //    sendNotFoundEmail("This varibale has 0 value ...!" + listOfVariableWithZero, listOfVariableWithZero);
                //}
                if (inVarirableData.Step2ULAtFullFlexion == 0)
                {
                    misv.type = _type;
                    missingVariable.Add(misv);
                    listOfVariableWithZero = "Step2ULAtFullFlexion  ";
                    //sendNotFoundEmail("This varibale has 0 value ...!" + listOfVariableWithZero, listOfVariableWithZero);
                }
                if (inVarirableData.Step3GroundTime == 0)
                {
                    misv.type = _type;
                    missingVariable.Add(misv);
                    listOfVariableWithZero = "Step3GroundTime  ";
                   // sendNotFoundEmail("This varibale has 0 value ...!" + listOfVariableWithZero, listOfVariableWithZero);
                }
                if (inVarirableData.Step3AirTime == 0)
                {
                    misv.type = _type;
                    missingVariable.Add(misv);
                    listOfVariableWithZero = "Step3AirTime  ";
                    //sendNotFoundEmail("This varibale has 0 value ...!" + listOfVariableWithZero, listOfVariableWithZero);
                }
                //if (inVarirableData.Step3StrideRate == 0)
                //{
                //    listOfVariableWithZero = "Step3StrideRate  ";
                //    sendNotFoundEmail("This varibale has 0 value ...!" + listOfVariableWithZero, listOfVariableWithZero);
                //}
                if (inVarirableData.Step3StrideLength == 0)
                {
                    misv.type = _type;
                    missingVariable.Add(misv);
                    listOfVariableWithZero = "Step3StrideLength  ";
                   // sendNotFoundEmail("This varibale has 0 value ...!" + listOfVariableWithZero, listOfVariableWithZero);
                }
                if (inVarirableData.Step3TouchdownDistance == 0)
                {
                    misv.type = _type;
                    missingVariable.Add(misv);
                    listOfVariableWithZero = "Step3TouchdownDistance  ";
                   // sendNotFoundEmail("This varibale has 0 value ...!" + listOfVariableWithZero, listOfVariableWithZero);
                }
                if (inVarirableData.Step3KneeSeperationatTouchdown == 0)
                {
                    misv.type = _type;
                    missingVariable.Add(misv);
                    listOfVariableWithZero = "Step3KneeSeperationatTouchdown  ";
                   // sendNotFoundEmail("This varibale has 0 value ...!" + listOfVariableWithZero, listOfVariableWithZero);
                }
                if (inVarirableData.Step3TrunkTouchdownAngle == 0)
                {
                    misv.type = _type;
                    missingVariable.Add(misv);
                    listOfVariableWithZero = "Step3TrunkTouchdownAngle  ";
                   // sendNotFoundEmail("This varibale has 0 value ...!" + listOfVariableWithZero, listOfVariableWithZero);
                }
                if (inVarirableData.Step3TrunkTakeoffAngle == 0)
                {
                    misv.type = _type;
                    missingVariable.Add(misv);
                    listOfVariableWithZero = "Step3TrunkTakeoffAngle  ";
                   // sendNotFoundEmail("This varibale has 0 value ...!" + listOfVariableWithZero, listOfVariableWithZero);
                }
                if (inVarirableData.Step3ULAtFullExtension == 0)
                {
                    misv.type = _type;
                    missingVariable.Add(misv);
                    listOfVariableWithZero = "Step3ULAtFullExtension  ";
                    //sendNotFoundEmail("This varibale has 0 value ...!" + listOfVariableWithZero, listOfVariableWithZero);
                }
                if (inVarirableData.Step3LLAtTakeoff == 0)
                {
                    misv.type = _type;
                    missingVariable.Add(misv);
                    listOfVariableWithZero = "Step3LLAtTakeoff  ";
                   // sendNotFoundEmail("This varibale has 0 value ...!" + listOfVariableWithZero, listOfVariableWithZero);
                }
                if (inVarirableData.Step3LLAtFullFlexion == 0)
                {
                    misv.type = _type;
                    missingVariable.Add(misv);
                    listOfVariableWithZero = "Step3LLAtFullFlexion  ";
                   // sendNotFoundEmail("This varibale has 0 value ...!" + listOfVariableWithZero, listOfVariableWithZero);
                }
                //if (inVarirableData.Step3LLAtatAnkleCross == 0)
                //{
                //    listOfVariableWithZero = "LLFullFlexionAngleRight ";
                //    sendNotFoundEmail("This varibale has 0 value ...!" + listOfVariableWithZero, listOfVariableWithZero);
                //}
                if (inVarirableData.Step3ULAtFullFlexion == 0)
                {
                    misv.type = _type;
                    missingVariable.Add(misv);
                    listOfVariableWithZero = "Step3ULAtFullFlexion  ";
                   // sendNotFoundEmail("This varibale has 0 value ...!" + listOfVariableWithZero, listOfVariableWithZero);
                }
                if (inVarirableData.SetTouchdownDistanceIntoTheHurdle == 0)
                {
                    misv.type = _type;
                    missingVariable.Add(misv);
                    listOfVariableWithZero = "SetTouchdownDistanceIntoTheHurdle  ";
                   // sendNotFoundEmail("This varibale has 0 value ...!" + listOfVariableWithZero, listOfVariableWithZero);
                }
                if (inVarirableData.SetKneeSeperationatTouchdownIntoTheHurdle == 0)
                {
                    misv.type = _type;
                    missingVariable.Add(misv);
                    listOfVariableWithZero = "SetKneeSeperationatTouchdownIntoTheHurdle  ";
                    //sendNotFoundEmail("This varibale has 0 value ...!" + listOfVariableWithZero, listOfVariableWithZero);
                }
                if (inVarirableData.SetTrunkTouchdownAngleIntoTheHurdle == 0)
                {
                    misv.type = _type;
                    missingVariable.Add(misv);
                    listOfVariableWithZero = "SetTrunkTouchdownAngleIntoTheHurdle  ";
                   // sendNotFoundEmail("This varibale has 0 value ...!" + listOfVariableWithZero, listOfVariableWithZero);
                }
                if (inVarirableData.SetLLAtTouchdownIntoTheHurdle == 0)
                {
                    misv.type = _type;
                    missingVariable.Add(misv);
                    listOfVariableWithZero = "SetLLAtTouchdownIntoTheHurdle  ";
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
                lesson.SiteId = 11;//defualt site for customer is Baylor
            }
            lesson.CustomerId = custmer.CustomerId;
            lesson.LessonTypeId = 6;
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
                    int MovieIdInitialSide = sae.InsertMovieOnTrack(0, movie.DateRecorded, "Users/MovieFiles/ModelSprint-Initial-Side.mp4", lesson.LessonId);
                    InsertMovieClip(MovieIdInitialSide);
                    int MovieIdInitialBack = sae.InsertMovieOnTrack(1, movie.DateRecorded, "Users/MovieFiles/ModelSprint-Initial-Back.mp4", lesson.LessonId);
                    InsertMovieClip(MovieIdInitialBack);
                }
                if (Hurdle_FinalDataId == string.Empty && _finalCount > 1)
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
                int MovieIdInitialSide = sae.UpdateMovieOnTrack(0, DateTime.Now, "Users/MovieFiles/ModelSprint-Initial-Side.mp4", _onTrackSessionlessonId);
                int MovieIdInitialBack = sae.UpdateMovieOnTrack(1, DateTime.Now, "Users/MovieFiles/ModelSprint-Initial-Back.mp4", _onTrackSessionlessonId);
                int MovieIdCurrentSide = sae.UpdateMovieOnTrack(2, DateTime.Now, "Users/MovieFiles/ModelSprint-Current-Side.mp4", _onTrackSessionlessonId);
                int MovieIdCurrentBack = sae.UpdateMovieOnTrack(3, DateTime.Now, "Users/MovieFiles/ModelSprint-Current-Back.mp4", _onTrackSessionlessonId);
                Hurdle_InitialDataId = sae.SelectHurdleStepsInitialDataid(_onTrackSessionlessonId.ToString());
                Hurdle_FinalDataId = sae.SelectHurdleStepsCurrentDataid(_onTrackSessionlessonId.ToString());
                Hurdle_modelSummary = sae.SelectHurdleStepsModelDataid(_onTrackSessionlessonId.ToString());
            }
            if (Hurdle_InitialDataId == string.Empty && _initialCount > 1)
            {
                _initialSummary.LessonId = lesson.LessonId;
                _initialSummary.InsertIntoHurdleStepsInitialData();
            }
            else
            {
                _initialSummary.LessonId = _onTrackSessionlessonId;
                _initialSummary.UpdateHurdleStepsInitialData();
            }
            if (Hurdle_FinalDataId == string.Empty && _finalCount > 1)
            {
                _finalSummary.LessonId = lesson.LessonId;
                //_finalSummary.LessonId = _onTrackSessionlessonId;
                _finalSummary.InsertIntoHurdleStepsCurrentData();
            }
            else
            {
                _finalSummary.LessonId = _onTrackSessionlessonId;
                _finalSummary.UpdateHurdleStepsCurrentData();

            }
            if (Hurdle_modelSummary == string.Empty && _modelCount > 1)
            {
                _modelSummary.LessonId = lesson.LessonId;
                //_modelSummary.LessonId = _onTrackSessionlessonId;
                _modelSummary.InsertIntoHurdleStepsModelData();
                // _modelSummary.InsertIntoSprintOntrackModelData();
            }
            else
            {
                _modelSummary.LessonId = _onTrackSessionlessonId;
                _modelSummary.UpdateHurdleStepsModelData();
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
}
