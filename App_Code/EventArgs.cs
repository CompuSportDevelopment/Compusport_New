using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

/// <summary>
/// Summary description for EventArgs
/// </summary>
 public class PersonEventArgs:EventArgs
{
    private bool isSuccess = false;
    public bool IsSuccess
    {
        get { return isSuccess; }
        set { isSuccess = value; }
    }
    public PersonEventArgs(bool success)
	{
        isSuccess = success;
	}
}

 public class EditPersonEventArgs:EventArgs
{
    private int personId = 0;
    public int PersonId
    {
        get { return personId; }
        set { personId = value; }
    }
    public EditPersonEventArgs(int Id)
    {
        personId = Id;
    }
}
 public class NewMethodEventArgs : EventArgs
 {
     private int personId = 0;
     public int PersonId
     {
         get { return personId; }
         set { personId = value; }
     }
     public NewMethodEventArgs(int Id)
     {
         personId = Id;
     }
   
 }