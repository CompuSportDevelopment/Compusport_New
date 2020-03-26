using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using SwingModel.Data;
using SwingModel.Entities;

//public partial class Shop_PayMembership : System.Web.UI.Page
public partial class Shop_PayRenewal : SwingModel.UI.BasePage
{
    string PassedUsername = "";
    string SelectedMonth = "";
    string SelectedYear = "";
    int x;
    const int US = 1;
    const int EUROS = 2;
    int Currency;
    WebClient wc = new WebClient();
    string wcURL = "http://www.webservicex.net/CurrencyConvertor.asmx/ConversionRate?FromCurrency=EUR&ToCurrency=USD";
    string wcReturn;
    int FindRate;
    int FindRateStart;
    int FindRateEnd;
    string strEurosToUSDollars;
    double EurosToUSDollars;
    double AmountToCharge;

    protected override void OnPreLoad(EventArgs e)
    {
        if (DropDownList4.SelectedValue.Equals("") || DropDownList2.SelectedValue.Equals(null))
        {
            TList<CountryLookup> countries = DataRepository.CountryLookupProvider.GetAll();
            DropDownList4.Items.Clear();
            DropDownList4.Items.Add("Select Country");
            DropDownList4.Items[0].Value = "0";
            DropDownList4.Items[0].Selected = false;
            x = 0;
            foreach (CountryLookup country in countries)
            {
                x++;
                DropDownList4.Items.Add(country.CountryName);
                DropDownList4.Items[x].Value = country.CountryId.ToString();
            }
        }
    }
        
    protected void Page_Load(object sender, EventArgs e)
    {
        PassedUsername = Request.QueryString.Get("Username");
        Label2.Text = Request.QueryString.Get("Username");
        SelectedMonth = DropDownList2.SelectedValue;
        SelectedYear = DropDownList3.SelectedValue;

        DropDownList3.Items.Add("Year");
        DropDownList3.Items[0].Value = "0";
        x = 0;
        for (int i = DateTime.Now.Year; i <= DateTime.Now.Year + 15; i++)
        {
            x++;
            DropDownList3.Items.Add(i.ToString());
            DropDownList3.Items[x].Value = i.ToString().Substring(2, 2);
        }
        DropDownList3.SelectedValue = SelectedYear;
        DropDownList2.SelectedValue = SelectedMonth;
    }

    protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt16(DropDownList4.SelectedValue).Equals(248) || Convert.ToInt16(DropDownList4.SelectedValue).Equals(287))
        {
            DropDownList5.Visible = true;
            TextBox7.Visible = false;

            DropDownList5.Items.Clear();
            DropDownList5.Items.Add("Select State/Province");
            DropDownList5.Items[0].Value = "0";
            x = 0;
            TList<StateProvince> states = DataRepository.StateProvinceProvider.GetByCountry(Convert.ToInt16(DropDownList4.SelectedValue));
            foreach (StateProvince sp in states)
            {
                x++;
                DropDownList5.Items.Add(sp.StateProvinceName);
                DropDownList5.Items[x].Value = sp.StateProvinceAbbvr;
            }
            DropDownList5.SelectedValue = DropDownList5.Items[0].Value;
        }
        else
        {
            DropDownList5.Visible = false;
            TextBox7.Visible = true;
            TextBox7.Text = "";
        }

        switch (Convert.ToInt16(DropDownList4.SelectedValue))
        {
            case 251:
                Label18.Text = "99 Euros";
                break;
            case 254:
                Label18.Text = "99 Euros";
                break;
            case 260:
                Label18.Text = "99 Euros";
                break;
            case 263:
                Label18.Text = "99 Euros";
                break;
            case 264:
                Label18.Text = "99 Euros";
                break;
            case 269:
                Label18.Text = "99 Euros";
                break;
            case 270:
                Label18.Text = "99 Euros";
                break;
            case 276:
                Label18.Text = "99 Euros";
                break;
            case 282:
                Label18.Text = "99 Euros";
                break;
            case 303:
                Label18.Text = "99 Euros";
                break;
            case 305:
                Label18.Text = "99 Euros";
                break;
            case 306:
                Label18.Text = "99 Euros";
                break;
            case 307:
                Label18.Text = "99 Euros";
                break;
            case 316:
                Label18.Text = "99 Euros";
                break;
            case 321:
                Label18.Text = "99 Euros";
                break;
            case 322:
                Label18.Text = "99 Euros";
                break;
            case 328:
                Label18.Text = "99 Euros";
                break;
            case 329:
                Label18.Text = "99 Euros";
                break;
            case 332:
                Label18.Text = "99 Euros";
                break;
            case 344:
                Label18.Text = "99 Euros";
                break;
            case 347:
                Label18.Text = "99 Euros";
                break;
            case 348:
                Label18.Text = "99 Euros";
                break;
            case 353:
                Label18.Text = "99 Euros";
                break;
            case 354:
                Label18.Text = "99 Euros";
                break;
            case 356:
                Label18.Text = "99 Euros";
                break;
            case 361:
                Label18.Text = "99 Euros";
                break;
            case 369:
                Label18.Text = "99 Euros";
                break;
            case 374:
                Label18.Text = "99 Euros";
                break;
            case 375:
                Label18.Text = "99 Euros";
                break;
            case 376:
                Label18.Text = "99 Euros";
                break;
            case 378:
                Label18.Text = "99 Euros";
                break;
            case 384:
                Label18.Text = "99 Euros";
                break;
            case 392:
                Label18.Text = "99 Euros";
                break;
            case 393:
                Label18.Text = "99 Euros";
                break;
            case 395:
                Label18.Text = "99 Euros";
                break;
            case 403:
                Label18.Text = "99 Euros";
                break;
            case 413:
                Label18.Text = "99 Euros";
                break;
            case 424:
                Label18.Text = "99 Euros";
                break;
            case 425:
                Label18.Text = "99 Euros";
                break;
            case 429:
                Label18.Text = "99 Euros";
                break;
            case 430:
                Label18.Text = "99 Euros";
                break;
            case 440:
                Label18.Text = "99 Euros";
                break;
            case 444:
                Label18.Text = "99 Euros";
                break;
            case 448:
                Label18.Text = "99 Euros";
                break;
            case 449:
                Label18.Text = "99 Euros";
                break;
            case 454:
                Label18.Text = "99 Euros";
                break;
            case 460:
                Label18.Text = "99 Euros";
                break;
            case 461:
                Label18.Text = "99 Euros";
                break;
            case 473:
                Label18.Text = "99 Euros";
                break;
            case 478:
                Label18.Text = "99 Euros";
                break;
            case 480:
                Label18.Text = "99 Euros";
                break;

            default:
                Label18.Text = "US $99.00";
                break;
        }
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        bool DoCharge = false;
        string[] response_array;

        if (TextBox1.Text.Equals("") || TextBox1.Text.Equals(null))
        {
            DoCharge = false;
            Label19.Visible = true;
            Label21.Visible = true;
        }
        else
        {
            DoCharge = true;
            if (!Label19.Visible)
            //Label19.Visible = false;
            Label21.Visible = false;
        }
        if (TextBox10.Text.Equals("") || TextBox10.Text.Equals(null))
        {
            DoCharge = false;
            Label19.Visible = true;
            Label33.Visible = true;
        }
        else
        {
            if (DoCharge)
                DoCharge = true;
            //Label19.Visible = false;
            Label33.Visible = false;
        }
        if (TextBox2.Text.Equals("") || TextBox2.Text.Equals(null))
        {
            DoCharge = false;
            Label19.Visible = true;
            Label23.Visible = true;
        }
        else
        {
            if (TextBox2.Text.Length < 15)
            {
                DoCharge = false;
                Label19.Text = "Please complete items with * below. Enter correct Card Number.";
                Label19.Visible = true;
                Label23.Visible = true;
            }
            else
            {
                if (DropDownList1.SelectedValue.Equals("AmericanExpress"))
                {
                    if (!TextBox2.Text.Length.Equals(15))
                    {
                        DoCharge = false;
                        Label19.Text = "Please complete items with * below. Select correct Card Type or enter correct Card Number.";
                        Label19.Visible = true;
                        Label23.Visible = true;
                    }
                    else if (!TextBox2.Text.StartsWith("3"))
                    {
                        DoCharge = false;
                        Label19.Text = "Please complete items with * below. Enter correct Card Number.";
                        Label19.Visible = true;
                        Label23.Visible = true;
                    }
                    else
                    {
                        if (DoCharge)
                            DoCharge = true;
                        Label19.Text = "Please complete items with * below.";
                        //Label19.Visible = false;
                        Label23.Visible = false;
                    }
                }
                else if (DropDownList1.SelectedValue.Equals("Discover"))
                {
                    if (!TextBox2.Text.Length.Equals(16))
                    {
                        DoCharge = false;
                        Label19.Text = "Please complete items with * below. Select correct Card Type or enter correct Card Number.";
                        Label19.Visible = true;
                        Label23.Visible = true;
                    }
                    else if (!TextBox2.Text.StartsWith("6"))
                    {
                        DoCharge = false;
                        Label19.Text = "Please complete items with * below. Enter correct Card Number.";
                        Label19.Visible = true;
                        Label23.Visible = true;
                    }
                    else
                    {
                        if (DoCharge)
                            DoCharge = true;
                        Label19.Text = "Please complete items with * below.";
                        //Label19.Visible = false;
                        Label23.Visible = false;
                    }
                }
                else if (DropDownList1.SelectedValue.Equals("Mastercard"))
                {
                    if (!TextBox2.Text.Length.Equals(16))
                    {
                        DoCharge = false;
                        Label19.Text = "Please complete items with * below. Select correct Card Type or enter correct Card Number.";
                        Label19.Visible = true;
                        Label23.Visible = true;
                    }
                    else if (!TextBox2.Text.StartsWith("5"))
                    {
                        DoCharge = false;
                        Label19.Text = "Please complete items with * below. Enter correct Card Number.";
                        Label19.Visible = true;
                        Label23.Visible = true;
                    }
                    else
                    {
                        if (DoCharge)
                            DoCharge = true;
                        Label19.Text = "Please complete items with * below.";
                        //Label19.Visible = false;
                        Label23.Visible = false;
                    }
                }
                else if (DropDownList1.SelectedValue.Equals("Visa"))
                {
                    if (!TextBox2.Text.Length.Equals(16))
                    {
                        DoCharge = false;
                        Label19.Text = "Please complete items with * below. Select correct Card Type or enter correct Card Number.";
                        Label19.Visible = true;
                        Label23.Visible = true;
                    }
                    else if (!TextBox2.Text.StartsWith("4"))
                    {
                        DoCharge = false;
                        Label19.Text = "Please complete items with * below. Enter correct Card Number.";
                        Label19.Visible = true;
                        Label23.Visible = true;
                    }
                    else
                    {
                        if (DoCharge)
                            DoCharge = true;
                        Label19.Text = "Please complete items with * below.";
                        //Label19.Visible = false;
                        Label23.Visible = false;
                    }
                }
                else
                {
                    if (DoCharge)
                        DoCharge = true;
                    Label19.Text = "Please complete items with * below.";
                    //Label19.Visible = false;
                    Label23.Visible = false;
                }
            }
        }
        if (DropDownList2.SelectedValue.Equals("0") || DropDownList3.SelectedValue.Equals("0"))
        {
            DoCharge = false;
            Label19.Text = "Please complete items with * below.";
            Label19.Visible = true;
            Label24.Visible = true;
        }
        else
        {
            if (DoCharge)
                DoCharge = true;
            //Label19.Visible = false;
            Label24.Visible = false;
        }
        if (TextBox3.Text.Equals("") || TextBox3.Text.Equals(null))
        {
            DoCharge = false;
            Label19.Visible = true;
            Label25.Visible = true;
        }
        else
        {
            if (TextBox3.Text.Length < 3)
            {
                DoCharge = false;
                Label19.Text = "Please complete items with * below. Enter correct CVV Number.";
                Label19.Visible = true;
                Label25.Visible = true;
            }
            else
            {
                if (DropDownList1.SelectedValue.Equals("AmericanExpress"))
                {
                    if (!TextBox3.Text.Length.Equals(4))
                    {
                        DoCharge = false;
                        Label19.Text = "Please complete items with * below. Enter correct CVV Number.";
                        Label19.Visible = true;
                        Label25.Visible = true;
                    }
                    else
                    {
                        if (DoCharge)
                            DoCharge = true;
                        Label19.Text = "Please complete items with * below.";
                        //Label19.Visible = false;
                        Label25.Visible = false;
                    }
                }
                else if (DropDownList1.SelectedValue.Equals("Discover"))
                {
                    if (!TextBox3.Text.Length.Equals(3))
                    {
                        DoCharge = false;
                        Label19.Text = "Please complete items with * below. Enter correct CVV Number.";
                        Label19.Visible = true;
                        Label25.Visible = true;
                    }
                    else
                    {
                        if (DoCharge)
                            DoCharge = true;
                        Label19.Text = "Please complete items with * below.";
                        //Label19.Visible = false;
                        Label25.Visible = false;
                    }
                }
                else if (DropDownList1.SelectedValue.Equals("Mastercard"))
                {
                    if (!TextBox3.Text.Length.Equals(3))
                    {
                        DoCharge = false;
                        Label19.Text = "Please complete items with * below. Enter correct CVV Number.";
                        Label19.Visible = true;
                        Label25.Visible = true;
                    }
                    else
                    {
                        if (DoCharge)
                            DoCharge = true;
                        Label19.Text = "Please complete items with * below.";
                        //Label19.Visible = false;
                        Label25.Visible = false;
                    }
                }
                else if (DropDownList1.SelectedValue.Equals("Visa"))
                {
                    if (!TextBox3.Text.Length.Equals(3))
                    {
                        DoCharge = false;
                        Label19.Text = "Please complete items with * below. Enter correct CVV Number.";
                        Label19.Visible = true;
                        Label25.Visible = true;
                    }
                    else
                    {
                        if (DoCharge)
                            DoCharge = true;
                        Label19.Text = "Please complete items with * below.";
                        //Label19.Visible = false;
                        Label25.Visible = false;
                    }
                }
                else
                {
                    if (DoCharge)
                        DoCharge = true;
                    Label19.Text = "Please complete items with * below.";
                    //Label19.Visible = false;
                    Label25.Visible = false;
                }
            }
        }
        if (DropDownList4.SelectedValue.Equals("0"))
        {
            DoCharge = false;
            Label19.Visible = true;
            Label26.Visible = true;
        }
        else
        {
            if (DoCharge)
                //Label19.Visible = false;
            Label26.Visible = false;
        }
        if (TextBox4.Text.Equals("") || TextBox4.Text.Equals(null))
        {
            DoCharge = false;
            Label19.Visible = true;
            Label27.Visible = true;
        }
        else
        {
            if (DoCharge)
                //Label19.Visible = false;
            Label27.Visible = false;
        }
        if (TextBox6.Text.Equals("") || TextBox6.Text.Equals(null))
        {
            DoCharge = false;
            Label19.Visible = true;
            Label28.Visible = true;
        }
        else
        {
            if (DoCharge)
                //Label19.Visible = false;
            Label28.Visible = false;
        }
        if (TextBox7.Visible.Equals(true))
        {
            if (TextBox7.Text.Equals("") || TextBox7.Text.Equals(null))
            {
                DoCharge = false;
                Label19.Visible = true;
                Label29.Visible = true;
            }
            else
            {
                if (DoCharge)
                    //Label19.Visible = false;
                Label29.Visible = false;
            }
        }
        else
        {
            if (DropDownList5.SelectedValue.Equals("0"))
            {
                DoCharge = false;
                Label19.Visible = true;
                Label29.Visible = true;
            }
            else
            {
                if (DoCharge)
                    //Label19.Visible = false;
                Label29.Visible = false;
            }
        }
        if (TextBox8.Text.Equals("") || TextBox8.Text.Equals(null))
        {
            DoCharge = false;
            Label19.Visible = true;
            Label30.Visible = true;
        }
        else
        {
            if (DoCharge)
                //Label19.Visible = false;
            Label30.Visible = false;
        }
        if (TextBox9.Text.Equals("") || TextBox9.Text.Equals(null))
        {
            DoCharge = false;
            Label19.Visible = true;
            Label31.Visible = true;
        }
        else
        {
            if (DoCharge)
                //Label19.Visible = false;
            Label31.Visible = false;
        }

        if (DoCharge)
        {
            switch (Convert.ToInt16(DropDownList4.SelectedValue))
            {
                case 251:
                    Currency = EUROS;
                    break;
                case 254:
                    Currency = EUROS;
                    break;
                case 260:
                    Currency = EUROS;
                    break;
                case 263:
                    Currency = EUROS;
                    break;
                case 264:
                    Currency = EUROS;
                    break;
                case 269:
                    Currency = EUROS;
                    break;
                case 270:
                    Currency = EUROS;
                    break;
                case 276:
                    Currency = EUROS;
                    break;
                case 282:
                    Currency = EUROS;
                    break;
                case 303:
                    Currency = EUROS;
                    break;
                case 305:
                    Currency = EUROS;
                    break;
                case 306:
                    Currency = EUROS;
                    break;
                case 307:
                    Currency = EUROS;
                    break;
                case 316:
                    Currency = EUROS;
                    break;
                case 321:
                    Currency = EUROS;
                    break;
                case 322:
                    Currency = EUROS;
                    break;
                case 328:
                    Currency = EUROS;
                    break;
                case 329:
                    Currency = EUROS;
                    break;
                case 332:
                    Currency = EUROS;
                    break;
                case 344:
                    Currency = EUROS;
                    break;
                case 347:
                    Currency = EUROS;
                    break;
                case 348:
                    Currency = EUROS;
                    break;
                case 353:
                    Currency = EUROS;
                    break;
                case 354:
                    Currency = EUROS;
                    break;
                case 356:
                    Currency = EUROS;
                    break;
                case 361:
                    Currency = EUROS;
                    break;
                case 369:
                    Currency = EUROS;
                    break;
                case 374:
                    Currency = EUROS;
                    break;
                case 375:
                    Currency = EUROS;
                    break;
                case 376:
                    Currency = EUROS;
                    break;
                case 378:
                    Currency = EUROS;
                    break;
                case 384:
                    Currency = EUROS;
                    break;
                case 392:
                    Currency = EUROS;
                    break;
                case 393:
                    Currency = EUROS;
                    break;
                case 395:
                    Currency = EUROS;
                    break;
                case 403:
                    Currency = EUROS;
                    break;
                case 413:
                    Currency = EUROS;
                    break;
                case 424:
                    Currency = EUROS;
                    break;
                case 425:
                    Currency = EUROS;
                    break;
                case 429:
                    Currency = EUROS;
                    break;
                case 430:
                    Currency = EUROS;
                    break;
                case 440:
                    Currency = EUROS;
                    break;
                case 444:
                    Currency = EUROS;
                    break;
                case 448:
                    Currency = EUROS;
                    break;
                case 449:
                    Currency = EUROS;
                    break;
                case 454:
                    Currency = EUROS;
                    break;
                case 460:
                    Currency = EUROS;
                    break;
                case 461:
                    Currency = EUROS;
                    break;
                case 473:
                    Currency = EUROS;
                    break;
                case 478:
                    Currency = EUROS;
                    break;
                case 480:
                    Currency = EUROS;
                    break;

                default:
                    Currency = US;
                    break;
            }

            // By default, this sample code is designed to post to our test server for
            // developer accounts: https://test.authorize.net/gateway/transact.dll
            // for real accounts (even in test mode), please make sure that you are
            // posting to: https://secure.authorize.net/gateway/transact.dll
            //String post_url = "https://test.authorize.net/gateway/transact.dll";
            String post_url = "https://secure.authorize.net/gateway/transact.dll";

            Hashtable post_values = new Hashtable();

            //the API Login ID and Transaction Key must be replaced with valid values
            post_values.Add("x_login", ConfigurationSettings.AppSettings["x_login"]);
            post_values.Add("x_tran_key", ConfigurationSettings.AppSettings["x_tran_key"]);
            //post_values.Add("x_test_request", "TRUE");

            post_values.Add("x_delim_data", "TRUE");
            post_values.Add("x_delim_char", '|');
            post_values.Add("x_relay_response", "FALSE");

            post_values.Add("x_type", "AUTH_CAPTURE");
            post_values.Add("x_method", "CC");
            //post_values.Add("x_card_num", "4111111111111111");
            post_values.Add("x_card_num", TextBox2.Text);
            post_values.Add("x_exp_date", DropDownList2.SelectedValue + DropDownList3.SelectedValue);
            post_values.Add("x_card_code", TextBox3.Text);

            if (Currency.Equals(US))
                post_values.Add("x_amount", "99.00");
            else if (Currency.Equals(EUROS))
            {
                try
                {
                    wcReturn = wc.DownloadString(wcURL);
                    FindRate = wcReturn.IndexOf("<double");
                    FindRateStart = wcReturn.IndexOf(">", FindRate);
                    FindRateEnd = wcReturn.IndexOf("</double>", FindRateStart);
                    strEurosToUSDollars = wcReturn.Substring(FindRateStart + 1, (FindRateEnd - FindRateStart - 1));
                    EurosToUSDollars = Convert.ToDouble(strEurosToUSDollars);
                    AmountToCharge = 99.00 * EurosToUSDollars;
                }
                catch (Exception ex)
                {
                    AmountToCharge = 135.00;
                }
                post_values.Add("x_amount", AmountToCharge.ToString());
            }
            post_values.Add("x_description", "SwingModel Lesson and Membership/Renewal Website");

            post_values.Add("x_first_name", TextBox1.Text);
            post_values.Add("x_last_name", TextBox10.Text);
            post_values.Add("x_address", TextBox4.Text);
            if (TextBox7.Visible.Equals(true))
                post_values.Add("x_state", TextBox7.Text);
            else
                post_values.Add("x_state", DropDownList5.SelectedValue);
            post_values.Add("x_zip", TextBox8.Text);
            post_values.Add("x_email", TextBox9.Text);
            // Additional fields can be added here as outlined in the AIM integration
            // guide at: http://developer.authorize.net

            // This section takes the input fields and converts them to the proper format
            // for an http post.  For example: "x_login=username&x_tran_key=a1B2c3D4"
            String post_string = "";
            foreach (DictionaryEntry field in post_values)
            {
                post_string += field.Key + "=" + field.Value + "&";
            }
            post_string = post_string.TrimEnd('&');

            // create an HttpWebRequest object to communicate with Authorize.net
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(post_url);
            objRequest.Method = "POST";
            objRequest.ContentLength = post_string.Length;
            objRequest.ContentType = "application/x-www-form-urlencoded";

            // post data is sent as a stream
            StreamWriter myWriter = null;
            myWriter = new StreamWriter(objRequest.GetRequestStream());
            myWriter.Write(post_string);
            myWriter.Close();

            // returned values are returned as a stream, then read into a string
            String post_response;
            HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
            using (StreamReader responseStream = new StreamReader(objResponse.GetResponseStream()))
            {
                post_response = responseStream.ReadToEnd();
                responseStream.Close();
            }
            Label19.Visible = false;

            // the response string is broken into an array
            // The split character specified here must match the delimiting character specified above
            //Array response_array = post_response.Split('|');
            response_array = post_response.Split('|');

            // the results are output to the screen in the form of an html numbered list.
            /*
            resultSpan.InnerHtml += "<OL> \n";
            foreach (string value in response_array)
            {
                resultSpan.InnerHtml += "<LI>" + value + "&nbsp;</LI> \n";
            }
            resultSpan.InnerHtml += "</OL> \n";
            */
            // individual elements of the array could be accessed to read certain response
            // fields.  For example, response_array[0] would return the Response Code,
            // response_array[2] would return the Response Reason Code.
            // for a list of response fields, please review the AIM Implementation Guide
            if (response_array[0].Equals("1"))
            {
                MembershipUser user = Membership.GetUser(PassedUsername);
                user.IsApproved = true;
                Membership.UpdateUser(user);
                user = Membership.GetUser(PassedUsername);

                Customer customer;
                customer = DataRepository.CustomerProvider.GetByAspnetMembershipUserId((Guid)user.ProviderUserKey)[0];
                customer.MembershipStatus = 2;
                customer.MembershipExpiration = DateTime.Today.AddYears(1);
                customer.MembershipRenewal = DateTime.Today;
                customer.IsRenewal = 1;
                customer.MembershipCost = 99;
                customer.BillFacility = 0;
                DataRepository.CustomerProvider.Update(customer);
                customer = null;

                //Go to page to direct to login
                Response.Redirect("http://www.swingmodel.com/RenewSuccess.aspx");
            }
            else
            {
                Label32.Text = "The charge attempt failed. Please correct the information above, or use a different credit card.<br>The Response Reason is: " + response_array[3];
                Label32.Visible = true;
            }
        }
    }
}
