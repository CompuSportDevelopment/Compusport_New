using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace CompuSportDAL
{
    class HurdleStepsData
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        #region[Property For HurdleSteps]
        public int LessonId { get; set; }
        public decimal SetDistanceBetweenHurdleSteps { get; set; }
        public decimal SetDistanceIntoHurdleSteps { get; set; }
        public decimal SetDistanceOffHurdleSteps { get; set; }
        public decimal Velocity { get; set; }

        public decimal Step1GroundTime { get; set; }
        public decimal Step1AirTime { get; set; }
        //public decimal Step1UlFlexTime { get; set; }
        public decimal Step1StrideRate { get; set; }
        public decimal Step1StrideLength { get; set; }
        public decimal Step1TouchdownDistance { get; set; }
        public decimal Step1KneeSeperationatTouchdown { get; set; }
        public int Step1TrunkTouchdownAngle { get; set; }
        public int Step1TrunkTakeoffAngle { get; set; }

        public int Step1ULAtFullExtension { get; set; }
        public int Step1LLAtTakeoff { get; set; }
        public int Step1ULAtFullFlexion { get; set; }

        public decimal Step2GroundTime { get; set; }
        public decimal Step2AirTime { get; set; }
        //public decimal Step2UlFlexTime { get; set; }
        public decimal Step2StrideRate { get; set; }
        public decimal Step2StrideLength { get; set; }
        public decimal Step2TouchdownDistance { get; set; }
        public decimal Step2KneeSeperationatTouchdown { get; set; }
        public int Step2TrunkTouchdownAngle { get; set; }
        public int Step2TrunkTakeoffAngle { get; set; }

        public int Step2ULAtFullExtension { get; set; }
        public int Step2LLAtTakeoff { get; set; }
        public int Step2LLAtFullFlexion { get; set; }
        public int Step2LLAtatAnkleCross { get; set; }
        public int Step2ULAtFullFlexion { get; set; }


        public decimal Step3GroundTime { get; set; }
        public decimal Step3AirTime { get; set; }
        //public decimal Step3UlFlexTime { get; set; }
        public decimal Step3StrideRate { get; set; }
        public decimal Step3StrideLength { get; set; }
        public decimal Step3TouchdownDistance { get; set; }
        public decimal Step3KneeSeperationatTouchdown { get; set; }
        public int Step3TrunkTouchdownAngle { get; set; }
        public int Step3TrunkTakeoffAngle { get; set; }

        public int Step3ULAtFullExtension { get; set; }
        public int Step3LLAtTakeoff { get; set; }
        public int Step3LLAtFullFlexion { get; set; }
        public int Step3LLAtatAnkleCross { get; set; }
        public int Step3ULAtFullFlexion { get; set; }



        public decimal SetTouchdownDistanceIntoTheHurdle { get; set; }
        public decimal SetKneeSeperationatTouchdownIntoTheHurdle { get; set; }

        public int SetTrunkTouchdownAngleIntoTheHurdle { get; set; }

        public int SetLLAtTouchdownIntoTheHurdle { get; set; }

        #endregion



        #region[HurdleStepstInitial Data]
        public void InsertIntoHurdleStepsInitialData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmdInsert = connection.CreateCommand())
                    {
                        cmdInsert.CommandType = CommandType.StoredProcedure;
                        cmdInsert.CommandText = "InsertIntoHurdleStepsInitialData";
                        cmdInsert.Parameters.AddWithValue("@LessonId", LessonId);


                        cmdInsert.Parameters.AddWithValue("@SetDistanceBetweenHurdleSteps", SetDistanceBetweenHurdleSteps);
                        cmdInsert.Parameters.AddWithValue("@SetDistanceIntoHurdleSteps", SetDistanceIntoHurdleSteps);
                        cmdInsert.Parameters.AddWithValue("@SetDistanceOffHurdleSteps", SetDistanceOffHurdleSteps);
                        // cmdInsert.Parameters.AddWithValue("@Velocity", Velocity); // For multiple session 28/12/2016
                        //Step1
                        cmdInsert.Parameters.AddWithValue("@Step1GroundTime", Step1GroundTime);
                        cmdInsert.Parameters.AddWithValue("@Step1AirTime", Step1AirTime);
                        //cmdInsert.Parameters.AddWithValue("@Step1UlFlexTime", Step1UlFlexTime);
                        //cmdInsert.Parameters.AddWithValue("@Step1StrideRate", Step1StrideRate);
                        cmdInsert.Parameters.AddWithValue("@Step1StrideLength", Step1StrideLength);
                        cmdInsert.Parameters.AddWithValue("@Step1TouchdownDistance", Step1TouchdownDistance);
                        cmdInsert.Parameters.AddWithValue("@Step1KneeSeperationatTouchdown", Step1KneeSeperationatTouchdown);
                        cmdInsert.Parameters.AddWithValue("@Step1TrunkTouchdownAngle", Step1TrunkTouchdownAngle);
                        cmdInsert.Parameters.AddWithValue("@Step1TrunkTakeoffAngle", Step1TrunkTakeoffAngle);


                        cmdInsert.Parameters.AddWithValue("@Step1ULAtFullExtension", Step1ULAtFullExtension);
                        cmdInsert.Parameters.AddWithValue("@Step1LLAtTakeoff", Step1LLAtTakeoff);
                        cmdInsert.Parameters.AddWithValue("@Step1ULAtFullFlexion", Step1ULAtFullFlexion);
                        //Step2
                        cmdInsert.Parameters.AddWithValue("@Step2GroundTime", Step2GroundTime);
                        cmdInsert.Parameters.AddWithValue("@Step2AirTime", Step2AirTime);
                        // cmdInsert.Parameters.AddWithValue("@Step2UlFlexTime", Step2UlFlexTime);
                        //cmdInsert.Parameters.AddWithValue("@Step2StrideRate ", Step2StrideRate);
                        cmdInsert.Parameters.AddWithValue("@Step2StrideLength", Step2StrideLength);
                        cmdInsert.Parameters.AddWithValue("@Step2TouchdownDistance", Step2TouchdownDistance);
                        cmdInsert.Parameters.AddWithValue("@Step2KneeSeperationatTouchdown", Step2KneeSeperationatTouchdown);
                        cmdInsert.Parameters.AddWithValue("@Step2TrunkTouchdownAngle", Step2TrunkTouchdownAngle);
                        cmdInsert.Parameters.AddWithValue("@Step2TrunkTakeoffAngle", Step2TrunkTakeoffAngle);

                        cmdInsert.Parameters.AddWithValue("@Step2ULAtFullExtension", Step2ULAtFullExtension);
                        cmdInsert.Parameters.AddWithValue("@Step2LLAtTakeoff", Step2LLAtTakeoff);
                        cmdInsert.Parameters.AddWithValue("@Step2LLAtFullFlexion", Step2LLAtFullFlexion);
                        //cmdInsert.Parameters.AddWithValue("@Step2LLAtatAnkleCross", Step2LLAtatAnkleCross);
                        cmdInsert.Parameters.AddWithValue("@Step2ULAtFullFlexion", Step2ULAtFullFlexion);


                        //Step3
                        cmdInsert.Parameters.AddWithValue("@Step3GroundTime", Step3GroundTime);
                        cmdInsert.Parameters.AddWithValue("@Step3AirTime", Step3AirTime);
                        // cmdInsert.Parameters.AddWithValue("@Step3UlFlexTime", Step3UlFlexTime);
                        //cmdInsert.Parameters.AddWithValue("@Step3StrideRate ", Step3StrideRate);
                        cmdInsert.Parameters.AddWithValue("@Step3StrideLength", Step3StrideLength);
                        cmdInsert.Parameters.AddWithValue("@Step3TouchdownDistance", Step3TouchdownDistance);
                        cmdInsert.Parameters.AddWithValue("@Step3KneeSeperationatTouchdown", Step3KneeSeperationatTouchdown);
                        cmdInsert.Parameters.AddWithValue("@Step3TrunkTouchdownAngle", Step3TrunkTouchdownAngle);
                        cmdInsert.Parameters.AddWithValue("@Step3TrunkTakeoffAngle", Step3TrunkTakeoffAngle);

                        cmdInsert.Parameters.AddWithValue("@Step3ULAtFullExtension", Step3ULAtFullExtension);
                        cmdInsert.Parameters.AddWithValue("@Step3LLAtTakeoff", Step3LLAtTakeoff);
                        cmdInsert.Parameters.AddWithValue("@Step3LLAtFullFlexion", Step3LLAtFullFlexion);
                        // cmdInsert.Parameters.AddWithValue("@Step3LLAtatAnkleCross", Step3LLAtatAnkleCross);
                        cmdInsert.Parameters.AddWithValue("@Step3ULAtFullFlexion", Step3ULAtFullFlexion);

                        //intoHurdleSteps
                        cmdInsert.Parameters.AddWithValue("@SetTouchdownDistanceIntoTheHurdle", SetTouchdownDistanceIntoTheHurdle);
                        cmdInsert.Parameters.AddWithValue("@SetKneeSeperationatTouchdownIntoTheHurdle", SetKneeSeperationatTouchdownIntoTheHurdle);
                        cmdInsert.Parameters.AddWithValue("@SetTrunkTouchdownAngleIntoTheHurdle", SetTrunkTouchdownAngleIntoTheHurdle);  //For new variable
                        cmdInsert.Parameters.AddWithValue("@SetLLAtTouchdownIntoTheHurdle", SetLLAtTouchdownIntoTheHurdle);


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
        public void UpdateHurdleStepsInitialData()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand Updatecmd = con.CreateCommand())
                {
                    try
                    {
                        Updatecmd.CommandType = CommandType.StoredProcedure;
                        Updatecmd.CommandText = "UpdateHurdleStepsInitialData";
                        Updatecmd.Parameters.AddWithValue("@LessonId", LessonId);

                        Updatecmd.Parameters.AddWithValue("@SetDistanceBetweenHurdleSteps", SetDistanceBetweenHurdleSteps);
                        Updatecmd.Parameters.AddWithValue("@SetDistanceIntoHurdleSteps", SetDistanceIntoHurdleSteps);
                        Updatecmd.Parameters.AddWithValue("@SetDistanceOffHurdleSteps", SetDistanceOffHurdleSteps);
                       // Updatecmd.Parameters.AddWithValue("@Velocity", Velocity);
                        //Step1
                        Updatecmd.Parameters.AddWithValue("@Step1GroundTime", Step1GroundTime);
                        Updatecmd.Parameters.AddWithValue("@Step1AirTime", Step1AirTime);
                        //Updatecmd.Parameters.AddWithValue("@Step1UlFlexTime", Step1UlFlexTime);
                        //Updatecmd.Parameters.AddWithValue("@Step1StrideRate", Step1StrideRate);
                        Updatecmd.Parameters.AddWithValue("@Step1StrideLength", Step1StrideLength);
                        Updatecmd.Parameters.AddWithValue("@Step1TouchdownDistance", Step1TouchdownDistance);
                        Updatecmd.Parameters.AddWithValue("@Step1KneeSeperationatTouchdown", Step1KneeSeperationatTouchdown);
                        Updatecmd.Parameters.AddWithValue("@Step1TrunkTouchdownAngle ", Step1TrunkTouchdownAngle);
                        Updatecmd.Parameters.AddWithValue("@Step1TrunkTakeoffAngle", Step1TrunkTakeoffAngle);


                        Updatecmd.Parameters.AddWithValue("@Step1ULAtFullExtension", Step1ULAtFullExtension);
                        Updatecmd.Parameters.AddWithValue("@Step1LLAtTakeoff", Step1LLAtTakeoff);
                        Updatecmd.Parameters.AddWithValue("@Step1ULAtFullFlexion", Step1ULAtFullFlexion);
                        //Step2
                        Updatecmd.Parameters.AddWithValue("@Step2GroundTime", Step2GroundTime);
                        Updatecmd.Parameters.AddWithValue("@Step2AirTime", Step2AirTime);
                        // Updatecmd.Parameters.AddWithValue("@Step2UlFlexTime", Step2UlFlexTime);
                        // Updatecmd.Parameters.AddWithValue("@Step2StrideRate ", Step2StrideRate);
                        Updatecmd.Parameters.AddWithValue("@Step2StrideLength", Step2StrideLength);
                        Updatecmd.Parameters.AddWithValue("@Step2TouchdownDistance", Step2TouchdownDistance);
                        Updatecmd.Parameters.AddWithValue("@Step2KneeSeperationatTouchdown", Step2KneeSeperationatTouchdown);
                        Updatecmd.Parameters.AddWithValue("@Step2TrunkTouchdownAngle", Step2TrunkTouchdownAngle);
                        Updatecmd.Parameters.AddWithValue("@Step2TrunkTakeoffAngle", Step2TrunkTakeoffAngle);


                        Updatecmd.Parameters.AddWithValue("@Step2ULAtFullExtension", Step2ULAtFullExtension);
                        Updatecmd.Parameters.AddWithValue("@Step2LLAtTakeoff", Step2LLAtTakeoff);
                        Updatecmd.Parameters.AddWithValue("@Step2LLAtFullFlexion", Step2LLAtFullFlexion);
                        // Updatecmd.Parameters.AddWithValue("@Step2LLAtatAnkleCross", Step2LLAtatAnkleCross);
                        Updatecmd.Parameters.AddWithValue("@Step2ULAtFullFlexion", Step2ULAtFullFlexion);


                        //Step3
                        Updatecmd.Parameters.AddWithValue("@Step3GroundTime", Step3GroundTime);
                        Updatecmd.Parameters.AddWithValue("@Step3AirTime", Step3AirTime);
                        //Updatecmd.Parameters.AddWithValue("@Step3UlFlexTime", Step3UlFlexTime);
                        //Updatecmd.Parameters.AddWithValue("@Step3StrideRate ", Step3StrideRate);
                        Updatecmd.Parameters.AddWithValue("@Step3StrideLength", Step3StrideLength);
                        Updatecmd.Parameters.AddWithValue("@Step3TouchdownDistance", Step3TouchdownDistance);
                        Updatecmd.Parameters.AddWithValue("@Step3KneeSeperationatTouchdown", Step3KneeSeperationatTouchdown);
                        Updatecmd.Parameters.AddWithValue("@Step3TrunkTouchdownAngle", Step3TrunkTouchdownAngle);
                        Updatecmd.Parameters.AddWithValue("@Step3TrunkTakeoffAngle", Step3TrunkTakeoffAngle);

                        Updatecmd.Parameters.AddWithValue("@Step3ULAtFullExtension", Step3ULAtFullExtension);
                        Updatecmd.Parameters.AddWithValue("@Step3LLAtTakeoff", Step3LLAtTakeoff);
                        Updatecmd.Parameters.AddWithValue("@Step3LLAtFullFlexion ", Step3LLAtFullFlexion);
                        // Updatecmd.Parameters.AddWithValue("@Step3LLAtatAnkleCross", Step3LLAtatAnkleCross);
                        Updatecmd.Parameters.AddWithValue("@Step3ULAtFullFlexion", Step3ULAtFullFlexion);

                        //intoHurdleSteps
                        Updatecmd.Parameters.AddWithValue("@SetTouchdownDistanceIntoTheHurdle", SetTouchdownDistanceIntoTheHurdle);
                        Updatecmd.Parameters.AddWithValue("@SetKneeSeperationatTouchdownIntoTheHurdle", SetKneeSeperationatTouchdownIntoTheHurdle);
                        Updatecmd.Parameters.AddWithValue("@SetTrunkTouchdownAngleIntoTheHurdle", SetTrunkTouchdownAngleIntoTheHurdle); // For new variable
                        Updatecmd.Parameters.AddWithValue("@SetLLAtTouchdownIntoTheHurdle", SetLLAtTouchdownIntoTheHurdle);

                        Boolean flag;
                        Updatecmd.Connection = con;
                        if (Updatecmd.ExecuteNonQuery() == 1)
                            flag = true;
                        else
                            flag = false;

                    }
                    catch (Exception ex)
                    {
                        ex.Message.ToString();
                    }
                }
            }

        }
        public void DeleteHurdleStepsInitialLessonData(int LessonId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmdDelete = connection.CreateCommand())
                    {
                        cmdDelete.CommandType = CommandType.StoredProcedure;
                        cmdDelete.CommandText = "DeleteFromHurdleStepsInitialData";
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
        #endregion[HurdleStepsInitial Data]

        #region[HurdleStepsCurrent Data]
        public void InsertIntoHurdleStepsCurrentData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmdInsert = connection.CreateCommand())
                    {
                        cmdInsert.CommandType = CommandType.StoredProcedure;
                        cmdInsert.CommandText = "InsertIntoHurdleStepsCurrentData";
                        cmdInsert.Parameters.AddWithValue("@LessonId", LessonId);

                        cmdInsert.Parameters.AddWithValue("@SetDistanceBetweenHurdleSteps", SetDistanceBetweenHurdleSteps);
                        cmdInsert.Parameters.AddWithValue("@SetDistanceIntoHurdleSteps", SetDistanceIntoHurdleSteps);
                        cmdInsert.Parameters.AddWithValue("@SetDistanceOffHurdleSteps", SetDistanceOffHurdleSteps);
                        //cmdInsert.Parameters.AddWithValue("@Velocity", Velocity);
                        //Step1
                        cmdInsert.Parameters.AddWithValue("@Step1GroundTime", Step1GroundTime);
                        cmdInsert.Parameters.AddWithValue("@Step1AirTime", Step1AirTime);
                        //cmdInsert.Parameters.AddWithValue("@Step1UlFlexTime", Step1UlFlexTime);
                        //cmdInsert.Parameters.AddWithValue("@Step1StrideRate", Step1StrideRate);
                        cmdInsert.Parameters.AddWithValue("@Step1StrideLength", Step1StrideLength);
                        cmdInsert.Parameters.AddWithValue("@Step1TouchdownDistance", Step1TouchdownDistance);
                        cmdInsert.Parameters.AddWithValue("@Step1KneeSeperationatTouchdown", Step1KneeSeperationatTouchdown);
                        cmdInsert.Parameters.AddWithValue("@Step1TrunkTouchdownAngle", Step1TrunkTouchdownAngle);
                        cmdInsert.Parameters.AddWithValue("@Step1TrunkTakeoffAngle", Step1TrunkTakeoffAngle);


                        cmdInsert.Parameters.AddWithValue("@Step1ULAtFullExtension", Step1ULAtFullExtension);
                        cmdInsert.Parameters.AddWithValue("@Step1LLAtTakeoff", Step1LLAtTakeoff);
                        cmdInsert.Parameters.AddWithValue("@Step1ULAtFullFlexion", Step1ULAtFullFlexion);
                        //Step2
                        cmdInsert.Parameters.AddWithValue("@Step2GroundTime", Step2GroundTime);
                        cmdInsert.Parameters.AddWithValue("@Step2AirTime", Step2AirTime);
                        //cmdInsert.Parameters.AddWithValue("@Step2UlFlexTime", Step2UlFlexTime);
                        //cmdInsert.Parameters.AddWithValue("@Step2StrideRate ", Step2StrideRate);
                        cmdInsert.Parameters.AddWithValue("@Step2StrideLength", Step2StrideLength);
                        cmdInsert.Parameters.AddWithValue("@Step2TouchdownDistance", Step2TouchdownDistance);
                        cmdInsert.Parameters.AddWithValue("@Step2KneeSeperationatTouchdown", Step2KneeSeperationatTouchdown);
                        cmdInsert.Parameters.AddWithValue("@Step2TrunkTouchdownAngle", Step2TrunkTouchdownAngle);
                        cmdInsert.Parameters.AddWithValue("@Step2TrunkTakeoffAngle", Step2TrunkTakeoffAngle);

                        cmdInsert.Parameters.AddWithValue("@Step2ULAtFullExtension", Step2ULAtFullExtension);
                        cmdInsert.Parameters.AddWithValue("@Step2LLAtTakeoff", Step2LLAtTakeoff);
                        cmdInsert.Parameters.AddWithValue("@Step2LLAtFullFlexion", Step2LLAtFullFlexion);
                        //   cmdInsert.Parameters.AddWithValue("@Step2LLAtatAnkleCross", Step2LLAtatAnkleCross);
                        cmdInsert.Parameters.AddWithValue("@Step2ULAtFullFlexion", Step2ULAtFullFlexion);


                        //Step3
                        cmdInsert.Parameters.AddWithValue("@Step3GroundTime", Step3GroundTime);
                        cmdInsert.Parameters.AddWithValue("@Step3AirTime", Step3AirTime);
                        //cmdInsert.Parameters.AddWithValue("@Step3UlFlexTime", Step3UlFlexTime);
                        //cmdInsert.Parameters.AddWithValue("@Step3StrideRate ", Step3StrideRate);
                        cmdInsert.Parameters.AddWithValue("@Step3StrideLength", Step3StrideLength);
                        cmdInsert.Parameters.AddWithValue("@Step3TouchdownDistance", Step3TouchdownDistance);
                        cmdInsert.Parameters.AddWithValue("@Step3KneeSeperationatTouchdown", Step3KneeSeperationatTouchdown);
                        cmdInsert.Parameters.AddWithValue("@Step3TrunkTouchdownAngle", Step3TrunkTouchdownAngle);
                        cmdInsert.Parameters.AddWithValue("@Step3TrunkTakeoffAngle", Step3TrunkTakeoffAngle);

                        cmdInsert.Parameters.AddWithValue("@Step3ULAtFullExtension", Step3ULAtFullExtension);
                        cmdInsert.Parameters.AddWithValue("@Step3LLAtTakeoff", Step3LLAtTakeoff);
                        cmdInsert.Parameters.AddWithValue("@Step3LLAtFullFlexion", Step3LLAtFullFlexion);
                        //cmdInsert.Parameters.AddWithValue("@Step3LLAtatAnkleCross", Step3LLAtatAnkleCross);
                        cmdInsert.Parameters.AddWithValue("@Step3ULAtFullFlexion", Step3ULAtFullFlexion);

                        //intoHurdleSteps
                        cmdInsert.Parameters.AddWithValue("@SetTouchdownDistanceIntoTheHurdle", SetTouchdownDistanceIntoTheHurdle);
                        cmdInsert.Parameters.AddWithValue("@SetKneeSeperationatTouchdownIntoTheHurdle", SetKneeSeperationatTouchdownIntoTheHurdle);
                        cmdInsert.Parameters.AddWithValue("@SetTrunkTouchdownAngleIntoTheHurdle", SetTrunkTouchdownAngleIntoTheHurdle); // For new variable
                        cmdInsert.Parameters.AddWithValue("@SetLLAtTouchdownIntoTheHurdle", SetLLAtTouchdownIntoTheHurdle);



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
        public void UpdateHurdleStepsCurrentData()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand Updatecmd = con.CreateCommand())
                {
                    try
                    {
                        Updatecmd.CommandType = CommandType.StoredProcedure;
                        Updatecmd.CommandText = "UpdateHurdleStepsCurrentData";
                        Updatecmd.Parameters.AddWithValue("@LessonId", LessonId);

                        Updatecmd.Parameters.AddWithValue("@SetDistanceBetweenHurdleSteps", SetDistanceBetweenHurdleSteps);
                        Updatecmd.Parameters.AddWithValue("@SetDistanceIntoHurdleSteps", SetDistanceIntoHurdleSteps);
                        Updatecmd.Parameters.AddWithValue("@SetDistanceOffHurdleSteps", SetDistanceOffHurdleSteps);
                        //Updatecmd.Parameters.AddWithValue("@Velocity", Velocity);
                        //Step1
                        Updatecmd.Parameters.AddWithValue("@Step1GroundTime", Step1GroundTime);
                        Updatecmd.Parameters.AddWithValue("@Step1AirTime", Step1AirTime);
                        //Updatecmd.Parameters.AddWithValue("@Step1UlFlexTime", Step1UlFlexTime);
                        //Updatecmd.Parameters.AddWithValue("@Step1StrideRate", Step1StrideRate);
                        Updatecmd.Parameters.AddWithValue("@Step1StrideLength", Step1StrideLength);
                        Updatecmd.Parameters.AddWithValue("@Step1TouchdownDistance", Step1TouchdownDistance);
                        Updatecmd.Parameters.AddWithValue("@Step1KneeSeperationatTouchdown", Step1KneeSeperationatTouchdown);
                        Updatecmd.Parameters.AddWithValue("@Step1TrunkTouchdownAngle", Step1TrunkTouchdownAngle);
                        Updatecmd.Parameters.AddWithValue("@Step1TrunkTakeoffAngle", Step1TrunkTakeoffAngle);

                        Updatecmd.Parameters.AddWithValue("@Step1ULAtFullExtension", Step1ULAtFullExtension);
                        Updatecmd.Parameters.AddWithValue("@Step1LLAtTakeoff", Step1LLAtTakeoff);
                        Updatecmd.Parameters.AddWithValue("@Step1ULAtFullFlexion", Step1ULAtFullFlexion);
                        //Step2
                        Updatecmd.Parameters.AddWithValue("@Step2GroundTime", Step2GroundTime);
                        Updatecmd.Parameters.AddWithValue("@Step2AirTime", Step2AirTime);
                        //Updatecmd.Parameters.AddWithValue("@Step2UlFlexTime", Step2UlFlexTime);
                        //Updatecmd.Parameters.AddWithValue("@Step2StrideRate ", Step2StrideRate);
                        Updatecmd.Parameters.AddWithValue("@Step2StrideLength", Step2StrideLength);
                        Updatecmd.Parameters.AddWithValue("@Step2TouchdownDistance", Step2TouchdownDistance);
                        Updatecmd.Parameters.AddWithValue("@Step2KneeSeperationatTouchdown", Step2KneeSeperationatTouchdown);
                        Updatecmd.Parameters.AddWithValue("@Step2TrunkTouchdownAngle", Step2TrunkTouchdownAngle);
                        Updatecmd.Parameters.AddWithValue("@Step2TrunkTakeoffAngle", Step2TrunkTakeoffAngle);

                        Updatecmd.Parameters.AddWithValue("@Step2ULAtFullExtension", Step2ULAtFullExtension);
                        Updatecmd.Parameters.AddWithValue("@Step2LLAtTakeoff", Step2LLAtTakeoff);
                        Updatecmd.Parameters.AddWithValue("@Step2LLAtFullFlexion", Step2LLAtFullFlexion);
                        //   Updatecmd.Parameters.AddWithValue("@Step2LLAtatAnkleCross", Step2LLAtatAnkleCross);
                        Updatecmd.Parameters.AddWithValue("@Step2ULAtFullFlexion", Step2ULAtFullFlexion);


                        //Step3
                        Updatecmd.Parameters.AddWithValue("@Step3GroundTime", Step3GroundTime);
                        Updatecmd.Parameters.AddWithValue("@Step3AirTime", Step3AirTime);
                        // Updatecmd.Parameters.AddWithValue("@Step3UlFlexTime", Step3UlFlexTime);
                        //Updatecmd.Parameters.AddWithValue("@Step3StrideRate ", Step3StrideRate);
                        Updatecmd.Parameters.AddWithValue("@Step3StrideLength", Step3StrideLength);
                        Updatecmd.Parameters.AddWithValue("@Step3TouchdownDistance", Step3TouchdownDistance);
                        Updatecmd.Parameters.AddWithValue("@Step3KneeSeperationatTouchdown", Step3KneeSeperationatTouchdown);
                        Updatecmd.Parameters.AddWithValue("@Step3TrunkTouchdownAngle", Step3TrunkTouchdownAngle);
                        Updatecmd.Parameters.AddWithValue("@Step3TrunkTakeoffAngle", Step3TrunkTakeoffAngle);

                        Updatecmd.Parameters.AddWithValue("@Step3ULAtFullExtension", Step3ULAtFullExtension);
                        Updatecmd.Parameters.AddWithValue("@Step3LLAtTakeoff", Step3LLAtTakeoff);
                        Updatecmd.Parameters.AddWithValue("@Step3LLAtFullFlexion", Step3LLAtFullFlexion);
                        // Updatecmd.Parameters.AddWithValue("@Step3LLAtatAnkleCross", Step3LLAtatAnkleCross);
                        Updatecmd.Parameters.AddWithValue("@Step3ULAtFullFlexion", Step3ULAtFullFlexion);

                        //intoHurdleSteps
                        Updatecmd.Parameters.AddWithValue("@SetTouchdownDistanceIntoTheHurdle", SetTouchdownDistanceIntoTheHurdle);
                        Updatecmd.Parameters.AddWithValue("@SetKneeSeperationatTouchdownIntoTheHurdle", SetKneeSeperationatTouchdownIntoTheHurdle);
                        Updatecmd.Parameters.AddWithValue("@SetTrunkTouchdownAngleIntoTheHurdle", SetTrunkTouchdownAngleIntoTheHurdle); // For new variable
                        Updatecmd.Parameters.AddWithValue("@SetLLAtTouchdownIntoTheHurdle", SetLLAtTouchdownIntoTheHurdle);


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
        public void DeleteHurdleStepsCurrentLessonData(int LessonId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmdDelete = connection.CreateCommand())
                    {
                        cmdDelete.CommandType = CommandType.StoredProcedure;
                        cmdDelete.CommandText = "DeleteFromHurdleStepsCurrentData";
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
        #endregion[Hurdle StepsIntial Data]

        #region[HurdleSteps Model Data]
        public void InsertIntoHurdleStepsModelData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmdInsert = connection.CreateCommand())
                    {
                        cmdInsert.CommandType = CommandType.StoredProcedure;
                        cmdInsert.CommandText = "InsertIntoHurdleStepsModelData";
                        cmdInsert.Parameters.AddWithValue("@LessonId", LessonId);


                        cmdInsert.Parameters.AddWithValue("@SetDistanceBetweenHurdleSteps", SetDistanceBetweenHurdleSteps);
                        cmdInsert.Parameters.AddWithValue("@SetDistanceIntoHurdleSteps", SetDistanceIntoHurdleSteps);
                        cmdInsert.Parameters.AddWithValue("@SetDistanceOffHurdleSteps", SetDistanceOffHurdleSteps);
                        //cmdInsert.Parameters.AddWithValue("@Velocity", Velocity);
                        //Step1
                        cmdInsert.Parameters.AddWithValue("@Step1GroundTime", Step1GroundTime);
                        cmdInsert.Parameters.AddWithValue("@Step1AirTime", Step1AirTime);
                        //cmdInsert.Parameters.AddWithValue("@Step1UlFlexTime", Step1UlFlexTime);
                        //cmdInsert.Parameters.AddWithValue("@Step1StrideRate", Step1StrideRate);
                        cmdInsert.Parameters.AddWithValue("@Step1StrideLength", Step1StrideLength);
                        cmdInsert.Parameters.AddWithValue("@Step1TouchdownDistance", Step1TouchdownDistance);
                        cmdInsert.Parameters.AddWithValue("@Step1KneeSeperationatTouchdown", Step1KneeSeperationatTouchdown);
                        cmdInsert.Parameters.AddWithValue("@Step1TrunkTouchdownAngle", Step1TrunkTouchdownAngle);
                        cmdInsert.Parameters.AddWithValue("@Step1TrunkTakeoffAngle", Step1TrunkTakeoffAngle);

                        cmdInsert.Parameters.AddWithValue("@Step1ULAtFullExtension", Step1ULAtFullExtension);
                        cmdInsert.Parameters.AddWithValue("@Step1LLAtTakeoff", Step1LLAtTakeoff);
                        cmdInsert.Parameters.AddWithValue("@Step1ULAtFullFlexion", Step1ULAtFullFlexion);
                        //Step2
                        cmdInsert.Parameters.AddWithValue("@Step2GroundTime", Step2GroundTime);
                        cmdInsert.Parameters.AddWithValue("@Step2AirTime", Step2AirTime);
                        //cmdInsert.Parameters.AddWithValue("@Step2UlFlexTime", Step2UlFlexTime);
                        //cmdInsert.Parameters.AddWithValue("@Step2StrideRate ", Step2StrideRate);
                        cmdInsert.Parameters.AddWithValue("@Step2StrideLength", Step2StrideLength);
                        cmdInsert.Parameters.AddWithValue("@Step2TouchdownDistance", Step2TouchdownDistance);
                        cmdInsert.Parameters.AddWithValue("@Step2KneeSeperationatTouchdown", Step2KneeSeperationatTouchdown);
                        cmdInsert.Parameters.AddWithValue("@Step2TrunkTouchdownAngle", Step2TrunkTouchdownAngle);
                        cmdInsert.Parameters.AddWithValue("@Step2TrunkTakeoffAngle", Step2TrunkTakeoffAngle);


                        cmdInsert.Parameters.AddWithValue("@Step2ULAtFullExtension", Step2ULAtFullExtension);
                        cmdInsert.Parameters.AddWithValue("@Step2LLAtTakeoff", Step2LLAtTakeoff);
                        cmdInsert.Parameters.AddWithValue("@Step2LLAtFullFlexion", Step2LLAtFullFlexion);
                        // cmdInsert.Parameters.AddWithValue("@Step2LLAtatAnkleCross", Step2LLAtatAnkleCross);
                        cmdInsert.Parameters.AddWithValue("@Step2ULAtFullFlexion", Step2ULAtFullFlexion);


                        //Step3
                        cmdInsert.Parameters.AddWithValue("@Step3GroundTime", Step3GroundTime);
                        cmdInsert.Parameters.AddWithValue("@Step3AirTime", Step3AirTime);
                        //cmdInsert.Parameters.AddWithValue("@Step3UlFlexTime", Step3UlFlexTime);
                        //cmdInsert.Parameters.AddWithValue("@Step3StrideRate ", Step3StrideRate);
                        cmdInsert.Parameters.AddWithValue("@Step3StrideLength", Step3StrideLength);
                        cmdInsert.Parameters.AddWithValue("@Step3TouchdownDistance", Step3TouchdownDistance);
                        cmdInsert.Parameters.AddWithValue("@Step3KneeSeperationatTouchdown", Step3KneeSeperationatTouchdown);
                        cmdInsert.Parameters.AddWithValue("@Step3TrunkTouchdownAngle", Step3TrunkTouchdownAngle);
                        cmdInsert.Parameters.AddWithValue("@Step3TrunkTakeoffAngle", Step3TrunkTakeoffAngle);


                        cmdInsert.Parameters.AddWithValue("@Step3ULAtFullExtension", Step3ULAtFullExtension);
                        cmdInsert.Parameters.AddWithValue("@Step3LLAtTakeoff", Step3LLAtTakeoff);
                        cmdInsert.Parameters.AddWithValue("@Step3LLAtFullFlexion", Step3LLAtFullFlexion);
                        //cmdInsert.Parameters.AddWithValue("@Step3LLAtatAnkleCross", Step3LLAtatAnkleCross);
                        cmdInsert.Parameters.AddWithValue("@Step3ULAtFullFlexion", Step3ULAtFullFlexion);

                        //intoHurdleSteps
                        cmdInsert.Parameters.AddWithValue("@SetTouchdownDistanceIntoTheHurdle", SetTouchdownDistanceIntoTheHurdle);
                        cmdInsert.Parameters.AddWithValue("@SetKneeSeperationatTouchdownIntoTheHurdle", SetKneeSeperationatTouchdownIntoTheHurdle);
                        cmdInsert.Parameters.AddWithValue("@SetTrunkTouchdownAngleIntoTheHurdle", SetTrunkTouchdownAngleIntoTheHurdle); // For new variable
                        cmdInsert.Parameters.AddWithValue("@SetLLAtTouchdownIntoTheHurdle", SetLLAtTouchdownIntoTheHurdle);

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
        public void UpdateHurdleStepsModelData()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand Updatecmd = con.CreateCommand())
                {
                    try
                    {
                        Updatecmd.CommandType = CommandType.StoredProcedure;
                        Updatecmd.CommandText = "UpdateHurdleStepsModelData";
                        Updatecmd.Parameters.AddWithValue("@LessonId", LessonId);


                        Updatecmd.Parameters.AddWithValue("@SetDistanceBetweenHurdleSteps", SetDistanceBetweenHurdleSteps);
                        Updatecmd.Parameters.AddWithValue("@SetDistanceIntoHurdleSteps", SetDistanceIntoHurdleSteps);
                        Updatecmd.Parameters.AddWithValue("@SetDistanceOffHurdleSteps", SetDistanceOffHurdleSteps);
                        //Updatecmd.Parameters.AddWithValue("@Velocity", Velocity);
                        //Step1
                        Updatecmd.Parameters.AddWithValue("@Step1GroundTime", Step1GroundTime);
                        Updatecmd.Parameters.AddWithValue("@Step1AirTime", Step1AirTime);
                        //Updatecmd.Parameters.AddWithValue("@Step1UlFlexTime", Step1UlFlexTime);
                        //Updatecmd.Parameters.AddWithValue("@Step1StrideRate", Step1StrideRate);
                        Updatecmd.Parameters.AddWithValue("@Step1StrideLength", Step1StrideLength);
                        Updatecmd.Parameters.AddWithValue("@Step1TouchdownDistance", Step1TouchdownDistance);
                        Updatecmd.Parameters.AddWithValue("@Step1KneeSeperationatTouchdown", Step1KneeSeperationatTouchdown);
                        Updatecmd.Parameters.AddWithValue("@Step1TrunkTouchdownAngle", Step1TrunkTouchdownAngle);
                        Updatecmd.Parameters.AddWithValue("@Step1TrunkTakeoffAngle", Step1TrunkTakeoffAngle);

                        Updatecmd.Parameters.AddWithValue("@Step1ULAtFullExtension", Step1ULAtFullExtension);
                        Updatecmd.Parameters.AddWithValue("@Step1LLAtTakeoff", Step1LLAtTakeoff);
                        Updatecmd.Parameters.AddWithValue("@Step1ULAtFullFlexion", Step1ULAtFullFlexion);
                        //Step2
                        Updatecmd.Parameters.AddWithValue("@Step2GroundTime", Step2GroundTime);
                        Updatecmd.Parameters.AddWithValue("@Step2AirTime", Step2AirTime);
                        //Updatecmd.Parameters.AddWithValue("@Step2UlFlexTime", Step2UlFlexTime);
                        //Updatecmd.Parameters.AddWithValue("@Step2StrideRate ", Step2StrideRate);
                        Updatecmd.Parameters.AddWithValue("@Step2StrideLength", Step2StrideLength);
                        Updatecmd.Parameters.AddWithValue("@Step2TouchdownDistance", Step2TouchdownDistance);
                        Updatecmd.Parameters.AddWithValue("@Step2KneeSeperationatTouchdown", Step2KneeSeperationatTouchdown);
                        Updatecmd.Parameters.AddWithValue("@Step2TrunkTouchdownAngle", Step2TrunkTouchdownAngle);
                        Updatecmd.Parameters.AddWithValue("@Step2TrunkTakeoffAngle", Step2TrunkTakeoffAngle);


                        Updatecmd.Parameters.AddWithValue("@Step2ULAtFullExtension", Step2ULAtFullExtension);
                        Updatecmd.Parameters.AddWithValue("@Step2LLAtTakeoff", Step2LLAtTakeoff);
                        Updatecmd.Parameters.AddWithValue("@Step2LLAtFullFlexion", Step2LLAtFullFlexion);
                        // Updatecmd.Parameters.AddWithValue("@Step2LLAtatAnkleCross", Step2LLAtatAnkleCross);
                        Updatecmd.Parameters.AddWithValue("@Step2ULAtFullFlexion", Step2ULAtFullFlexion);


                        //Step3
                        Updatecmd.Parameters.AddWithValue("@Step3GroundTime", Step3GroundTime);
                        Updatecmd.Parameters.AddWithValue("@Step3AirTime", Step3AirTime);
                        //Updatecmd.Parameters.AddWithValue("@Step3UlFlexTime", Step3UlFlexTime);
                        //Updatecmd.Parameters.AddWithValue("@Step3StrideRate ", Step3StrideRate);
                        Updatecmd.Parameters.AddWithValue("@Step3StrideLength", Step3StrideLength);
                        Updatecmd.Parameters.AddWithValue("@Step3TouchdownDistance", Step3TouchdownDistance);
                        Updatecmd.Parameters.AddWithValue("@Step3KneeSeperationatTouchdown", Step3KneeSeperationatTouchdown);
                        Updatecmd.Parameters.AddWithValue("@Step3TrunkTouchdownAngle", Step3TrunkTouchdownAngle);
                        Updatecmd.Parameters.AddWithValue("@Step3TrunkTakeoffAngle", Step3TrunkTakeoffAngle);


                        Updatecmd.Parameters.AddWithValue("@Step3ULAtFullExtension", Step3ULAtFullExtension);
                        Updatecmd.Parameters.AddWithValue("@Step3LLAtTakeoff", Step3LLAtTakeoff);
                        Updatecmd.Parameters.AddWithValue("@Step3LLAtFullFlexion", Step3LLAtFullFlexion);
                        //Updatecmd.Parameters.AddWithValue("@Step3LLAtatAnkleCross", Step3LLAtatAnkleCross);
                        Updatecmd.Parameters.AddWithValue("@Step3ULAtFullFlexion", Step3ULAtFullFlexion);

                        //intoHurdleSteps
                        Updatecmd.Parameters.AddWithValue("@SetTouchdownDistanceIntoTheHurdle", SetTouchdownDistanceIntoTheHurdle);
                        Updatecmd.Parameters.AddWithValue("@SetKneeSeperationatTouchdownIntoTheHurdle", SetKneeSeperationatTouchdownIntoTheHurdle);
                        Updatecmd.Parameters.AddWithValue("@SetTrunkTouchdownAngleIntoTheHurdle", SetTrunkTouchdownAngleIntoTheHurdle); // For new variable
                        Updatecmd.Parameters.AddWithValue("@SetLLAtTouchdownIntoTheHurdle", SetLLAtTouchdownIntoTheHurdle);

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
        public void DeleteHurdleStepsModelLessonData(int LessonId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmdDelete = connection.CreateCommand())
                    {
                        cmdDelete.CommandType = CommandType.StoredProcedure;
                        cmdDelete.CommandText = "DeleteFromHurdleStepsModelData";
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
        #endregion[Hurdle Steps Model Data]



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


        internal void SetHurdleStepData(DataRow HurdleDRData)
        {

            LessonId = convertToInt(HurdleDRData[LessonId]);
            SetDistanceBetweenHurdleSteps = convertToDecimal(HurdleDRData["SetDistanceBetweenHurdleSteps"]);
            SetDistanceIntoHurdleSteps =convertToDecimal(HurdleDRData["SetDistanceIntoHurdleSteps"]);
            SetDistanceOffHurdleSteps =convertToDecimal(HurdleDRData["SetDistanceOffHurdleSteps"]);
            // cmdInsert.Parameters.AddWithValue("@Velocity", Velocity); // For multiple session 28/12/2016
            //Step1
            Step1GroundTime =convertToDecimal(HurdleDRData["Step1GroundTime"]);
            Step1AirTime =convertToDecimal(HurdleDRData["Step1AirTime"]);
            //cmdInsert.Parameters.AddWithValue("@Step1UlFlexTime", Step1UlFlexTime);
            //cmdInsert.Parameters.AddWithValue("@Step1StrideRate", Step1StrideRate);
            Step1StrideLength =convertToDecimal(HurdleDRData["Step1StrideLength"]);
            Step1TouchdownDistance =convertToDecimal(HurdleDRData["Step1TouchdownDistance"]);
            Step1KneeSeperationatTouchdown =convertToDecimal(HurdleDRData["Step1KneeSeperationatTouchdown"]);
            Step1TrunkTouchdownAngle =convertToInt(HurdleDRData["Step1TrunkTouchdownAngle"]);
            Step1TrunkTakeoffAngle =convertToInt(HurdleDRData["Step1TrunkTakeoffAngle"]);


            Step1ULAtFullExtension =convertToInt(HurdleDRData["Step1ULAtFullExtension"]);
            Step1LLAtTakeoff =convertToInt(HurdleDRData["Step1LLAtTakeoff"]);
            Step1ULAtFullFlexion= convertToInt(HurdleDRData["Step1ULAtFullFlexion"]);
            //Step2
            Step2GroundTime =convertToDecimal(HurdleDRData["Step2GroundTime"]);
            Step2AirTime =convertToDecimal(HurdleDRData["Step2AirTime"]);
            // cmdInsert.Parameters.AddWithValue("@Step2UlFlexTime", Step2UlFlexTime);
            //cmdInsert.Parameters.AddWithValue("@Step2StrideRate ", Step2StrideRate);
            Step2StrideLength =convertToDecimal(HurdleDRData["Step2StrideLength"]);
            Step2TouchdownDistance=convertToDecimal(HurdleDRData["Step2TouchdownDistance"]);
            Step2KneeSeperationatTouchdown =convertToDecimal(HurdleDRData["Step2KneeSeperationatTouchdown"]);
            Step2TrunkTouchdownAngle=convertToInt(HurdleDRData["Step2TrunkTouchdownAngle"]);
            Step2TrunkTakeoffAngle=convertToInt(HurdleDRData["Step2TrunkTakeoffAngle"]);

            Step2ULAtFullExtension=convertToInt(HurdleDRData["Step2ULAtFullExtension"]);
            Step2LLAtTakeoff =convertToInt(HurdleDRData["Step2LLAtTakeoff"]);
            Step2LLAtFullFlexion =convertToInt(HurdleDRData["Step2LLAtFullFlexion"]);
            //cmdInsert.Parameters.AddWithValue("@Step2LLAtatAnkleCross", Step2LLAtatAnkleCross);
            Step2ULAtFullFlexion=convertToInt(HurdleDRData["Step2ULAtFullFlexion"]);


            //Step3
            Step3GroundTime =convertToDecimal(HurdleDRData["Step3GroundTime"]);
            Step3AirTime =convertToDecimal(HurdleDRData["Step3AirTime"]);
            // cmdInsert.Parameters.AddWithValue("@Step3UlFlexTime", Step3UlFlexTime);
            //cmdInsert.Parameters.AddWithValue("@Step3StrideRate ", Step3StrideRate);
            Step3StrideLength=convertToDecimal(HurdleDRData["Step3StrideLength"]);
            Step3TouchdownDistance=convertToDecimal(HurdleDRData["Step3TouchdownDistance"]);
            Step3KneeSeperationatTouchdown=convertToDecimal(HurdleDRData["Step3KneeSeperationatTouchdown"]);
            Step3TrunkTouchdownAngle=convertToInt(HurdleDRData["Step3TrunkTouchdownAngle"]);
            Step3TrunkTakeoffAngle=convertToInt(HurdleDRData["Step3TrunkTakeoffAngle"]);

            Step3ULAtFullExtension=convertToInt(HurdleDRData["Step3ULAtFullExtension"]);
            Step3LLAtTakeoff=convertToInt(HurdleDRData["Step3LLAtTakeoff"]);
            Step3LLAtFullFlexion=convertToInt(HurdleDRData["Step3LLAtFullFlexion"]);
            // cmdInsert.Parameters.AddWithValue("@Step3LLAtatAnkleCross", Step3LLAtatAnkleCross);
            Step3ULAtFullFlexion=convertToInt(HurdleDRData["Step3ULAtFullFlexion"]);

            //intoHurdleSteps
            SetTouchdownDistanceIntoTheHurdle=convertToDecimal(HurdleDRData["SetTouchdownDistanceIntoTheHurdle"]);
            SetKneeSeperationatTouchdownIntoTheHurdle=convertToDecimal(HurdleDRData["SetKneeSeperationatTouchdownIntoTheHurdle"]);
            SetTrunkTouchdownAngleIntoTheHurdle=convertToInt(HurdleDRData["SetTrunkTouchdownAngleIntoTheHurdle"]);
            SetLLAtTouchdownIntoTheHurdle = convertToInt(HurdleDRData["SetLLAtTouchdownIntoTheHurdle"]);

        }

    }
}