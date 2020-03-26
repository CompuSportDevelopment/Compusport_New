using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Windows.Forms;
using System.IO;
using MemberDownload;
using SwingModel.Data;
using SwingModel.Entities;

//public partial class Teachers_SummaryPlayer : System.Web.UI.Page
public partial class Teachers_SummaryPlayer : SwingModel.UI.BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.Params["customerid"]))
        {
            Session["customerid"] = Convert.ToInt32(Request.Params["customerid"]);
        }

    }
}
