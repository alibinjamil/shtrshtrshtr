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
        public static class Cookies
        {
            public static string UserLoginSession = "UserLoginSession";
        }
        public static class TemplateNames
        {
            public static string ACTIVATION = "ACTIVATION";
            public static string PASSWORD = "PASSWORD";
        }

        public static class Session
        {
            public static string USER_ID = "USER_ID";
            public static string VIEW_DEMO = "VIEW_DEMO";
            public static string TROLLEY = "TROLLEY";
            public static string RETURN_URL = "RETURN_URL";
            public static string PASSWORD = "PASSWORD";
            public static string ACTIVATION_CODE = "ACTIVATION_CODE";
            public static string CURRENT_CURRENCY = "CURRENT_CURRENCY";
            public static string PAYMENT_DETAILS = "PAYMENT_DETAILS";
            public static string USER_CO_ID = "USER_CO_ID";
            public static string DEPT_ID = "DEPT_ID";
            public static string USER_ROLE = "USER_ROLE";
            public static string COMPANY_NAME = "COMPANY_NAME";
            public static string HAS_AGREED = "HAS_AGREED";
            public static string REG_CO_ID = "REG_CO_ID";
            public static string REG_DEPT_ID = "REG_DEPT_ID";
            public static string REG_USER_ID = "REG_USER_ID";
            public static string WIZARD_STEP = "WIZARD_STEP";
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
            public static string TRANSACTION_ID = "transactionId";
            public static string INVALID_FIELDS = "invalidFields";
            public static string MISSING_FIELDS = "missingFields";
            public static string REASON_CODE = "reasonCode";
            public static string TRY = "try";
            public static string RETURN_URL = "RETURN_URL";
            public static string SESSION_EXPIRED = "sessionExpired";
            public static string DEPT_PERSON_ID = "deptPersonId";
            public static string ACTION = "action";
            public static string DEPT_ID = "depId";
            public static string ERROR_MSG = "errorMsg";
            public static string INFO_MSG = "infoMsg";
            public static string DEPT_ORDER_ID = "deptOrderId";
            public static string NO_DEPT = "noDept";
            public static string SEC_ID = "secId";
            public static string DOC_ID = "docId";
            public static string DOC_TYPE_ID = "docTypeId";
            public static string CO_ID = "coId";
            public static string USER_ID = "userId";
            public static string SCREEN_ID = "screenId";
            public static string DELETE = "delete";
            public static string INVALID_CACHE = "invalidCache";
        }
        public static class RequestValues
        {
            public static string ACTION_EDIT = "edit";
            public static string ACTION_DELETE = "delete";
        }
        public static class Messages
        {
            public static class Information
            {
                public static string RECORD_SAVED = "Record(s) saved successfully.";
                //public static string RECORD_UPDATED = "Record(s) updated successfully.";
                public static string ACCOUNT_VERIFIED = "Your account has been verified. Please login to continue";
                public static string RECORD_DELETED = "Record(s) deleted successfully.";
                public static string ORDER_CANCELLED = "Order cancelled successfully.";
                public static string ORDER_UNCANCELLED = "Order Uncancelled successfully.";
            }
            public static class Error
            {
                public static string SESSION_EXPIRED = "Session Expired. Please login again.";
                public static string INVALID_ID = "Select record is not present.";
                public static string ALREAD_EXISTS = "Record with this name already exists.";
                public static string CONNECTION_ERROR = "Connection error try again.";
                public static string NEXT_WARNING_ENTERRECORD = "Please enter a record to continue.";
                public static string NEXT_WARNING_COMPANYAUTOSAVE = "Autosave is not enabled for the company you belong to.";
                public static string SUPERVISOR_SELECTION_ERROR = "Only one supervisor is allowed for an order.";
                public static string SELECT_ATLEAST_ONE_DOCTYPE = "Atleast one Document Type must be selected.";
                public static string DOC_NOT_GENERATED = "Document could not be generated.";
                public static string NO_DEPT_DEFINED = "No department defined in the system. Atleast one department must be defined.";
                public static string INVALID_CACHE = "You have been logged out because you logged in from another machine";
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
        public static class Config
        {
            public static string ADMIN_EMAIL_ADDRESSES = "AdminEmailAddress";
		    public static string FROM_EMAIL_ADDRESS = "FromEmailAddress";
		    public static string CYBER_SOURCE_URL = "CyberSourceURL";
            public static string REDIRECT_URL = "RedirectURL";
		    public static string PAYMENT_OFFLINE = "PaymentOffline";
            public static string MERCHANT_ID = "MerchantID";
            public static string PUBLIC_KEY = "PublicKey";
            public static string PRIVATE_KEY = "PrivateKey";
            public static string SERIAL_NUMBER = "SerialNumber";
            public static string HS_URL = "HSURL";
        }
    }
