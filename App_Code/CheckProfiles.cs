using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Text;
using SwingModel.Data;
using SwingModel.Entities;


/// <summary>
/// Summary description for CheckProfiles
/// </summary>
public class CheckProfiles
{
    Customer customer;
    CustomerProfile customerprofile;
    bool customerexists;
    bool customerprofileexists;
    CompuSportDataAccess.AthleteBodyDimensions abd = new CompuSportDataAccess.AthleteBodyDimensions();
    DataTable dt = new DataTable();
    public bool Personal()
	{
        try
        {
            customer = DataRepository.CustomerProvider.GetByAspnetMembershipUserId(new Guid(Membership.GetUser().ProviderUserKey.ToString()))[0];
            customerexists = true;
        }
        catch
        {
            customerexists = false;
            return false;
        }

        if (customerexists)
        {
            try
            {
                customerprofile = DataRepository.CustomerProfileProvider.GetByCustomerId(customer.CustomerId)[0];
                customerprofileexists = true;
            }
            catch
            {
                customerprofileexists = false;
                return false;
            }
        }
        else
        {
            customerprofileexists = false;
            return false;
        }

        if (customer.FirstName.Equals("") || customer.FirstName.Equals(null) || customer.FirstName.Trim().Equals("None"))
        {
            return false;
        }
        if (customer.LastName.Equals("") || customer.LastName.Equals(null) || customer.LastName.Trim().Equals("None"))
        {
            return false;
        }
        if (customerprofile.Gender.Equals("") || customerprofile.Gender.Equals(null) || customerprofile.Gender.Equals("0"))
        {
            return false;
        }

        return true;
	}

    public bool Facility()
    {
        try
        {
            customer = DataRepository.CustomerProvider.GetByAspnetMembershipUserId(new Guid(Membership.GetUser().ProviderUserKey.ToString()))[0];
            customerexists = true;
        }
        catch
        {
            customerexists = false;
            return false;
        }

        if (customerexists)
        {
            try
            {
                customerprofile = DataRepository.CustomerProfileProvider.GetByCustomerId(customer.CustomerId)[0];
                customerprofileexists = true;
            }
            catch
            {
                customerprofileexists = false;
                return false;
            }
        }
        else
        {
            customerprofileexists = false;
            return false;
        }

        if (customerprofile.CustomerSite.Equals("") || customerprofile.CustomerSite.Equals(null) || customerprofile.CustomerSite.Equals(0) || customerprofile.CustomerSite.Equals(-1))
        {
            return false;
        }
        if (customerprofile.Teacher.Equals("") || customerprofile.Teacher.Equals(null) || customerprofile.Teacher.Equals(0) || customerprofile.Teacher.Equals(-1))
        {
            return false;
        }

        return true;
    }

    public bool Address()
    {
        try
        {
            customer = DataRepository.CustomerProvider.GetByAspnetMembershipUserId(new Guid(Membership.GetUser().ProviderUserKey.ToString()))[0];
            customerexists = true;
        }
        catch
        {
            customerexists = false;
            return false;
        }

        if (customer.Country.Equals("") || customer.Country.Equals(null) || customer.Country.Equals(0) || customer.Country.Equals(-1))
        {
            return false;
        }
        if (customer.Address1.Equals("") || customer.Address1.Equals(null) || customer.Address1.Trim().Equals("None"))
        {
            return false;
        }
        if (customer.City.Equals("") || customer.City.Equals(null) || customer.Address1.Trim().Equals("None"))
        {
            return false;
        }
        if (customer.State.Equals("") || customer.State.Equals(null) || customer.Address1.Trim().Equals("None"))
        {
            return false;
        }
        if (customer.Zip.Equals("") || customer.Zip.Equals(null) || customer.Address1.Trim().Equals("None"))
        {
            return false;
        }

        return true;
    }

