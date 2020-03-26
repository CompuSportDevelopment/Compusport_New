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

    public class StartPageOnTrackSession
    {
        public CustomerProfile customerprofile;
        public CustomerProfile customerprofile1;
        public int _onTrackSessionlessonId;
        IList<StartPageSessionData> _sessionDataList = new List<StartPageSessionData>();
        int _initialCount = 0;
        int _finalCount = 0;
        int _modelCount = 0;

        StartInitialData _sessionSummary = new StartInitialData();
        StartInitialData _initialSummary = new StartInitialData();
        StartInitialData _finalSummary = new StartInitialData();
        StartInitialData _modelSummary = new StartInitialData();
        Customer customer;

        CompuSportDAL.SprintAthleteEdit sae = new CompuSportDAL.SprintAthleteEdit();
        CompuSportDAL.StartInitialData _SprintData = new CompuSportDAL.StartInitialData();

        DataSet dsSessions = new DataSet();
        DataTable dtSession = new DataTable();

        public void StartPageOnTrackSessionData(int athleteSelected)
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
                    if ((location != "On-Track Sesssion Summary" && lesson.LessonTypeId != 2))
                    {
                        if (!location.Contains('(') && lesson.LessonTypeId.Equals(1))
                        {
                            //DataSet dsSession = new DataSet();
                            var dsSession = sae.GetAllStartAthletesData(lesson.LessonId);
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
                        if (location == "On-Track Sesssion Summary" && lesson.LessonTypeId.Equals(1))
                        {
                            _onTrackSessionlessonId = lesson.LessonId;
                        }
                    }
                }

                avgVariableDataValues(athleteSelected);
                missingVariableStar.Clear();
                string missingVairableInitialList = anyVairableDataZero(_initialSummary, _initialCount, "_initial");
                string missingVairableFinalList = anyVairableDataZero(_finalSummary, _finalCount, "Final");
                string missingVairableModelList = anyVairableDataZero(_modelSummary, _modelCount, "Currnt");



                if (missingVairableInitialList == string.Empty || missingVairableFinalList == string.Empty)
                {
                    if ((_initialCount > 1 || _finalCount > 1) && !(missingVariableStar.Count > 0))
                    {
                        createOnTrackSprintSession(athleteSelected);
                    }
                    else if (missingVariableStar.Count > 0)
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
            for (int i = 0; i < missingVariableStar.Count; i++)
            {

                var lessiodatelocaon = DateTime.Now.ToString("M/d/yyyy") + "-" + "On-Track Sesssion Summary";
                if (missingVariableStar[i].type == "_initial")
                {
                    _initialMessage += missingVariableStar[i].variableName + ", ";
                    message = "Session Details :- " + lessiodatelocaon + "\n" + _initialMessage + "\n";

                }
                else
                {
                    _finalMessage += missingVariableStar[i].variableName + ", ";
                    message = "Session Details :- " + lessiodatelocaon + "\n" + _finalMessage + "\n";
                }
            }
            //var message = _initialMessage + _finalMessage;
            var email = Membership.GetUser().Email;
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            msg.From = new System.Net.Mail.MailAddress(email);
            msg.To.Add("roshant@sveltoz.com");
            msg.Body = message;
            msg.Subject = "Compusport : " + customer.FirstName + "" + customer.LastName + " Data Missing";
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
            smtp.Host = "smtpout.secureserver.net";
            smtp.Port = 25;
            smtp.Credentials = new System.Net.NetworkCredential("anandb@sveltoz.com", "Passw0rd1");
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
            return Convert.ToInt32(Math.Round(Convert.ToDecimal(value), 3));
        }

        void LoadSession(DataSet dsSession)
        {
            StartPageSessionData sessionData = new StartPageSessionData();
            if (dsSession.Tables[0].Rows.Count > 0)
            {
                if (variableDataExists(dsSession.Tables[0].Rows[0]) == true)
                {
                    _initialCount++;
                    sessionData.SetStartInitialData(dsSession.Tables[0].Rows[0]);
                }
            }
            if (dsSession.Tables[2].Rows.Count > 0)
            {
                if (variableDataExists(dsSession.Tables[2].Rows[0]) == true)
                {
                    _finalCount++;
                    sessionData.SetStartFinalData(dsSession.Tables[2].Rows[0]);
                }
            }

            if (dsSession.Tables[1].Rows.Count > 0)
            {
                if (variableDataExists(dsSession.Tables[1].Rows[0]) == true)
                {
                    _modelCount++;
                    sessionData.SetStartModelData(dsSession.Tables[1].Rows[0]);
                }
            }


            _sessionDataList.Add(sessionData);
        }

        void avgVariableDataValues(int athleteSelected)
        {
            foreach (StartPageSessionData sessionData in _sessionDataList)
            {
                _initialSummary = addSessionData(_initialSummary, sessionData.StartInitialData);
                _finalSummary = addSessionData(_finalSummary, sessionData.StartFinalData);
                _modelSummary = addSessionData(_modelSummary, sessionData.StartModelData);
            }
            _initialSummary = avgVairableData(_initialSummary, _initialCount);
            _finalSummary = avgVairableData(_finalSummary, _finalCount);
            _modelSummary = avgVairableData(_modelSummary, _modelCount);
        }

        StartInitialData addSessionData(StartInitialData inVariableData, StartInitialData newVariableData)
        {
            inVariableData.SetFrontBlockDistanceI += newVariableData.SetFrontBlockDistanceI;
            inVariableData.SetRearBlockDistanceI += newVariableData.SetRearBlockDistanceI;
            inVariableData.SetFrontULAngleI += newVariableData.SetFrontULAngleI;
            inVariableData.SetRearULAngleI += newVariableData.SetRearULAngleI;
            inVariableData.SetFrontLLAngleI += newVariableData.SetFrontLLAngleI;
            inVariableData.SetRearLLAngleI += newVariableData.SetRearLLAngleI;
            inVariableData.SetTrunkAngleI += newVariableData.SetTrunkAngleI;
            inVariableData.SetCOGDistanceI += newVariableData.SetCOGDistanceI;
            inVariableData.BCRearFootClearanceTimeI += newVariableData.BCRearFootClearanceTimeI;
            inVariableData.BCFrontFootClearanceTimeI += newVariableData.BCFrontFootClearanceTimeI;
            inVariableData.BCRearLLAngleTakeoffI += newVariableData.BCRearLLAngleTakeoffI;
            inVariableData.BCFrontLLAngleTakeoffI += newVariableData.BCFrontLLAngleTakeoffI;
            inVariableData.BCTrunkAngleTakeoffI += newVariableData.BCTrunkAngleTakeoffI;
            inVariableData.BCLLAngleACI += newVariableData.BCLLAngleACI;
            inVariableData.BCAirTimeI += newVariableData.BCAirTimeI;
            inVariableData.BCStrideLengthI += newVariableData.BCStrideLengthI;
            inVariableData.Step1COGDistanceI += newVariableData.Step1COGDistanceI;
            inVariableData.Step1LLAngleTakeoffI += newVariableData.Step1LLAngleTakeoffI;
            inVariableData.Step1TrunkAngleTakeoffI += newVariableData.Step1TrunkAngleTakeoffI;
            inVariableData.Step1LLAngleACI += newVariableData.Step1LLAngleACI;
            inVariableData.Step1GroundTimeI += newVariableData.Step1GroundTimeI;
            inVariableData.Step1AirTimeI += newVariableData.Step1AirTimeI;
            inVariableData.Step1StrideLengthI += newVariableData.Step1StrideLengthI;
            inVariableData.Step2COGDistanceI += newVariableData.Step2COGDistanceI;
            inVariableData.Step2LLAngleTakeoffI += newVariableData.Step2LLAngleTakeoffI;
            inVariableData.Step2TrunkAngleTakeoffI += newVariableData.Step2TrunkAngleTakeoffI;
            inVariableData.Step2LLAngleACI += newVariableData.Step2LLAngleACI;
            inVariableData.Step2GroundTimeI += newVariableData.Step2GroundTimeI;
            inVariableData.Step2AirTimeI += newVariableData.Step2AirTimeI;
            inVariableData.Step2StrideLengthI += newVariableData.Step2StrideLengthI;
            inVariableData.Step3COGDistanceI += newVariableData.Step3COGDistanceI;
            inVariableData.TimeTo3mI += newVariableData.TimeTo3mI;
            inVariableData.TimeTo5mI += newVariableData.TimeTo5mI;

            return inVariableData;
        }

        StartInitialData avgVairableData(StartInitialData inVariableData, int totalCount)
        {
            if (totalCount > 1)
            {
                inVariableData.SetFrontBlockDistanceI = roundDecimal(inVariableData.SetFrontBlockDistanceI / totalCount);
                inVariableData.SetRearBlockDistanceI = roundDecimal(inVariableData.SetRearBlockDistanceI / totalCount);

                inVariableData.SetFrontULAngleI = roundInteger((decimal)inVariableData.SetFrontULAngleI / totalCount);
                inVariableData.SetRearULAngleI = roundInteger((decimal)inVariableData.SetRearULAngleI / totalCount);
                inVariableData.SetFrontLLAngleI = roundInteger((decimal)inVariableData.SetFrontLLAngleI / totalCount);
                inVariableData.SetRearLLAngleI = roundInteger((decimal)inVariableData.SetRearLLAngleI / totalCount);
                inVariableData.SetTrunkAngleI = roundInteger((decimal)inVariableData.SetTrunkAngleI / totalCount);

                inVariableData.SetCOGDistanceI = roundDecimal(inVariableData.SetCOGDistanceI / totalCount);
                inVariableData.BCRearFootClearanceTimeI = roundDecimal(inVariableData.BCRearFootClearanceTimeI / totalCount);
                inVariableData.BCFrontFootClearanceTimeI = roundDecimal(inVariableData.BCFrontFootClearanceTimeI / totalCount);

                inVariableData.BCRearLLAngleTakeoffI = roundInteger((decimal)inVariableData.BCRearLLAngleTakeoffI / totalCount);
                inVariableData.BCFrontLLAngleTakeoffI = roundInteger((decimal)inVariableData.BCFrontLLAngleTakeoffI / totalCount);
                inVariableData.BCTrunkAngleTakeoffI = roundInteger((decimal)inVariableData.BCTrunkAngleTakeoffI / totalCount);
                inVariableData.BCLLAngleACI = roundInteger((decimal)inVariableData.BCLLAngleACI / totalCount);

                inVariableData.BCAirTimeI = roundDecimal(inVariableData.BCAirTimeI / totalCount);
                inVariableData.BCStrideLengthI = roundDecimal(inVariableData.BCStrideLengthI / totalCount);
                inVariableData.Step1COGDistanceI = roundDecimal(inVariableData.Step1COGDistanceI / totalCount);

                inVariableData.Step1LLAngleTakeoffI = roundInteger((decimal)inVariableData.Step1LLAngleTakeoffI / totalCount);
                inVariableData.Step1TrunkAngleTakeoffI = roundInteger((decimal)inVariableData.Step1TrunkAngleTakeoffI / totalCount);
                inVariableData.Step1LLAngleACI = roundInteger((decimal)inVariableData.Step1LLAngleACI / totalCount);

                inVariableData.Step1GroundTimeI = roundDecimal(inVariableData.Step1GroundTimeI / totalCount);
                inVariableData.Step1AirTimeI = roundDecimal(inVariableData.Step1AirTimeI / totalCount);
                inVariableData.Step1StrideLengthI = roundDecimal(inVariableData.Step1StrideLengthI / totalCount);
                inVariableData.Step2COGDistanceI = roundDecimal(inVariableData.Step2COGDistanceI / totalCount);

                inVariableData.Step2LLAngleTakeoffI = roundInteger((decimal)inVariableData.Step2LLAngleTakeoffI / totalCount);
                inVariableData.Step2TrunkAngleTakeoffI = roundInteger((decimal)inVariableData.Step2TrunkAngleTakeoffI / totalCount);
                inVariableData.Step2LLAngleACI = roundInteger((decimal)inVariableData.Step2LLAngleACI / totalCount);

                inVariableData.Step2GroundTimeI = roundDecimal(inVariableData.Step2GroundTimeI / totalCount);
                inVariableData.Step2AirTimeI = roundDecimal(inVariableData.Step2AirTimeI / totalCount);
                inVariableData.Step2StrideLengthI = roundDecimal(inVariableData.Step2StrideLengthI / totalCount);
                inVariableData.Step3COGDistanceI = roundDecimal(inVariableData.Step3COGDistanceI / totalCount);
                inVariableData.TimeTo3mI = roundDecimal(inVariableData.TimeTo3mI / totalCount);
                inVariableData.TimeTo5mI = roundDecimal(inVariableData.TimeTo5mI / totalCount);

            }
            else
            {
                inVariableData.SetFrontBlockDistanceI = 0;
                inVariableData.SetRearBlockDistanceI = 0;
                inVariableData.SetFrontULAngleI = 0;
                inVariableData.SetRearULAngleI = 0;
                inVariableData.SetFrontLLAngleI = 0;
                inVariableData.SetRearLLAngleI = 0;
                inVariableData.SetTrunkAngleI = 0;
                inVariableData.SetCOGDistanceI = 0;
                inVariableData.BCRearFootClearanceTimeI = 0;
                inVariableData.BCFrontFootClearanceTimeI = 0;
                inVariableData.BCRearLLAngleTakeoffI = 0;
                inVariableData.BCFrontLLAngleTakeoffI = 0;
                inVariableData.BCTrunkAngleTakeoffI = 0;
                inVariableData.BCLLAngleACI = 0;
                inVariableData.BCAirTimeI = 0;
                inVariableData.BCStrideLengthI = 0;
                inVariableData.Step1COGDistanceI = 0;
                inVariableData.Step1LLAngleTakeoffI = 0;
                inVariableData.Step1TrunkAngleTakeoffI = 0;
                inVariableData.Step1LLAngleACI = 0;
                inVariableData.Step1GroundTimeI = 0;
                inVariableData.Step1AirTimeI = 0;
                inVariableData.Step1StrideLengthI = 0;
                inVariableData.Step2COGDistanceI = 0;
                inVariableData.Step2LLAngleTakeoffI = 0;
                inVariableData.Step2TrunkAngleTakeoffI = 0;
                inVariableData.Step2LLAngleACI = 0;
                inVariableData.Step2GroundTimeI = 0;
                inVariableData.Step2AirTimeI = 0;
                inVariableData.Step2StrideLengthI = 0;
                inVariableData.Step3COGDistanceI = 0;
                inVariableData.TimeTo3mI = 0;
                inVariableData.TimeTo5mI = 0;


            }
            return inVariableData;

        }
        List<MissingVariableStart> missingVariableStar = new List<MissingVariableStart>();

        string anyVairableDataZero(StartInitialData inVarirableData, int totalCount, string _type)
        {
            string listOfVariableWithZero = "";
            //MissingVariableStart MISSV = new MissingVariableStart();
            if (totalCount > 1)
            {
                if (inVarirableData.SetFrontBlockDistanceI == 0)
                {
                    MissingVariableStart MISSV = new MissingVariableStart();
                    MISSV.type = _type;
                    MISSV.variableName = "SetFrontBlockDistance";
                    missingVariableStar.Add(MISSV);

                }
                if (inVarirableData.SetRearBlockDistanceI == 0)
                {
                    MissingVariableStart MISSV = new MissingVariableStart();
                    MISSV.type = _type;
                    MISSV.variableName = "SetRearBlockDistance";
                    missingVariableStar.Add(MISSV);
                }
                if (inVarirableData.SetFrontULAngleI == 0)
                {
                    MissingVariableStart MISSV = new MissingVariableStart();
                    MISSV.type = _type;
                    MISSV.variableName = "SetFrontULAngle";
                    missingVariableStar.Add(MISSV);
                }
                if (inVarirableData.SetRearULAngleI == 0)
                {
                    MissingVariableStart MISSV = new MissingVariableStart();
                    MISSV.type = _type;
                    MISSV.variableName = "SetRearULAngle";
                    missingVariableStar.Add(MISSV);
                }
                if (inVarirableData.SetFrontLLAngleI == 0)
                {
                    MissingVariableStart MISSV = new MissingVariableStart();
                    MISSV.type = _type;
                    MISSV.variableName = "SetFrontLLAngle";
                    missingVariableStar.Add(MISSV);
                }
                if (inVarirableData.SetRearLLAngleI == 0)
                {
                    MissingVariableStart MISSV = new MissingVariableStart();
                    MISSV.type = _type;
                    MISSV.variableName = "SetFrontBlockDistance";
                    missingVariableStar.Add(MISSV);
                }
                if (inVarirableData.SetTrunkAngleI == 0)
                {
                    MissingVariableStart MISSV = new MissingVariableStart();
                    MISSV.type = _type;
                    MISSV.variableName = "SetTrunkAngle";
                    missingVariableStar.Add(MISSV);
                }
                if (inVarirableData.SetCOGDistanceI == 0)
                {
                    MissingVariableStart MISSV = new MissingVariableStart();
                    MISSV.type = _type;
                    MISSV.variableName = "SetCOGDistance";
                    missingVariableStar.Add(MISSV);
                }
                if (inVarirableData.BCRearFootClearanceTimeI == 0)
                {
                    MissingVariableStart MISSV = new MissingVariableStart();
                    MISSV.type = _type;
                    MISSV.variableName = "BCRearFootClearanceTime";
                    missingVariableStar.Add(MISSV);
                }
                if (inVarirableData.BCFrontFootClearanceTimeI == 0)
                {
                    MissingVariableStart MISSV = new MissingVariableStart();
                    MISSV.type = _type;
                    MISSV.variableName = "BCFrontFootClearanceTime";
                    missingVariableStar.Add(MISSV);
                }
                if (inVarirableData.BCRearLLAngleTakeoffI == 0)
                {
                    MissingVariableStart MISSV = new MissingVariableStart();
                    MISSV.type = _type;
                    MISSV.variableName = "BCRearLLAngleTakeoff";
                    missingVariableStar.Add(MISSV);
                }
                if (inVarirableData.BCFrontLLAngleTakeoffI == 0)
                {
                    MissingVariableStart MISSV = new MissingVariableStart();
                    MISSV.type = _type;
                    MISSV.variableName = "BCFrontLLAngleTakeoff";
                    missingVariableStar.Add(MISSV);
                }
                if (inVarirableData.BCTrunkAngleTakeoffI == 0)
                {
                    MissingVariableStart MISSV = new MissingVariableStart();
                    MISSV.type = _type;
                    MISSV.variableName = "SetFrontBlockDistance";
                    missingVariableStar.Add(MISSV);
                }
                if (inVarirableData.BCLLAngleACI == 0)
                {
                    MissingVariableStart MISSV = new MissingVariableStart();
                    MISSV.type = _type;
                    MISSV.variableName = "BCLLAngleAC";
                    missingVariableStar.Add(MISSV);
                }
                if (inVarirableData.BCAirTimeI == 0)
                {
                    MissingVariableStart MISSV = new MissingVariableStart();
                    MISSV.type = _type;
                    MISSV.variableName = "BCAirTime";
                    missingVariableStar.Add(MISSV);
                }
                //if (inVarirableData.BCStrideLengthI == 0)
                //{
                //    listOfVariableWithZero = "BC Stride Length";
                //    sendNotFoundEmail("This varibale has 0 value ...!" + listOfVariableWithZero, listOfVariableWithZero);
                //}
                if (inVarirableData.Step1COGDistanceI == 0)
                {
                    MissingVariableStart MISSV = new MissingVariableStart();
                    MISSV.type = _type;
                    MISSV.variableName = "Step1COGDistance";
                    missingVariableStar.Add(MISSV);
                }
                if (inVarirableData.Step1LLAngleTakeoffI == 0)
                {
                    MissingVariableStart MISSV = new MissingVariableStart();
                    MISSV.type = _type;
                    MISSV.variableName = "Step1LLAngleTakeoff";
                    missingVariableStar.Add(MISSV);
                }
                if (inVarirableData.Step1TrunkAngleTakeoffI == 0)
                {
                    MissingVariableStart MISSV = new MissingVariableStart();
                    MISSV.type = _type;
                    MISSV.variableName = "Step1TrunkAngleTakeoff";
                    missingVariableStar.Add(MISSV);
                }
                if (inVarirableData.Step1LLAngleACI == 0)
                {
                    MissingVariableStart MISSV = new MissingVariableStart();
                    MISSV.type = _type;
                    MISSV.variableName = "Step1LLAngleAC";
                    missingVariableStar.Add(MISSV);
                }
                if (inVarirableData.Step1GroundTimeI == 0)
                {
                    MissingVariableStart MISSV = new MissingVariableStart();
                    MISSV.type = _type;
                    MISSV.variableName = "Step1GroundTime";
                    missingVariableStar.Add(MISSV);
                }
                if (inVarirableData.Step1AirTimeI == 0)
                {
                    MissingVariableStart MISSV = new MissingVariableStart();
                    listOfVariableWithZero = "Step1AirTime";
                    MISSV.type = _type;
                    MISSV.variableName = "SetFrontBlockDistance";
                    missingVariableStar.Add(MISSV);
                }
                if (inVarirableData.Step1StrideLengthI == 0)
                {
                    MissingVariableStart MISSV = new MissingVariableStart();
                    MISSV.type = _type;
                    MISSV.variableName = "Step1StrideLength";
                    missingVariableStar.Add(MISSV);
                }
                if (inVarirableData.Step2COGDistanceI == 0)
                {
                    MissingVariableStart MISSV = new MissingVariableStart();
                    MISSV.type = _type;
                    MISSV.variableName = "Step2COGDistance";
                    missingVariableStar.Add(MISSV);
                }
                if (inVarirableData.Step2LLAngleTakeoffI == 0)
                {
                    MissingVariableStart MISSV = new MissingVariableStart();
                    MISSV.type = _type;
                    MISSV.variableName = "Step2LLAngleTakeoff";
                    missingVariableStar.Add(MISSV);
                }
                if (inVarirableData.Step2TrunkAngleTakeoffI == 0)
                {
                    MissingVariableStart MISSV = new MissingVariableStart();
                    MISSV.variableName = "Step2TrunkAngleTakeoff";
                    missingVariableStar.Add(MISSV);
                }
                if (inVarirableData.Step2LLAngleACI == 0)
                {
                    MissingVariableStart MISSV = new MissingVariableStart();
                    MISSV.type = _type;
                    MISSV.variableName = "Step2LLAngleAC";
                    missingVariableStar.Add(MISSV);
                }
                if (inVarirableData.Step2GroundTimeI == 0)
                {
                    MissingVariableStart MISSV = new MissingVariableStart();
                    MISSV.type = _type;
                    MISSV.variableName = "Step2GroundTime";
                    missingVariableStar.Add(MISSV);
                }
                if (inVarirableData.Step2AirTimeI == 0)
                {
                    MissingVariableStart MISSV = new MissingVariableStart();
                    MISSV.type = _type;
                    MISSV.variableName = "Step2AirTime";
                    missingVariableStar.Add(MISSV);
                }
                if (inVarirableData.Step2StrideLengthI == 0)
                {
                    MissingVariableStart MISSV = new MissingVariableStart();
                    MISSV.type = _type;
                    MISSV.variableName = "Step2StrideLength";
                    missingVariableStar.Add(MISSV);
                }
                if (inVarirableData.Step3COGDistanceI == 0)
                {
                    MissingVariableStart MISSV = new MissingVariableStart();
                    MISSV.type = _type;
                    MISSV.variableName = "Step3COGDistance";
                    missingVariableStar.Add(MISSV);
                }
                if (inVarirableData.TimeTo3mI == 0)
                {
                    MissingVariableStart MISSV = new MissingVariableStart();
                    MISSV.type = _type;
                    MISSV.variableName = "TimeTo3m";
                    missingVariableStar.Add(MISSV);
                }
                if (inVarirableData.TimeTo5mI == 0)
                {
                    MissingVariableStart MISSV = new MissingVariableStart();
                    MISSV.type = _type;
                    MISSV.variableName = "TimeTo5m";
                    missingVariableStar.Add(MISSV);
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
            lesson.LessonTypeId = 1;
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
                    int MovieIdInitialSide = sae.InsertMovieOnTrack(0, movie.DateRecorded, "Users/MovieFiles/ModelStart-Initial-Side.mp4", lesson.LessonId);
                    InsertMovieClip(MovieIdInitialSide);
                    int MovieIdInitialBack = sae.InsertMovieOnTrack(1, movie.DateRecorded, "Users/MovieFiles/ModelStart-Initial-Back.mp4", lesson.LessonId);
                    InsertMovieClip(MovieIdInitialBack);
                }
                if (sprint_FinalDataId == string.Empty && _finalCount > 1)
                {
                    int MovieIdCurrentSide = sae.InsertMovieOnTrack(2, movie.DateRecorded, "Users/MovieFiles/ModelStart-Current-Side.mp4", lesson.LessonId);
                    InsertMovieClip(MovieIdCurrentSide);
                    int MovieIdCurrentBack = sae.InsertMovieOnTrack(3, movie.DateRecorded, "Users/MovieFiles/ModelStart-Current-Back.mp4", lesson.LessonId);
                    InsertMovieClip(MovieIdCurrentBack);
                }

            }
            else
            {
                sae.UpdateOntrackLessonLocation(location, _onTrackSessionlessonId, DateTime.Now);
                if (sprint_InitialDataId == string.Empty && _initialCount > 1)
                {
                    int MovieIdInitialSide = sae.UpdateMovieOnTrack(0, DateTime.Now, "Users/MovieFiles/ModelStart-Initial-Side.mp4", _onTrackSessionlessonId);
                    int MovieIdInitialBack = sae.UpdateMovieOnTrack(1, DateTime.Now, "Users/MovieFiles/ModelStart-Initial-Back.mp4", _onTrackSessionlessonId);
                }
                if (sprint_FinalDataId == string.Empty && _finalCount > 1)
                {
                    int MovieIdCurrentSide = sae.UpdateMovieOnTrack(2, DateTime.Now, "Users/MovieFiles/ModelStart-Current-Side.mp4", _onTrackSessionlessonId);
                    int MovieIdCurrentBack = sae.UpdateMovieOnTrack(3, DateTime.Now, "Users/MovieFiles/ModelStart-Current-Back.mp4", _onTrackSessionlessonId);
                }
                sprint_InitialDataId = sae.SelectStartInitialDataid(_onTrackSessionlessonId.ToString());
                sprint_FinalDataId = sae.SelectStartCurrentDataid(_onTrackSessionlessonId.ToString());
                sprint_modelSummary = sae.SelectStartModelDataid(_onTrackSessionlessonId.ToString());
            }
            if (sprint_InitialDataId == string.Empty && _initialCount > 1)
            {
                _initialSummary.LessonId = lesson.LessonId;
                _initialSummary.InsertIntoStartInitialData();
            }
            else
            {
                _initialSummary.LessonId = _onTrackSessionlessonId;
                _initialSummary.UpdateStartInitialData();
            }
            if (sprint_FinalDataId == string.Empty && _finalCount > 1)
            {
                _finalSummary.LessonId = lesson.LessonId;
                _finalSummary.InsertIntoStartCurrentData();
            }
            else
            {
                _finalSummary.LessonId = _onTrackSessionlessonId;
                _finalSummary.UpdateStartCurrentData();

            }
            if (sprint_modelSummary == string.Empty && _modelCount > 1)
            {
                _modelSummary.LessonId = lesson.LessonId;
                _modelSummary.InsertIntoStartModelData();
                // _modelSummary.InsertIntoSprintOntrackModelData();
            }
            else
            {
                _modelSummary.LessonId = _onTrackSessionlessonId;
                _modelSummary.UpdateStartModelData();
                // _modelSummary.UpadteIntoSprintOntrackModelData();
            }

        }

        void InsertMovieClip(int MovieId)
        {
            sae.InsertMovieClip(MovieId, 1, 1);
            sae.InsertMovieClip(MovieId, 1, 35);
            sae.InsertMovieClip(MovieId, 35, 73);
            sae.InsertMovieClip(MovieId, 73, 84);
            sae.InsertMovieClip(MovieId, 84, 116);
            sae.InsertMovieClip(MovieId, 116, 131);
            sae.InsertMovieClip(MovieId, 131, 156);
            sae.InsertMovieClip(MovieId, 156, 178);
            sae.InsertMovieClip(MovieId, 178, 188);


        }

    }
    public class MissingVariableStart
    {
        public string type { get; set; }
        public string variableName { get; set; }
    }
}
