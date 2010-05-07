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
using System.Collections.Generic;

using ShoppingTrolley.Web;
using SimplicityCommLib;	//mjaved.sim.CommonLib
public partial class pages_Login : GenericPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SetInfoMessage("You may connect to Simplicity EAS and Simplicity H&S Live by clicking on the relevant tabs");
        if (LoggedIsUser != null)
        {
            PanelLogin.Visible = false;
            PanelAlreadyLoggedIn.Visible = true;
        }
        else
        {
            PanelLogin.Visible = true;
            PanelAlreadyLoggedIn.Visible = false;
            if (Request[WebConstants.Request.NEED_LOGIN] != null)
            {
                lblErrorMessage.Visible = true;
                lblErrorMessage.Text = "Please login to continue";
            }
            else if (Request[WebConstants.Request.FROM_PAGE] != null)
            {
                SetInfoMessage("An email has been sent to you for your login details");
            }
        }
    }
    protected void imgBtnLogin_Click(object sender, ImageClickEventArgs e)
    {
        CustomerTableAdapters.CustomerTableAdapter ta = new CustomerTableAdapters.CustomerTableAdapter();
        IEnumerator<Customer.CustomerEntityRow> iEnum = ta.GetCustomerByEmail(txtEmail.Text).GetEnumerator();
        if (iEnum.MoveNext())
        {
            if (iEnum.Current.logon_enable.Equals(Utility.GetMd5Sum(txtPassword.Text)) && iEnum.Current.flg_verified)
            {
                Session[WebConstants.Session.USER_ID] = iEnum.Current.entity_id;
                if (Session[WebConstants.Session.RETURN_URL] != null)
                {
                    Response.Redirect((string)Session[WebConstants.Session.RETURN_URL]);
                }
                else
                {
                    Response.Redirect("~/pages/UserHome.aspx");
                }
            }
            else
            {
                SetErrorMessage();
            }
        }
        else
        {
            SetErrorMessage();
        }
        
        //mjaved.sim.CommonLib Verifying User and creat its cookie

        CommLibController userOBJ = new CommLibController();
        IEnumerator<LINQSimplicityCommDAL.UserSelectByEmailResult> iEnumUser = userOBJ.GetUserByEmail(txtEmail.Text);
        if (iEnumUser.MoveNext())
        {
            if (iEnumUser.Current.Logon_Enable.Equals(Utility.GetMd5Sum(txtPassword.Text)) && iEnumUser.Current.Flg_verified.Value)
            {

                CommLibController sessionOBJ = new CommLibController();
                sessionOBJ.InsertUserSession(iEnumUser.Current.User_Uid, iEnumUser.Current.UserId.Value, DateTime.Now, DateTime.Now.AddMinutes(20), Request.UserHostAddress);                
         
                // Cookie Implementation
                HttpCookie Cookie = new HttpCookie("UserLoginSession");
                Cookie.Value = iEnumUser.Current.UserId.Value.ToString();
                Cookie.Expires = DateTime.Now + TimeSpan.FromMinutes(20);
                Response.Cookies.Add(Cookie);

                //Cache.Insert("UserLoginSession", iEnumUser.Current.UserId, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(20));

                Session[WebConstants.Session.USER_ID] = iEnumUser.Current.UserId;
                if (Session[WebConstants.Session.RETURN_URL] != null)
                {
                    Response.Redirect((string)Session[WebConstants.Session.RETURN_URL]);
                }
                else
                {
                    Response.Redirect("~/pages/UserHome.aspx");
                }
            }
            else
            {
                SetErrorMessage();
            }
        }
        else
        {
            SetErrorMessage();
        }

    }

    protected void SetErrorMessage()
    {
        lblErrorMessage.Text = WebConstants.Messages.Error.CANNOT_LOGIN;
        lblErrorMessage.Visible = true;
    }
}
