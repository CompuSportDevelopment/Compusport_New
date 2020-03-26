using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for BasePage
/// </summary>
namespace SwingModel.UI
{
    public class BasePage : System.Web.UI.Page
    {
        protected override void OnPreInit(EventArgs e)
        {
            if (this.User.Identity.IsAuthenticated)
            {
                //Master.FindControl("HyperLink2").Visible = false;
                Master.FindControl("Label1").Visible = true;
                Master.FindControl("Label2").Visible = true;
            }
            else
            {
                //Master.FindControl("HyperLink2").Visible = true;
                Master.FindControl("Label1").Visible = false;
                Master.FindControl("Label2").Visible = false;
            }

            base.OnPreInit(e);
        }
    }

    public class ConfirmButtonField : ButtonField
    {
        public override void InitializeCell(DataControlFieldCell cell, DataControlCellType cellType, DataControlRowState rowState, int rowIndex)
        {
            base.InitializeCell(cell, cellType, rowState, rowIndex);
            if (cellType == DataControlCellType.DataCell)
            {
                cell.Attributes.Add("onclick", "return confirm(\"Are you sure you want to delete the item?\");");
            }
        }
    }
}
