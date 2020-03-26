
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
    public class SprintAthleteEdit
    {

        // int x;
        public string wmvFileName = "";
        public string wmpfile = "";
        public ArrayList GuidMatch;

        string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();

        public int CustomerId { get; set; }
        public int LessonId { get; set; }
        public DateTime ForceDate { get; set; }

        public int AthleteHorizontalValue { get; set; }
        public int ModelHorizontalValue { get; set; }
        public int AthleteVerticalValue { get; set; }
        public int ModelVerticalValue { get; set; }
        public int AthleteTotalValue { get; set; }
        public int ModelTotalValue { get; set; }
        public int RelativeHorizontalForce { get; set; }
        public int RelativeVerticalForce { get; set; }
        public int RelativeTotalForce { get; set; }


        public DataTable SelectLatestLessonIdOfForces()
        {
            DataTable dtSecondLatestLesson = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmdSelectStartInitialDid = connection.CreateCommand())
                    {
                        cmdSelectStartInitialDid.CommandType = CommandType.StoredProcedure;
                        cmdSelectStartInitialDid.Parameters.AddWithValue("@CustomerId", CustomerId);
                        cmdSelectStartInitialDid.CommandText = "SelectLatestLessonIdOfAllForces";
                        cmdSelectStartInitialDid.Connection = connection;
                        SqlDataAdapter da = new SqlDataAdapter(cmdSelectStartInitialDid);
                        da.Fill(dtSecondLatestLesson);
                        return dtSecondLatestLesson;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                return null;
            }
        }

        public void InsertIntoRquestedSession(string sessionRequested, int customerId, int lessonType)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmdTeachers = con.CreateCommand())
                    {
                        cmdTeachers.CommandType = CommandType.StoredProcedure;
                        cmdTeachers.CommandText = "InsertIntoSessionRequested";
                        cmdTeachers.Parameters.AddWithValue("@sessionRequested", sessionRequested);
                        cmdTeachers.Parameters.AddWithValue("@CustomerId", customerId);
                        cmdTeachers.Parameters.AddWithValue("@lessonType", lessonType);
                        cmdTeachers.Connection = con;
                        cmdTeachers.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        public string CheckRequestedSessionExists(string sessionRequested, int customerId, int lessonType)
        {
            string strPath = string.Empty;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmdSelectlocation = connection.CreateCommand())
                    {
                        cmdSelectlocation.CommandType = CommandType.StoredProcedure;
                        cmdSelectlocation.Parameters.AddWithValue("@CustomerId", customerId);
                        cmdSelectlocation.Parameters.AddWithValue("@sessionRequested", sessionRequested);
                        cmdSelectlocation.Parameters.AddWithValue("@lessonType", lessonType);
                        cmdSelectlocation.CommandText = "CheckRequestedSession";
                        cmdSelectlocation.Connection = connection;
                        SqlDataReader dr = cmdSelectlocation.ExecuteReader();
                        if (dr.Read())
                        {
                            strPath = Convert.ToString(dr["SessionName"]);
                        }
                    }
                }
                return strPath;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return null;
            }
        }


        public DataTable SelectSecondEarliestLessonIdOfForces()
        {
            DataTable dtSecondEarliestLesson = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmdSelectStartInitialDid = connection.CreateCommand())
                    {
                        cmdSelectStartInitialDid.CommandType = CommandType.StoredProcedure;
                        cmdSelectStartInitialDid.Parameters.AddWithValue("@CustomerId", CustomerId);
                        cmdSelectStartInitialDid.CommandText = "SelectSecondLatestLessonIdOfAllForces";
                        cmdSelectStartInitialDid.Connection = connection;
                        SqlDataAdapter da = new SqlDataAdapter(cmdSelectStartInitialDid);
                        da.Fill(dtSecondEarliestLesson);
                        return dtSecondEarliestLesson;

                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                return null;
            }
        }

        public void deleteuser(string UserToDelete)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmdSelectStartInitialDid = connection.CreateCommand())
                    {
                        cmdSelectStartInitialDid.CommandType = CommandType.StoredProcedure;
                        cmdSelectStartInitialDid.Parameters.AddWithValue("@UserToDelete", UserToDelete);
                        cmdSelectStartInitialDid.CommandText = "Delete_ASPNET_Member";
                        cmdSelectStartInitialDid.Connection = connection;
                        cmdSelectStartInitialDid.ExecuteNonQuery();

                    }
                }

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        public DataTable GetActualForceBlockForceInputData()
        {
            DataTable dtGetBlockForceData = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmdBlockForce = con.CreateCommand())
                    {
                        cmdBlockForce.CommandType = CommandType.StoredProcedure;
                        cmdBlockForce.CommandText = "GetActualForce_BlockForceInputData";
                        cmdBlockForce.Parameters.AddWithValue("@CustomerId", CustomerId);
                        cmdBlockForce.Parameters.AddWithValue("@LessonId", LessonId);
                        cmdBlockForce.Connection = con;
                        SqlDataAdapter da = new SqlDataAdapter(cmdBlockForce);
                        da.Fill(dtGetBlockForceData);
                        return dtGetBlockForceData;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return null;
            }
        }

        public DataTable GetActualForceFrontBlockForceInputData()
        {
            DataTable dtGetBlockForceData = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmdBlockForce = con.CreateCommand())
                    {
                        cmdBlockForce.CommandType = CommandType.StoredProcedure;
                        cmdBlockForce.CommandText = "GetFrontBlockActualForce_BlockForceInputData";
                        cmdBlockForce.Parameters.AddWithValue("@CustomerId", CustomerId);
                        cmdBlockForce.Parameters.AddWithValue("@LessonId", LessonId);
                        cmdBlockForce.Connection = con;
                        SqlDataAdapter da = new SqlDataAdapter(cmdBlockForce);
                        da.Fill(dtGetBlockForceData);
                        return dtGetBlockForceData;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return null;
            }
        }
        public DataTable GetRelativeForcesBlockForceInputData()
        {
            DataTable dtGetRelativeForcesData = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmdRelativeForces = con.CreateCommand())
                    {
                        cmdRelativeForces.CommandType = CommandType.StoredProcedure;
                        cmdRelativeForces.CommandText = "GetRelativeForces_BlockForceInputData";
                        cmdRelativeForces.Parameters.AddWithValue("@CustomerId", CustomerId);
                        cmdRelativeForces.Parameters.AddWithValue("@LessonId", LessonId);
                        cmdRelativeForces.Connection = con;
                        SqlDataAdapter da = new SqlDataAdapter(cmdRelativeForces);
                        da.Fill(dtGetRelativeForcesData);
                        return dtGetRelativeForcesData;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return null;
            }
        }

        public DataTable GetRelativeForcesFrontBlockForceInputData()
        {
            DataTable dtGetRelativeForcesData = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmdRelativeForces = con.CreateCommand())
                    {
                        cmdRelativeForces.CommandType = CommandType.StoredProcedure;
                        cmdRelativeForces.CommandText = "GetFrontBlockRelativeForces_BlockForceInputData";
                        cmdRelativeForces.Parameters.AddWithValue("@CustomerId", CustomerId);
                        cmdRelativeForces.Parameters.AddWithValue("@LessonId", LessonId);
                        cmdRelativeForces.Connection = con;
                        SqlDataAdapter da = new SqlDataAdapter(cmdRelativeForces);
                        da.Fill(dtGetRelativeForcesData);
                        return dtGetRelativeForcesData;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return null;
            }
        }

        public DataTable GetActualPowerBlockForceInputData()
        {
            DataTable dtGetActualPowerData = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmdActualPower = con.CreateCommand())
                    {
                        cmdActualPower.CommandType = CommandType.StoredProcedure;
                        cmdActualPower.CommandText = "GetActualPower_BlockForceInputData";
                        cmdActualPower.Parameters.AddWithValue("@CustomerId", CustomerId);
                        cmdActualPower.Parameters.AddWithValue("@LessonId", LessonId);
                        cmdActualPower.Connection = con;
                        SqlDataAdapter da = new SqlDataAdapter(cmdActualPower);
                        da.Fill(dtGetActualPowerData);
                        return dtGetActualPowerData;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return null;
            }
        }

        public DataTable GetActualPowerFrontBlockForceInputData()
        {
            DataTable dtGetActualPowerData = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmdActualPower = con.CreateCommand())
                    {
                        cmdActualPower.CommandType = CommandType.StoredProcedure;
                        cmdActualPower.CommandText = "GetFrontBlockActualPower_BlockForceInputData";
                        cmdActualPower.Parameters.AddWithValue("@CustomerId", CustomerId);
                        cmdActualPower.Parameters.AddWithValue("@LessonId", LessonId);
                        cmdActualPower.Connection = con;
                        SqlDataAdapter da = new SqlDataAdapter(cmdActualPower);
                        da.Fill(dtGetActualPowerData);
                        return dtGetActualPowerData;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return null;
            }
        }

        public DataTable GetRelativePowerBlockForceInputData()
        {
            DataTable dtGetRelativePowerData = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmdRelativePower = con.CreateCommand())
                    {
                        cmdRelativePower.CommandType = CommandType.StoredProcedure;
                        cmdRelativePower.CommandText = "GetRelativePower_BlockForceInputData";
                        cmdRelativePower.Parameters.AddWithValue("@CustomerId", CustomerId);
                        cmdRelativePower.Parameters.AddWithValue("@LessonId", LessonId);
                        cmdRelativePower.Connection = con;
                        SqlDataAdapter da = new SqlDataAdapter(cmdRelativePower);
                        da.Fill(dtGetRelativePowerData);
                        return dtGetRelativePowerData;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return null;
            }
        }

        public DataTable GetRelativePowerFrontBlockForceInputData()
        {
            DataTable dtGetRelativePowerData = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmdRelativePower = con.CreateCommand())
                    {
                        cmdRelativePower.CommandType = CommandType.StoredProcedure;
                        cmdRelativePower.CommandText = "GetFrontBlockRelativePower_BlockForceInputData";
                        cmdRelativePower.Parameters.AddWithValue("@CustomerId", CustomerId);
                        cmdRelativePower.Parameters.AddWithValue("@LessonId", LessonId);
                        cmdRelativePower.Connection = con;
                        SqlDataAdapter da = new SqlDataAdapter(cmdRelativePower);
                        da.Fill(dtGetRelativePowerData);
                        return dtGetRelativePowerData;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return null;
            }
        }
        public DataTable InsertIntoActualForce()
        {
            DataTable dtActualForce = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmdActualForce = con.CreateCommand())
                    {
                        cmdActualForce.CommandType = CommandType.StoredProcedure;
                        cmdActualForce.CommandText = "InsertInto_ActualForce";
                        cmdActualForce.Parameters.AddWithValue("@CustomerId", CustomerId);
                        cmdActualForce.Parameters.AddWithValue("@LessonId", LessonId);
                        cmdActualForce.Parameters.AddWithValue("@ForceDate", ForceDate);
                        cmdActualForce.Parameters.AddWithValue("@AthleteHorizontalValue", AthleteHorizontalValue);
                        cmdActualForce.Parameters.AddWithValue("@ModelHorizontalValue", ModelHorizontalValue);
                        cmdActualForce.Parameters.AddWithValue("@AthleteVerticalValue", AthleteVerticalValue);
                        cmdActualForce.Parameters.AddWithValue("@ModelVerticalValue", ModelVerticalValue);
                        cmdActualForce.Parameters.AddWithValue("@AthleteTotalValue", AthleteTotalValue);
                        cmdActualForce.Parameters.AddWithValue("@ModelTotalValue", ModelTotalValue);
                        cmdActualForce.Connection = con;
                        SqlDataAdapter daActualForce = new SqlDataAdapter(cmdActualForce);
                        daActualForce.Fill(dtActualForce);
                        return dtActualForce;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return null;
            }
        }
        public void UpdateBackBlockActualForce()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmdUpdateBackActualForce = con.CreateCommand())
                    {
                        cmdUpdateBackActualForce.CommandType = CommandType.StoredProcedure;
                        cmdUpdateBackActualForce.CommandText = "UpdateBackBlockActualForce";
                        cmdUpdateBackActualForce.Parameters.AddWithValue("@CustomerId", CustomerId);
                        cmdUpdateBackActualForce.Parameters.AddWithValue("@LessonId", LessonId);
                        cmdUpdateBackActualForce.Parameters.AddWithValue("@AthleteHorizontalValue", AthleteHorizontalValue);
                        //cmdUpdateBackActualForce.Parameters.AddWithValue("@ModelHorizontalValue", ModelHorizontalValue);
                        cmdUpdateBackActualForce.Parameters.AddWithValue("@AthleteVerticalValue", AthleteVerticalValue);
                        //cmdUpdateBackActualForce.Parameters.AddWithValue("@ModelVerticalValue", ModelVerticalValue);
                        cmdUpdateBackActualForce.Parameters.AddWithValue("@AthleteTotalValue", AthleteTotalValue);
                        //cmdUpdateBackActualForce.Parameters.AddWithValue("@ModelTotalValue", ModelTotalValue);
                        cmdUpdateBackActualForce.Connection = con;
                        cmdUpdateBackActualForce.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        public void UpdateBackBlockActualPower()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmdUpdateBackActualPower = con.CreateCommand())
                    {
                        cmdUpdateBackActualPower.CommandType = CommandType.StoredProcedure;
                        cmdUpdateBackActualPower.CommandText = "UpdateBackBlockActualPower";
                        cmdUpdateBackActualPower.Parameters.AddWithValue("@CustomerId", CustomerId);
                        cmdUpdateBackActualPower.Parameters.AddWithValue("@LessonId", LessonId);
                        cmdUpdateBackActualPower.Parameters.AddWithValue("@AthleteHorizontalValue", AthleteHorizontalValue);
                        //cmdUpdateBackActualPower.Parameters.AddWithValue("@ModelHorizontalValue", ModelHorizontalValue);
                        cmdUpdateBackActualPower.Parameters.AddWithValue("@AthleteVerticalValue", AthleteVerticalValue);
                        //cmdUpdateBackActualPower.Parameters.AddWithValue("@ModelVerticalValue", ModelVerticalValue);
                        cmdUpdateBackActualPower.Parameters.AddWithValue("@AthleteTotalValue", AthleteTotalValue);
                        //cmdUpdateBackActualPower.Parameters.AddWithValue("@ModelTotalValue", ModelTotalValue);
                        cmdUpdateBackActualPower.Connection = con;
                        cmdUpdateBackActualPower.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        //public void UpdateBackBlockRelativeForce()
        //{
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(ConnectionString))
        //        {
        //            con.Open();
        //            using (SqlCommand cmdUpdateBackRelativeForce = con.CreateCommand())
        //            {
        //                cmdUpdateBackRelativeForce.CommandType = CommandType.StoredProcedure;
        //                cmdUpdateBackRelativeForce.CommandText = "UpdateBackBlockRelativeForce";
        //                cmdUpdateBackRelativeForce.Parameters.AddWithValue("@CustomerId", CustomerId);
        //                cmdUpdateBackRelativeForce.Parameters.AddWithValue("@LessonId", LessonId);
        //                cmdUpdateBackRelativeForce.Parameters.AddWithValue("@AthleteHorizontalValue", AthleteHorizontalValue);
        //                //cmdUpdateBackRelativeForce.Parameters.AddWithValue("@ModelHorizontalValue", ModelHorizontalValue);
        //                cmdUpdateBackRelativeForce.Parameters.AddWithValue("@AthleteVerticalValue", AthleteVerticalValue);
        //                //cmdUpdateBackRelativeForce.Parameters.AddWithValue("@ModelVerticalValue", ModelVerticalValue);
        //                cmdUpdateBackRelativeForce.Parameters.AddWithValue("@AthleteTotalValue", AthleteTotalValue);
        //                //cmdUpdateBackRelativeForce.Parameters.AddWithValue("@ModelTotalValue", ModelTotalValue);
        //                cmdUpdateBackRelativeForce.Connection = con;
        //                cmdUpdateBackRelativeForce.ExecuteNonQuery();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.Message.ToString();
        //    }
        //}

        //public void UpdateBackBlockRelativePower()
        //{
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(ConnectionString))
        //        {
        //            con.Open();
        //            using (SqlCommand cmdUpdateBackRelativePower = con.CreateCommand())
        //            {
        //                cmdUpdateBackRelativePower.CommandType = CommandType.StoredProcedure;
        //                cmdUpdateBackRelativePower.CommandText = "UpdateBackBlockRelativePower";
        //                cmdUpdateBackRelativePower.Parameters.AddWithValue("@CustomerId", CustomerId);
        //                cmdUpdateBackRelativePower.Parameters.AddWithValue("@LessonId", LessonId);
        //                cmdUpdateBackRelativePower.Parameters.AddWithValue("@AthleteHorizontalValue", AthleteHorizontalValue);
        //                //cmdUpdateBackRelativePower.Parameters.AddWithValue("@ModelHorizontalValue", ModelHorizontalValue);
        //                cmdUpdateBackRelativePower.Parameters.AddWithValue("@AthleteVerticalValue", AthleteVerticalValue);
        //                //cmdUpdateBackRelativePower.Parameters.AddWithValue("@ModelVerticalValue", ModelVerticalValue);
        //                cmdUpdateBackRelativePower.Parameters.AddWithValue("@AthleteTotalValue", AthleteTotalValue);
        //                //cmdUpdateBackRelativePower.Parameters.AddWithValue("@ModelTotalValue", ModelTotalValue);
        //                cmdUpdateBackRelativePower.Connection = con;
        //                cmdUpdateBackRelativePower.ExecuteNonQuery();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.Message.ToString();
        //    }
        //}


        /////////////Start the Region For Updating the Back Block Model Values in all the sessions//////////////////////
        public DataTable UpdateActualForce_BlockForceModelData()
        {

            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmdActualForceModelData = con.CreateCommand())
                    {
                        cmdActualForceModelData.CommandType = CommandType.StoredProcedure;
                        cmdActualForceModelData.CommandText = "UpdateActualForce_BlockForceModelData";
                        cmdActualForceModelData.Parameters.AddWithValue("@CustomerId", CustomerId);
                        //cmdActualForceModelData.Parameters.AddWithValue("@LessonId", LessonId);

                        cmdActualForceModelData.Parameters.AddWithValue("@ModelHorizontalValue", ModelHorizontalValue);

                        cmdActualForceModelData.Parameters.AddWithValue("@ModelVerticalValue", ModelVerticalValue);

                        cmdActualForceModelData.Parameters.AddWithValue("@ModelTotalValue", ModelTotalValue);
                        cmdActualForceModelData.Connection = con;
                        cmdActualForceModelData.ExecuteNonQuery();
                    }

                }
            }


            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return null;

        }


        //public DataTable UpdateRelativeForce_BlockForceModelData()
        //{

        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(ConnectionString))
        //        {
        //            con.Open();
        //            using (SqlCommand cmdRelativeForceModelData = con.CreateCommand())
        //            {
        //                cmdRelativeForceModelData.CommandType = CommandType.StoredProcedure;
        //                cmdRelativeForceModelData.CommandText = "UpdateRelativeForce_BlockForceModelData";
        //                cmdRelativeForceModelData.Parameters.AddWithValue("@CustomerId", CustomerId);


        //                cmdRelativeForceModelData.Parameters.AddWithValue("@ModelHorizontalValue", ModelHorizontalValue);

        //                cmdRelativeForceModelData.Parameters.AddWithValue("@ModelVerticalValue", ModelVerticalValue);

        //                cmdRelativeForceModelData.Parameters.AddWithValue("@ModelTotalValue", ModelTotalValue);
        //                cmdRelativeForceModelData.Connection = con;
        //                cmdRelativeForceModelData.ExecuteNonQuery();
        //            }

        //        }
        //    }


        //    catch (Exception ex)
        //    {
        //        ex.Message.ToString();
        //    }
        //    return null;

        //}


        //public DataTable UpdateRelativePower_BlockForceModelData()
        //{

        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(ConnectionString))
        //        {
        //            con.Open();
        //            using (SqlCommand cmdRelativePowerModelData = con.CreateCommand())
        //            {
        //                cmdRelativePowerModelData.CommandType = CommandType.StoredProcedure;
        //                cmdRelativePowerModelData.CommandText = "UpdateRelativePower_BlockForceModelData";
        //                cmdRelativePowerModelData.Parameters.AddWithValue("@CustomerId", CustomerId);


        //                cmdRelativePowerModelData.Parameters.AddWithValue("@ModelHorizontalValue", ModelHorizontalValue);

        //                cmdRelativePowerModelData.Parameters.AddWithValue("@ModelVerticalValue", ModelVerticalValue);

        //                cmdRelativePowerModelData.Parameters.AddWithValue("@ModelTotalValue", ModelTotalValue);
        //                cmdRelativePowerModelData.Connection = con;
        //                cmdRelativePowerModelData.ExecuteNonQuery();
        //            }

        //        }
        //    }


        //    catch (Exception ex)
        //    {
        //        ex.Message.ToString();
        //    }
        //    return null;

        //}



        public DataTable UpdateActualPower_BlockForceModelData()
        {

            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmdActualPowerModelData = con.CreateCommand())
                    {
                        cmdActualPowerModelData.CommandType = CommandType.StoredProcedure;
                        cmdActualPowerModelData.CommandText = "UpdateActualPower_BlockForceModelData";
                        cmdActualPowerModelData.Parameters.AddWithValue("@CustomerId", CustomerId);


                        cmdActualPowerModelData.Parameters.AddWithValue("@ModelHorizontalValue", ModelHorizontalValue);

                        cmdActualPowerModelData.Parameters.AddWithValue("@ModelVerticalValue", ModelVerticalValue);

                        cmdActualPowerModelData.Parameters.AddWithValue("@ModelTotalValue", ModelTotalValue);
                        cmdActualPowerModelData.Connection = con;
                        cmdActualPowerModelData.ExecuteNonQuery();
                    }

                }
            }


            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return null;

        }


        /////////////End the Region For Updating the Back Block Model Values in all the sessions//////////////////////


        /////////////Start the Region For Updating the Front Block Model Values in all the sessions//////////////////////

        public DataTable UpdateFrontActualForce_BlockForceModelData()
        {

            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmdActualForceModelData = con.CreateCommand())
                    {
                        cmdActualForceModelData.CommandType = CommandType.StoredProcedure;
                        cmdActualForceModelData.CommandText = "UpdateFrontActualForce_BlockForceModelData";
                        cmdActualForceModelData.Parameters.AddWithValue("@CustomerId", CustomerId);


                        cmdActualForceModelData.Parameters.AddWithValue("@ModelHorizontalValue", ModelHorizontalValue);

                        cmdActualForceModelData.Parameters.AddWithValue("@ModelVerticalValue", ModelVerticalValue);

                        cmdActualForceModelData.Parameters.AddWithValue("@ModelTotalValue", ModelTotalValue);
                        cmdActualForceModelData.Connection = con;
                        cmdActualForceModelData.ExecuteNonQuery();
                    }

                }
            }


            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return null;

        }


        //public DataTable UpdateFrontRelativeForce_BlockForceModelData()
        //{

        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(ConnectionString))
        //        {
        //            con.Open();
        //            using (SqlCommand cmdRelativeForceModelData = con.CreateCommand())
        //            {
        //                cmdRelativeForceModelData.CommandType = CommandType.StoredProcedure;
        //                cmdRelativeForceModelData.CommandText = "UpdateFrontRelativeForce_BlockForceModelData";
        //                cmdRelativeForceModelData.Parameters.AddWithValue("@CustomerId", CustomerId);


        //                cmdRelativeForceModelData.Parameters.AddWithValue("@ModelHorizontalValue", ModelHorizontalValue);

        //                cmdRelativeForceModelData.Parameters.AddWithValue("@ModelVerticalValue", ModelVerticalValue);

        //                cmdRelativeForceModelData.Parameters.AddWithValue("@ModelTotalValue", ModelTotalValue);
        //                cmdRelativeForceModelData.Connection = con;
        //                cmdRelativeForceModelData.ExecuteNonQuery();
        //            }

        //        }
        //    }


        //    catch (Exception ex)
        //    {
        //        ex.Message.ToString();
        //    }
        //    return null;

        //}


        //public DataTable UpdateFrontRelativePower_BlockForceModelData()
        //{

        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(ConnectionString))
        //        {
        //            con.Open();
        //            using (SqlCommand cmdRelativePowerModelData = con.CreateCommand())
        //            {
        //                cmdRelativePowerModelData.CommandType = CommandType.StoredProcedure;
        //                cmdRelativePowerModelData.CommandText = "UpdateFrontRelativePower_BlockForceModelData";
        //                cmdRelativePowerModelData.Parameters.AddWithValue("@CustomerId", CustomerId);


        //                cmdRelativePowerModelData.Parameters.AddWithValue("@ModelHorizontalValue", ModelHorizontalValue);

        //                cmdRelativePowerModelData.Parameters.AddWithValue("@ModelVerticalValue", ModelVerticalValue);

        //                cmdRelativePowerModelData.Parameters.AddWithValue("@ModelTotalValue", ModelTotalValue);
        //                cmdRelativePowerModelData.Connection = con;
        //                cmdRelativePowerModelData.ExecuteNonQuery();
        //            }

        //        }
        //    }


        //    catch (Exception ex)
        //    {
        //        ex.Message.ToString();
        //    }
        //    return null;

        //}





        public DataTable UpdateFrontActualPower_BlockForceModelData()
        {

            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmdActaulPowerModelData = con.CreateCommand())
                    {
                        cmdActaulPowerModelData.CommandType = CommandType.StoredProcedure;
                        cmdActaulPowerModelData.CommandText = "UpdateFrontActualPower_BlockForceModelData";
                        cmdActaulPowerModelData.Parameters.AddWithValue("@CustomerId", CustomerId);


                        cmdActaulPowerModelData.Parameters.AddWithValue("@ModelHorizontalValue", ModelHorizontalValue);

                        cmdActaulPowerModelData.Parameters.AddWithValue("@ModelVerticalValue", ModelVerticalValue);

                        cmdActaulPowerModelData.Parameters.AddWithValue("@ModelTotalValue", ModelTotalValue);
                        cmdActaulPowerModelData.Connection = con;
                        cmdActaulPowerModelData.ExecuteNonQuery();
                    }

                }
            }


            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return null;

        }

        /////////////End the Region For Updating the Front Block Model Values in all the sessions//////////////////////




        public void DeleteBackBlockActualForce()
        {
            try
            {

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
        public DataTable InsertIntoFrontBlockActualForce()
        {
            DataTable dtActualForce = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmdActualForce = con.CreateCommand())
                    {
                        cmdActualForce.CommandType = CommandType.StoredProcedure;
                        cmdActualForce.CommandText = "InsertInto_FrontBlockActualForce";
                        cmdActualForce.Parameters.AddWithValue("@CustomerId", CustomerId);
                        cmdActualForce.Parameters.AddWithValue("@LessonId", LessonId);
                        cmdActualForce.Parameters.AddWithValue("@ForceDate", ForceDate);
                        cmdActualForce.Parameters.AddWithValue("@AthleteHorizontalValue", AthleteHorizontalValue);
                        cmdActualForce.Parameters.AddWithValue("@ModelHorizontalValue", ModelHorizontalValue);
                        cmdActualForce.Parameters.AddWithValue("@AthleteVerticalValue", AthleteVerticalValue);
                        cmdActualForce.Parameters.AddWithValue("@ModelVerticalValue", ModelVerticalValue);
                        cmdActualForce.Parameters.AddWithValue("@AthleteTotalValue", AthleteTotalValue);
                        cmdActualForce.Parameters.AddWithValue("@ModelTotalValue", ModelTotalValue);
                        cmdActualForce.Connection = con;
                        SqlDataAdapter daActualForce = new SqlDataAdapter(cmdActualForce);
                        daActualForce.Fill(dtActualForce);
                        return dtActualForce;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return null;
            }
        }

        //public DataTable InsertIntoRelativeForces()
        //{
        //    DataTable dtRelativeForces = new DataTable();
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(ConnectionString))
        //        {
        //            con.Open();
        //            using (SqlCommand cmdRelativeForces = con.CreateCommand())
        //            {
        //                cmdRelativeForces.CommandType = CommandType.StoredProcedure;
        //                cmdRelativeForces.CommandText = "InsertInto_RelativeForces";
        //                cmdRelativeForces.Parameters.AddWithValue("@CustomerId", CustomerId);
        //                cmdRelativeForces.Parameters.AddWithValue("@LessonId", LessonId);
        //                cmdRelativeForces.Parameters.AddWithValue("@ForceDate", ForceDate);
        //                cmdRelativeForces.Parameters.AddWithValue("@AthleteHorizontalValue", AthleteHorizontalValue);
        //                cmdRelativeForces.Parameters.AddWithValue("@ModelHorizontalValue", ModelHorizontalValue);
        //                cmdRelativeForces.Parameters.AddWithValue("@AthleteVerticalValue", AthleteVerticalValue);
        //                cmdRelativeForces.Parameters.AddWithValue("@ModelVerticalValue", ModelVerticalValue);
        //                cmdRelativeForces.Parameters.AddWithValue("@AthleteTotalValue", AthleteTotalValue);
        //                cmdRelativeForces.Parameters.AddWithValue("@ModelTotalValue", ModelTotalValue);
        //                cmdRelativeForces.Connection = con;
        //                SqlDataAdapter daActualForce = new SqlDataAdapter(cmdRelativeForces);
        //                daActualForce.Fill(dtRelativeForces);
        //                return dtRelativeForces;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.Message.ToString();
        //        return null;
        //    }
        //}

        //public DataTable InsertIntoFrontBlockRelativeForces()
        //{
        //    DataTable dtRelativeForces = new DataTable();
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(ConnectionString))
        //        {
        //            con.Open();
        //            using (SqlCommand cmdRelativeForces = con.CreateCommand())
        //            {
        //                cmdRelativeForces.CommandType = CommandType.StoredProcedure;
        //                cmdRelativeForces.CommandText = "InsertInto_FrontBlockRelativeForces";
        //                cmdRelativeForces.Parameters.AddWithValue("@CustomerId", CustomerId);
        //                cmdRelativeForces.Parameters.AddWithValue("@LessonId", LessonId);
        //                cmdRelativeForces.Parameters.AddWithValue("@ForceDate", ForceDate);
        //                cmdRelativeForces.Parameters.AddWithValue("@AthleteHorizontalValue", AthleteHorizontalValue);
        //                cmdRelativeForces.Parameters.AddWithValue("@ModelHorizontalValue", ModelHorizontalValue);
        //                cmdRelativeForces.Parameters.AddWithValue("@AthleteVerticalValue", AthleteVerticalValue);
        //                cmdRelativeForces.Parameters.AddWithValue("@ModelVerticalValue", ModelVerticalValue);
        //                cmdRelativeForces.Parameters.AddWithValue("@AthleteTotalValue", AthleteTotalValue);
        //                cmdRelativeForces.Parameters.AddWithValue("@ModelTotalValue", ModelTotalValue);
        //                cmdRelativeForces.Connection = con;
        //                SqlDataAdapter daActualForce = new SqlDataAdapter(cmdRelativeForces);
        //                daActualForce.Fill(dtRelativeForces);
        //                return dtRelativeForces;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.Message.ToString();
        //        return null;
        //    }
        //}

        public DataTable InsertIntoActualPower()
        {
            DataTable dtActualPower = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmdActualPower = con.CreateCommand())
                    {
                        cmdActualPower.CommandType = CommandType.StoredProcedure;
                        cmdActualPower.CommandText = "InsertInto_ActualPower";
                        cmdActualPower.Parameters.AddWithValue("@CustomerId", CustomerId);
                        cmdActualPower.Parameters.AddWithValue("@LessonId", LessonId);
                        cmdActualPower.Parameters.AddWithValue("@ForceDate", ForceDate);
                        cmdActualPower.Parameters.AddWithValue("@AthleteHorizontalValue", AthleteHorizontalValue);
                        cmdActualPower.Parameters.AddWithValue("@ModelHorizontalValue", ModelHorizontalValue);
                        cmdActualPower.Parameters.AddWithValue("@AthleteVerticalValue", AthleteVerticalValue);
                        cmdActualPower.Parameters.AddWithValue("@ModelVerticalValue", ModelVerticalValue);
                        cmdActualPower.Parameters.AddWithValue("@AthleteTotalValue", AthleteTotalValue);
                        cmdActualPower.Parameters.AddWithValue("@ModelTotalValue", ModelTotalValue);
                        cmdActualPower.Connection = con;
                        SqlDataAdapter daActualForce = new SqlDataAdapter(cmdActualPower);
                        daActualForce.Fill(dtActualPower);
                        return dtActualPower;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return null;
            }
        }

        public DataTable InsertIntoFrontBlockActualPower()
        {
            DataTable dtActualPower = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmdActualPower = con.CreateCommand())
                    {
                        cmdActualPower.CommandType = CommandType.StoredProcedure;
                        cmdActualPower.CommandText = "InsertInto_FrontBlockActualPower";
                        cmdActualPower.Parameters.AddWithValue("@CustomerId", CustomerId);
                        cmdActualPower.Parameters.AddWithValue("@LessonId", LessonId);
                        cmdActualPower.Parameters.AddWithValue("@ForceDate", ForceDate);
                        cmdActualPower.Parameters.AddWithValue("@AthleteHorizontalValue", AthleteHorizontalValue);
                        cmdActualPower.Parameters.AddWithValue("@ModelHorizontalValue", ModelHorizontalValue);
                        cmdActualPower.Parameters.AddWithValue("@AthleteVerticalValue", AthleteVerticalValue);
                        cmdActualPower.Parameters.AddWithValue("@ModelVerticalValue", ModelVerticalValue);
                        cmdActualPower.Parameters.AddWithValue("@AthleteTotalValue", AthleteTotalValue);
                        cmdActualPower.Parameters.AddWithValue("@ModelTotalValue", ModelTotalValue);
                        cmdActualPower.Connection = con;
                        SqlDataAdapter daActualForce = new SqlDataAdapter(cmdActualPower);
                        daActualForce.Fill(dtActualPower);
                        return dtActualPower;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return null;
            }
        }

        //public DataTable InsertIntoRelativePower()
        //{
        //    DataTable dtRelativePower = new DataTable();
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(ConnectionString))
        //        {
        //            con.Open();
        //            using (SqlCommand cmdRelativePower = con.CreateCommand())
        //            {
        //                cmdRelativePower.CommandType = CommandType.StoredProcedure;
        //                cmdRelativePower.CommandText = "InsertInto_RelativePower";
        //                cmdRelativePower.Parameters.AddWithValue("@CustomerId", CustomerId);
        //                cmdRelativePower.Parameters.AddWithValue("@LessonId", LessonId);
        //                cmdRelativePower.Parameters.AddWithValue("@ForceDate", ForceDate);
        //                cmdRelativePower.Parameters.AddWithValue("@AthleteHorizontalValue", AthleteHorizontalValue);
        //                cmdRelativePower.Parameters.AddWithValue("@ModelHorizontalValue", ModelHorizontalValue);
        //                cmdRelativePower.Parameters.AddWithValue("@AthleteVerticalValue", AthleteVerticalValue);
        //                cmdRelativePower.Parameters.AddWithValue("@ModelVerticalValue", ModelVerticalValue);
        //                cmdRelativePower.Parameters.AddWithValue("@AthleteTotalValue", AthleteTotalValue);
        //                cmdRelativePower.Parameters.AddWithValue("@ModelTotalValue", ModelTotalValue);
        //                cmdRelativePower.Connection = con;
        //                SqlDataAdapter daActualForce = new SqlDataAdapter(cmdRelativePower);
        //                daActualForce.Fill(dtRelativePower);
        //                return dtRelativePower;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.Message.ToString();
        //        return null;
        //    }
        //}

        //public DataTable InsertIntoFrontBlockRelativePower()
        //{
        //    DataTable dtRelativePower = new DataTable();
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(ConnectionString))
        //        {
        //            con.Open();
        //            using (SqlCommand cmdRelativePower = con.CreateCommand())
        //            {
        //                cmdRelativePower.CommandType = CommandType.StoredProcedure;
        //                cmdRelativePower.CommandText = "InsertInto_FrontBlockRelativePower";
        //                cmdRelativePower.Parameters.AddWithValue("@CustomerId", CustomerId);
        //                cmdRelativePower.Parameters.AddWithValue("@LessonId", LessonId);
        //                cmdRelativePower.Parameters.AddWithValue("@ForceDate", ForceDate);
        //                cmdRelativePower.Parameters.AddWithValue("@AthleteHorizontalValue", AthleteHorizontalValue);
        //                cmdRelativePower.Parameters.AddWithValue("@ModelHorizontalValue", ModelHorizontalValue);
        //                cmdRelativePower.Parameters.AddWithValue("@AthleteVerticalValue", AthleteVerticalValue);
        //                cmdRelativePower.Parameters.AddWithValue("@ModelVerticalValue", ModelVerticalValue);
        //                cmdRelativePower.Parameters.AddWithValue("@AthleteTotalValue", AthleteTotalValue);
        //                cmdRelativePower.Parameters.AddWithValue("@ModelTotalValue", ModelTotalValue);
        //                cmdRelativePower.Connection = con;
        //                SqlDataAdapter daActualForce = new SqlDataAdapter(cmdRelativePower);
        //                daActualForce.Fill(dtRelativePower);
        //                return dtRelativePower;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.Message.ToString();
        //        return null;
        //    }
        //}

        public void UpdateFrontBlockActualForce()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmdUpdateFrontActualForce = con.CreateCommand())
                    {
                        cmdUpdateFrontActualForce.CommandType = CommandType.StoredProcedure;
                        cmdUpdateFrontActualForce.CommandText = "UpdateFrontBlockActualForce";
                        cmdUpdateFrontActualForce.Parameters.AddWithValue("@CustomerId", CustomerId);
                        cmdUpdateFrontActualForce.Parameters.AddWithValue("@LessonId", LessonId);
                        cmdUpdateFrontActualForce.Parameters.AddWithValue("@AthleteHorizontalValue", AthleteHorizontalValue);
                        //cmdUpdateFrontActualForce.Parameters.AddWithValue("@ModelHorizontalValue", ModelHorizontalValue);
                        cmdUpdateFrontActualForce.Parameters.AddWithValue("@AthleteVerticalValue", AthleteVerticalValue);
                        //cmdUpdateFrontActualForce.Parameters.AddWithValue("@ModelVerticalValue", ModelVerticalValue);
                        cmdUpdateFrontActualForce.Parameters.AddWithValue("@AthleteTotalValue", AthleteTotalValue);
                        //cmdUpdateFrontActualForce.Parameters.AddWithValue("@ModelTotalValue", ModelTotalValue);
                        cmdUpdateFrontActualForce.Connection = con;
                        cmdUpdateFrontActualForce.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        public void UpdateFrontBlockActualPower()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmdUpdateFrontActualPower = con.CreateCommand())
                    {
                        cmdUpdateFrontActualPower.CommandType = CommandType.StoredProcedure;
                        cmdUpdateFrontActualPower.CommandText = "UpdateFrontBlockActualPower";
                        cmdUpdateFrontActualPower.Parameters.AddWithValue("@CustomerId", CustomerId);
                        cmdUpdateFrontActualPower.Parameters.AddWithValue("@LessonId", LessonId);
                        cmdUpdateFrontActualPower.Parameters.AddWithValue("@AthleteHorizontalValue", AthleteHorizontalValue);
                        //cmdUpdateFrontActualPower.Parameters.AddWithValue("@ModelHorizontalValue", ModelHorizontalValue);
                        cmdUpdateFrontActualPower.Parameters.AddWithValue("@AthleteVerticalValue", AthleteVerticalValue);
                        //cmdUpdateFrontActualPower.Parameters.AddWithValue("@ModelVerticalValue", ModelVerticalValue);
                        cmdUpdateFrontActualPower.Parameters.AddWithValue("@AthleteTotalValue", AthleteTotalValue);
                        //cmdUpdateFrontActualPower.Parameters.AddWithValue("@ModelTotalValue", ModelTotalValue);
                        cmdUpdateFrontActualPower.Connection = con;
                        cmdUpdateFrontActualPower.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        //public void UpdateFrontBlockRelativePower()
        //{
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(ConnectionString))
        //        {
        //            con.Open();
        //            using (SqlCommand cmdUpdateFrontRelativePower = con.CreateCommand())
        //            {
        //                cmdUpdateFrontRelativePower.CommandType = CommandType.StoredProcedure;
        //                cmdUpdateFrontRelativePower.CommandText = "UpdateFrontBlockRelativePower";
        //                cmdUpdateFrontRelativePower.Parameters.AddWithValue("@CustomerId", CustomerId);
        //                cmdUpdateFrontRelativePower.Parameters.AddWithValue("@LessonId", LessonId);
        //                cmdUpdateFrontRelativePower.Parameters.AddWithValue("@AthleteHorizontalValue", AthleteHorizontalValue);
        //                //cmdUpdateFrontRelativePower.Parameters.AddWithValue("@ModelHorizontalValue", ModelHorizontalValue);
        //                cmdUpdateFrontRelativePower.Parameters.AddWithValue("@AthleteVerticalValue", AthleteVerticalValue);
        //                //cmdUpdateFrontRelativePower.Parameters.AddWithValue("@ModelVerticalValue", ModelVerticalValue);
        //                cmdUpdateFrontRelativePower.Parameters.AddWithValue("@AthleteTotalValue", AthleteTotalValue);
        //                //cmdUpdateFrontRelativePower.Parameters.AddWithValue("@ModelTotalValue", ModelTotalValue);
        //                cmdUpdateFrontRelativePower.Connection = con;
        //                cmdUpdateFrontRelativePower.ExecuteNonQuery();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.Message.ToString();
        //    }
        //}
        //public void UpdateFrontBlockRelativeForce()
        //{
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(ConnectionString))
        //        {
        //            con.Open();
        //            using (SqlCommand cmdUpdateFrontRelativeForce = con.CreateCommand())
        //            {
        //                cmdUpdateFrontRelativeForce.CommandType = CommandType.StoredProcedure;
        //                cmdUpdateFrontRelativeForce.CommandText = "UpdateFrontBlockRelativeForce";
        //                cmdUpdateFrontRelativeForce.Parameters.AddWithValue("@CustomerId", CustomerId);
        //                cmdUpdateFrontRelativeForce.Parameters.AddWithValue("@LessonId", LessonId);
        //                cmdUpdateFrontRelativeForce.Parameters.AddWithValue("@AthleteHorizontalValue", AthleteHorizontalValue);
        //                //cmdUpdateFrontRelativeForce.Parameters.AddWithValue("@ModelHorizontalValue", ModelHorizontalValue);
        //                cmdUpdateFrontRelativeForce.Parameters.AddWithValue("@AthleteVerticalValue", AthleteVerticalValue);
        //                //cmdUpdateFrontRelativeForce.Parameters.AddWithValue("@ModelVerticalValue", ModelVerticalValue);
        //                cmdUpdateFrontRelativeForce.Parameters.AddWithValue("@AthleteTotalValue", AthleteTotalValue);
        //                //cmdUpdateFrontRelativeForce.Parameters.AddWithValue("@ModelTotalValue", ModelTotalValue);
        //                cmdUpdateFrontRelativeForce.Connection = con;
        //                cmdUpdateFrontRelativeForce.ExecuteNonQuery();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.Message.ToString();
        //    }
        //}
        public void DeleteFromFrontBlockForceData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmdDeleteFrontForceData = connection.CreateCommand())
                    {
                        cmdDeleteFrontForceData.CommandType = CommandType.StoredProcedure;
                        cmdDeleteFrontForceData.CommandText = "DeleteFromFrontBlockForceData";
                        cmdDeleteFrontForceData.Parameters.AddWithValue("@CustomerId", CustomerId);
                        cmdDeleteFrontForceData.Parameters.AddWithValue("@LessonId", LessonId);
                        cmdDeleteFrontForceData.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        public void DeleteFromBackBlockForceData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmdDeleteBackForceData = connection.CreateCommand())
                    {
                        cmdDeleteBackForceData.CommandType = CommandType.StoredProcedure;
                        cmdDeleteBackForceData.CommandText = "DeleteFromBackBlockForceData";
                        cmdDeleteBackForceData.Parameters.AddWithValue("@CustomerId", CustomerId);
                        cmdDeleteBackForceData.Parameters.AddWithValue("@LessonId", LessonId);
                        cmdDeleteBackForceData.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public void Data_Delete(int _Athleteuserid, int _coachuserid)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmdDCoachAthlete = connection.CreateCommand())
                    {
                        cmdDCoachAthlete.CommandType = CommandType.StoredProcedure;
                        cmdDCoachAthlete.CommandText = "DeleteFrom_AssignAthlete";
                        //cmdDCoachAthlete.Parameters.AddWithValue("@Id", _id);
                        cmdDCoachAthlete.Parameters.AddWithValue("@AthleteUserId", _Athleteuserid);
                        cmdDCoachAthlete.Parameters.AddWithValue("@CoachUserId", _coachuserid);

                        cmdDCoachAthlete.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception err)
            {
                throw err;
            }

        }

        public void DeleteFromAssignSecondaryCoach(int _Athleteuserid)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmdDCoachAthlete = connection.CreateCommand())
                    {
                        cmdDCoachAthlete.CommandType = CommandType.StoredProcedure;
                        cmdDCoachAthlete.CommandText = "DeleteAthleteFromAssignSecondaryCoach";
                        cmdDCoachAthlete.Parameters.AddWithValue("@AthleteUserId", _Athleteuserid);

                        cmdDCoachAthlete.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception err)
            {
                throw err;
            }

        }

        public void Delete_PrimaaryCoach(int _Athleteuserid, int _coachuserid)
        {
            try
            {
                //@AthleteUserId = 14,
                //@CoachUserId = 21
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmdDCoachAthlete = connection.CreateCommand())
                    {
                        cmdDCoachAthlete.CommandType = CommandType.StoredProcedure;
                        cmdDCoachAthlete.CommandText = "DeleteFrom_AssignPrimaryCoach";
                        //cmdDCoachAthlete.Parameters.AddWithValue("@Id", _id);
                        cmdDCoachAthlete.Parameters.AddWithValue("@AthleteUserId", _Athleteuserid);
                        cmdDCoachAthlete.Parameters.AddWithValue("@CoachUserId", _coachuserid);
                        cmdDCoachAthlete.ExecuteNonQuery();
                    }
                }

                // DataRepository.CustomerProfileProvider.Update(customerprofile);
            }
            catch (Exception err)
            {
                throw err;
            }

        }

        public void DeleteFromAssignPrimaaryCoach(int _Athleteuserid)
        {
            try
            {
                //@AthleteUserId = 14,
                //@CoachUserId = 21
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmdDCoachAthlete = connection.CreateCommand())
                    {
                        cmdDCoachAthlete.CommandType = CommandType.StoredProcedure;
                        cmdDCoachAthlete.CommandText = "DeleteAthleteFromAssignPrimaryCoach";
                        cmdDCoachAthlete.Parameters.AddWithValue("@AthleteUserId", _Athleteuserid);
                        cmdDCoachAthlete.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        //--------------New Project 11-18-2019
        //--------------------------------------------------Sprint
        public DataSet GetAllSprintAthletesData(int LessonId)
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@LessonId", SqlDbType.Int).Value = LessonId;
                    cmd.CommandText = "GetAllSprintAthleteDataByLessonId";
                    cmd.Connection = conn;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    return ds;
                }
            }
        }

        public DataTable GetAllSprintAthletesDataInital(int LessonId, int MovieType)
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@LessonId", SqlDbType.Int).Value = LessonId;
                    cmd.Parameters.Add("@MovieType", SqlDbType.Int).Value = MovieType;
                    cmd.CommandText = "GetAllSprintAthleteDataFromInitialTable";
                    cmd.Connection = conn;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    return ds.Tables[0];
                }
            }
        }
        public DataTable GetAllSprintAthletesDataModel(int LessonId, int MovieType)
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@LessonId", SqlDbType.Int).Value = LessonId;
                    cmd.Parameters.Add("@MovieType", SqlDbType.Int).Value = MovieType;
                    cmd.CommandText = "GetAllSprintAthleteDataFromModelTable";
                    cmd.Connection = conn;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    return ds.Tables[0];
                }
            }
        }
        public DataTable GetAllSprintAthletesDataFinal(int LessonId, int MovieType)
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@LessonId", SqlDbType.Int).Value = LessonId;
                    cmd.Parameters.Add("@MovieType", SqlDbType.Int).Value = MovieType;
                    cmd.CommandText = "GetAllSprintAthleteDataFromFinalTable";
                    cmd.Connection = conn;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    return ds.Tables[0];
                }
            }
        }
        //------------------------------------------------------------------Start
        public DataTable GetAllStartAthletesDataInitial(int LessonId, int MovieType)
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@LessonId", SqlDbType.Int).Value = LessonId;
                    cmd.CommandText = "GetAllStartAthleteDataFromIntialTable";
                    cmd.Parameters.Add("@MovieType", SqlDbType.Int).Value = MovieType;
                    cmd.Connection = conn;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    return ds.Tables[0];
                }
            }
        }

        public DataTable GetAllStartAthletesDataFinal(int LessonId, int MovieType)
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@LessonId", SqlDbType.Int).Value = LessonId;
                    cmd.Parameters.Add("@MovieType", SqlDbType.Int).Value = MovieType;
                    cmd.CommandText = "GetAllStartAthleteDataFromCurrentTable";

                    cmd.Connection = conn;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    return ds.Tables[0];
                }
            }
        }
        public DataTable GetAllStartAthletesDataModel(int LessonId, int MovieType)
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@LessonId", SqlDbType.Int).Value = LessonId;
                    cmd.Parameters.Add("@MovieType", SqlDbType.Int).Value = MovieType;
                    cmd.CommandText = "GetAllStartAthleteDataFromModelTable";
                    cmd.Connection = conn;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    return ds.Tables[0];
                }
            }
        }

        //------------------------------------------------------------Hurdle
        public DataTable GetAllHurdleAthletesDataIntial(int LessonId, int MovieType)
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@LessonId", SqlDbType.Int).Value = LessonId;
                    cmd.Parameters.Add("@MovieType", SqlDbType.Int).Value = MovieType;
                    cmd.CommandText = "GetAllHurdleAthleteDataFromIntialTable";
                    cmd.Connection = conn;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    return ds.Tables[0];
                }
            }
        }
        public DataTable GetAllHurdleAthletesDataFinal(int LessonId, int MovieType)
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@LessonId", SqlDbType.Int).Value = LessonId;
                    cmd.Parameters.Add("@MovieType", SqlDbType.Int).Value = MovieType;
                    cmd.CommandText = "GetAllHurdleAthleteDataFromCurrentTable";
                    cmd.Connection = conn;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    return ds.Tables[0];
                }
            }
        }
        public DataTable GetAllHurdleAthletesDataModel(int LessonId, int MovieType)
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@LessonId", SqlDbType.Int).Value = LessonId;
                    cmd.CommandText = "GetAllHurdleAthleteDataFromModelTable";
                    cmd.Parameters.Add("@MovieType", SqlDbType.Int).Value = MovieType;
                    cmd.Connection = conn;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    return ds.Tables[0];
                }
            }
        }

        //-------------------------------------------------HurdleStep 
        public DataTable GetAllHurdleStepAthletesDataInitial(int LessonId, int MovieType)
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@LessonId", SqlDbType.Int).Value = LessonId;
                    cmd.Parameters.Add("@MovieType", SqlDbType.Int).Value = MovieType;
                    cmd.CommandText = "GetAllHurdleStepAthleteDataFromInitialTable";
                    cmd.Connection = conn;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    return ds.Tables[0];
                }
            }
        }
        public DataTable GetAllHurdleStepAthletesDataFinal(int LessonId, int MovieType)
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@LessonId", SqlDbType.Int).Value = LessonId;
                    cmd.Parameters.Add("@MovieType", SqlDbType.Int).Value = MovieType;
                    cmd.CommandText = "GetAllHurdleStepAthleteDataFromCurrentTable";
                    cmd.Connection = conn;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    return ds.Tables[0];
                }
            }
        }
        public DataTable GetAllHurdleStepAthletesDataModel(int LessonId, int MovieType)
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@LessonId", SqlDbType.Int).Value = LessonId;
                    cmd.Parameters.Add("@MovieType", SqlDbType.Int).Value = MovieType;
                    cmd.CommandText = "GetAllHurdleStepAthleteDataFromModelTable";
                    cmd.Connection = conn;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    return ds.Tables[0];
                }
            }
        }
        //-------------------------------------End------------------------------->>>

        public DataTable GetAllAthleteSessonData(int LessonTypeID)
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@LessonTypeID", SqlDbType.Int).Value = LessonTypeID;
                    cmd.CommandText = "GetAllAthleteEventSessonDataByLessonTypeID";
                    cmd.Connection = conn;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    // return ds;
                    return ds.Tables[0];
                }
            }
        }
        //-------------------------------------All Event Type ----------------->>
        public DataTable getAllCustmorLessionID(int CustomerId)
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CustomerId", SqlDbType.Int).Value = CustomerId;
                    cmd.CommandText = "GetStartlessionID";
                    cmd.Connection = conn;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    return ds.Tables[0];
                }
            }

        }

        public DataTable GetAllAthliteListData(int CustomerId)
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CustomerId", SqlDbType.Int).Value = CustomerId;
                    cmd.CommandText = "GetAllAthliteList";
                    cmd.Connection = conn;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    return ds.Tables[0];
                }
            }
        }
        public DataSet GetAllHurdleStepsAthletesData(int LessonId)
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@LessonId", SqlDbType.Int).Value = LessonId;
                    cmd.CommandText = "GetAllHurdleStepsAthleteDataByLessonId";
                    cmd.Connection = conn;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);

                    return ds;
                }
            }
        }

        public DataSet GetSprintSummaryModeldata(int LessonId)
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@LessonId", SqlDbType.Int).Value = LessonId;
                    cmd.CommandText = "GetAllSprintAthleteDataByLessonId";
                    cmd.Connection = conn;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);

                    return ds;
                }
            }
        }

        public DataSet GetHurdleStepsSummaryModeldata(int LessonId)
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@LessonId", SqlDbType.Int).Value = LessonId;
                    cmd.CommandText = "GetAllHurdleStepsAthleteDataByLessonId";
                    cmd.Connection = conn;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);

                    return ds;
                }
            }
        }

        public DataSet GetAllStartAthletesData(int LessonId)
        {
            try //not on server side only swaping on local machine
            {
                DataSet ds = new DataSet();
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@LessonId", SqlDbType.Int).Value = LessonId;
                        cmd.CommandText = "GetAllStartAthleteDataByLessonId";
                        cmd.Connection = conn;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                        return ds;
                    }
                }
            }
            catch (Exception ex) //not on server side only swaping on local machine
            {
                ex.Message.ToString();
                return null;
            }
        }

        public DataSet GetAllHurdleAthleteData(int LessonId)
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@LessonId", SqlDbType.Int).Value = LessonId;
                    cmd.CommandText = "GetAllHurdleAthleteDataByLessonId";
                    cmd.Connection = conn;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    return ds;
                }
            }
        }


        public DataTable GetPrimaryCoachesForAthlete(int Customerid)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmdSelectAllCoaches = connection.CreateCommand())
                    {
                        cmdSelectAllCoaches.CommandType = CommandType.StoredProcedure;
                        cmdSelectAllCoaches.CommandText = "SelectPrimaryCoachesForAthlete";
                        cmdSelectAllCoaches.Parameters.AddWithValue("@Customerid", Customerid);
                        cmdSelectAllCoaches.Connection = connection;
                        SqlDataAdapter da = new SqlDataAdapter(cmdSelectAllCoaches);
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                return dt = null;
            }
        }
        public DataTable Get_PrimaryCoach(int CustomerId)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmdSelectCoach = connection.CreateCommand())
                    {
                        cmdSelectCoach.CommandType = CommandType.StoredProcedure;
                        cmdSelectCoach.CommandText = "Get_PrimaryCoach";
                        cmdSelectCoach.Parameters.AddWithValue("@CustomerId", CustomerId);
                        cmdSelectCoach.Connection = connection;
                        SqlDataAdapter da = new SqlDataAdapter(cmdSelectCoach);
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                return dt = null;
                ex.Message.ToString();
            }
        }

        public DataTable GetAllTeachers()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmdTeachers = con.CreateCommand())
                    {
                        cmdTeachers.CommandType = CommandType.StoredProcedure;
                        cmdTeachers.CommandText = "GetAll_Teachers";
                        cmdTeachers.Connection = con;
                        SqlDataAdapter da = new SqlDataAdapter(cmdTeachers);
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return null;
        }

        public DataTable InsertIntoAssignAthleteCoach(int athleteid, int teacherid)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmdTeachers = con.CreateCommand())
                    {
                        cmdTeachers.CommandType = CommandType.StoredProcedure;
                        cmdTeachers.CommandText = "InsertInto_AssignAthleteCoach";
                        cmdTeachers.Parameters.AddWithValue("@CustomerId", athleteid);
                        cmdTeachers.Parameters.AddWithValue("@TeacherId", teacherid);
                        cmdTeachers.Connection = con;
                        SqlDataAdapter da = new SqlDataAdapter(cmdTeachers);
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return null;
        }

        public DataSet GetPrimaryCoach(int CustomerId)
        {
            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                DataSet ds = new DataSet();
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@CustomerId", SqlDbType.Int).Value = CustomerId;
                        cmd.CommandText = "GetTeacheNameById";
                        cmd.Connection = conn;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                        return ds;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return null;
            }
        }




        //public DataSet GetAllLessons()
        //{
        //    DataSet ds = new DataSet();
        //    using (SqlConnection conn = new SqlConnection(ConnectionString))
        //    {
        //        using (SqlCommand cmd = conn.CreateCommand())
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            //cmd.Parameters.Add("@LessonId", SqlDbType.Int).Value = LessonId;
        //            cmd.CommandText = "GetAll_Lesson";
        //            cmd.Connection = conn;
        //            SqlDataAdapter da = new SqlDataAdapter(cmd);
        //            da.Fill(ds);

        //            return ds;
        //        }
        //    }


        //}

        public string[] SelectParentId(string userid)
        {
            //  string strid = string.Empty;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmdSelectParentid = connection.CreateCommand())
                    {
                        cmdSelectParentid.CommandType = CommandType.StoredProcedure;
                        cmdSelectParentid.Parameters.AddWithValue("@UserId", userid);
                        cmdSelectParentid.CommandText = "SelectParentIDofUser";
                        cmdSelectParentid.Connection = connection;
                        SqlDataAdapter da = new SqlDataAdapter(cmdSelectParentid);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        int no = dt.Rows.Count;
                        String[] Parent = new String[no];
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            String parent1 = dt.Rows[i]["Parentid"].ToString();
                            // string parent2 = dt.Rows[i]["Parentid"].ToString();
                            Parent[i] = parent1;
                        }

                        // object P_id = cmdSelectParentid.ExecuteScalar();
                        //return P_id.ToString();
                        return Parent;
                    }
                }

            }
            catch (Exception ex)
            {
                ex.ToString();
                return null;
            }
        }

        public DataTable GetCoachesForAthlete(int Customerid)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmdSelectAllCoaches = connection.CreateCommand())
                    {
                        cmdSelectAllCoaches.CommandType = CommandType.StoredProcedure;
                        cmdSelectAllCoaches.CommandText = "SelectCoachesForAthlete";
                        cmdSelectAllCoaches.Parameters.AddWithValue("@Customerid", Customerid);
                        cmdSelectAllCoaches.Connection = connection;
                        SqlDataAdapter da = new SqlDataAdapter(cmdSelectAllCoaches);
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                return dt = null;
            }
        }


        public DataTable GetCoaches()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmdSelectAllCoaches = connection.CreateCommand())
                    {
                        cmdSelectAllCoaches.CommandType = CommandType.StoredProcedure;
                        cmdSelectAllCoaches.CommandText = "GetAll_Teachers";
                        cmdSelectAllCoaches.Connection = connection;
                        SqlDataAdapter da = new SqlDataAdapter(cmdSelectAllCoaches);
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                return dt = null;
            }
        }

        public DataTable GetPrimarySecondaryAthlets_Coach(int _TeacherId)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmdSelectAllAthletesofCoach = connection.CreateCommand())
                    {
                        cmdSelectAllAthletesofCoach.CommandType = CommandType.StoredProcedure;
                        cmdSelectAllAthletesofCoach.CommandText = "GetPrimarySecondaryAthletsCoach";
                        cmdSelectAllAthletesofCoach.Parameters.AddWithValue("@TeacherId", _TeacherId);
                        cmdSelectAllAthletesofCoach.Connection = connection;
                        SqlDataAdapter da = new SqlDataAdapter(cmdSelectAllAthletesofCoach);
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                return dt = null;
            }
        }

        public object GetChildID(object _Customer_id, string parentid)
        {
            try
            {
                object ChilId;
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmdupdate = connection.CreateCommand())
                    {
                        cmdupdate.CommandType = CommandType.StoredProcedure;
                        cmdupdate.CommandText = "SelectChildIDofUser";
                        cmdupdate.Parameters.AddWithValue("@CustomerID", _Customer_id);
                        cmdupdate.Parameters.AddWithValue("@Parentid", parentid);
                        ChilId = cmdupdate.ExecuteScalar();
                        return ChilId;
                    }

                }

            }
            catch (Exception err)
            {
                return err;
            }
        }
        public string SelectLessonlocation(string lid)
        {
            string strid = string.Empty;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmdSelectlocation = connection.CreateCommand())
                    {
                        cmdSelectlocation.CommandType = CommandType.StoredProcedure;
                        cmdSelectlocation.Parameters.AddWithValue("@LessonId", lid);
                        cmdSelectlocation.CommandText = "Select_Lessonlocation";
                        cmdSelectlocation.Connection = connection;
                        SqlDataReader dr = cmdSelectlocation.ExecuteReader();

                        if (dr.Read())
                        {
                            strid = Convert.ToString(dr["LessonLocation"]);
                        }
                    }
                }
                return strid;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return null;
            }
        }


        public void InsertIntoLessonLocation(int lessonid, string location, int CustomerId, int TeacherId, int SiteId, string LessonDate, int LessonTypeID, int MachineNumber)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmdTeachers = con.CreateCommand())
                    {
                        cmdTeachers.CommandType = CommandType.StoredProcedure;
                        cmdTeachers.CommandText = "InsertInto_LessonLocation";
                        cmdTeachers.Parameters.AddWithValue("@LessonId", lessonid);
                        cmdTeachers.Parameters.AddWithValue("@Location", location);
                        cmdTeachers.Parameters.AddWithValue("@TeacherId", TeacherId);
                        cmdTeachers.Parameters.AddWithValue("@SiteId", SiteId);
                        cmdTeachers.Parameters.AddWithValue("@CustomerId", CustomerId);
                        cmdTeachers.Parameters.AddWithValue("@LessonDate ", LessonDate);
                        cmdTeachers.Parameters.AddWithValue("@LessonTypeID", LessonTypeID);
                        cmdTeachers.Parameters.AddWithValue("@MachineNumber", MachineNumber);

                        cmdTeachers.Connection = con;
                        cmdTeachers.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        public void UpdateLessonLocation(string location, int lessonid)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmdTeachers = con.CreateCommand())
                    {
                        cmdTeachers.CommandType = CommandType.StoredProcedure;
                        cmdTeachers.CommandText = "Update_LessonLocation";
                        // cmdTeachers.Parameters.AddWithValue("@LessonId", lessonid);
                        cmdTeachers.Parameters.AddWithValue("@Location", location);
                        cmdTeachers.Parameters.AddWithValue("@LessonId", lessonid);
                        cmdTeachers.Connection = con;
                        cmdTeachers.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

        }
        public void InsertMovie(int lessonid, int MovieType, string DateRecorded, string FilePath)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmdTeachers = con.CreateCommand())
                    {
                        cmdTeachers.CommandType = CommandType.StoredProcedure;
                        cmdTeachers.CommandText = "sp_InsertOntrackMovie";
                        cmdTeachers.Parameters.AddWithValue("@LessonId", lessonid);
                        cmdTeachers.Parameters.AddWithValue("@MovieType", 0);
                        cmdTeachers.Parameters.AddWithValue("@DateRecorded", DateRecorded);
                        cmdTeachers.Parameters.AddWithValue("@FilePath", FilePath);
                        cmdTeachers.Connection = con;
                        cmdTeachers.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

        }
        public void InsertMovieClip(int MovieId, int BeginFrame, int EndFrame)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmdTeachers = con.CreateCommand())
                    {
                        cmdTeachers.CommandType = CommandType.StoredProcedure;
                        cmdTeachers.CommandText = "sp_InsertOntrackMovieClip";
                        cmdTeachers.Parameters.AddWithValue("@MovieId", MovieId);
                        cmdTeachers.Parameters.AddWithValue("@BeginFrame", BeginFrame);
                        cmdTeachers.Parameters.AddWithValue("@EndFrame", EndFrame);

                        cmdTeachers.Connection = con;
                        cmdTeachers.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

        }

        public int InsertMovieOnTrack(int MovieType, DateTime DateRecorded, string FilePath, int LessonId)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmdTeachers = con.CreateCommand())
                    {
                        cmdTeachers.CommandType = CommandType.StoredProcedure;
                        cmdTeachers.CommandText = "sp_InsertMovieOnTrack";
                        cmdTeachers.Parameters.AddWithValue("@MovieType", MovieType);
                        cmdTeachers.Parameters.AddWithValue("@DateRecorded", DateRecorded);
                        cmdTeachers.Parameters.AddWithValue("@FilePath", FilePath);
                        cmdTeachers.Parameters.AddWithValue("@LessonId", LessonId);
                        cmdTeachers.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmdTeachers.Connection = con;
                        cmdTeachers.ExecuteNonQuery();
                        return (int)cmdTeachers.Parameters["@id"].Value;
                    }
                }

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return 0;
            }

        }

        public int UpdateMovieOnTrack(int MovieType, DateTime DateRecorded, string FilePath, int LessonId)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmdTeachers = con.CreateCommand())
                    {
                        cmdTeachers.CommandType = CommandType.StoredProcedure;
                        cmdTeachers.CommandText = "Update_OntrackLessonMovie";
                        cmdTeachers.Parameters.AddWithValue("@MovieType", MovieType);
                        cmdTeachers.Parameters.AddWithValue("@DateRecorded", DateRecorded);
                        cmdTeachers.Parameters.AddWithValue("@FilePath", FilePath);
                        cmdTeachers.Parameters.AddWithValue("@LessonId", LessonId);
                        cmdTeachers.Connection = con;
                        cmdTeachers.ExecuteNonQuery();
                        return (int)cmdTeachers.Parameters["@MovieType"].Value;
                    }
                }

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return 0;
            }

        }


        public void UpdateOntrackLessonLocation(string location, int lessonid, DateTime LessonDate)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmdTeachers = con.CreateCommand())
                    {
                        cmdTeachers.CommandType = CommandType.StoredProcedure;
                        cmdTeachers.CommandText = "Update_OntrackLessonLocation";
                        // cmdTeachers.Parameters.AddWithValue("@LessonId", lessonid);
                        cmdTeachers.Parameters.AddWithValue("@Location", location);
                        cmdTeachers.Parameters.AddWithValue("@LessonId", lessonid);
                        cmdTeachers.Parameters.AddWithValue("@LessonDate", LessonDate);

                        cmdTeachers.Connection = con;
                        cmdTeachers.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

        }

	 public void UpdateMemberEmailID(string UserId, string Email)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmdTeachers = con.CreateCommand())
                    {
                        cmdTeachers.CommandType = CommandType.StoredProcedure;
                        cmdTeachers.CommandText = "Update_Member_Email_ID";

                        cmdTeachers.Parameters.AddWithValue("@UserId", UserId);
                        cmdTeachers.Parameters.AddWithValue("@Email", Email);

                        cmdTeachers.Connection = con;
                        cmdTeachers.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

        }

        public void UpdateLessonAndMovieDate(string location, int lessonid, DateTime movieDate)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmdTeachers = con.CreateCommand())
                    {
                        cmdTeachers.CommandType = CommandType.StoredProcedure;
                        cmdTeachers.CommandText = "Update_LessonLocationAndMovieDate";
                        cmdTeachers.Parameters.AddWithValue("@Location", location);
                        cmdTeachers.Parameters.AddWithValue("@LessonId", lessonid);
                        cmdTeachers.Parameters.AddWithValue("@MovieDate", movieDate);
                        cmdTeachers.Connection = con;
                        cmdTeachers.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

        }



        public string SelectStartInitialDataid(string lid)
        {
            string strid = string.Empty;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmdSelectStartInitialDid = connection.CreateCommand())
                    {
                        cmdSelectStartInitialDid.CommandType = CommandType.StoredProcedure;
                        cmdSelectStartInitialDid.Parameters.AddWithValue("@LessonId", lid);
                        cmdSelectStartInitialDid.CommandText = "GetStartInitialdata";
                        cmdSelectStartInitialDid.Connection = connection;
                        SqlDataReader dr = cmdSelectStartInitialDid.ExecuteReader();

                        if (dr.Read())
                        {
                            strid = Convert.ToString(dr["StartInitialDataId"]);
                        }

                    }
                }
                return strid;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return null;
            }
        }


        public string SelectStartCurrentDataid(string lid)
        {
            string strid = string.Empty;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmdSelectStartInitialDid = connection.CreateCommand())
                    {
                        cmdSelectStartInitialDid.CommandType = CommandType.StoredProcedure;
                        cmdSelectStartInitialDid.Parameters.AddWithValue("@LessonId", lid);
                        cmdSelectStartInitialDid.CommandText = "GetStartCurrentdata";
                        cmdSelectStartInitialDid.Connection = connection;
                        SqlDataReader dr = cmdSelectStartInitialDid.ExecuteReader();

                        if (dr.Read())
                        {
                            strid = Convert.ToString(dr["StartCurrentDataId"]);
                        }

                    }
                }
                return strid;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return null;
            }
        }


        public string SelectStartModelDataid(string lid)
        {
            string strid = string.Empty;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmdSelectStartInitialDid = connection.CreateCommand())
                    {
                        cmdSelectStartInitialDid.CommandType = CommandType.StoredProcedure;
                        cmdSelectStartInitialDid.Parameters.AddWithValue("@LessonId", lid);
                        cmdSelectStartInitialDid.CommandText = "GetStartModeldata";
                        cmdSelectStartInitialDid.Connection = connection;
                        SqlDataReader dr = cmdSelectStartInitialDid.ExecuteReader();

                        if (dr.Read())
                        {
                            strid = Convert.ToString(dr["StartModelDataId"]);
                        }

                    }
                }
                return strid;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return null;
            }
        }




        public string SelectSprintInitialDataid(string lid)
        {
            string strid = string.Empty;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmdSelectStartInitialDid = connection.CreateCommand())
                    {
                        cmdSelectStartInitialDid.CommandType = CommandType.StoredProcedure;
                        cmdSelectStartInitialDid.Parameters.AddWithValue("@LessonId", lid);
                        cmdSelectStartInitialDid.CommandText = "GetSprintInitialDataId";
                        cmdSelectStartInitialDid.Connection = connection;
                        SqlDataReader dr = cmdSelectStartInitialDid.ExecuteReader();
                        if (dr.Read())
                        {
                            strid = Convert.ToString(dr["SprintInitialDataId"]);
                        }

                    }
                }
                return strid;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return null;
            }
        }
        public string SelectHurdleStepsInitialDataid(string lid)
        {
            string strid = string.Empty;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmdSelectStartInitialDid = connection.CreateCommand())
                    {
                        cmdSelectStartInitialDid.CommandType = CommandType.StoredProcedure;
                        cmdSelectStartInitialDid.Parameters.AddWithValue("@LessonId", lid);
                        cmdSelectStartInitialDid.CommandText = "GetHurdleStepsInitialDataId";
                        cmdSelectStartInitialDid.Connection = connection;
                        SqlDataReader dr = cmdSelectStartInitialDid.ExecuteReader();
                        if (dr.Read())
                        {
                            strid = Convert.ToString(dr["HurdleStepsInitialDataId"]);
                        }

                    }
                }
                return strid;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return null;
            }
        }
        public string SelectSprintCurrentDataid(string lid)
        {
            string strid = string.Empty;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmdSelectStartInitialDid = connection.CreateCommand())
                    {
                        cmdSelectStartInitialDid.CommandType = CommandType.StoredProcedure;
                        cmdSelectStartInitialDid.Parameters.AddWithValue("@LessonId", lid);
                        cmdSelectStartInitialDid.CommandText = "GetSprintCurrentdata";
                        cmdSelectStartInitialDid.Connection = connection;
                        SqlDataReader dr = cmdSelectStartInitialDid.ExecuteReader();

                        if (dr.Read())
                        {
                            strid = Convert.ToString(dr["SprintcurrentDataId"]);
                        }

                    }
                }
                return strid;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return null;
            }
        }

        public string SelectHurdleStepsCurrentDataid(string lid)
        {
            string strid = string.Empty;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmdSelectStartInitialDid = connection.CreateCommand())
                    {
                        cmdSelectStartInitialDid.CommandType = CommandType.StoredProcedure;
                        cmdSelectStartInitialDid.Parameters.AddWithValue("@LessonId", lid);
                        cmdSelectStartInitialDid.CommandText = "GetHurdleStepsCurrentdataID";
                        cmdSelectStartInitialDid.Connection = connection;
                        SqlDataReader dr = cmdSelectStartInitialDid.ExecuteReader();

                        if (dr.Read())
                        {
                            strid = Convert.ToString(dr["HurdleStepscurrentDataId"]);
                        }

                    }
                }
                return strid;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return null;
            }
        }
        public string SelectSprintModelDataid(string lid)
        {
            string strid = string.Empty;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmdSelectStartInitialDid = connection.CreateCommand())
                    {
                        cmdSelectStartInitialDid.CommandType = CommandType.StoredProcedure;
                        cmdSelectStartInitialDid.Parameters.AddWithValue("@LessonId", lid);
                        cmdSelectStartInitialDid.CommandText = "GetSprintModelDataId";
                        cmdSelectStartInitialDid.Connection = connection;
                        SqlDataReader dr = cmdSelectStartInitialDid.ExecuteReader();

                        if (dr.Read())
                        {
                            strid = Convert.ToString(dr["SprintModelDataId"]);
                        }

                    }
                }
                return strid;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return null;
            }
        }
        public string SelectSprintModelOntrackDataid(string lid)
        {
            string strid = string.Empty;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmdSelectStartInitialDid = connection.CreateCommand())
                    {
                        cmdSelectStartInitialDid.CommandType = CommandType.StoredProcedure;
                        cmdSelectStartInitialDid.Parameters.AddWithValue("@LessonId", lid);
                        cmdSelectStartInitialDid.CommandText = "GetSprintModelOntrackdata";
                        cmdSelectStartInitialDid.Connection = connection;
                        SqlDataReader dr = cmdSelectStartInitialDid.ExecuteReader();

                        if (dr.Read())
                        {
                            strid = Convert.ToString(dr["SprintModelDataId"]);
                        }

                    }
                }
                return strid;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return null;
            }
        }

        public string SelectHurdleStepsModelDataid(string lid)
        {
            string strid = string.Empty;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmdSelectStartInitialDid = connection.CreateCommand())
                    {
                        cmdSelectStartInitialDid.CommandType = CommandType.StoredProcedure;
                        cmdSelectStartInitialDid.Parameters.AddWithValue("@LessonId", lid);
                        cmdSelectStartInitialDid.CommandText = "GetHurdleStepsModelDataId";
                        cmdSelectStartInitialDid.Connection = connection;
                        SqlDataReader dr = cmdSelectStartInitialDid.ExecuteReader();

                        if (dr.Read())
                        {
                            strid = Convert.ToString(dr["HurdleStepsModelDataId"]);
                        }

                    }
                }
                return strid;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return null;
            }
        }

        public string SelectHurdleInitialDataid(string lid)
        {
            string strid = string.Empty;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmdSelectStartInitialDid = connection.CreateCommand())
                    {
                        cmdSelectStartInitialDid.CommandType = CommandType.StoredProcedure;
                        cmdSelectStartInitialDid.Parameters.AddWithValue("@LessonId", lid);
                        cmdSelectStartInitialDid.CommandText = "GetHurdleInitialdataId";
                        cmdSelectStartInitialDid.Connection = connection;
                        SqlDataReader dr = cmdSelectStartInitialDid.ExecuteReader();

                        if (dr.Read())
                        {
                            strid = Convert.ToString(dr["HurdleInitialDataId"]);
                        }

                    }
                }
                return strid;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return null;
            }
        }

        public string SelectHurdleModelDataid(string lid)
        {
            string strid = string.Empty;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmdSelectStartInitialDid = connection.CreateCommand())
                    {
                        cmdSelectStartInitialDid.CommandType = CommandType.StoredProcedure;
                        cmdSelectStartInitialDid.Parameters.AddWithValue("@LessonId", lid);
                        cmdSelectStartInitialDid.CommandText = "GetHurdleModeldataId";
                        cmdSelectStartInitialDid.Connection = connection;
                        SqlDataReader dr = cmdSelectStartInitialDid.ExecuteReader();

                        if (dr.Read())
                        {
                            strid = Convert.ToString(dr["HurdleModelDataId"]);
                        }

                    }
                }
                return strid;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return null;
            }
        }

        public string SelectHurdleCurrentDataid(string lid)
        {
            string strid = string.Empty;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmdSelectStartInitialDid = connection.CreateCommand())
                    {
                        cmdSelectStartInitialDid.CommandType = CommandType.StoredProcedure;
                        cmdSelectStartInitialDid.Parameters.AddWithValue("@LessonId", lid);
                        cmdSelectStartInitialDid.CommandText = "GetHurdleCurrentdataId";
                        cmdSelectStartInitialDid.Connection = connection;
                        SqlDataReader dr = cmdSelectStartInitialDid.ExecuteReader();

                        if (dr.Read())
                        {
                            strid = Convert.ToString(dr["HurdleCurrentDataId"]);
                        }

                    }
                }
                return strid;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return null;
            }
        }
        public DataTable InsertIntoAssignPrimaryCoach(int athleteid, int teacherid)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmdTeachers = con.CreateCommand())
                    {
                        cmdTeachers.CommandType = CommandType.StoredProcedure;
                        cmdTeachers.CommandText = "InsertInto_AssignPrimaryCoach";
                        cmdTeachers.Parameters.AddWithValue("@CustomerId", athleteid);
                        cmdTeachers.Parameters.AddWithValue("@TeacherId", teacherid);
                        cmdTeachers.Connection = con;
                        SqlDataAdapter da = new SqlDataAdapter(cmdTeachers);
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return null;
        }

        public DataTable UpdateAssignPrimaryCoach(int athleteid, int teacherid)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmdTeachers = con.CreateCommand())
                    {
                        cmdTeachers.CommandType = CommandType.StoredProcedure;
                        cmdTeachers.CommandText = "Update_AssignPrimaryCoach";
                        cmdTeachers.Parameters.AddWithValue("@CustomerId", athleteid);
                        cmdTeachers.Parameters.AddWithValue("@TeacherId", teacherid);
                        cmdTeachers.Connection = con;
                        SqlDataAdapter da = new SqlDataAdapter(cmdTeachers);
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return null;
        }


        public DataTable UpdateCustomerProfile_Customersite(int Teacherid, int CustomerSiteid)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmdSite = con.CreateCommand())
                    {
                        cmdSite.CommandType = CommandType.StoredProcedure;
                        cmdSite.CommandText = "UpdateCustomerProfile_CustomerSite";
                        cmdSite.Parameters.AddWithValue("@Teacherid", Teacherid);
                        cmdSite.Parameters.AddWithValue("@CustomerSiteid", CustomerSiteid);
                        cmdSite.Connection = con;
                        SqlDataAdapter da = new SqlDataAdapter(cmdSite);
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return null;
        }


        public Guid GetRollIdByUserId(Guid userid)
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            Guid rollid = new Guid();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmdSelectlocation = connection.CreateCommand())
                {
                    cmdSelectlocation.CommandType = CommandType.StoredProcedure;
                    cmdSelectlocation.Parameters.AddWithValue("@UserId", userid);
                    cmdSelectlocation.CommandText = "Get_UserRole";
                    cmdSelectlocation.Connection = connection;
                    SqlDataReader dr = cmdSelectlocation.ExecuteReader();

                    if (dr.Read())
                    {
                        Guid temp = new Guid(dr["RoleID"].ToString());
                        rollid = temp;
                    }
                }
            }
            return rollid;
        }

        public DataTable GetMembers(string _firstname, string _lastname, int _teacherId)
        {
            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                DataTable dt = new DataTable();
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FirstName", SqlDbType.VarChar).Value = _firstname;
                        cmd.Parameters.AddWithValue("@LastName", SqlDbType.VarChar).Value = _lastname;
                        cmd.Parameters.AddWithValue("@TeacherId", _teacherId);
                        cmd.CommandText = "GetMembers";
                        cmd.Connection = conn;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return null;
            }
        }


        public DataTable GetPrimaryAthletsCoach(int teacherid)
        {
            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                DataTable dt = new DataTable();
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TeacherId", teacherid);
                        cmd.CommandText = "GetPrimaryAthletsCoach";
                        cmd.Connection = conn;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return null;
            }
        }
        public DataTable GetSecondaryAthlets_Coach(int teacherid)
        {
            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                DataTable dt = new DataTable();
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TeacherId", teacherid);
                        cmd.CommandText = "GetSecondaryAthletsCoach";
                        cmd.Connection = conn;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return null;
            }
        }
        public DataSet Get_TeacherMembers(string _firstname, string _lastname)
        {
            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                DataSet ds = new DataSet();
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FirstName", SqlDbType.VarChar).Value = _firstname;
                        cmd.Parameters.AddWithValue("@LastName", SqlDbType.VarChar).Value = _lastname;
                        // cmd.Parameters.AddWithValue("@TeacherId", _teacherId);
                        cmd.CommandText = "GetTeacherMembers";
                        cmd.Connection = conn;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                    }
                }
                return ds;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return null;
            }
        }

        public DataTable Get_AthleteMembers(string _firstname, string _lastname)
        {
            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                DataTable dt = new DataTable();
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FirstName", SqlDbType.VarChar).Value = _firstname;
                        cmd.Parameters.AddWithValue("@LastName", SqlDbType.VarChar).Value = _lastname;
                        // cmd.Parameters.AddWithValue("@TeacherId", _teacherId);
                        cmd.CommandText = "GetAthleteMembers";
                        cmd.Connection = conn;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return null;
            }
        }

        public void DeleteCustomerProfileByCustomerId(int _Customerid)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmdCustomerProfile = connection.CreateCommand())
                    {
                        cmdCustomerProfile.CommandType = CommandType.StoredProcedure;
                        cmdCustomerProfile.CommandText = "[dbo].[DeleteCustomerProfileByCustomerId]";
                        cmdCustomerProfile.Parameters.AddWithValue("@CustomerId", _Customerid);

                        cmdCustomerProfile.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception err)
            {
                throw err;
            }

        }

        //public bool FindOnTrackSession()
        //{
        //    using (SqlConnection connection = new SqlConnection(ConnectionString))
        //    {
        //        var queryString = " SELECT * FROM  Lesson WHERE  LessonLocation='On-Track Sesssion Summary'";
        //        //var queryString= "SELECT LessonLocation,LessonId FROM Lesson WHERE LessonLocation='On-Track Sesssion Summary'";
        //        SqlCommand command = new SqlCommand(queryString, connection);
        //        connection.Open();
        //        SqlDataReader reader = command.ExecuteReader();
        //        try
        //        {
        //            if (reader.HasRows)
        //            {
        //                return false;
        //            }
        //            else
        //            {
        //                return true;
        //            }
        //        }
        //        finally
        //        {
        //            reader.Close();
        //        }
        //    }
        //}
    }
}