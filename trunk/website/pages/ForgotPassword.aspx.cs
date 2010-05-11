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
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnContinue_Click(object sender, ImageClickEventArgs e)
    {
        //mjaved.sim.CommonLib Verifying Answer and updating password
        CommLibController userOBJ = new CommLibController();
        IEnumerator<UserSelectByEmailResult> user = userOBJ.GetUserByEmail(txtEmail.Text);

        if (user.MoveNext())
        {
            if (user.Current.ReminderQuestionId == byte.Parse(listForgotPasswordQuestion.SelectedValue)
                && user.Current.ReminderQuestionAnswer.Equals(Utility.GetMd5Sum(txtForgotPasswordAnswer.Text)))
            {
                string password = Utility.RandomString(8, true);

                userOBJ.UdateUserPassword(Utility.GetMd5Sum(password), user.Current.UserId.Value, user.Current.UserId.Value);
                EmailUtility.SendPasswordEmail(user.Current.Email, password);
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
