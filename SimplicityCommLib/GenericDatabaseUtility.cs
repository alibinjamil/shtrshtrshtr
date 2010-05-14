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
using System.Collections.Generic;
using SimplicityCommLib;
/// <summary>
/// Summary description for DatabaseUtility
/// </summary>
namespace SimplicityCommLib.Utility
{
    public abstract class GenericDatabaseUtility
    {
        public SimplicityCommLib.DataSets.Common.Products.ProductsRow GetProduct(int productId)
        {
            SimplicityCommLib.DataSets.Common.ProductsTableAdapters.ProductsTableAdapter prodTA = new SimplicityCommLib.DataSets.Common.ProductsTableAdapters.ProductsTableAdapter();
            IEnumerator<SimplicityCommLib.DataSets.Common.Products.ProductsRow> ieProducts = prodTA.GetProductById(productId).GetEnumerator();
            if (ieProducts.MoveNext())
            {
                return ieProducts.Current;
            }
            return null;
        }
        public SimplicityCommLib.DataSets.Common.Users.UsersRow GetLoggedInCustomer()
        {
            if (HttpContext.Current.Request.Cookies[WebConstants.Cookies.UserLoginSession] != null)
            {
                string sessionId = HttpContext.Current.Request.Cookies[WebConstants.Cookies.UserLoginSession].Value;
                if (sessionId != null && sessionId.Length > 0)
                {
                    SimplicityCommLib.DataSets.Common.SessionsTableAdapters.SessionsTableAdapter sessionTA = new SimplicityCommLib.DataSets.Common.SessionsTableAdapters.SessionsTableAdapter();
                    IEnumerator<SimplicityCommLib.DataSets.Common.Sessions.SessionsRow> ieSession = sessionTA.GetSessionByUID(sessionId).GetEnumerator();
                    if (ieSession.MoveNext())
                    {
                        SimplicityCommLib.DataSets.Common.UsersTableAdapters.UsersTableAdapter userTA = new SimplicityCommLib.DataSets.Common.UsersTableAdapters.UsersTableAdapter();
                        IEnumerator<SimplicityCommLib.DataSets.Common.Users.UsersRow> ieUser = userTA.GetUserById(ieSession.Current.UserId).GetEnumerator();
                        if (ieUser.MoveNext())
                        {
                            return ieUser.Current;
                        }
                    }
                }
            }
            return null;
        }
        public SimplicityCommLib.DataSets.Common.Users.UsersRow GetUserByEmail(string email)
        {
            SimplicityCommLib.DataSets.Common.UsersTableAdapters.UsersTableAdapter userTA = new SimplicityCommLib.DataSets.Common.UsersTableAdapters.UsersTableAdapter();
            IEnumerator<SimplicityCommLib.DataSets.Common.Users.UsersRow> ieUsers = userTA.GetUserByEmail(email).GetEnumerator();
            if (ieUsers.MoveNext())
            {
                return ieUsers.Current;
            }
            return null;
        }
        public SimplicityCommLib.DataSets.Common.Users.UsersRow GetUserByUID(string uid)
        {
            SimplicityCommLib.DataSets.Common.UsersTableAdapters.UsersTableAdapter userTA = new SimplicityCommLib.DataSets.Common.UsersTableAdapters.UsersTableAdapter();
            IEnumerator<SimplicityCommLib.DataSets.Common.Users.UsersRow> ieUsers = userTA.GetUserByUID(uid).GetEnumerator();
            if (ieUsers.MoveNext())
            {
                return ieUsers.Current;
            }
            return null;
        }


    }
}