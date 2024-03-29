﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

using ShoppingTrolley.Web;
using System.Collections.Generic;
using SimplicityCommLib;
public partial class Simplicity : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        
        if (Session[WebConstants.Session.USER_ID] == null)
        {
            hlLogout.Visible = false;
        }
        else
        {
            hlLogout.Visible = true;
        }
 


        //Request.Url.Segments[Request.Url.Segments.Length-1]
    }
    protected void btnLogout_Click(object sender, EventArgs e)
    {
		//mjaved.sim.CommonLib Cookie Destroy

        HttpCookie cookie = Request.Cookies["UserLoginSession"];
        if (cookie != null)
        {
            cookie.Expires = DateTime.Now;        
        }
    }
}
