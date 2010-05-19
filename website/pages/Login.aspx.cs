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
        SetInfoMessage("You may connect to Simplicity EAS and Simplicity H&S Live by clicking on the relevant tabs" + Utility.GetMd5Sum("1"));
        if (Request[WebConstants.Request.RETURN_URL] != null)
        {
            Session[WebConstants.Session.RETURN_URL] = Request[WebConstants.Request.RETURN_URL];
        }
    }
    protected override void PostAuthenticated(SimplicityCommLib.DataSets.Common.Users.UsersRow user)
    {
        PanelLogin.Visible = false;
        PanelAlreadyLoggedIn.Visible = true;
    }
    protected override void PostUnauthenticated()
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
    protected void imgBtnLogin_Click(object sender, ImageClickEventArgs e)
    {
        //mjaved.sim.CommonLib Verifying User and creat its cookie

        SimplicityCommLib.DataSets.Common.UsersTableAdapters.UsersTableAdapter userTA = new SimplicityCommLib.DataSets.Common.UsersTableAdapters.UsersTableAdapter();
        IEnumerator<SimplicityCommLib.DataSets.Common.Users.UsersRow> ieUser = userTA.GetUserByEmail(txtEmail.Text).GetEnumerator();
        if (ieUser.MoveNext())
        {
            if (ieUser.Current.Password.Equals(Utility.GetMd5Sum(txtPassword.Text)) && ieUser.Current.FlgVerified)
            {                
                // Cookie Implementation
                HttpCookie Cookie = new HttpCookie(WebConstants.Cookies.UserLoginSession);
                Cookie.Value = System.Guid.NewGuid().ToString();
                Cookie.Expires = DateTime.Now.AddMinutes(Constants.Configuration.SessionTimeoutInMinutes);
                Response.Cookies.Add(Cookie);

                SimplicityCommLib.DataSets.Common.SessionsTableAdapters.SessionsTableAdapter sessionTA = new SimplicityCommLib.DataSets.Common.SessionsTableAdapters.SessionsTableAdapter();
                sessionTA.Insert(System.Guid.NewGuid().ToString(), ieUser.Current.UserId, DateTime.Now, DateTime.Now.AddMinutes(Constants.Configuration.SessionTimeoutInMinutes), Request.UserHostAddress);
                
                //Cache.Insert("UserLoginSession", iEnumUser.Current.UserId, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(20));

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
