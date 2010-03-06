using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

    public static class WebConstants
    {
        public static int DEFAULT_DURATION = 12;
        public static int DEFAULT_ADDONS = 5;
        public static class Session
        {
            public static string USER_ID = "USER_ID";
            public static string VIEW_DEMO = "VIEW_DEMO";
            public static string TROLLEY = "TROLLEY";
            public static string RETURN_URL = "RETURN_URL";
            public static string PASSWORD = "PASSWORD";
            public static string ACTIVATION_CODE = "ACTIVATION_CODE";
            public static string CURRENT_CURRENCY = "CURRENT_CURRENCY";
        }

        public static class Request
        {
            public static string NEED_LOGIN = "NEED_LOGIN";
            public static string USER_UID = "USER_UID";
            public static string VERIFICATION_CODE = "VERIFICATION_CODE";
            public static string RECEIVE_EMAILS = "receiveEmails";
            public static string PRODUCT_ID = "productId";
            public static string VERSION_ID = "versionId";
            public static string PRODUCT_DETAIL_ID = "productDetailId";
            public static string PRICE = "price";
            public static string VIDEO_ID = "videoId";
            public static string MORE = "more";
            public static string FROM_PAGE = "fromPage";
        }
        public static class Messages
        {
            public static class Information
            {
                public static string ACCOUNT_VERIFIED = "Your account has been verified. Please login to continue";
            }
            public static class Error
            {
                public static string CANNOT_VERIFY = "Your account can not be verified. Please contact administrator";
                public static string CANNOT_LOGIN = "Invalid User Name / Password";
                public static string INVALID_CREDENTIALS = "Invalid Credentials. Can not proceed furhter.";
            }
        }
        public static class Currencies
        {
            public static string GBP = "GBP";
            public static string EUR = "EUR";
            public static string USD = "USD";
        }
    }
