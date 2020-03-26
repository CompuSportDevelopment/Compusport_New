using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.IO;
using System.Data.SqlClient;

namespace CompuSportDAL
{
    public class StartInitialData
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();

        #region[Property]
        public int LessonId { get; set; }
        public decimal SetFrontBlockDistanceI { get; set; }
        public decimal SetRearBlockDistanceI { get; set; }
        public int SetFrontULAngleI { get; set; }
        public int SetRearULAngleI { get; set; }
        public int SetFrontLLAngleI { get; set; }
        public int SetRearLLAngleI { get; set; }
        public int SetTrunkAngleI { get; set; }
        public decimal SetCOGDistanceI { get; set; }
        public decimal BCRearFootClearanceTimeI { get; set; }
        public decimal BCFrontFootClearanceTimeI { get; set; }
        public int BCRearLLAngleTakeoffI { get; set; }
        public int BCFrontLLAngleTakeoffI { get; set; }
        public int BCTrunkAngleTakeoffI { get; set; }
        public int BCLLAngleACI { get; set; }
        public decimal BCAirTimeI { get; set; }
        public decimal BCStrideLengthI { get; set; }
        public decimal Step1COGDistanceI { get; set; }
        public int Step1LLAngleTakeoffI { get; set; }
        public int Step1TrunkAngleTakeoffI { get; set; }
        public int Step1LLAngleACI { get; set; }
        public decimal Step1GroundTimeI { get; set; }
        public decimal Step1AirTimeI { get; set; }
        public decimal Step1StrideLengthI { get; set; }
        public decimal Step2COGDistanceI { get; set; }
        public int Step2LLAngleTakeoffI { get; set; }
        public int Step2TrunkAngleTakeoffI { get; set; }
        public int Step2LLAngleACI { get; set; }
        public decimal Step2GroundTimeI { get; set; }
        public decimal Step2AirTimeI { get; set; }
        public decimal Step2StrideLengthI { get; set; }
        public decimal Step3COGDistanceI { get; set; }
        public decimal TimeTo3mI { get; set; }
        public decimal TimeTo5mI { get; set; }
        public decimal BodyVolAt3Meters { get; set; }
        #endregion[Property]

