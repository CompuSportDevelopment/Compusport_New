using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace CompuSportDataAccess
{
    public class AthleteBodyDimensions
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        public int _AthleteBodyDimensionsId;
        public int _AthleteUserId;
        public decimal _Height;
        public decimal _Waist;
        public decimal _HipHeight;
        public decimal _UpperLegLength;
        public decimal _LowerLegLength;
        public decimal _AnkleHeight;
        public decimal _ShoeSize;
        public decimal _TrunkLength;
        public decimal _UpperArmLength;
        public decimal _LowerArmLength;
        public decimal _ShoulderWidth;
        public decimal _EnterVelocity;
        public decimal _EnterStartVelocity;

        public int AthleteBodyDimensionsId
        {
            get { return _AthleteBodyDimensionsId; }
            set { _AthleteBodyDimensionsId = value; }
        }

        public int AthleteUserId
        {
            get { return _AthleteUserId; }
            set { _AthleteUserId = value; }
        }


        public decimal Height
        {
            get { return _Height; }
            set { _Height = value; }
        }



        public decimal Waist
        {
            get { return _Waist; }
            set { _Waist = value; }
        }



        public decimal HipHeight
        {
            get { return _HipHeight; }
            set { _HipHeight = value; }
        }



        public decimal UpperLegLength
        {
            get { return _UpperLegLength; }
            set { _UpperLegLength = value; }
        }



        public decimal LowerLegLength
        {
            get { return _LowerLegLength; }
            set { _LowerLegLength = value; }
        }


        public decimal AnkleHeight
        {
            get { return _AnkleHeight; }
            set { _AnkleHeight = value; }
        }



        public decimal ShoeSize
        {
            get { return _ShoeSize; }
            set { _ShoeSize = value; }
        }




        public decimal TrunkLength
        {
            get { return _TrunkLength; }
            set { _TrunkLength = value; }
        }



        public decimal UpperArmLength
        {
            get { return _UpperArmLength; }
            set { _UpperArmLength = value; }
        }



        public decimal LowerArmLength
        {
            get { return _LowerArmLength; }
            set { _LowerArmLength = value; }
        }



        public decimal ShoulderWidth
        {
            get { return _ShoulderWidth; }
            set { _ShoulderWidth = value; }
        }


        public decimal EnterVelocity
        {
            get { return _EnterVelocity; }
            set { _EnterVelocity = value; }
        }

        public decimal EnterStartVelocity
        {
            get { return _EnterStartVelocity; }
            set { _EnterStartVelocity = value; }
        }

        # region Methods

        public DataTable Data_SelectAll()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    DataTable dtContact = new DataTable();
                    connection.Open();
                    using (SqlCommand cmdContact = connection.CreateCommand())
                    {
                        cmdContact.CommandType = CommandType.StoredProcedure;
                        cmdContact.CommandText = "LESSON_DELETEALL";
                        cmdContact.Connection = connection;
                        SqlDataAdapter daCommon = new SqlDataAdapter(cmdContact);
                        daCommon.Fill(dtContact);
                    }
                    return dtContact;
                }
            }
            catch (Exception ex)
            {
            }
            return null;
        }

        public DataTable GetAllBodyDimensionsBycustomerid(int customerid)
        {
            int x;

            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmdbodydims = con.CreateCommand())
                    {
                        cmdbodydims.CommandType = CommandType.StoredProcedure;
                        cmdbodydims.CommandText = "BodyDimension_ByCusId";
                        cmdbodydims.Parameters.AddWithValue("@AthleteUserId", customerid);
                        cmdbodydims.Connection = con;
                        SqlDataAdapter da = new SqlDataAdapter(cmdbodydims);
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

        public int Insert_ABD()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = con.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "InsertBodyDimensions";
                        cmd.Connection = con;
                        SqlParameter sp = new SqlParameter("@AthleteBodyDimensionsId", SqlDbType.Int);
                        sp.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(sp);
                        DoInsertUpdate(cmd);
                        AthleteBodyDimensionsId = Convert.ToInt32(cmd.Parameters["@AthleteBodyDimensionsId"].Value);
                        return AthleteUserId;
                    }

                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.ToString());

            }
        }
        //my 

        public int InsertTo_CustomerProfile(decimal Trunklength,decimal Upperarmlength)
    {
        return 0;
        }


        public int Update_ABD()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmdWorkCommand = connection.CreateCommand())
                    {
                        cmdWorkCommand.CommandType = CommandType.StoredProcedure;
                        cmdWorkCommand.CommandText = "UpdateAthleteBodyDimensions";
                        cmdWorkCommand.Parameters.AddWithValue("@AthleteUserId", AthleteUserId);
                        //cmdWorkCommand.Parameters.Add("@AthleteUserId", SqlDbType.Int).Value = AthleteUserId;
                        cmdWorkCommand.Parameters.Add("@Height", SqlDbType.Int).Value = Height;
                        cmdWorkCommand.Parameters.Add("@Waist", SqlDbType.Int).Value = Waist;
                        cmdWorkCommand.Parameters.Add("@HipHeight", SqlDbType.Int).Value = HipHeight;
                        cmdWorkCommand.Parameters.Add("@UpperLegLength", SqlDbType.Int).Value = UpperLegLength;
                        cmdWorkCommand.Parameters.Add("@LowerLegLength", SqlDbType.Int).Value = LowerLegLength;
                        cmdWorkCommand.Parameters.Add("@AnkleHeight", SqlDbType.Int).Value =  AnkleHeight;
                        cmdWorkCommand.Parameters.Add("@ShoeSize", SqlDbType.Int).Value = ShoeSize;
                        cmdWorkCommand.Parameters.Add("@TrunkLength", SqlDbType.Int).Value = TrunkLength;
                        cmdWorkCommand.Parameters.Add("@UpperArmLength", SqlDbType.Int).Value = UpperArmLength;
                        cmdWorkCommand.Parameters.Add("@LowerArmLength", SqlDbType.Int).Value = LowerArmLength;
                        cmdWorkCommand.Parameters.Add("@ShoulderWidth", SqlDbType.Int).Value = ShoulderWidth;
                        cmdWorkCommand.Parameters.Add("@EnterVelocity", SqlDbType.Int).Value = EnterVelocity;
                        cmdWorkCommand.Parameters.Add("@EnterStartVelocity", SqlDbType.Int).Value = EnterStartVelocity;
                        cmdWorkCommand.ExecuteNonQuery();

                        //cmdWorkCommand.CommandType = CommandType.StoredProcedure;
                        //cmdWorkCommand.CommandText = "ASSIGNORDERDETAILS_Update";
                        //cmdWorkCommand.Parameters.AddWithValue("@AssignID", AssignID);
                        //cmdWorkCommand.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = EmployeeID;
                        //cmdWorkCommand.Parameters.Add("@OrderID", SqlDbType.Int).Value = OrderID;
                        //cmdWorkCommand.Parameters.Add("AssignedDate", SqlDbType.DateTime).Value = Assigndate;
                        //cmdWorkCommand.Parameters.Add("COmpletionDate", SqlDbType.DateTime).Value = CompletionDate;
                        //cmdWorkCommand.ExecuteNonQuery();
                    }
                }
                return AthleteBodyDimensionsId;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public void DoInsertUpdate(SqlCommand cmdWorkCommand)
        {
            cmdWorkCommand.Parameters.Add("@AthleteUserId", SqlDbType.Int).Value = AthleteUserId;
            cmdWorkCommand.Parameters.Add("@Height", SqlDbType.Int).Value = Height;
            cmdWorkCommand.Parameters.Add("@Waist", SqlDbType.Int).Value = Waist;
            cmdWorkCommand.Parameters.Add("@HipHeight", SqlDbType.Int).Value = HipHeight;
            cmdWorkCommand.Parameters.Add("@UpperLegLength", SqlDbType.Int).Value = UpperLegLength;
            cmdWorkCommand.Parameters.Add("@LowerLegLength", SqlDbType.Int).Value = LowerLegLength;
            cmdWorkCommand.Parameters.Add("@AnkleHeight", SqlDbType.Int).Value = AnkleHeight;
            cmdWorkCommand.Parameters.Add("@ShoeSize", SqlDbType.Int).Value = ShoeSize;
            cmdWorkCommand.Parameters.Add("@TrunkLength", SqlDbType.Int).Value = TrunkLength;
            cmdWorkCommand.Parameters.Add("@UpperArmLength", SqlDbType.Int).Value = UpperArmLength;
            cmdWorkCommand.Parameters.Add("@LowerArmLength", SqlDbType.Int).Value = LowerArmLength;
            cmdWorkCommand.Parameters.Add("@ShoulderWidth", SqlDbType.Int).Value = ShoulderWidth;
            cmdWorkCommand.Parameters.Add("@EnterVelocity", SqlDbType.Int).Value = EnterVelocity;
            cmdWorkCommand.Parameters.Add("@EnterStartVelocity", SqlDbType.Int).Value = EnterStartVelocity;
            cmdWorkCommand.ExecuteNonQuery();
        }

        # endregion Methods

        //,[AthleteUserId]
        //,[Height]
        //,[Waist]
        //,[HipHeight]
        //,[UpperLegLength]
        //,[LowerLegLength]
        //,[AnkleHeight]
        //,[ShoeSize]
        //,[TrunkLength]
        //,[UpperArmLength]
        //,[LowerArmLength]
        //,[ShoulderWidth]
        //,[EnterVelocity]
        //,[EnterStartVelocity]

        public DataTable GetDataFromCustomerProfile(int Customer_id)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    using (SqlCommand selectcmd = con.CreateCommand())
                    {
                        selectcmd.CommandType = CommandType.StoredProcedure;
                        selectcmd.CommandText = "GetBodyDimensions";
                        selectcmd.Parameters.AddWithValue("@CustomerID", Customer_id);
                        selectcmd.Connection = con;
                        SqlDataAdapter da = new SqlDataAdapter(selectcmd);
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return dt = null;
            }

        }

    }
               
    //public int Data_Insert()
        //{
        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(ConnectionString))
        //        {
        //            connection.Open();
        //            using (SqlCommand cmdWorkCommand = connection.CreateCommand())
        //            {
        //                cmdWorkCommand.CommandType = CommandType.StoredProcedure;
        //                cmdWorkCommand.CommandText = "ASSIGNORDERDETAILS_INSERT";
        //                SqlParameter sp = new SqlParameter("@AssignID", SqlDbType.Int);
        //                sp.Direction = ParameterDirection.Output;
        //                cmdWorkCommand.Parameters.Add(sp);
        //                DoInsertUpdate(cmdWorkCommand);
        //                AssignID = Convert.ToInt32(cmdWorkCommand.Parameters["@AssignID"].Value);
        //                return AssignID;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.ToString());
        //    }
        //}
        //public DataTable SelectHeight(int Customerid)
        //{

        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(ConnectionString))
        //        {
        //            connection.Open();
        //            using (SqlCommand cmdSelectTire = connection.CreateCommand())
        //            {
        //                cmdSelectTire.CommandType = CommandType.StoredProcedure;
        //                cmdSelectTire.CommandText = "Select_Height";
        //                cmdSelectTire.Parameters.AddWithValue("@CustomerID", Customerid);
        //                cmdSelectTire.Connection = connection;
        //                SqlDataAdapter da = new SqlDataAdapter(cmdSelectTire);
        //                da.Fill(dt);
        //                return dt;
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        return dt = null;
        //    }
        //}
      //,[AthleteUserId]
      //,[Height]
      //,[Waist]
      //,[HipHeight]
      //,[UpperLegLength]
      //,[LowerLegLength]
      //,[AnkleHeight]
      //,[ShoeSize]
      //,[TrunkLength]
      //,[UpperArmLength]
      //,[LowerArmLength]
      //,[ShoulderWidth]
      //,[EnterVelocity]
      //,[EnterStartVelocity]
    }


