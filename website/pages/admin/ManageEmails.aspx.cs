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

public partial class pages_admin_ManageEmails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        EmailTemplates.EmailTemplateEntityRow email = DatabaseUtility.Instance.GetEmailTemplate(tbName.Text);
        if (email != null)
        {
            email.html = tbHtml.Text;
            email.subject = tbSubject.Text;
            EmailTemplatesTableAdapters.EmailTemplateTableAdapter ta = new EmailTemplatesTableAdapters.EmailTemplateTableAdapter();
            ta.Update(email);
        }
        else
        {
            EmailTemplatesTableAdapters.EmailTemplateTableAdapter ta = new EmailTemplatesTableAdapters.EmailTemplateTableAdapter();
            ta.Insert(tbName.Text, tbSubject.Text, tbHtml.Text);
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewEmail.aspx?name=" + tbName.Text);
    }
    protected void ButtonLoad_Click(object sender, EventArgs e)
    {
        EmailTemplates.EmailTemplateEntityRow email = DatabaseUtility.Instance.GetEmailTemplate(tbName.Text);
        if (email != null)
        {
            tbHtml.Text = email.html;
            tbSubject.Text = email.subject;
        }
        else
        {
            tbHtml.Text = "";
            tbSubject.Text = "";
        }
    }
    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {

    }
}
