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
using SimplicityCommLib;

public partial class pages_VerifyEmail : GenericPage
{
    protected override void PostAuthenticated(SimplicityCommLib.DataSets.Common.Users.UsersRow user)
    {

    }
    protected override void PostUnauthenticated()
    {

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request[WebConstants.Request.USER_UID] != null && Request[WebConstants.Request.VERIFICATION_CODE] != null)
        {
            SimplicityCommLib.DataSets.Common.Users.UsersRow user = DatabaseUtility.Instance.GetUserByUID(Request[WebConstants.Request.USER_UID]);
            if (user != null)
            {
                string verificationCode = Utility.GetMd5Sum(user.VerificationCode);
                if (verificationCode.Equals(Request[WebConstants.Request.VERIFICATION_CODE]))
                {
                    SimplicityCommLib.DataSets.Common.UsersTableAdapters.UsersTableAdapter userTA = new SimplicityCommLib.DataSets.Common.UsersTableAdapters.UsersTableAdapter();
                    userTA.VerifyUser(user.UserId);
                    SetInfoMessage(WebConstants.Messages.Information.ACCOUNT_VERIFIED);
                }
                else
                {
                    SetErrorMessage(WebConstants.Messages.Error.CANNOT_VERIFY);
                }
            }
            else
            {
                SetErrorMessage(WebConstants.Messages.Error.CANNOT_VERIFY);
            }
        }
        else
        {
            SetErrorMessage(WebConstants.Messages.Error.CANNOT_VERIFY);
        }
    }
}
