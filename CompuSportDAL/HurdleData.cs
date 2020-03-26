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
    public class HurdleData
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();

        public int LessonId { get; set; }
        public decimal GroundTimeInto { get; set; }
        public decimal GroundTimeOff { get; set; }
        public decimal AirTimeOver { get; set; }
        public decimal StrideLengthInto { get; set; }
        public decimal StrideLengthOff { get; set; }
        public decimal StrideLengthTotal { get; set; }
        public decimal Velocity { get; set; }
        public decimal COGDistanceInto { get; set; }
        public decimal COGDistanceOff { get; set; }
        public decimal KSTouchDownInto { get; set; }
        public decimal KSTouchDownOff { get; set; }
        public decimal TTDAngleInto { get; set; }
        public decimal TTAngleInto { get; set; }
        public decimal TMAngleOver { get; set; }
        public decimal TTDAngleOff { get; set; }
        public decimal TTAngleOff { get; set; }
        public int ULAngleTDInto { get; set; }
        public int ULMAngleOver { get; set; }
        public int ULAngleTOInto { get; set; }
        public int ULAngleTDOff { get; set; }
        public int ULAngleTOOff { get; set; }
        public decimal KAMSeparationOver { get; set; }
        public int LeadLegMinimumAngle { get; set; }
        public int LeadLegAngleAC { get; set; }
        public int LLMAngleOver { get; set; }
        public int LLAngleTDOff { get; set; }
        public int LLAngleTOOff { get; set; }


        // Relay Data Properties

        public int CustomerId { get; set; }
        public int RelayVelocityIn { get; set; }
        public int RelayVelocityOut { get; set; }
        public int RelayStart { get; set; }
        public int MeterTime { get; set; }



        #region[HurdleIntial Data]
        public void InsertIntoHurdleInitialData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmdInsert = connection.CreateCommand())
                    {
                        cmdInsert.CommandType = CommandType.StoredProcedure;
                        cmdInsert.CommandText = "InsertIntoHurdleInitialData";

                        cmdInsert.Parameters.AddWithValue("@LessonId", LessonId);
                        cmdInsert.Parameters.AddWithValue("@GroundTimeInto", GroundTimeInto);
                        cmdInsert.Parameters.AddWithValue("@GroundTimeOff", GroundTimeOff);
                        cmdInsert.Parameters.AddWithValue("@AirTimeOver", AirTimeOver);
                        cmdInsert.Parameters.AddWithValue("@StrideLengthInto", StrideLengthInto);
                        cmdInsert.Parameters.AddWithValue("@StrideLengthOff", StrideLengthOff);
                        cmdInsert.Parameters.AddWithValue("@StrideLengthTotal", StrideLengthTotal);
                        cmdInsert.Parameters.AddWithValue("@Velocity", Velocity);
                        cmdInsert.Parameters.AddWithValue("@COGDistanceInto", COGDistanceInto);
                        cmdInsert.Parameters.AddWithValue("@COGDistanceOff", COGDistanceOff);

                        cmdInsert.Parameters.AddWithValue("@ULAngleTDInto", ULAngleTDInto);
                        cmdInsert.Parameters.AddWithValue("@ULMAngleOver", ULMAngleOver);
                        cmdInsert.Parameters.AddWithValue("@ULAngleTOInto", ULAngleTOInto);
                        cmdInsert.Parameters.AddWithValue("@ULAngleTDOff", ULAngleTDOff);
                        cmdInsert.Parameters.AddWithValue("@ULAngleTOOff", ULAngleTOOff);
                        cmdInsert.Parameters.AddWithValue("@KAMSeparationOver", KAMSeparationOver);
                        cmdInsert.Parameters.AddWithValue("@LeadLegMinimumAngle", LeadLegMinimumAngle);
                        cmdInsert.Parameters.AddWithValue("@LeadLegAngleAC", LeadLegAngleAC);
                        cmdInsert.Parameters.AddWithValue("@LLMAngleOver", LLMAngleOver);
                        cmdInsert.Parameters.AddWithValue("@LLAngleTDOff", LLAngleTDOff);
                        cmdInsert.Parameters.AddWithValue("@LLAngleTOOff", LLAngleTOOff);
                        cmdInsert.Parameters.AddWithValue("@KSTouchDownInto", KSTouchDownInto);
                        cmdInsert.Parameters.AddWithValue("@KSTouchDownOff", KSTouchDownOff);
                        cmdInsert.Parameters.AddWithValue("@TTDAngleInto", TTDAngleInto);
                        cmdInsert.Parameters.AddWithValue("@TTAngleInto", TTAngleInto);
                        cmdInsert.Parameters.AddWithValue("@TMAngleOver", TMAngleOver);
                        cmdInsert.Parameters.AddWithValue("@TTDAngleOff", TTDAngleOff);
                        cmdInsert.Parameters.AddWithValue("@TTAngleOff", TTAngleOff);

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
        public void UpdateHurdleInitialData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmdInsert = connection.CreateCommand())
                    {
                        cmdInsert.CommandType = CommandType.StoredProcedure;
                        cmdInsert.CommandText = "UpdateHurdleInitialData";

                        cmdInsert.Parameters.AddWithValue("@LessonId", LessonId);
                        cmdInsert.Parameters.AddWithValue("@GroundTimeInto", GroundTimeInto);
                        cmdInsert.Parameters.AddWithValue("@GroundTimeOff", GroundTimeOff);
                        cmdInsert.Parameters.AddWithValue("@AirTimeOver", AirTimeOver);
                        cmdInsert.Parameters.AddWithValue("@StrideLengthInto", StrideLengthInto);
                        cmdInsert.Parameters.AddWithValue("@StrideLengthOff", StrideLengthOff);
                        cmdInsert.Parameters.AddWithValue("@StrideLengthTotal", StrideLengthTotal);
                        cmdInsert.Parameters.AddWithValue("@Velocity", Velocity);
                        cmdInsert.Parameters.AddWithValue("@COGDistanceInto", COGDistanceInto);
                        cmdInsert.Parameters.AddWithValue("@COGDistanceOff", COGDistanceOff);
                        cmdInsert.Parameters.AddWithValue("@ULAngleTDInto", ULAngleTDInto);
                        cmdInsert.Parameters.AddWithValue("@ULMAngleOver", ULMAngleOver);
                        cmdInsert.Parameters.AddWithValue("@ULAngleTOInto", ULAngleTOInto);
                        cmdInsert.Parameters.AddWithValue("@ULAngleTDOff", ULAngleTDOff);
                        cmdInsert.Parameters.AddWithValue("@ULAngleTOOff", ULAngleTOOff);
                        cmdInsert.Parameters.AddWithValue("@KAMSeparationOver", KAMSeparationOver);
                        cmdInsert.Parameters.AddWithValue("@LeadLegMinimumAngle", LeadLegMinimumAngle);
                        cmdInsert.Parameters.AddWithValue("@LeadLegAngleAC", LeadLegAngleAC);
                        cmdInsert.Parameters.AddWithValue("@LLMAngleOver", LLMAngleOver);
                        cmdInsert.Parameters.AddWithValue("@LLAngleTDOff", LLAngleTDOff);
                        cmdInsert.Parameters.AddWithValue("@LLAngleTOOff", LLAngleTOOff);
                        cmdInsert.Parameters.AddWithValue("@KSTouchDownInto", KSTouchDownInto);
                        cmdInsert.Parameters.AddWithValue("@KSTouchDownOff", KSTouchDownOff);
                        cmdInsert.Parameters.AddWithValue("@TTDAngleInto", TTDAngleInto);
                        cmdInsert.Parameters.AddWithValue("@TTAngleInto", TTAngleInto);
                        cmdInsert.Parameters.AddWithValue("@TMAngleOver", TMAngleOver);
                        cmdInsert.Parameters.AddWithValue("@TTDAngleOff", TTDAngleOff);
                        cmdInsert.Parameters.AddWithValue("@TTAngleOff", TTAngleOff);

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
        public void DeleteHurdleInitialLessonData(int LessonId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmdDelete = connection.CreateCommand())
                    {
                        cmdDelete.CommandType = CommandType.StoredProcedure;
                        cmdDelete.CommandText = "DeleteFromHurdleInitialData";
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
        #endregion[HurdleIntial Data]

        #region[HurdleModel Data]
        public void InsertIntoHurdleModelData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmdInsert = connection.CreateCommand())
                    {
                        cmdInsert.CommandType = CommandType.StoredProcedure;
                        cmdInsert.CommandText = "InsertIntoHurdleModelData";

                        cmdInsert.Parameters.AddWithValue("@LessonId", LessonId);
                        cmdInsert.Parameters.AddWithValue("@GroundTimeInto", GroundTimeInto);
                        cmdInsert.Parameters.AddWithValue("@GroundTimeOff", GroundTimeOff);
                        cmdInsert.Parameters.AddWithValue("@AirTimeOver", AirTimeOver);
                        cmdInsert.Parameters.AddWithValue("@StrideLengthInto", StrideLengthInto);
                        cmdInsert.Parameters.AddWithValue("@StrideLengthOff", StrideLengthOff);
                        cmdInsert.Parameters.AddWithValue("@StrideLengthTotal", StrideLengthTotal);
                        cmdInsert.Parameters.AddWithValue("@Velocity", Velocity);
                        cmdInsert.Parameters.AddWithValue("@COGDistanceInto", COGDistanceInto);
                        cmdInsert.Parameters.AddWithValue("@COGDistanceOff", COGDistanceOff);
                        cmdInsert.Parameters.AddWithValue("@KSTouchDownInto", KSTouchDownInto);
                        cmdInsert.Parameters.AddWithValue("@KSTouchDownOff", KSTouchDownOff);
                        cmdInsert.Parameters.AddWithValue("@TTDAngleInto", TTDAngleInto);
                        cmdInsert.Parameters.AddWithValue("@TTAngleInto", TTAngleInto);
                        cmdInsert.Parameters.AddWithValue("@TMAngleOver", TMAngleOver);
                        cmdInsert.Parameters.AddWithValue("@TTDAngleOff", TTDAngleOff);
                        cmdInsert.Parameters.AddWithValue("@TTAngleOff", TTAngleOff);
                        cmdInsert.Parameters.AddWithValue("@ULAngleTDInto", ULAngleTDInto);
                        cmdInsert.Parameters.AddWithValue("@ULMAngleOver", ULMAngleOver);
                        cmdInsert.Parameters.AddWithValue("@ULAngleTOInto", ULAngleTOInto);
                        cmdInsert.Parameters.AddWithValue("@ULAngleTDOff", ULAngleTDOff);
                        cmdInsert.Parameters.AddWithValue("@ULAngleTOOff", ULAngleTOOff);
                        cmdInsert.Parameters.AddWithValue("@KAMSeparationOver", KAMSeparationOver);
                        cmdInsert.Parameters.AddWithValue("@LeadLegMinimumAngle", LeadLegMinimumAngle);
                        cmdInsert.Parameters.AddWithValue("@LeadLegAngleAC", LeadLegAngleAC);
                        cmdInsert.Parameters.AddWithValue("@LLMAngleOver", LLMAngleOver);
                        cmdInsert.Parameters.AddWithValue("@LLAngleTDOff", LLAngleTDOff);
                        cmdInsert.Parameters.AddWithValue("@LLAngleTOOff", LLAngleTOOff);
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
        public void UpdateHurdleModelData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmdInsert = connection.CreateCommand())
                    {
                        cmdInsert.CommandType = CommandType.StoredProcedure;
                        cmdInsert.CommandText = "UpdateHurdleModelData";

                        cmdInsert.Parameters.AddWithValue("@LessonId", LessonId);
                        cmdInsert.Parameters.AddWithValue("@GroundTimeInto", GroundTimeInto);
                        cmdInsert.Parameters.AddWithValue("@GroundTimeOff", GroundTimeOff);
                        cmdInsert.Parameters.AddWithValue("@AirTimeOver", AirTimeOver);
                        cmdInsert.Parameters.AddWithValue("@StrideLengthInto", StrideLengthInto);
                        cmdInsert.Parameters.AddWithValue("@StrideLengthOff", StrideLengthOff);
                        cmdInsert.Parameters.AddWithValue("@StrideLengthTotal", StrideLengthTotal);
                        cmdInsert.Parameters.AddWithValue("@Velocity", Velocity);
                        cmdInsert.Parameters.AddWithValue("@COGDistanceInto", COGDistanceInto);
                        cmdInsert.Parameters.AddWithValue("@COGDistanceOff", COGDistanceOff);
                        cmdInsert.Parameters.AddWithValue("@KSTouchDownInto", KSTouchDownInto);
                        cmdInsert.Parameters.AddWithValue("@KSTouchDownOff", KSTouchDownOff);
                        cmdInsert.Parameters.AddWithValue("@TTDAngleInto", TTDAngleInto);
                        cmdInsert.Parameters.AddWithValue("@TTAngleInto", TTAngleInto);
                        cmdInsert.Parameters.AddWithValue("@TMAngleOver", TMAngleOver);
                        cmdInsert.Parameters.AddWithValue("@TTDAngleOff", TTDAngleOff);
                        cmdInsert.Parameters.AddWithValue("@TTAngleOff", TTAngleOff);
                        cmdInsert.Parameters.AddWithValue("@ULAngleTDInto", ULAngleTDInto);
                        cmdInsert.Parameters.AddWithValue("@ULMAngleOver", ULMAngleOver);
                        cmdInsert.Parameters.AddWithValue("@ULAngleTOInto", ULAngleTOInto);
                        cmdInsert.Parameters.AddWithValue("@ULAngleTDOff", ULAngleTDOff);
                        cmdInsert.Parameters.AddWithValue("@ULAngleTOOff", ULAngleTOOff);
                        cmdInsert.Parameters.AddWithValue("@KAMSeparationOver", KAMSeparationOver);
                        cmdInsert.Parameters.AddWithValue("@LeadLegMinimumAngle", LeadLegMinimumAngle);
                        cmdInsert.Parameters.AddWithValue("@LeadLegAngleAC", LeadLegAngleAC);
                        cmdInsert.Parameters.AddWithValue("@LLMAngleOver", LLMAngleOver);
                        cmdInsert.Parameters.AddWithValue("@LLAngleTDOff", LLAngleTDOff);
                        cmdInsert.Parameters.AddWithValue("@LLAngleTOOff", LLAngleTOOff);
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
        public void DeleteHurdleCurrentLessonData(int LessonId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmdDelete = connection.CreateCommand())
                    {
                        cmdDelete.CommandType = CommandType.StoredProcedure;
                        cmdDelete.CommandText = "DeleteFromHurdleCurrentData";
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
        #endregion[HurdleModel Data]

        #region[HurdleCurrent Data]
        public void InsertIntoHurdleCurrentData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmdInsert = connection.CreateCommand())
                    {
                        cmdInsert.CommandType = CommandType.StoredProcedure;
                        cmdInsert.CommandText = "InsertIntoHurdleCurrentData";

                        cmdInsert.Parameters.AddWithValue("@LessonId", LessonId);
                        cmdInsert.Parameters.AddWithValue("@GroundTimeInto", GroundTimeInto);
                        cmdInsert.Parameters.AddWithValue("@GroundTimeOff", GroundTimeOff);
                        cmdInsert.Parameters.AddWithValue("@AirTimeOver", AirTimeOver);
                        cmdInsert.Parameters.AddWithValue("@StrideLengthInto", StrideLengthInto);
                        cmdInsert.Parameters.AddWithValue("@StrideLengthOff", StrideLengthOff);
                        cmdInsert.Parameters.AddWithValue("@StrideLengthTotal", StrideLengthTotal);
                        cmdInsert.Parameters.AddWithValue("@Velocity", Velocity);
                        cmdInsert.Parameters.AddWithValue("@COGDistanceInto", COGDistanceInto);
                        cmdInsert.Parameters.AddWithValue("@COGDistanceOff", COGDistanceOff);

                        cmdInsert.Parameters.AddWithValue("@ULAngleTDInto", ULAngleTDInto);
                        cmdInsert.Parameters.AddWithValue("@ULMAngleOver", ULMAngleOver);
                        cmdInsert.Parameters.AddWithValue("@ULAngleTOInto", ULAngleTOInto);
                        cmdInsert.Parameters.AddWithValue("@ULAngleTDOff", ULAngleTDOff);
                        cmdInsert.Parameters.AddWithValue("@ULAngleTOOff", ULAngleTOOff);
                        cmdInsert.Parameters.AddWithValue("@KAMSeparationOver", KAMSeparationOver);
                        cmdInsert.Parameters.AddWithValue("@LeadLegMinimumAngle", LeadLegMinimumAngle);
                        cmdInsert.Parameters.AddWithValue("@LeadLegAngleAC", LeadLegAngleAC);
                        cmdInsert.Parameters.AddWithValue("@LLMAngleOver", LLMAngleOver);
                        cmdInsert.Parameters.AddWithValue("@LLAngleTDOff", LLAngleTDOff);
                        cmdInsert.Parameters.AddWithValue("@LLAngleTOOff", LLAngleTOOff);
                        cmdInsert.Parameters.AddWithValue("@KSTouchDownInto", KSTouchDownInto);
                        cmdInsert.Parameters.AddWithValue("@KSTouchDownOff", KSTouchDownOff);
                        cmdInsert.Parameters.AddWithValue("@TTDAngleInto", TTDAngleInto);
                        cmdInsert.Parameters.AddWithValue("@TTAngleInto", TTAngleInto);
                        cmdInsert.Parameters.AddWithValue("@TMAngleOver", TMAngleOver);
                        cmdInsert.Parameters.AddWithValue("@TTDAngleOff", TTDAngleOff);
                        cmdInsert.Parameters.AddWithValue("@TTAngleOff", TTAngleOff);
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
        public void UpdateHurdleCurrentData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmdInsert = connection.CreateCommand())
                    {
                        cmdInsert.CommandType = CommandType.StoredProcedure;
                        cmdInsert.CommandText = "UpdateHurdleCurrentData";

                        cmdInsert.Parameters.AddWithValue("@LessonId", LessonId);
                        cmdInsert.Parameters.AddWithValue("@GroundTimeInto", GroundTimeInto);
                        cmdInsert.Parameters.AddWithValue("@GroundTimeOff", GroundTimeOff);
                        cmdInsert.Parameters.AddWithValue("@AirTimeOver", AirTimeOver);
                        cmdInsert.Parameters.AddWithValue("@StrideLengthInto", StrideLengthInto);
                        cmdInsert.Parameters.AddWithValue("@StrideLengthOff", StrideLengthOff);
                        cmdInsert.Parameters.AddWithValue("@StrideLengthTotal", StrideLengthTotal);
                        cmdInsert.Parameters.AddWithValue("@Velocity", Velocity);
                        cmdInsert.Parameters.AddWithValue("@COGDistanceInto", COGDistanceInto);
                        cmdInsert.Parameters.AddWithValue("@COGDistanceOff", COGDistanceOff);
                        cmdInsert.Parameters.AddWithValue("@ULAngleTDInto", ULAngleTDInto);
                        cmdInsert.Parameters.AddWithValue("@ULMAngleOver", ULMAngleOver);
                        cmdInsert.Parameters.AddWithValue("@ULAngleTOInto", ULAngleTOInto);
                        cmdInsert.Parameters.AddWithValue("@ULAngleTDOff", ULAngleTDOff);
                        cmdInsert.Parameters.AddWithValue("@ULAngleTOOff", ULAngleTOOff);
                        cmdInsert.Parameters.AddWithValue("@KAMSeparationOver", KAMSeparationOver);
                        cmdInsert.Parameters.AddWithValue("@LeadLegMinimumAngle", LeadLegMinimumAngle);
                        cmdInsert.Parameters.AddWithValue("@LeadLegAngleAC", LeadLegAngleAC);
                        cmdInsert.Parameters.AddWithValue("@LLMAngleOver", LLMAngleOver);
                        cmdInsert.Parameters.AddWithValue("@LLAngleTDOff", LLAngleTDOff);
                        cmdInsert.Parameters.AddWithValue("@LLAngleTOOff", LLAngleTOOff);
                        cmdInsert.Parameters.AddWithValue("@KSTouchDownInto", KSTouchDownInto);
                        cmdInsert.Parameters.AddWithValue("@KSTouchDownOff", KSTouchDownOff);
                        cmdInsert.Parameters.AddWithValue("@TTDAngleInto", TTDAngleInto);
                        cmdInsert.Parameters.AddWithValue("@TTAngleInto", TTAngleInto);
                        cmdInsert.Parameters.AddWithValue("@TMAngleOver", TMAngleOver);
                        cmdInsert.Parameters.AddWithValue("@TTDAngleOff", TTDAngleOff);
                        cmdInsert.Parameters.AddWithValue("@TTAngleOff", TTAngleOff);
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
        public void DeleteHurdleModelLessonData(int LessonId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmdDelete = connection.CreateCommand())
                    {
                        cmdDelete.CommandType = CommandType.StoredProcedure;
                        cmdDelete.CommandText = "DeleteFromHurdleModelData";
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
        #endregion[HurdleCurrent Data]

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

        //#region[Relay Data]
        public void InsertIntoRelayData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmdInsert = connection.CreateCommand())
                    {
                        cmdInsert.CommandType = CommandType.StoredProcedure;
                        cmdInsert.CommandText = "InsertIntoRelayInitialData";

                        cmdInsert.Parameters.AddWithValue("@CustomerId", CustomerId);
                        cmdInsert.Parameters.AddWithValue("@RelayVelocityIn", RelayVelocityIn);
                        cmdInsert.Parameters.AddWithValue("@RelayVelocityOut", RelayVelocityOut);
                        cmdInsert.Parameters.AddWithValue("@RelayStart", RelayStart);
                        cmdInsert.Parameters.AddWithValue("@MeterTime", MeterTime);


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
        public void UpdateRelayData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmdInsert = connection.CreateCommand())
                    {
                        cmdInsert.CommandType = CommandType.StoredProcedure;
                        cmdInsert.CommandText = "InsertIntoRelayInitialData";

                        cmdInsert.Parameters.AddWithValue("@CustomerId", CustomerId);
                        cmdInsert.Parameters.AddWithValue("@RelayVelocityIn", RelayVelocityIn);
                        cmdInsert.Parameters.AddWithValue("@RelayVelocityOut", RelayVelocityOut);
                        cmdInsert.Parameters.AddWithValue("@RelayStart", RelayStart);
                        cmdInsert.Parameters.AddWithValue("@MeterTime", MeterTime);


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

        internal void SetdataHurdle(DataRow drData)
        {
            LessonId = convertToInt(drData[LessonId]);

            GroundTimeInto = convertToDecimal(drData["GroundTimeInto"]);
            GroundTimeOff = convertToDecimal(drData["GroundTimeOff"]);
            AirTimeOver = convertToDecimal(drData["AirTimeOver"]);
            StrideLengthInto = convertToDecimal(drData["StrideLengthInto"]);
            StrideLengthOff = convertToDecimal(drData["StrideLengthOff"]);
            StrideLengthTotal = convertToDecimal(drData["StrideLengthTotal"]);
            Velocity = convertToDecimal(drData["Velocity"]);
            COGDistanceInto = convertToDecimal(drData["COGDistanceInto"]);
            COGDistanceOff = convertToDecimal(drData["COGDistanceOff"]);
            KSTouchDownInto = convertToDecimal(drData["KSTouchDownInto"]);
            KSTouchDownOff = convertToDecimal(drData["KSTouchDownOff"]);
            TTDAngleInto = convertToDecimal(drData["TTDAngleInto"]);
            TTAngleInto = convertToDecimal(drData["TTAngleInto"]);
            TMAngleOver = convertToDecimal(drData["TMAngleOver"]);
            TTDAngleOff = convertToDecimal(drData["TTDAngleOff"]);
            TTAngleOff = convertToDecimal(drData["TTAngleOff"]);
            ULAngleTDInto = convertToInt(drData["ULAngleTDInto"]);
            ULAngleTOInto = convertToInt(drData["ULAngleTOInto"]);
            ULMAngleOver = convertToInt(drData["ULMAngleOver"]);
            ULAngleTDOff = convertToInt(drData["ULAngleTDOff"]);
            ULAngleTOOff = convertToInt(drData["ULAngleTOOff"]);
            KAMSeparationOver = convertToDecimal(drData["KAMSeparationOver"]);
            LeadLegMinimumAngle = convertToInt(drData["LeadLegMinimumAngle"]);
            LeadLegAngleAC = convertToInt(drData["LeadLegAngleAC"]);
            LLMAngleOver = convertToInt(drData["LLMAngleOver"]);
            LLAngleTDOff = convertToInt(drData["LLAngleTDOff"]);
            LLAngleTOOff = convertToInt(drData["LLAngleTOOff"]);


        }

    }
}