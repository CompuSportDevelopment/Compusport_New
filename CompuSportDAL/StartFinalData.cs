using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace CompuSportDAL
{
    class StartFinalData
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        public int LessonId { get; set; }
        public decimal SetFrontBlockDistance { get; set; }
        public decimal SetRearBlockDistance { get; set; }
        public int SetFrontULAngle { get; set; }
        public int SetRearULAngle { get; set; }
        public int SetFrontLLAngle { get; set; }
        public int SetRearLLAngle { get; set; }
        public int SetTrunkAngle { get; set; }
        public decimal SetCOGDistance { get; set; }
        public decimal BCRearFootClearanceTime { get; set; }
        public decimal BCFrontFootClearanceTime { get; set; }
        public int BCRearLLAngleTakeoff { get; set; }
        public int BCFrontLLAngleTakeoff { get; set; }
        public int BCTrunkAngleTakeoff { get; set; }
        public int BCLLAngleAC { get; set; }
        public decimal BCAirTime { get; set; }
        public decimal BCStrideLength { get; set; }
        public decimal Step1COGDistance { get; set; }
        public int Step1LLAngleTakeoff { get; set; }
        public int Step1TrunkAngleTakeoff { get; set; }
        public int Step1LLAngleAC { get; set; }
        public decimal Step1GroundTime { get; set; }
        public decimal Step1AirTime { get; set; }
        public decimal Step1StrideLength { get; set; }
        public decimal Step2COGDistance { get; set; }
        public int Step2LLAngleTakeoff { get; set; }
        public int Step2TrunkAngleTakeoff { get; set; }
        public int Step2LLAngleAC { get; set; }
        public decimal Step2GroundTime { get; set; }
        public decimal Step2AirTime { get; set; }
        public decimal Step2StrideLength { get; set; }
        public decimal Step3COGDistance { get; set; }
        public decimal TimeTo3m { get; set; }
        public decimal TimeTo5m { get; set; }
        public decimal BodyVolAt3Meters { get; set; }


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

                        cmdInsert.Parameters.AddWithValue("LessonId", LessonId);
                        cmdInsert.Parameters.AddWithValue("SetFrontBlockDistance", SetFrontBlockDistance);
                        cmdInsert.Parameters.AddWithValue("SetRearBlockDistance", SetRearBlockDistance);
                        cmdInsert.Parameters.AddWithValue("SetFrontULAngle", SetFrontULAngle);
                        cmdInsert.Parameters.AddWithValue("SetRearULAngle", SetRearULAngle);
                        cmdInsert.Parameters.AddWithValue("SetFrontLLAngle", SetFrontLLAngle);
                        cmdInsert.Parameters.AddWithValue("SetRearLLAngle", SetRearLLAngle);
                        cmdInsert.Parameters.AddWithValue("SetTrunkAngle", SetTrunkAngle);
                        cmdInsert.Parameters.AddWithValue("SetCOGDistance", SetCOGDistance);
                        cmdInsert.Parameters.AddWithValue("BCRearFootClearanceTime", BCRearFootClearanceTime);
                        cmdInsert.Parameters.AddWithValue("BCFrontFootClearanceTime", BCFrontFootClearanceTime);
                        cmdInsert.Parameters.AddWithValue("BCRearLLAngleTakeoff", BCRearLLAngleTakeoff);
                        cmdInsert.Parameters.AddWithValue("BCFrontLLAngleTakeoff", BCFrontLLAngleTakeoff);
                        cmdInsert.Parameters.AddWithValue("BCTrunkAngleTakeoff", BCTrunkAngleTakeoff);
                        cmdInsert.Parameters.AddWithValue("BCLLAngleAC", BCLLAngleAC);
                        cmdInsert.Parameters.AddWithValue("BCAirTime", BCAirTime);
                        cmdInsert.Parameters.AddWithValue("BCStrideLength", BCStrideLength);
                        cmdInsert.Parameters.AddWithValue("Step1COGDistance", Step1COGDistance);
                        cmdInsert.Parameters.AddWithValue("Step1LLAngleTakeoff", Step1LLAngleTakeoff);
                        cmdInsert.Parameters.AddWithValue("Step1TrunkAngleTakeoff", Step1TrunkAngleTakeoff);
                        cmdInsert.Parameters.AddWithValue("Step1LLAngleAC", Step1LLAngleAC);
                        cmdInsert.Parameters.AddWithValue("Step1GroundTime", Step1GroundTime);
                        cmdInsert.Parameters.AddWithValue("Step1AirTime", Step1AirTime);
                        cmdInsert.Parameters.AddWithValue("Step1StrideLength", Step1StrideLength);
                        cmdInsert.Parameters.AddWithValue("Step2COGDistance", Step2COGDistance);
                        cmdInsert.Parameters.AddWithValue("Step2LLAngleTakeoff", Step2LLAngleTakeoff);
                        cmdInsert.Parameters.AddWithValue("Step2TrunkAngleTakeoff", Step2TrunkAngleTakeoff);
                        cmdInsert.Parameters.AddWithValue("Step2LLAngleAC", Step2LLAngleAC);
                        cmdInsert.Parameters.AddWithValue("Step2GroundTime", Step2GroundTime);
                        cmdInsert.Parameters.AddWithValue("Step2AirTime", Step2AirTime);
                        cmdInsert.Parameters.AddWithValue("Step2StrideLength", Step2StrideLength);
                        cmdInsert.Parameters.AddWithValue("Step3COGDistance", Step3COGDistance);
                        cmdInsert.Parameters.AddWithValue("TimeTo3m", TimeTo3m);
                        cmdInsert.Parameters.AddWithValue("TimeTo5m", TimeTo5m);
                        cmdInsert.Parameters.AddWithValue("BodyVolAt3Meters", BodyVolAt3Meters);
                        cmdInsert.Connection = connection;
                        cmdInsert.ExecuteNonQuery();
                    }
                }
                return;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
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
                        Updatecmd.Parameters.AddWithValue("LessonId", LessonId);
                        Updatecmd.Parameters.AddWithValue("SetFrontBlockDistance", SetFrontBlockDistance);
                        Updatecmd.Parameters.AddWithValue("SetRearBlockDistance", SetRearBlockDistance);
                        Updatecmd.Parameters.AddWithValue("SetFrontULAngle", SetFrontULAngle);
                        Updatecmd.Parameters.AddWithValue("SetRearULAngle", SetRearULAngle);
                        Updatecmd.Parameters.AddWithValue("SetFrontLLAngle", SetFrontLLAngle);
                        Updatecmd.Parameters.AddWithValue("SetRearLLAngle", SetRearLLAngle);
                        Updatecmd.Parameters.AddWithValue("SetTrunkAngle", SetTrunkAngle);
                        Updatecmd.Parameters.AddWithValue("SetCOGDistance", SetCOGDistance);
                        Updatecmd.Parameters.AddWithValue("BCRearFootClearanceTime", BCRearFootClearanceTime);
                        Updatecmd.Parameters.AddWithValue("BCFrontFootClearanceTime", BCFrontFootClearanceTime);
                        Updatecmd.Parameters.AddWithValue("BCRearLLAngleTakeoff", BCRearLLAngleTakeoff);
                        Updatecmd.Parameters.AddWithValue("BCFrontLLAngleTakeoff", BCFrontLLAngleTakeoff);
                        Updatecmd.Parameters.AddWithValue("BCTrunkAngleTakeoff", BCTrunkAngleTakeoff);
                        Updatecmd.Parameters.AddWithValue("BCLLAngleAC", BCLLAngleAC);
                        Updatecmd.Parameters.AddWithValue("BCAirTime", BCAirTime);
                        Updatecmd.Parameters.AddWithValue("BCStrideLength", BCStrideLength);
                        Updatecmd.Parameters.AddWithValue("Step1COGDistance", Step1COGDistance);
                        Updatecmd.Parameters.AddWithValue("Step1LLAngleTakeoff", Step1LLAngleTakeoff);
                        Updatecmd.Parameters.AddWithValue("Step1TrunkAngleTakeoff", Step1TrunkAngleTakeoff);
                        Updatecmd.Parameters.AddWithValue("Step1LLAngleAC", Step1LLAngleAC);
                        Updatecmd.Parameters.AddWithValue("Step1GroundTime", Step1GroundTime);
                        Updatecmd.Parameters.AddWithValue("Step1AirTime", Step1AirTime);
                        Updatecmd.Parameters.AddWithValue("Step1StrideLength", Step1StrideLength);
                        Updatecmd.Parameters.AddWithValue("Step2COGDistance", Step2COGDistance);
                        Updatecmd.Parameters.AddWithValue("Step2LLAngleTakeoff", Step2LLAngleTakeoff);
                        Updatecmd.Parameters.AddWithValue("Step2TrunkAngleTakeoff", Step2TrunkAngleTakeoff);
                        Updatecmd.Parameters.AddWithValue("Step2LLAngleAC", Step2LLAngleAC);
                        Updatecmd.Parameters.AddWithValue("Step2GroundTime", Step2GroundTime);
                        Updatecmd.Parameters.AddWithValue("Step2AirTime", Step2AirTime);
                        Updatecmd.Parameters.AddWithValue("Step2StrideLength", Step2StrideLength);
                        Updatecmd.Parameters.AddWithValue("Step3COGDistance", Step3COGDistance);
                        Updatecmd.Parameters.AddWithValue("TimeTo3m", TimeTo3m);
                        Updatecmd.Parameters.AddWithValue("TimeTo5m", TimeTo5m);
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
    }
}