        #region[StartIntial Data]
        public void InsertIntoStartInitialData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmdInsert = connection.CreateCommand())
                    {
                        cmdInsert.CommandType = CommandType.StoredProcedure;
                        cmdInsert.CommandText = "InsertIntoStartInitialData";

                        cmdInsert.Parameters.AddWithValue("@LessonId", LessonId);
                        cmdInsert.Parameters.AddWithValue("@SetFrontBlockDistanceI", SetFrontBlockDistanceI);
                        cmdInsert.Parameters.AddWithValue("@SetRearBlockDistance", SetRearBlockDistanceI);
                        cmdInsert.Parameters.AddWithValue("@SetFrontULAngle", SetFrontULAngleI);
                        cmdInsert.Parameters.AddWithValue("@SetRearULAngle", SetRearULAngleI);
                        cmdInsert.Parameters.AddWithValue("@SetFrontLLAngle", SetFrontLLAngleI);
                        cmdInsert.Parameters.AddWithValue("@SetRearLLAngle", SetRearLLAngleI);
                        cmdInsert.Parameters.AddWithValue("@SetTrunkAngle", SetTrunkAngleI);
                        cmdInsert.Parameters.AddWithValue("@SetCOGDistance", SetCOGDistanceI);
                        cmdInsert.Parameters.AddWithValue("@BCRearFootClearanceTime", BCRearFootClearanceTimeI);
                        cmdInsert.Parameters.AddWithValue("@BCFrontFootClearanceTime", BCFrontFootClearanceTimeI);
                        cmdInsert.Parameters.AddWithValue("@BCRearLLAngleTakeoff", BCRearLLAngleTakeoffI);
                        cmdInsert.Parameters.AddWithValue("@BCFrontLLAngleTakeoff", BCFrontLLAngleTakeoffI);
                        cmdInsert.Parameters.AddWithValue("@BCTrunkAngleTakeoff", BCTrunkAngleTakeoffI);
                        cmdInsert.Parameters.AddWithValue("@BCLLAngleAC", BCLLAngleACI);
                        cmdInsert.Parameters.AddWithValue("@BCAirTime", BCAirTimeI);
                        cmdInsert.Parameters.AddWithValue("@BCStrideLength", BCStrideLengthI);
                        cmdInsert.Parameters.AddWithValue("@Step1COGDistance", Step1COGDistanceI);
                        cmdInsert.Parameters.AddWithValue("@Step1LLAngleTakeoff", Step1LLAngleTakeoffI);
                        cmdInsert.Parameters.AddWithValue("@Step1TrunkAngleTakeoff", Step1TrunkAngleTakeoffI);
                        cmdInsert.Parameters.AddWithValue("@Step1LLAngleAC", Step1LLAngleACI);
                        cmdInsert.Parameters.AddWithValue("@Step1GroundTime", Step1GroundTimeI);
                        cmdInsert.Parameters.AddWithValue("@Step1AirTime", Step1AirTimeI);
                        cmdInsert.Parameters.AddWithValue("@Step1StrideLength", Step1StrideLengthI);
                        cmdInsert.Parameters.AddWithValue("@Step2COGDistance", Step2COGDistanceI);
                        cmdInsert.Parameters.AddWithValue("@Step2LLAngleTakeoff", Step2LLAngleTakeoffI);
                        cmdInsert.Parameters.AddWithValue("@Step2TrunkAngleTakeoff", Step2TrunkAngleTakeoffI);
                        cmdInsert.Parameters.AddWithValue("@Step2LLAngleAC", Step2LLAngleACI);
                        cmdInsert.Parameters.AddWithValue("@Step2GroundTime", Step2GroundTimeI);
                        cmdInsert.Parameters.AddWithValue("@Step2AirTime", Step2AirTimeI);
                        cmdInsert.Parameters.AddWithValue("@Step2StrideLength", Step2StrideLengthI);
                        cmdInsert.Parameters.AddWithValue("@Step3COGDistance", Step3COGDistanceI);
                        cmdInsert.Parameters.AddWithValue("@TimeTo3m", TimeTo3mI);
                        cmdInsert.Parameters.AddWithValue("@TimeTo5m", TimeTo5mI);
                        cmdInsert.Parameters.AddWithValue("BodyVolAt3Meters", BodyVolAt3Meters);
                        cmdInsert.Connection = connection;
                        cmdInsert.ExecuteNonQuery();
                    }
                }
                return;
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        public void UpdateStartInitialData()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand Updatecmd = con.CreateCommand())
                {
                    try
                    {
                        Updatecmd.CommandType = CommandType.StoredProcedure;
                        Updatecmd.CommandText = "UpdateStartInitialData";

                        Updatecmd.Parameters.AddWithValue("@LessonId", LessonId);
                        Updatecmd.Parameters.AddWithValue("@SetFrontBlockDistance", SetFrontBlockDistanceI);
                        Updatecmd.Parameters.AddWithValue("@SetRearBlockDistance", SetRearBlockDistanceI);
                        Updatecmd.Parameters.AddWithValue("@SetFrontULAngle", SetFrontULAngleI);
                        Updatecmd.Parameters.AddWithValue("@SetRearULAngle", SetRearULAngleI);
                        Updatecmd.Parameters.AddWithValue("@SetFrontLLAngle", SetFrontLLAngleI);
                        Updatecmd.Parameters.AddWithValue("@SetRearLLAngle", SetRearLLAngleI);
                        Updatecmd.Parameters.AddWithValue("@SetTrunkAngle", SetTrunkAngleI);
                        Updatecmd.Parameters.AddWithValue("@SetCOGDistance", SetCOGDistanceI);
                        Updatecmd.Parameters.AddWithValue("@BCRearFootClearanceTime", BCRearFootClearanceTimeI);
                        Updatecmd.Parameters.AddWithValue("@BCFrontFootClearanceTime", BCFrontFootClearanceTimeI);
                        Updatecmd.Parameters.AddWithValue("@BCRearLLAngleTakeoff", BCRearLLAngleTakeoffI);
                        Updatecmd.Parameters.AddWithValue("@BCFrontLLAngleTakeoff", BCFrontLLAngleTakeoffI);
                        Updatecmd.Parameters.AddWithValue("@BCTrunkAngleTakeoff", BCTrunkAngleTakeoffI);
                        Updatecmd.Parameters.AddWithValue("@BCLLAngleAC", BCLLAngleACI);
                        Updatecmd.Parameters.AddWithValue("@BCAirTime", BCAirTimeI);
                        Updatecmd.Parameters.AddWithValue("@BCStrideLength", BCStrideLengthI);
                        Updatecmd.Parameters.AddWithValue("@Step1COGDistance", Step1COGDistanceI);
                        Updatecmd.Parameters.AddWithValue("@Step1LLAngleTakeoff", Step1LLAngleTakeoffI);
                        Updatecmd.Parameters.AddWithValue("@Step1TrunkAngleTakeoff", Step1TrunkAngleTakeoffI);
                        Updatecmd.Parameters.AddWithValue("@Step1LLAngleAC", Step1LLAngleACI);
                        Updatecmd.Parameters.AddWithValue("@Step1GroundTime", Step1GroundTimeI);
                        Updatecmd.Parameters.AddWithValue("@Step1AirTime", Step1AirTimeI);
                        Updatecmd.Parameters.AddWithValue("@Step1StrideLength", Step1StrideLengthI);
                        Updatecmd.Parameters.AddWithValue("@Step2COGDistance", Step2COGDistanceI);
                        Updatecmd.Parameters.AddWithValue("@Step2LLAngleTakeoff", Step2LLAngleTakeoffI);
                        Updatecmd.Parameters.AddWithValue("@Step2TrunkAngleTakeoff", Step2TrunkAngleTakeoffI);
                        Updatecmd.Parameters.AddWithValue("@Step2LLAngleAC", Step2LLAngleACI);
                        Updatecmd.Parameters.AddWithValue("@Step2GroundTime", Step2GroundTimeI);
                        Updatecmd.Parameters.AddWithValue("@Step2AirTime", Step2AirTimeI);
                        Updatecmd.Parameters.AddWithValue("@Step2StrideLength", Step2StrideLengthI);
                        Updatecmd.Parameters.AddWithValue("@Step3COGDistance", Step3COGDistanceI);
                        Updatecmd.Parameters.AddWithValue("@TimeTo3m", TimeTo3mI);
                        Updatecmd.Parameters.AddWithValue("@TimeTo5m", TimeTo5mI);
                        Updatecmd.Parameters.AddWithValue("BodyVolAt3Meters", BodyVolAt3Meters);
                        Updatecmd.Connection = con;
                        Updatecmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        ex.Message.ToString();
                    }
                }
            }

        }
        public void DeleteStartInitialLessonData(int LessonId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmdDelete = connection.CreateCommand())
                    {
                        cmdDelete.CommandType = CommandType.StoredProcedure;
                        cmdDelete.CommandText = "DeleteFromStartInitialData";
                        cmdDelete.Parameters.AddWithValue("@LessonId", LessonId);
                        cmdDelete.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception err)
            {
                throw err;
            }

        }
        #endregion[StartIntial Data]

        #region[StartCurrent Data]
        public void InsertIntoStartCurrentData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmdInsert = connection.CreateCommand())
                    {
                        cmdInsert.CommandType = CommandType.StoredProcedure;
                        cmdInsert.CommandText = "InsertIntoStartCurrentData";

                        cmdInsert.Parameters.AddWithValue("@LessonId", LessonId);
                        cmdInsert.Parameters.AddWithValue("@SetFrontBlockDistanceI", SetFrontBlockDistanceI);
                        cmdInsert.Parameters.AddWithValue("@SetRearBlockDistance", SetRearBlockDistanceI);
                        cmdInsert.Parameters.AddWithValue("@SetFrontULAngle", SetFrontULAngleI);
                        cmdInsert.Parameters.AddWithValue("@SetRearULAngle", SetRearULAngleI);
                        cmdInsert.Parameters.AddWithValue("@SetFrontLLAngle", SetFrontLLAngleI);
                        cmdInsert.Parameters.AddWithValue("@SetRearLLAngle", SetRearLLAngleI);
                        cmdInsert.Parameters.AddWithValue("@SetTrunkAngle", SetTrunkAngleI);
                        cmdInsert.Parameters.AddWithValue("@SetCOGDistance", SetCOGDistanceI);
                        cmdInsert.Parameters.AddWithValue("@BCRearFootClearanceTime", BCRearFootClearanceTimeI);
                        cmdInsert.Parameters.AddWithValue("@BCFrontFootClearanceTime", BCFrontFootClearanceTimeI);
                        cmdInsert.Parameters.AddWithValue("@BCRearLLAngleTakeoff", BCRearLLAngleTakeoffI);
                        cmdInsert.Parameters.AddWithValue("@BCFrontLLAngleTakeoff", BCFrontLLAngleTakeoffI);
                        cmdInsert.Parameters.AddWithValue("@BCTrunkAngleTakeoff", BCTrunkAngleTakeoffI);
                        cmdInsert.Parameters.AddWithValue("@BCLLAngleAC", BCLLAngleACI);
                        cmdInsert.Parameters.AddWithValue("@BCAirTime", BCAirTimeI);
                        cmdInsert.Parameters.AddWithValue("@BCStrideLength", BCStrideLengthI);
                        cmdInsert.Parameters.AddWithValue("@Step1COGDistance", Step1COGDistanceI);
                        cmdInsert.Parameters.AddWithValue("@Step1LLAngleTakeoff", Step1LLAngleTakeoffI);
                        cmdInsert.Parameters.AddWithValue("@Step1TrunkAngleTakeoff", Step1TrunkAngleTakeoffI);
                        cmdInsert.Parameters.AddWithValue("@Step1LLAngleAC", Step1LLAngleACI);
                        cmdInsert.Parameters.AddWithValue("@Step1GroundTime", Step1GroundTimeI);
                        cmdInsert.Parameters.AddWithValue("@Step1AirTime", Step1AirTimeI);
                        cmdInsert.Parameters.AddWithValue("@Step1StrideLength", Step1StrideLengthI);
                        cmdInsert.Parameters.AddWithValue("@Step2COGDistance", Step2COGDistanceI);
                        cmdInsert.Parameters.AddWithValue("@Step2LLAngleTakeoff", Step2LLAngleTakeoffI);
                        cmdInsert.Parameters.AddWithValue("@Step2TrunkAngleTakeoff", Step2TrunkAngleTakeoffI);
                        cmdInsert.Parameters.AddWithValue("@Step2LLAngleAC", Step2LLAngleACI);
                        cmdInsert.Parameters.AddWithValue("@Step2GroundTime", Step2GroundTimeI);
                        cmdInsert.Parameters.AddWithValue("@Step2AirTime", Step2AirTimeI);
                        cmdInsert.Parameters.AddWithValue("@Step2StrideLength", Step2StrideLengthI);
                        cmdInsert.Parameters.AddWithValue("@Step3COGDistance", Step3COGDistanceI);
                        cmdInsert.Parameters.AddWithValue("@TimeTo3m", TimeTo3mI);
                        cmdInsert.Parameters.AddWithValue("@TimeTo5m", TimeTo5mI);
                        cmdInsert.Parameters.AddWithValue("BodyVolAt3Meters", BodyVolAt3Meters);
                        cmdInsert.Connection = connection;
                        cmdInsert.ExecuteNonQuery();
                    }
                }
                return;
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        public void UpdateStartCurrentData()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand Updatecmd = con.CreateCommand())
                {
                    try
                    {
                        Updatecmd.CommandType = CommandType.StoredProcedure;
                        Updatecmd.CommandText = "UpdateStartCurrentData";

                        Updatecmd.Parameters.AddWithValue("@LessonId", LessonId);
                        Updatecmd.Parameters.AddWithValue("@SetFrontBlockDistance", SetFrontBlockDistanceI);
                        Updatecmd.Parameters.AddWithValue("@SetRearBlockDistance", SetRearBlockDistanceI);
                        Updatecmd.Parameters.AddWithValue("@SetFrontULAngle", SetFrontULAngleI);
                        Updatecmd.Parameters.AddWithValue("@SetRearULAngle", SetRearULAngleI);
                        Updatecmd.Parameters.AddWithValue("@SetFrontLLAngle", SetFrontLLAngleI);
                        Updatecmd.Parameters.AddWithValue("@SetRearLLAngle", SetRearLLAngleI);
                        Updatecmd.Parameters.AddWithValue("@SetTrunkAngle", SetTrunkAngleI);
                        Updatecmd.Parameters.AddWithValue("@SetCOGDistance", SetCOGDistanceI);
                        Updatecmd.Parameters.AddWithValue("@BCRearFootClearanceTime", BCRearFootClearanceTimeI);
                        Updatecmd.Parameters.AddWithValue("@BCFrontFootClearanceTime", BCFrontFootClearanceTimeI);
                        Updatecmd.Parameters.AddWithValue("@BCRearLLAngleTakeoff", BCRearLLAngleTakeoffI);
                        Updatecmd.Parameters.AddWithValue("@BCFrontLLAngleTakeoff", BCFrontLLAngleTakeoffI);
                        Updatecmd.Parameters.AddWithValue("@BCTrunkAngleTakeoff", BCTrunkAngleTakeoffI);
                        Updatecmd.Parameters.AddWithValue("@BCLLAngleAC", BCLLAngleACI);
                        Updatecmd.Parameters.AddWithValue("@BCAirTime", BCAirTimeI);
                        Updatecmd.Parameters.AddWithValue("@BCStrideLength", BCStrideLengthI);
                        Updatecmd.Parameters.AddWithValue("@Step1COGDistance", Step1COGDistanceI);
                        Updatecmd.Parameters.AddWithValue("@Step1LLAngleTakeoff", Step1LLAngleTakeoffI);
                        Updatecmd.Parameters.AddWithValue("@Step1TrunkAngleTakeoff", Step1TrunkAngleTakeoffI);
                        Updatecmd.Parameters.AddWithValue("@Step1LLAngleAC", Step1LLAngleACI);
                        Updatecmd.Parameters.AddWithValue("@Step1GroundTime", Step1GroundTimeI);
                        Updatecmd.Parameters.AddWithValue("@Step1AirTime", Step1AirTimeI);
                        Updatecmd.Parameters.AddWithValue("@Step1StrideLength", Step1StrideLengthI);
                        Updatecmd.Parameters.AddWithValue("@Step2COGDistance", Step2COGDistanceI);
                        Updatecmd.Parameters.AddWithValue("@Step2LLAngleTakeoff", Step2LLAngleTakeoffI);
                        Updatecmd.Parameters.AddWithValue("@Step2TrunkAngleTakeoff", Step2TrunkAngleTakeoffI);
                        Updatecmd.Parameters.AddWithValue("@Step2LLAngleAC", Step2LLAngleACI);
                        Updatecmd.Parameters.AddWithValue("@Step2GroundTime", Step2GroundTimeI);
                        Updatecmd.Parameters.AddWithValue("@Step2AirTime", Step2AirTimeI);
                        Updatecmd.Parameters.AddWithValue("@Step2StrideLength", Step2StrideLengthI);
                        Updatecmd.Parameters.AddWithValue("@Step3COGDistance", Step3COGDistanceI);
                        Updatecmd.Parameters.AddWithValue("@TimeTo3m", TimeTo3mI);
                        Updatecmd.Parameters.AddWithValue("@TimeTo5m", TimeTo5mI);
                        Updatecmd.Parameters.AddWithValue("BodyVolAt3Meters", BodyVolAt3Meters);
                        Updatecmd.Connection = con;
                        Updatecmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        ex.Message.ToString();
                    }
                }
            }

        }
        public void DeleteStartCurrentLessonData(int LessonId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmdDelete = connection.CreateCommand())
                    {
                        cmdDelete.CommandType = CommandType.StoredProcedure;
                        cmdDelete.CommandText = "DeleteFromStartCurrentData";
                        cmdDelete.Parameters.AddWithValue("@LessonId", LessonId);
                        cmdDelete.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception err)
            {
                throw err;
            }

        }
        #endregion[StartCurrent Data]

        #region[StartModel Data]
        public void InsertIntoStartModelData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmdInsert = connection.CreateCommand())
                    {
                        cmdInsert.CommandType = CommandType.StoredProcedure;
                        cmdInsert.CommandText = "InsertIntoStartModelData";

                        cmdInsert.Parameters.AddWithValue("@LessonId", LessonId);
                        cmdInsert.Parameters.AddWithValue("@SetFrontBlockDistanceI", SetFrontBlockDistanceI);
                        cmdInsert.Parameters.AddWithValue("@SetRearBlockDistance", SetRearBlockDistanceI);
                        cmdInsert.Parameters.AddWithValue("@SetFrontULAngle", SetFrontULAngleI);
                        cmdInsert.Parameters.AddWithValue("@SetRearULAngle", SetRearULAngleI);
                        cmdInsert.Parameters.AddWithValue("@SetFrontLLAngle", SetFrontLLAngleI);
                        cmdInsert.Parameters.AddWithValue("@SetRearLLAngle", SetRearLLAngleI);
                        cmdInsert.Parameters.AddWithValue("@SetTrunkAngle", SetTrunkAngleI);
                        cmdInsert.Parameters.AddWithValue("@SetCOGDistance", SetCOGDistanceI);
                        cmdInsert.Parameters.AddWithValue("@BCRearFootClearanceTime", BCRearFootClearanceTimeI);
                        cmdInsert.Parameters.AddWithValue("@BCFrontFootClearanceTime", BCFrontFootClearanceTimeI);
                        cmdInsert.Parameters.AddWithValue("@BCRearLLAngleTakeoff", BCRearLLAngleTakeoffI);
                        cmdInsert.Parameters.AddWithValue("@BCFrontLLAngleTakeoff", BCFrontLLAngleTakeoffI);
                        cmdInsert.Parameters.AddWithValue("@BCTrunkAngleTakeoff", BCTrunkAngleTakeoffI);
                        cmdInsert.Parameters.AddWithValue("@BCLLAngleAC", BCLLAngleACI);
                        cmdInsert.Parameters.AddWithValue("@BCAirTime", BCAirTimeI);
                        cmdInsert.Parameters.AddWithValue("@BCStrideLength", BCStrideLengthI);
                        cmdInsert.Parameters.AddWithValue("@Step1COGDistance", Step1COGDistanceI);
                        cmdInsert.Parameters.AddWithValue("@Step1LLAngleTakeoff", Step1LLAngleTakeoffI);
                        cmdInsert.Parameters.AddWithValue("@Step1TrunkAngleTakeoff", Step1TrunkAngleTakeoffI);
                        cmdInsert.Parameters.AddWithValue("@Step1LLAngleAC", Step1LLAngleACI);
                        cmdInsert.Parameters.AddWithValue("@Step1GroundTime", Step1GroundTimeI);
                        cmdInsert.Parameters.AddWithValue("@Step1AirTime", Step1AirTimeI);
                        cmdInsert.Parameters.AddWithValue("@Step1StrideLength", Step1StrideLengthI);
                        cmdInsert.Parameters.AddWithValue("@Step2COGDistance", Step2COGDistanceI);
                        cmdInsert.Parameters.AddWithValue("@Step2LLAngleTakeoff", Step2LLAngleTakeoffI);
                        cmdInsert.Parameters.AddWithValue("@Step2TrunkAngleTakeoff", Step2TrunkAngleTakeoffI);
                        cmdInsert.Parameters.AddWithValue("@Step2LLAngleAC", Step2LLAngleACI);
                        cmdInsert.Parameters.AddWithValue("@Step2GroundTime", Step2GroundTimeI);
                        cmdInsert.Parameters.AddWithValue("@Step2AirTime", Step2AirTimeI);
                        cmdInsert.Parameters.AddWithValue("@Step2StrideLength", Step2StrideLengthI);
                        cmdInsert.Parameters.AddWithValue("@Step3COGDistance", Step3COGDistanceI);
                        cmdInsert.Parameters.AddWithValue("@TimeTo3m", TimeTo3mI);
                        cmdInsert.Parameters.AddWithValue("@TimeTo5m", TimeTo5mI);
                        cmdInsert.Parameters.AddWithValue("BodyVolAt3Meters", BodyVolAt3Meters);
                        cmdInsert.Connection = connection;
                        cmdInsert.ExecuteNonQuery();
                    }
                }
                return;
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        public void UpdateStartModelData()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand Updatecmd = con.CreateCommand())
                {
                    try
                    {
                        Updatecmd.CommandType = CommandType.StoredProcedure;
                        Updatecmd.CommandText = "UpdateStartModelData";

                        Updatecmd.Parameters.AddWithValue("@LessonId", LessonId);
                        Updatecmd.Parameters.AddWithValue("@SetFrontBlockDistance", SetFrontBlockDistanceI);
                        Updatecmd.Parameters.AddWithValue("@SetRearBlockDistance", SetRearBlockDistanceI);
                        Updatecmd.Parameters.AddWithValue("@SetFrontULAngle", SetFrontULAngleI);
                        Updatecmd.Parameters.AddWithValue("@SetRearULAngle", SetRearULAngleI);
                        Updatecmd.Parameters.AddWithValue("@SetFrontLLAngle", SetFrontLLAngleI);
                        Updatecmd.Parameters.AddWithValue("@SetRearLLAngle", SetRearLLAngleI);
                        Updatecmd.Parameters.AddWithValue("@SetTrunkAngle", SetTrunkAngleI);
                        Updatecmd.Parameters.AddWithValue("@SetCOGDistance", SetCOGDistanceI);
                        Updatecmd.Parameters.AddWithValue("@BCRearFootClearanceTime", BCRearFootClearanceTimeI);
                        Updatecmd.Parameters.AddWithValue("@BCFrontFootClearanceTime", BCFrontFootClearanceTimeI);
                        Updatecmd.Parameters.AddWithValue("@BCRearLLAngleTakeoff", BCRearLLAngleTakeoffI);
                        Updatecmd.Parameters.AddWithValue("@BCFrontLLAngleTakeoff", BCFrontLLAngleTakeoffI);
                        Updatecmd.Parameters.AddWithValue("@BCTrunkAngleTakeoff", BCTrunkAngleTakeoffI);
                        Updatecmd.Parameters.AddWithValue("@BCLLAngleAC", BCLLAngleACI);
                        Updatecmd.Parameters.AddWithValue("@BCAirTime", BCAirTimeI);
                        Updatecmd.Parameters.AddWithValue("@BCStrideLength", BCStrideLengthI);
                        Updatecmd.Parameters.AddWithValue("@Step1COGDistance", Step1COGDistanceI);
                        Updatecmd.Parameters.AddWithValue("@Step1LLAngleTakeoff", Step1LLAngleTakeoffI);
                        Updatecmd.Parameters.AddWithValue("@Step1TrunkAngleTakeoff", Step1TrunkAngleTakeoffI);
                        Updatecmd.Parameters.AddWithValue("@Step1LLAngleAC", Step1LLAngleACI);
                        Updatecmd.Parameters.AddWithValue("@Step1GroundTime", Step1GroundTimeI);
                        Updatecmd.Parameters.AddWithValue("@Step1AirTime", Step1AirTimeI);
                        Updatecmd.Parameters.AddWithValue("@Step1StrideLength", Step1StrideLengthI);
                        Updatecmd.Parameters.AddWithValue("@Step2COGDistance", Step2COGDistanceI);
                        Updatecmd.Parameters.AddWithValue("@Step2LLAngleTakeoff", Step2LLAngleTakeoffI);
                        Updatecmd.Parameters.AddWithValue("@Step2TrunkAngleTakeoff", Step2TrunkAngleTakeoffI);
                        Updatecmd.Parameters.AddWithValue("@Step2LLAngleAC", Step2LLAngleACI);
                        Updatecmd.Parameters.AddWithValue("@Step2GroundTime", Step2GroundTimeI);
                        Updatecmd.Parameters.AddWithValue("@Step2AirTime", Step2AirTimeI);
                        Updatecmd.Parameters.AddWithValue("@Step2StrideLength", Step2StrideLengthI);
                        Updatecmd.Parameters.AddWithValue("@Step3COGDistance", Step3COGDistanceI);
                        Updatecmd.Parameters.AddWithValue("@TimeTo3m", TimeTo3mI);
                        Updatecmd.Parameters.AddWithValue("@TimeTo5m", TimeTo5mI);
                        Updatecmd.Parameters.AddWithValue("BodyVolAt3Meters", BodyVolAt3Meters);
                        Updatecmd.Connection = con;
                        Updatecmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        ex.Message.ToString();
                    }
                }
            }

        }
        public void DeleteStartModelLessonData(int LessonId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmdDelete = connection.CreateCommand())
                    {
                        cmdDelete.CommandType = CommandType.StoredProcedure;
                        cmdDelete.CommandText = "DeleteFromStartModelData";
                        cmdDelete.Parameters.AddWithValue("@LessonId", LessonId);
                        cmdDelete.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception err)
            {
                throw err;
            }

        }
        #endregion[StartModel Data]

        decimal convertToDecimal(object data)
        {
            decimal value = 0;
            if (data != null && data.ToString() != string.Empty)
            {
                value = Convert.ToDecimal(data);
            }
            return value;
        }
        int convertToInt(object data)
        {
            int value = 0;
            if (data != null && data.ToString() != string.Empty)
            {
                value = Convert.ToInt32(data);
            }
            return value;
        }

        internal void SetdataStart(DataRow drData)
        {
            LessonId = convertToInt(drData[LessonId]);
            SetFrontBlockDistanceI = convertToDecimal(drData["SetFrontBlockDistance"]);
            SetRearBlockDistanceI = convertToDecimal(drData["SetRearBlockDistance"]);
            SetFrontULAngleI = convertToInt(drData["SetFrontULAngle"]);
            SetRearULAngleI = convertToInt(drData["SetRearULAngle"]);
            SetFrontLLAngleI = convertToInt(drData["SetFrontLLAngle"]);
            SetRearLLAngleI = convertToInt(drData["SetRearLLAngle"]);
            SetTrunkAngleI = convertToInt(drData["SetTrunkAngle"]);
            SetCOGDistanceI = convertToDecimal(drData["SetCOGDistance"]);
            BCRearFootClearanceTimeI = convertToDecimal(drData["BCRearFootClearanceTime"]);
            BCFrontFootClearanceTimeI = convertToDecimal(drData["BCFrontFootClearanceTime"]);
            BCRearLLAngleTakeoffI = convertToInt(drData["BCRearLLAngleTakeoff"]);
            BCFrontLLAngleTakeoffI = convertToInt(drData["BCFrontLLAngleTakeoff"]);
            BCTrunkAngleTakeoffI = convertToInt(drData["BCTrunkAngleTakeoff"]);
            BCLLAngleACI = convertToInt(drData["BCLLAngleAC"]);
            BCAirTimeI = convertToDecimal(drData["BCAirTime"]);
            BCStrideLengthI = convertToDecimal(drData["BCStrideLength"]);
            Step1COGDistanceI = convertToDecimal(drData["Step1COGDistance"]);
            Step1LLAngleTakeoffI = convertToInt(drData["Step1LLAngleTakeoff"]);
            Step1TrunkAngleTakeoffI = convertToInt(drData["Step1TrunkAngleTakeoff"]);
            Step1LLAngleACI = convertToInt(drData["Step1LLAngleAC"]);
            Step1GroundTimeI = convertToDecimal(drData["Step1GroundTime"]);
            Step1AirTimeI = convertToDecimal(drData["Step1AirTime"]);
            Step1StrideLengthI = convertToDecimal(drData["Step1StrideLength"]);
            Step2COGDistanceI = convertToDecimal(drData["Step2COGDistance"]);
            Step2LLAngleTakeoffI = convertToInt(drData["Step2LLAngleTakeoff"]);
            Step2TrunkAngleTakeoffI = convertToInt(drData["Step2TrunkAngleTakeoff"]);
            Step2LLAngleACI = convertToInt(drData["Step2LLAngleAC"]);
            Step2GroundTimeI = convertToDecimal(drData["Step2GroundTime"]);
            Step2AirTimeI = convertToDecimal(drData["Step2AirTime"]);
            Step2StrideLengthI = convertToDecimal(drData["Step2StrideLength"]);
            Step3COGDistanceI = convertToDecimal(drData["Step3COGDistance"]);
            TimeTo3mI = convertToDecimal(drData["TimeTo3m"]);
            TimeTo5mI = convertToDecimal(drData["TimeTo5m"]);
            BodyVolAt3Meters = convertToDecimal(drData["BodyVolAt3Meters"]);
 
        }
    }
}
