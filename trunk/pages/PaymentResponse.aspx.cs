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

public partial class pages_PaymentResponse : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!verifyTransactionSignature(Request))
        {
            panelSignature.Visible = true;
        }
        else
        {
            TransactionsTableAdapters.TransactionTableAdapter tranTA = new TransactionsTableAdapters.TransactionTableAdapter();
            string transactionId = Request["orderNumber"];
            if (Request.Form.Get("decision") == "ACCEPT" || Request.Form.Get("decision") == "REVIEW")
            {                
                panelSuccess.Visible = true;
                tranTA.Update(transactionId, Request.Form.Get("decision"), null, transactionId);
            }
            else
            {
                panelFailure.Visible = true;
                tranTA.Update(transactionId, Request.Form.Get("decision"), int.Parse(Request.Form.Get("reasonCode")), transactionId);
            }
        }
    }

    protected Boolean verifyTransactionSignature(System.Web.HttpRequest map)
    {
        return CyberSourceCS.verifyTransactionSignature(map);
    }
}
