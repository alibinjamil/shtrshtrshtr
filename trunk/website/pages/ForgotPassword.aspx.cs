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
using SimplicityCommLib;	//mjaved.sim.CommonLib

public partial class pages_ForgotPassword : GenericPage
{
    protected override void PostAuthenticated(SimplicityCommLib.DataSets.Common.Users.UsersRow user)
    {

    }
    protected override void PostUnauthenticated()
    {

    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnContinue_Click(object sender, ImageClickEventArgs e)
    {
        //mjaved.sim.CommonLib Verifying Answer and updating password
        SimplicityCommLib.DataSets.Common.Users.UsersRow user = DatabaseUtility.Instance.GetUserByEmail(txtEmail.Text);
        if (user != null)
        {
            if (user.ReminderQuestionId == byte.Parse(listForgotPasswordQuestion.SelectedValue)
                && user.ReminderQuestionAnswer.Equals(Utility.GetMd5Sum(txtForgotPasswordAnswer.Text)))
            {
                string password = Utility.RandomString(8, true);
                SimplicityCommLib.DataSets.Common.UsersTableAdapters.UsersTableAdapter userTA = new SimplicityCommLib.DataSets.Common.UsersTableAdapters.UsersTableAdapter();
                userTA.UpdatePassword(Utility.GetMd5Sum(password), user.UserId, user.UserId);
                EmailUtility.SendPasswordEmail(user.Email, password);
                Response.Redirect("~/pages/Login.aspx?" + WebConstants.Request.FROM_PAGE + "=ForgotPassword");
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
        lblErrorMessage.Text = WebConstants.Messages.Error.INVALID_CREDENTIALS;
        lblErrorMessage.Visible = true;
    }
}
