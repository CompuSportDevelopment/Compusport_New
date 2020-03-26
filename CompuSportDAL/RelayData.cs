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
    public class RelayData
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();

        public int CustomerId { get; set; }
        public int RelayVelocityIn { get; set; }
        public int RelayVelocityOut { get; set; }
        public int RelayStart { get; set; }
        public int MeterTime { get; set; }


        //#region[RelayData]
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

    }
}