    public bool Dimensions()
    {
        try
        {
            customer = DataRepository.CustomerProvider.GetByAspnetMembershipUserId(new Guid(Membership.GetUser().ProviderUserKey.ToString()))[0];
            customerexists = true;
        }
        catch
        {
            customerexists = false;
            return false;
        }

        if (customerexists)
        {
            try
            {
                customerprofile = DataRepository.CustomerProfileProvider.GetByCustomerId(customer.CustomerId)[0];
                customerprofileexists = true;
                dt = abd.GetDataFromCustomerProfile(customer.CustomerId);
            }
            catch
            {
                customerprofileexists = false;
                return false;
            }
        }
        else
        {
            customerprofileexists = false;
            return false;
        }

        if (customerprofile.Height.Equals("") || customerprofile.Height.Equals(null) || customerprofile.Height.Equals(0))
        {
            return false;
        }
        if (customerprofile.Weight.Equals("") || customerprofile.Weight.Equals(null) || customerprofile.Weight.Equals(0))
        {
            return false;
        }
        if (customerprofile.Shoulder.Equals("") || customerprofile.Shoulder.Equals(null) || customerprofile.Shoulder.Equals(0))
        {
            return false;
        }
        //if (customerprofile.Sleeve.Equals("") || customerprofile.Sleeve.Equals(null) || customerprofile.Sleeve.Equals(0))
        //{
        //    return false;
        //}
        //if (customerprofile.Glove.Equals("") || customerprofile.Glove.Equals(null))
        //{
        //    return false;
        //}
        if (customerprofile.Waist.Equals("") || customerprofile.Waist.Equals(null) || customerprofile.Waist.Equals(0))
        {
            return false;
        }
        //if (customerprofile.Inseam.Equals("") || customerprofile.Inseam.Equals(null) || customerprofile.Inseam.Equals(0))
        //{
        //    return false;
        //}
        if (customerprofile.Shoe.Equals("") || customerprofile.Shoe.Equals(null) || customerprofile.Shoe.Equals(0))
        {
            return false;
        }

        decimal _Trunklength = Convert.ToDecimal(dt.Rows[0]["TrunkLength"].ToString());
        if (_Trunklength.Equals(Convert.ToDecimal(0)))
        {
            return false;
        }

        decimal Upperleglength=Convert.ToDecimal(dt.Rows[0]["UpperLegLength"].ToString());
        if (Upperleglength.Equals(Convert.ToDecimal(0)))
        {
            return false;
        }
        decimal Lowerleglength = Convert.ToDecimal(dt.Rows[0]["LowerLegLength"].ToString());
        if (Lowerleglength.Equals(Convert.ToDecimal(0)))
        {
            return false;
        }
        decimal Hiplength=Convert.ToDecimal(dt.Rows[0]["HipLength"].ToString());
        if (Hiplength.Equals(Convert.ToDecimal(0)))
        {
            return false;
        }
        decimal Ankleheight = Convert.ToDecimal(dt.Rows[0]["AnkleHeight"].ToString());
        if (Ankleheight.Equals(Convert.ToDecimal(0)))
        {
            return false;
        }
        decimal Lowerarmlength = Convert.ToDecimal(dt.Rows[0]["LowerArmLength"].ToString());
        if (Lowerarmlength.Equals(Convert.ToDecimal(0)))
        {
            return false;
        }
        decimal Upperarmlength = Convert.ToDecimal(dt.Rows[0]["UpperArmLength"].ToString());
        if (Upperarmlength.Equals(Convert.ToDecimal(0)))
        {
            return false;
        }
        return true;
    }

    public bool Golf()
    {
        try
        {
            customer = DataRepository.CustomerProvider.GetByAspnetMembershipUserId(new Guid(Membership.GetUser().ProviderUserKey.ToString()))[0];
            customerexists = true;
        }
        catch
        {
            customerexists = false;
            return false;
        }

        if (customerexists)
        {
            try
            {
                customerprofile = DataRepository.CustomerProfileProvider.GetByCustomerId(customer.CustomerId)[0];
                customerprofileexists = true;
            }
            catch
            {
                customerprofileexists = false;
                return false;
            }
        }
        else
        {
            customerprofileexists = false;
            return false;
        }

        if (customerprofile.Age.Equals("") || customerprofile.Age.Equals(null))
        {
            return false;
        }
        if (customerprofile.Hand.Equals("") || customerprofile.Hand.Equals(null))
        {
            return false;
        }
        //if (customerprofile.Hcp.Equals("") || customerprofile.Hcp.Equals(null) || customerprofile.Hcp.Equals(-1))
        //{
        //    return false;
        //}
        if (customerprofile.Rounds.Equals("") || customerprofile.Rounds.Equals(null))
        {
            return false;
        }
        if (customerprofile.Practice.Equals("") || customerprofile.Practice.Equals(null))
        {
            return false;
        }
        if (customerprofile.Lessons.Equals("") || customerprofile.Lessons.Equals(null))
        {
            return false;
        }
        if (customerprofile.Altitude.Equals("") || customerprofile.Altitude.Equals(null))
        {
            return false;
        }
        if (customerprofile.Wind.Equals("") || customerprofile.Wind.Equals(null))
        {
            return false;
        }
        if (customerprofile.Roll.Equals("") || customerprofile.Roll.Equals(null))
        {
            return false;
        }

        return true;
    }
}
