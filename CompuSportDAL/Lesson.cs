using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
namespace CompuSportDataAccess
{
   public class LessonNew
    {
       string ConnectionString = ConfigurationManager.ConnectionStrings["compusport.Data.ConnectionString"].ToString();
       # region variables
       private int _LessonId;
       private int _UserId;
       private string _LessonType;
       private string _LessonDate;
       private string _LessonLocation;
       #endregion variables
       #region Properties
       public int LessonId
       {
           get { return _LessonId; }
           set { _LessonId = value; }
       }
       public int __UserId
       {
           get { return _UserId; }
           set { _UserId = value; }
       }
       public string LessonType
       {
           get { return _LessonType; }
           set { _LessonType = value; }
       }

       public string LessonDate
       {
           get { return _LessonDate; }
           set { _LessonDate = value; }
       }
       public string LessonLocation
       {
           get { return _LessonLocation; }
           set { _LessonLocation = value; }
       }

       #endregion Properties

       #region Data Access

       public int Data_Insert()
       {
           int ID;
           try
           {
               using (SqlConnection connection = new SqlConnection(ConnectionString))
               {
                   connection.Open();
                   using (SqlCommand cmdContact = connection.CreateCommand())
                   {
                       cmdContact.CommandType = CommandType.StoredProcedure;
                       cmdContact.CommandText = "LESSON_INSERT";
                       SqlParameter sp = new SqlParameter("@LessonId", SqlDbType.Int);
                       sp.Direction = ParameterDirection.Output;
                       cmdContact.Parameters.Add(sp);
                       DoInsertUpdate(cmdContact);
                       ID = Convert.ToInt32(cmdContact.Parameters["@LessonId"].Value);
                   }
               }
               return _LessonId;
           }
           catch (Exception ex)
           {
               throw new Exception(ex.ToString());
           }
       }

       public void Data_Delete(int _id)
       {
           try
           {
               using (SqlConnection connection = new SqlConnection(ConnectionString))
               {
                   connection.Open();
                   using (SqlCommand cmdDContact = connection.CreateCommand())
                   {
                       cmdDContact.CommandType = CommandType.StoredProcedure;
                       cmdDContact.CommandText = "LESSON_DELETE";
                       cmdDContact.Parameters.AddWithValue("@LessonId", _LessonId);
                       cmdDContact.ExecuteNonQuery();
                   }
               }
           }
           catch (Exception err)
           {
               throw err;
           }

       }

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

       public DataTable Data_SelectByID(int ContactID)
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
                       cmdContact.CommandText = "LESSSON_SELECTBYID";
                       cmdContact.Connection = connection;
                       SqlDataAdapter daCommon = new SqlDataAdapter(cmdContact);
                       cmdContact.Parameters.AddWithValue("@LessonId", ContactID);
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

       public void Data_Update()
       {
           try
           {
               using (SqlConnection connection = new SqlConnection(ConnectionString))
               {
                   connection.Open();
                   using (SqlCommand cmdContact = connection.CreateCommand())
                   {
                       cmdContact.CommandType = CommandType.StoredProcedure;
                       cmdContact.CommandText = "LESSON_UPDATE";
                       cmdContact.Parameters.AddWithValue("@LessonId", _LessonId);
                       DoInsertUpdate(cmdContact);
                   }
               }
           }
           catch (Exception err)
           {
               throw err;
           }
       }

       public void DoInsertUpdate(SqlCommand cmdContact)
       {
           cmdContact.Parameters.Add("@UserId", SqlDbType.NVarChar).Value = _UserId;
           cmdContact.Parameters.Add("@LessonType", SqlDbType.NVarChar).Value = _LessonType;
           cmdContact.Parameters.Add("@LessonDate", SqlDbType.NVarChar).Value = _LessonDate;
           cmdContact.Parameters.Add("@LessonDate", SqlDbType.NVarChar).Value = _LessonLocation;
           cmdContact.ExecuteNonQuery();
       }

       #endregion Data Access
    }
}
