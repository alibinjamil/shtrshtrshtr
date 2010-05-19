﻿using System;
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

public partial class pages_VerifyEmail : GenericPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request[WebConstants.Request.USER_UID] != null && Request[WebConstants.Request.VERIFICATION_CODE] != null)
        {
            CustomerTableAdapters.CustomerTableAdapter customerTA = new CustomerTableAdapters.CustomerTableAdapter();
            IEnumerator<Customer.CustomerEntityRow> iEnum = customerTA.GetCustomerByUID(Request[WebConstants.Request.USER_UID]).GetEnumerator();
            if (iEnum.MoveNext())
            {
                if (iEnum.Current.Isverification_codeNull() == false)
                {
                    string verificationCode = Utility.GetMd5Sum(iEnum.Current.verification_code);
                    if (verificationCode.Equals(Request[WebConstants.Request.VERIFICATION_CODE]))
                    {
                        customerTA.VerifyCustomer(iEnum.Current.entity_id);
                        //activate record into HS
                        UserTableAdapters.un_co_user_detailsTableAdapter userTA = new UserTableAdapters.un_co_user_detailsTableAdapter();
                        IEnumerator ieUser = userTA.GetUserByLogonName(iEnum.Current.email, null).GetEnumerator();
                        if (ieUser.MoveNext())
                        {
                            User.un_co_user_detailsRow user = (User.un_co_user_detailsRow)ieUser.Current;
                            HSCompanyTableAdapters.HSCompanyTableAdapter coTA = new HSCompanyTableAdapters.HSCompanyTableAdapter();
                            coTA.UpdateActive(true, user.co_id);
                        }
                        hlHS.Visible = true;
                        SetInfoMessage(WebConstants.Messages.Information.ACCOUNT_VERIFIED);
                    }
                    else
                    {
                        SetErrorMessage(WebConstants.Messages.Error.CANNOT_VERIFY);
                    }
                }
                else
                {
                    SetErrorMessage("Your account is already verified.");
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