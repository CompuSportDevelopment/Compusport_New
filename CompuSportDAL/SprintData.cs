using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace CompuSportDAL
{
    public class SprintData
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();

        #region[Property]
        public int LessonId { get; set; }
        public decimal GroundTimeLeft { get; set; }
        public decimal GroundTimeRight { get; set; }
        public decimal AirTimeLeftToRight { get; set; }
        public decimal AirTimeRightToLeft { get; set; }
        public decimal FullFlexionTimeLeft { get; set; }
        public decimal FullFlexionTimeRight { get; set; }
        public decimal StrideLengthLeftToRight { get; set; }
        public decimal StrideLengthRightToLeft { get; set; }
        public decimal COGDistanceLeft { get; set; }
        public decimal COGDistanceRight { get; set; }
        public int ULFullExtensionAngleLeft { get; set; }
        public int ULFullExtensionAngleRight { get; set; }
        public int LLAngleTakeoffLeft { get; set; }
        public int LLAAngleTakeoffRight { get; set; }
        public int LLAngleACLeft { get; set; }
        public int LLAngleACRight { get; set; }
        public int ULFullFlexionAngleLeft { get; set; }
        public int ULFullFlexionAngleRight { get; set; }
        public int LLFullFlexionAngleLeft { get; set; }
        public int LLFullFlexionAngleRight { get; set; }
        public int TAATouchDownLeft { get; set; }
        public int TAATouchDownRight { get; set; }
        public decimal KSATouchDownLeft { get; set; }
        public decimal KSATouchDownRight { get; set; }

        #endregion[Property]


        #region[Property For HurdleSteps]
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



        #region[For Sprint Model Table]
        public decimal GroundTime { get; set; }
        public decimal AirTime { get; set; }
        public decimal FullFlexionTime { get; set; }
        public decimal StrideLength { get; set; }
        public decimal COGDistance { get; set; }
        public int ULFullExtensionAngle { get; set; }
        public int LLAngleTakeoff { get; set; }
        public int LLAngleAC { get; set; }
        public int ULFullFlexionAngle { get; set; }
        public int LLFullFlexionAngle { get; set; }
        public int TAATouchDown { get; set; }
        public decimal KSATouchDown { get; set; }
      
        #endregion[For Sprint Model Table]


        #region[SprinttInitial Data]
        public void InsertIntoSprintInitialData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmdInsert = connection.CreateCommand())
                    {
                        cmdInsert.CommandType = CommandType.StoredProcedure;
                        cmdInsert.CommandText = "InsertIntoSprintInitialData";
                        cmdInsert.Parameters.AddWithValue("@LessonId", LessonId);
                        cmdInsert.Parameters.AddWithValue("@GroundTimeLeft", GroundTimeLeft);
                        cmdInsert.Parameters.AddWithValue("@GroundTimeRight", GroundTimeRight);
                        cmdInsert.Parameters.AddWithValue("@AirTimeLeftToRight", AirTimeLeftToRight);
                        cmdInsert.Parameters.AddWithValue("@AirTimeRightToLeft", AirTimeRightToLeft);
                        cmdInsert.Parameters.AddWithValue("@FullFlexionTimeLeft", FullFlexionTimeLeft);
                        cmdInsert.Parameters.AddWithValue("@FullFlexionTimeRight", FullFlexionTimeRight);
                        cmdInsert.Parameters.AddWithValue("@StrideLengthLeftToRight", StrideLengthLeftToRight);
                        cmdInsert.Parameters.AddWithValue("@StrideLengthRightToLeft", StrideLengthRightToLeft);
                        cmdInsert.Parameters.AddWithValue("@COGDistanceLeft", COGDistanceLeft);
                        cmdInsert.Parameters.AddWithValue("@COGDistanceRight", COGDistanceRight);
                        cmdInsert.Parameters.AddWithValue("@ULFullExtensionAngleLeft", ULFullExtensionAngleLeft);
                        cmdInsert.Parameters.AddWithValue("@ULFullExtensionAngleRight", ULFullExtensionAngleRight);
                        cmdInsert.Parameters.AddWithValue("@LLAngleTakeoffLeft", LLAngleTakeoffLeft);
                        cmdInsert.Parameters.AddWithValue("@LLAAngleTakeoffRight", LLAAngleTakeoffRight);
                        cmdInsert.Parameters.AddWithValue("@LLAngleACLeft", LLAngleACLeft);
                        cmdInsert.Parameters.AddWithValue("@LLAngleACRight", LLAngleACRight);
                        cmdInsert.Parameters.AddWithValue("@ULFullFlexionAngleLeft", ULFullFlexionAngleLeft);
                        cmdInsert.Parameters.AddWithValue("@ULFullFlexionAngleRight ", ULFullFlexionAngleRight);
                        cmdInsert.Parameters.AddWithValue("@LLFullFlexionAngleLeft", LLFullFlexionAngleLeft);
                        cmdInsert.Parameters.AddWithValue("@LLFullFlexionAngleRight", LLFullFlexionAngleRight);
                        cmdInsert.Parameters.AddWithValue("@TAATouchDownLeft", TAATouchDownLeft);
                        cmdInsert.Parameters.AddWithValue("@TAATouchDownRight", TAATouchDownRight);
                        cmdInsert.Parameters.AddWithValue("@KSATouchDownLeft", KSATouchDownLeft);
                        cmdInsert.Parameters.AddWithValue("@KSATouchDownRight", KSATouchDownRight);
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
        public void UpdateSprinttInitialData()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand Updatecmd = con.CreateCommand())
                {
                    try
                    {
                        Updatecmd.CommandType = CommandType.StoredProcedure;
                        Updatecmd.CommandText = "UpdateSprintInitialData";
                        Updatecmd.Parameters.AddWithValue("@LessonId", LessonId);
                        Updatecmd.Parameters.AddWithValue("@GroundTimeLeft", GroundTimeLeft);
                        Updatecmd.Parameters.AddWithValue("@GroundTimeRight", GroundTimeRight);
                        Updatecmd.Parameters.AddWithValue("@AirTimeLeftToRight", AirTimeLeftToRight);
                        Updatecmd.Parameters.AddWithValue("@AirTimeRightToLeft", AirTimeRightToLeft);
                        Updatecmd.Parameters.AddWithValue("@FullFlexionTimeLeft", FullFlexionTimeLeft);
                        Updatecmd.Parameters.AddWithValue("@FullFlexionTimeRight", FullFlexionTimeRight);
                        Updatecmd.Parameters.AddWithValue("@StrideLengthLeftToRight", StrideLengthLeftToRight);
                        Updatecmd.Parameters.AddWithValue("@StrideLengthRightToLeft", StrideLengthRightToLeft);
                        Updatecmd.Parameters.AddWithValue("@COGDistanceLeft", COGDistanceLeft);
                        Updatecmd.Parameters.AddWithValue("@COGDistanceRight", COGDistanceRight);
                        Updatecmd.Parameters.AddWithValue("@ULFullExtensionAngleLeft", ULFullExtensionAngleLeft);
                        Updatecmd.Parameters.AddWithValue("@ULFullExtensionAngleRight", ULFullExtensionAngleRight);
                        Updatecmd.Parameters.AddWithValue("@LLAngleTakeoffLeft", LLAngleTakeoffLeft);
                        Updatecmd.Parameters.AddWithValue("@LLAAngleTakeoffRight", LLAAngleTakeoffRight);
                        Updatecmd.Parameters.AddWithValue("@LLAngleACLeft", LLAngleACLeft);
                        Updatecmd.Parameters.AddWithValue("@LLAngleACRight", LLAngleACRight);
                        Updatecmd.Parameters.AddWithValue("@ULFullFlexionAngleLeft", ULFullFlexionAngleLeft);
                        Updatecmd.Parameters.AddWithValue("@ULFullFlexionAngleRight ", ULFullFlexionAngleRight);
                        Updatecmd.Parameters.AddWithValue("@LLFullFlexionAngleLeft", LLFullFlexionAngleLeft);
                        Updatecmd.Parameters.AddWithValue("@LLFullFlexionAngleRight", LLFullFlexionAngleRight);
                        Updatecmd.Parameters.AddWithValue("@TAATouchDownLeft", TAATouchDownLeft);
                        Updatecmd.Parameters.AddWithValue("@TAATouchDownRight", TAATouchDownRight);
                        Updatecmd.Parameters.AddWithValue("@KSATouchDownLeft", KSATouchDownLeft);
                        Updatecmd.Parameters.AddWithValue("@KSATouchDownRight", KSATouchDownRight);
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
        public void DeleteSprintInitialLessonData(int LessonId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmdDelete = connection.CreateCommand())
                    {
                        cmdDelete.CommandType = CommandType.StoredProcedure;
                        cmdDelete.CommandText = "DeleteFromSprintInitialData";
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
        #endregion[SprintInitial Data]

        #region[SprintCurrent Data]
        public void InsertIntoSprintCurrentData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmdInsert = connection.CreateCommand())
                    {
                        cmdInsert.CommandType = CommandType.StoredProcedure;
                        cmdInsert.CommandText = "InsertIntoSprintCurrentData";
                        cmdInsert.Parameters.AddWithValue("@LessonId", LessonId);
                        cmdInsert.Parameters.AddWithValue("@GroundTimeLeft", GroundTimeLeft);
                        cmdInsert.Parameters.AddWithValue("@GroundTimeRight", GroundTimeRight);
                        cmdInsert.Parameters.AddWithValue("@AirTimeLeftToRight", AirTimeLeftToRight);
                        cmdInsert.Parameters.AddWithValue("@AirTimeRightToLeft", AirTimeRightToLeft);
                        cmdInsert.Parameters.AddWithValue("@FullFlexionTimeLeft", FullFlexionTimeLeft);
                        cmdInsert.Parameters.AddWithValue("@FullFlexionTimeRight", FullFlexionTimeRight);
                        cmdInsert.Parameters.AddWithValue("@StrideLengthLeftToRight", StrideLengthLeftToRight);
                        cmdInsert.Parameters.AddWithValue("@StrideLengthRightToLeft", StrideLengthRightToLeft);
                        cmdInsert.Parameters.AddWithValue("@COGDistanceLeft", COGDistanceLeft);
                        cmdInsert.Parameters.AddWithValue("@COGDistanceRight", COGDistanceRight);
                        cmdInsert.Parameters.AddWithValue("@ULFullExtensionAngleLeft", ULFullExtensionAngleLeft);
                        cmdInsert.Parameters.AddWithValue("@ULFullExtensionAngleRight", ULFullExtensionAngleRight);
                        cmdInsert.Parameters.AddWithValue("@LLAngleTakeoffLeft", LLAngleTakeoffLeft);
                        cmdInsert.Parameters.AddWithValue("@LLAAngleTakeoffRight", LLAAngleTakeoffRight);
                        cmdInsert.Parameters.AddWithValue("@LLAngleACLeft", LLAngleACLeft);
                        cmdInsert.Parameters.AddWithValue("@LLAngleACRight", LLAngleACRight);
                        cmdInsert.Parameters.AddWithValue("@ULFullFlexionAngleLeft", ULFullFlexionAngleLeft);
                        cmdInsert.Parameters.AddWithValue("@ULFullFlexionAngleRight ", ULFullFlexionAngleRight);
                        cmdInsert.Parameters.AddWithValue("@LLFullFlexionAngleLeft", LLFullFlexionAngleLeft);
                        cmdInsert.Parameters.AddWithValue("@LLFullFlexionAngleRight", LLFullFlexionAngleRight);
                        cmdInsert.Parameters.AddWithValue("@TAATouchDownLeft", TAATouchDownLeft);
                        cmdInsert.Parameters.AddWithValue("@TAATouchDownRight", TAATouchDownRight);
                        cmdInsert.Parameters.AddWithValue("@KSATouchDownLeft", KSATouchDownLeft);
                        cmdInsert.Parameters.AddWithValue("@KSATouchDownRight", KSATouchDownRight);
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
        public void UpdateSprintCurrentData()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand Updatecmd = con.CreateCommand())
                {
                    try
                    {
                        Updatecmd.CommandType = CommandType.StoredProcedure;
                        Updatecmd.CommandText = "UpdateSprintCurrentData";
                        Updatecmd.Parameters.AddWithValue("@LessonId", LessonId);
                        Updatecmd.Parameters.AddWithValue("@GroundTimeLeft", GroundTimeLeft);
                        Updatecmd.Parameters.AddWithValue("@GroundTimeRight", GroundTimeRight);
                        Updatecmd.Parameters.AddWithValue("@AirTimeLeftToRight", AirTimeLeftToRight);
                        Updatecmd.Parameters.AddWithValue("@AirTimeRightToLeft", AirTimeRightToLeft);
                        Updatecmd.Parameters.AddWithValue("@FullFlexionTimeLeft", FullFlexionTimeLeft);
                        Updatecmd.Parameters.AddWithValue("@FullFlexionTimeRight", FullFlexionTimeRight);
                        Updatecmd.Parameters.AddWithValue("@StrideLengthLeftToRight", StrideLengthLeftToRight);
                        Updatecmd.Parameters.AddWithValue("@StrideLengthRightToLeft", StrideLengthRightToLeft);
                        Updatecmd.Parameters.AddWithValue("@COGDistanceLeft", COGDistanceLeft);
                        Updatecmd.Parameters.AddWithValue("@COGDistanceRight", COGDistanceRight);
                        Updatecmd.Parameters.AddWithValue("@ULFullExtensionAngleLeft", ULFullExtensionAngleLeft);
                        Updatecmd.Parameters.AddWithValue("@ULFullExtensionAngleRight", ULFullExtensionAngleRight);
                        Updatecmd.Parameters.AddWithValue("@LLAngleTakeoffLeft", LLAngleTakeoffLeft);
                        Updatecmd.Parameters.AddWithValue("@LLAAngleTakeoffRight", LLAAngleTakeoffRight);
                        Updatecmd.Parameters.AddWithValue("@LLAngleACLeft", LLAngleACLeft);
                        Updatecmd.Parameters.AddWithValue("@LLAngleACRight", LLAngleACRight);
                        Updatecmd.Parameters.AddWithValue("@ULFullFlexionAngleLeft", ULFullFlexionAngleLeft);
                        Updatecmd.Parameters.AddWithValue("@ULFullFlexionAngleRight ", ULFullFlexionAngleRight);
                        Updatecmd.Parameters.AddWithValue("@LLFullFlexionAngleLeft", LLFullFlexionAngleLeft);
                        Updatecmd.Parameters.AddWithValue("@LLFullFlexionAngleRight", LLFullFlexionAngleRight);
                        Updatecmd.Parameters.AddWithValue("@TAATouchDownLeft", TAATouchDownLeft);
                        Updatecmd.Parameters.AddWithValue("@TAATouchDownRight", TAATouchDownRight);
                        Updatecmd.Parameters.AddWithValue("@KSATouchDownLeft", KSATouchDownLeft);
                        Updatecmd.Parameters.AddWithValue("@KSATouchDownRight", KSATouchDownRight);
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
        public void DeleteSprintCurrentLessonData(int LessonId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmdDelete = connection.CreateCommand())
                    {
                        cmdDelete.CommandType = CommandType.StoredProcedure;
                        cmdDelete.CommandText = "DeleteFromSprintCurrentData";
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
        #endregion[SprintIntial Data]

        #region[Sprint Model Data]
        public void InsertIntoSprintModelData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmdInsert = connection.CreateCommand())
                    {
                        cmdInsert.CommandType = CommandType.StoredProcedure;
                        cmdInsert.CommandText = "InsertIntoSprintModelData";
                        cmdInsert.Parameters.AddWithValue("@LessonId", LessonId);
                        cmdInsert.Parameters.AddWithValue("@GroundTime", GroundTimeLeft);
                        cmdInsert.Parameters.AddWithValue("@AirTime", AirTimeRightToLeft);
                        cmdInsert.Parameters.AddWithValue("@FullFlexionTime", FullFlexionTimeLeft);
                        cmdInsert.Parameters.AddWithValue("@StrideLength", StrideLengthRightToLeft);
                        cmdInsert.Parameters.AddWithValue("@COGDistance", COGDistanceLeft);
                        cmdInsert.Parameters.AddWithValue("@ULFullExtensionAngle", ULFullExtensionAngleLeft);
                        cmdInsert.Parameters.AddWithValue("@LLAngleTakeoff", LLAngleTakeoffLeft);
                        cmdInsert.Parameters.AddWithValue("@LLFullFlexionAngle", LLFullFlexionAngleLeft);
                        cmdInsert.Parameters.AddWithValue("@LLAngleAC", LLAngleACLeft);
                        cmdInsert.Parameters.AddWithValue("@ULFullFlexionAngle", ULFullFlexionAngleLeft);
                        cmdInsert.Parameters.AddWithValue("@TAATouchDown", TAATouchDownLeft);
                        cmdInsert.Parameters.AddWithValue("@KSATouchDown", KSATouchDownLeft);

                        cmdInsert.Parameters.AddWithValue("@GroundTimeRight ", GroundTimeRight);
                        cmdInsert.Parameters.AddWithValue("@AirTimeLeftToRight ", AirTimeLeftToRight);
                        cmdInsert.Parameters.AddWithValue("@FullFlexionTimeRight ", FullFlexionTimeRight);
                        cmdInsert.Parameters.AddWithValue("@StrideLengthLeftToRight ", StrideLengthLeftToRight);
                        cmdInsert.Parameters.AddWithValue("@COGDistanceRight ", COGDistanceRight);
                        cmdInsert.Parameters.AddWithValue("@ULFullExtensionAngleRight ", ULFullExtensionAngleRight);
                        cmdInsert.Parameters.AddWithValue("@LLAAngleTakeoffRight ", LLAAngleTakeoffRight);
                        cmdInsert.Parameters.AddWithValue("@ULFullFlexionAngleRight ", ULFullFlexionAngleRight);
                        cmdInsert.Parameters.AddWithValue("@LLAngleACRight ", LLAngleACRight);
                        cmdInsert.Parameters.AddWithValue("@LLFullFlexionAngleRight ", LLFullFlexionAngleRight);
                        cmdInsert.Parameters.AddWithValue("@TAATouchDownRight ", TAATouchDownRight);
                        cmdInsert.Parameters.AddWithValue("@KSATouchDownRight ", KSATouchDownRight);
                       
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
        public void UpdateSprintModelData()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand Updatecmd = con.CreateCommand())
                {
                    try
                    {
                        Updatecmd.CommandType = CommandType.StoredProcedure;
                        Updatecmd.CommandText = "UpdateSprintModelData";
                        Updatecmd.Parameters.AddWithValue("@LessonId", LessonId);
                        Updatecmd.Parameters.AddWithValue("@GroundTime", GroundTimeLeft);
                        Updatecmd.Parameters.AddWithValue("@AirTime", AirTimeRightToLeft);
                        Updatecmd.Parameters.AddWithValue("@FullFlexionTime", FullFlexionTimeLeft);
                        Updatecmd.Parameters.AddWithValue("@StrideLength", StrideLengthRightToLeft);
                        Updatecmd.Parameters.AddWithValue("@COGDistance", COGDistanceLeft);
                        Updatecmd.Parameters.AddWithValue("@ULFullExtensionAngle", ULFullExtensionAngleLeft);
                        Updatecmd.Parameters.AddWithValue("@LLAngleTakeoff", LLAngleTakeoffLeft);
                        Updatecmd.Parameters.AddWithValue("@LLFullFlexionAngle", LLFullFlexionAngleLeft);
                        Updatecmd.Parameters.AddWithValue("@LLAngleAC", LLAngleACLeft);
                        Updatecmd.Parameters.AddWithValue("@ULFullFlexionAngle", ULFullFlexionAngleLeft);
                        Updatecmd.Parameters.AddWithValue("@TAATouchDown", TAATouchDownLeft);
                        Updatecmd.Parameters.AddWithValue("@KSATouchDown", KSATouchDownLeft);

                       //Updatecmd.Parameters.AddWithValue("@GroundTimeRight ", GroundTimeRight);
                        //Updatecmd.Parameters.AddWithValue("@AirTimeLeftToRight ", AirTimeLeftToRight);
                        //Updatecmd.Parameters.AddWithValue("@FullFlexionTimeRight ", FullFlexionTimeRight);
                        //Updatecmd.Parameters.AddWithValue("@StrideLengthLeftToRight ", StrideLengthLeftToRight);
                        //Updatecmd.Parameters.AddWithValue("@COGDistanceRight ", COGDistanceRight);
                        //Updatecmd.Parameters.AddWithValue("@ULFullExtensionAngleRight ", ULFullExtensionAngleRight);
                        //Updatecmd.Parameters.AddWithValue("@LLAAngleTakeoffRight ", LLAAngleTakeoffRight);
                        //Updatecmd.Parameters.AddWithValue("@ULFullFlexionAngleRight ", ULFullFlexionAngleRight);
                        //Updatecmd.Parameters.AddWithValue("@LLAngleACRight ", LLAngleACRight);
                        //Updatecmd.Parameters.AddWithValue("@LLFullFlexionAngleRight ", LLFullFlexionAngleRight);
                        //Updatecmd.Parameters.AddWithValue("@TAATouchDownRight ", TAATouchDownRight);
                        //Updatecmd.Parameters.AddWithValue("@KSATouchDownRight ", KSATouchDownRight);

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

        public void InsertIntoSprintOntrackModelData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmdInsert = connection.CreateCommand())
                    {
                        cmdInsert.CommandType = CommandType.StoredProcedure;
                        cmdInsert.CommandText = "AddSprintOnTrackModelDataId";
                        cmdInsert.Parameters.AddWithValue("@LessonId", LessonId);
                        cmdInsert.Parameters.AddWithValue("@GroundTimeLeft", GroundTimeLeft);
                        cmdInsert.Parameters.AddWithValue("@GroundTimeRight", GroundTimeRight);
                        cmdInsert.Parameters.AddWithValue("@AirTimeLeftToRight", AirTimeLeftToRight);
                        cmdInsert.Parameters.AddWithValue("@AirTimeRightToLeft", AirTimeRightToLeft);
                        cmdInsert.Parameters.AddWithValue("@FullFlexionTimeLeft", FullFlexionTimeLeft);
                        cmdInsert.Parameters.AddWithValue("@FullFlexionTimeRight", FullFlexionTimeRight);
                        cmdInsert.Parameters.AddWithValue("@StrideLengthLeftToRight", StrideLengthLeftToRight);
                        cmdInsert.Parameters.AddWithValue("@StrideLengthRightToLeft", StrideLengthRightToLeft);
                        cmdInsert.Parameters.AddWithValue("@COGDistanceLeft", COGDistanceLeft);
                        cmdInsert.Parameters.AddWithValue("@COGDistanceRight", COGDistanceRight);
                        cmdInsert.Parameters.AddWithValue("@ULFullExtensionAngleLeft", ULFullExtensionAngleLeft);
                        cmdInsert.Parameters.AddWithValue("@ULFullExtensionAngleRight", ULFullExtensionAngleRight);
                        cmdInsert.Parameters.AddWithValue("@LLAngleTakeoffLeft", LLAngleTakeoffLeft);
                        cmdInsert.Parameters.AddWithValue("@LLAAngleTakeoffRight", LLAAngleTakeoffRight);
                        cmdInsert.Parameters.AddWithValue("@LLAngleACLeft", LLAngleACLeft);
                        cmdInsert.Parameters.AddWithValue("@LLAngleACRight", LLAngleACRight);
                        cmdInsert.Parameters.AddWithValue("@ULFullFlexionAngleLeft", ULFullFlexionAngleLeft);
                        cmdInsert.Parameters.AddWithValue("@ULFullFlexionAngleRight ", ULFullFlexionAngleRight);
                        cmdInsert.Parameters.AddWithValue("@LLFullFlexionAngleLeft", LLFullFlexionAngleLeft);
                        cmdInsert.Parameters.AddWithValue("@LLFullFlexionAngleRight", LLFullFlexionAngleRight);
                        cmdInsert.Parameters.AddWithValue("@TAATouchDownLeft", TAATouchDownLeft);
                        cmdInsert.Parameters.AddWithValue("@TAATouchDownRight", TAATouchDownRight);
                        cmdInsert.Parameters.AddWithValue("@KSATouchDownLeft", KSATouchDownLeft);
                        cmdInsert.Parameters.AddWithValue("@KSATouchDownRight", KSATouchDownRight);

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
        public void UpadteIntoSprintOntrackModelData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmdInsert = connection.CreateCommand())
                    {
                        cmdInsert.CommandType = CommandType.StoredProcedure;
                        cmdInsert.CommandText = "UpdateSprintOnTrackModelDataId";
                        cmdInsert.Parameters.AddWithValue("@LessonId", LessonId);
                        cmdInsert.Parameters.AddWithValue("@GroundTimeLeft", GroundTimeLeft);
                        cmdInsert.Parameters.AddWithValue("@GroundTimeRight", GroundTimeRight);
                        cmdInsert.Parameters.AddWithValue("@AirTimeLeftToRight", AirTimeLeftToRight);
                        cmdInsert.Parameters.AddWithValue("@AirTimeRightToLeft", AirTimeRightToLeft);
                        cmdInsert.Parameters.AddWithValue("@FullFlexionTimeLeft", FullFlexionTimeLeft);
                        cmdInsert.Parameters.AddWithValue("@FullFlexionTimeRight", FullFlexionTimeRight);
                        cmdInsert.Parameters.AddWithValue("@StrideLengthLeftToRight", StrideLengthLeftToRight);
                        cmdInsert.Parameters.AddWithValue("@StrideLengthRightToLeft", StrideLengthRightToLeft);
                        cmdInsert.Parameters.AddWithValue("@COGDistanceLeft", COGDistanceLeft);
                        cmdInsert.Parameters.AddWithValue("@COGDistanceRight", COGDistanceRight);
                        cmdInsert.Parameters.AddWithValue("@ULFullExtensionAngleLeft", ULFullExtensionAngleLeft);
                        cmdInsert.Parameters.AddWithValue("@ULFullExtensionAngleRight", ULFullExtensionAngleRight);
                        cmdInsert.Parameters.AddWithValue("@LLAngleTakeoffLeft", LLAngleTakeoffLeft);
                        cmdInsert.Parameters.AddWithValue("@LLAAngleTakeoffRight", LLAAngleTakeoffRight);
                        cmdInsert.Parameters.AddWithValue("@LLAngleACLeft", LLAngleACLeft);
                        cmdInsert.Parameters.AddWithValue("@LLAngleACRight", LLAngleACRight);
                        cmdInsert.Parameters.AddWithValue("@ULFullFlexionAngleLeft", ULFullFlexionAngleLeft);
                        cmdInsert.Parameters.AddWithValue("@ULFullFlexionAngleRight ", ULFullFlexionAngleRight);
                        cmdInsert.Parameters.AddWithValue("@LLFullFlexionAngleLeft", LLFullFlexionAngleLeft);
                        cmdInsert.Parameters.AddWithValue("@LLFullFlexionAngleRight", LLFullFlexionAngleRight);
                        cmdInsert.Parameters.AddWithValue("@TAATouchDownLeft", TAATouchDownLeft);
                        cmdInsert.Parameters.AddWithValue("@TAATouchDownRight", TAATouchDownRight);
                        cmdInsert.Parameters.AddWithValue("@KSATouchDownLeft", KSATouchDownLeft);
                        cmdInsert.Parameters.AddWithValue("@KSATouchDownRight", KSATouchDownRight);

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
        public void DeleteSprintModelLessonData(int LessonId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmdDelete = connection.CreateCommand())
                    {
                        cmdDelete.CommandType = CommandType.StoredProcedure;
                        cmdDelete.CommandText = "DeleteFromSprintModelData";
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
        #endregion[Sprint Model Data]


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
                        Updatecmd.Parameters.AddWithValue("@Velocity", Velocity);
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
                        Updatecmd.Parameters.AddWithValue("@Velocity", Velocity);
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

        internal void Setdata(DataRow drData)
        {
            //LessonId = Convert.ToInt16(drData["LessonId"]);
            LessonId = convertToInt(drData[LessonId]);
            GroundTimeLeft = convertToDecimal(drData["Ground Time Left"]);
            GroundTimeRight = convertToDecimal(drData["Ground Time Right"]);
            AirTimeLeftToRight = convertToDecimal(drData["Air Time Left to Right"]);
            AirTimeRightToLeft = convertToDecimal(drData["Air Time Right to Left"]);
            FullFlexionTimeLeft = convertToDecimal(drData["Time to Upper Leg Full Flexion Left"]);
            FullFlexionTimeRight = convertToDecimal(drData["Time to Upper Leg Full Flexion Right"]);
            StrideLengthLeftToRight = convertToDecimal(drData["Stride Length Left to Right"]);
            StrideLengthRightToLeft = convertToDecimal(drData["Stride Length Right to Left"]);
            KSATouchDownLeft = convertToDecimal(drData["KSATouchDownLeft"]);
            KSATouchDownRight = convertToDecimal(drData["KSATouchDownRight"]);
            COGDistanceLeft = convertToDecimal(drData["Touchdown Distance Left"]);
            COGDistanceRight = convertToDecimal(drData["Touchdown Distance Right"]);
            TAATouchDownLeft = convertToInt(drData["TAATouchDownLeft"]);
            TAATouchDownRight = convertToInt(drData["TAATouchDownRight"]);
            ULFullExtensionAngleLeft = convertToInt(drData["Upper Leg Full Extension Angle Left"]);
            ULFullExtensionAngleRight = convertToInt(drData["Upper Leg Full Extension Angle Right"]);
            ULFullFlexionAngleLeft = convertToInt(drData["Upper Leg Full Flexion Angle Left"]);
            ULFullFlexionAngleRight = convertToInt(drData["Upper Leg Full Flexion Angle Right"]);
            LLAngleTakeoffLeft = convertToInt(drData["Lower Leg Angle at Takeoff Left"]);
            LLAAngleTakeoffRight = convertToInt(drData["Lower Leg Angle at Takeoff Right"]);
            LLFullFlexionAngleLeft = convertToInt(drData["Lower Leg Full Flexion Angle Left"]);
            LLFullFlexionAngleRight = convertToInt(drData["Lower Leg Full Flexion Angle Right"]);
            //throw new NotImplementedException();
        }

        internal void SetOnTrackModeldata(DataRow drData)
        {
            //LessonId = Convert.ToInt16(drData["LessonId"]);
            LessonId = convertToInt(drData[LessonId]);

            GroundTimeLeft = convertToDecimal(drData["GroundTime"]);
            GroundTimeRight = convertToDecimal(drData["GroundTime"]);
            AirTimeLeftToRight = convertToDecimal(drData["AirTime"]);
            AirTimeRightToLeft = convertToDecimal(drData["AirTime"]);
            FullFlexionTimeLeft = convertToDecimal(drData["FullFlexionTime"]);
            FullFlexionTimeRight = convertToDecimal(drData["FullFlexionTime"]);
            StrideLengthLeftToRight = convertToDecimal(drData["StrideLength"]);
            StrideLengthRightToLeft = convertToDecimal(drData["StrideLength"]);

            KSATouchDownLeft = convertToDecimal(drData["KSATouchDown"]);
            KSATouchDownRight = convertToDecimal(drData["KSATouchDown"]);

            COGDistanceLeft = convertToDecimal(drData["COGDistance"]);
            COGDistanceRight = convertToDecimal(drData["COGDistance"]);

            TAATouchDownLeft = convertToInt(drData["TAATouchDown"]);
            TAATouchDownRight = convertToInt(drData["TAATouchDown"]);

            ULFullExtensionAngleLeft = convertToInt(drData["ULFullExtensionAngle"]);
            ULFullExtensionAngleRight = convertToInt(drData["ULFullExtensionAngle"]);

            ULFullFlexionAngleLeft = convertToInt(drData["ULFullFlexionAngle"]);
            ULFullFlexionAngleRight = convertToInt(drData["ULFullFlexionAngle"]);

            LLAngleTakeoffLeft = convertToInt(drData["LLAngleTakeoff"]);
            LLAAngleTakeoffRight = convertToInt(drData["LLAngleTakeoff"]);

            LLFullFlexionAngleLeft = convertToInt(drData["LLFullFlexionAngle"]);
            LLFullFlexionAngleRight = convertToInt(drData["LLFullFlexionAngle"]);
            //throw new NotImplementedException();
        }

    }
}
