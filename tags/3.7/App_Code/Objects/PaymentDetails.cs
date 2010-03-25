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

/// <summary>
/// Summary description for PaymentDetails
/// </summary>
public class PaymentDetails
{
	public PaymentDetails()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private string cardType;
    public string CardType
    {
        get{ return cardType;}
        set { cardType = value; }
    }

    private string cardNumber;
    public string CardNumber
    {
        get { return cardNumber; }
        set { cardNumber = value; }
    }

    private string expiryMonth;
    public string ExpiryMonth
    {
        get { return expiryMonth; }
        set { expiryMonth = value; }
    }

    private string expiryYear;
    public string ExpiryYear
    {
        get { return expiryYear; }
        set { expiryYear = value; }
    }

    private string securityCode;
    public string SecurityCode
    {
        get { return securityCode; }
        set { securityCode = value; }
    }

    private string startMonth;
    public string StartMonth
    {
        get { return startMonth; }
        set { startMonth = value; }
    }

    private string startYear;
    public string StartYear
    {
        get { return startYear; }
        set { startYear = value; }
    }

    private string firstName;
    public string FirstName
    {
        get { return firstName; }
        set { firstName = value; }
    }

    private string lastName;
    public string LastName
    {
        get { return lastName; }
        set { lastName = value; }
    }

    private string telephone;
    public string Telephone
    {
        get { return telephone; }
        set { telephone = value; }
    }

    private string street;
    public string Street
    {
        get { return street; }
        set { street = value; }
    }

    private string town;
    public string Town
    {
        get { return town; }
        set { town = value; }
    }

    private string county;
    public string County
    {
        get { return county; }
        set { county = value; }
    }

    private string country;
    public string Country
    {
        get { return country; }
        set { country = value; }
    }

    private string postCode;
    public string PostCode
    {
        get { return postCode; }
        set { postCode = value; }
    }

}
