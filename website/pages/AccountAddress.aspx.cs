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

using ShoppingTrolley.Web.Objects;
using SimplicityCommLib;

public partial class pages_AccountAddress : AuthenticatedPage
{
    private void SetAddresses(ref Address accountAddress,ref Address billingAddress,ref Address shippingAddress)
    {
        CommLibController addressOBJ = new CommLibController();
        IEnumerator<Address> addresses = addressOBJ.GetAddressByTableId((int)ShoppingTrolley.Web.utils.Enums.ADDRESS_TYPE.PERSONAL, LoggedInUserId);
        while (addresses.MoveNext())
        {
            if (addresses.Current.MultiAddType.Equals(Enum.GetName(typeof(ShoppingTrolley.Web.utils.Enums.ADDRESS_TYPE), ShoppingTrolley.Web.utils.Enums.ADDRESS_TYPE.PERSONAL)))
            {
                accountAddress = addresses.Current;
            }
            else if (addresses.Current.MultiAddType.Equals(Enum.GetName(typeof(ShoppingTrolley.Web.utils.Enums.ADDRESS_TYPE), ShoppingTrolley.Web.utils.Enums.ADDRESS_TYPE.BILLING)))
            {
                billingAddress = addresses.Current;
            }
            else if (addresses.Current.MultiAddType.Equals(Enum.GetName(typeof(ShoppingTrolley.Web.utils.Enums.ADDRESS_TYPE), ShoppingTrolley.Web.utils.Enums.ADDRESS_TYPE.SHIPPING)))
            {
                shippingAddress = addresses.Current;
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            Address accountAddress = null;
            Address billingAddress = null;
            Address shippingAddress = null;

            SetAddresses(ref accountAddress, ref billingAddress, ref shippingAddress);

            if (billingAddress != null && billingAddress.FlgSameAsCustomer == false)
            {
                imgBtnBilling.ImageUrl = "~/images/checkbox_unchecked.png";
                EnableBillingFields(true);
                txtBillingAddressLine1.Text = billingAddress.AddressLine1;
                txtBillingAddressLine2.Text = billingAddress.AddressLine2;
                txtBillingAddressLine3.Text = billingAddress.AddressLine3;
                txtBillingAddressLine4.Text = billingAddress.AddressLine4;
                txtBillingAddressLine5.Text = billingAddress.AddressLine5;
                txtBillingAddressNo.Text = billingAddress.AddressNo;
                txtBillingCountry.Text = billingAddress.Country;
                txtBillingCounty.Text = billingAddress.County;
                txtBillingFax.Text = billingAddress.Fax;
                txtBillingMobile.Text = billingAddress.CellNumber;
                txtBillingPostCode.Text = billingAddress.AddressPostCode;
                txtBillingTele1.Text = billingAddress.Telephone1;
                txtBillingTele2.Text = billingAddress.Telephone2;
                txtBillingTown.Text = billingAddress.Town;
            }
            else
            {
                imgBtnBilling.ImageUrl = "~/images/checkbox_checked.png";
                EnableBillingFields(false);
                txtBillingAddressLine1.Text = accountAddress.AddressLine1;
                txtBillingAddressLine2.Text = accountAddress.AddressLine2;
                txtBillingAddressLine3.Text = accountAddress.AddressLine3;
                txtBillingAddressLine4.Text = accountAddress.AddressLine4;
                txtBillingAddressLine5.Text = accountAddress.AddressLine5;
                txtBillingAddressNo.Text = accountAddress.AddressNo;
                txtBillingCountry.Text = accountAddress.Country;
                txtBillingCounty.Text = accountAddress.County;
                txtBillingFax.Text = accountAddress.Fax;
                txtBillingMobile.Text = accountAddress.CellNumber;
                txtBillingPostCode.Text = accountAddress.AddressPostCode;
                txtBillingTele1.Text = accountAddress.Telephone1;
                txtBillingTele2.Text = accountAddress.Telephone2;
                txtBillingTown.Text = accountAddress.Town;
            }

            if (shippingAddress != null && shippingAddress.FlgSameAsCustomer == false)
            {
                imgBtnShipping.ImageUrl = "~/images/checkbox_unchecked.png";
                EnableShippingFields(true);
                txtShippingAddressLine1.Text = shippingAddress.AddressLine1;
                txtShippingAddressLine2.Text = shippingAddress.AddressLine2;
                txtShippingAddressLine3.Text = shippingAddress.AddressLine3;
                txtShippingAddressLine4.Text = shippingAddress.AddressLine4;
                txtShippingAddressLine5.Text = shippingAddress.AddressLine5;
                txtShippingAddressNo.Text = shippingAddress.AddressNo;
                txtShippingCountry.Text = shippingAddress.Country;
                txtShippingCounty.Text = shippingAddress.County;
                txtShippingFax.Text = shippingAddress.Fax;
                txtShippingMobile.Text = shippingAddress.CellNumber;
                txtShippingPostCode.Text = shippingAddress.AddressPostCode;
                txtShippingTele1.Text = shippingAddress.Telephone1;
                txtShippingTele2.Text = shippingAddress.Telephone2;
                txtShippingTown.Text = shippingAddress.Town;
            }
            else
            {
                imgBtnShipping.ImageUrl = "~/images/checkbox_checked.png";
                EnableShippingFields(false);
                txtShippingAddressLine1.Text = accountAddress.AddressLine1;
                txtShippingAddressLine2.Text = accountAddress.AddressLine2;
                txtShippingAddressLine3.Text = accountAddress.AddressLine3;
                txtShippingAddressLine4.Text = accountAddress.AddressLine4;
                txtShippingAddressLine5.Text = accountAddress.AddressLine5;
                txtShippingAddressNo.Text = accountAddress.AddressNo;
                txtShippingCountry.Text = accountAddress.Country;
                txtShippingCounty.Text = accountAddress.County;
                txtShippingFax.Text = accountAddress.Fax;
                txtShippingMobile.Text = accountAddress.CellNumber;
                txtShippingPostCode.Text = accountAddress.AddressPostCode;
                txtShippingTele1.Text = accountAddress.Telephone1;
                txtShippingTele2.Text = accountAddress.Telephone2;
                txtShippingTown.Text = accountAddress.Town;
            }
        }
    }
    private void EnableBillingFields(bool enable)
    {
        txtBillingAddressLine1.Enabled = enable;
        txtBillingAddressLine2.Enabled = enable;
        txtBillingAddressLine3.Enabled = enable;
        txtBillingAddressLine3.Enabled = enable;
        txtBillingAddressLine4.Enabled = enable;
        txtBillingAddressLine5.Enabled = enable;
        txtBillingAddressNo.Enabled = enable;
        txtBillingCountry.Enabled = enable;
        txtBillingCounty.Enabled = enable;
        txtBillingFax.Enabled = enable;
        txtBillingMobile.Enabled = enable;
        txtBillingPostCode.Enabled = enable;
        txtBillingTele1.Enabled = enable;
        txtBillingTele2.Enabled = enable;
        txtBillingTown.Enabled = enable;      
    }
    private void EnableShippingFields(bool enable)
    {
        txtShippingAddressLine1.Enabled = enable;
        txtShippingAddressLine2.Enabled = enable;
        txtShippingAddressLine3.Enabled = enable;
        txtShippingAddressLine3.Enabled = enable;
        txtShippingAddressLine4.Enabled = enable;
        txtShippingAddressLine5.Enabled = enable;
        txtShippingAddressNo.Enabled = enable;
        txtShippingCountry.Enabled = enable;
        txtShippingCounty.Enabled = enable;
        txtShippingFax.Enabled = enable;
        txtShippingMobile.Enabled = enable;
        txtShippingPostCode.Enabled = enable;
        txtShippingTele1.Enabled = enable;
        txtShippingTele2.Enabled = enable;
        txtShippingTown.Enabled = enable;
    }

    protected void imgBtnBilling_Click(object sender, ImageClickEventArgs e)
    {
        if (imgBtnBilling.ImageUrl.Equals("~/images/checkbox_checked.png"))
        {
            imgBtnBilling.ImageUrl = "~/images/checkbox_unchecked.png";
            EnableBillingFields(true);
        }
        else
        {
            imgBtnBilling.ImageUrl = "~/images/checkbox_checked.png";
            EnableBillingFields(false);
        }
    }
    protected void imgBtnShipping_Click(object sender, ImageClickEventArgs e)
    {
        if (imgBtnShipping.ImageUrl.Equals("~/images/checkbox_checked.png"))
        {
            imgBtnShipping.ImageUrl = "~/images/checkbox_unchecked.png";
            EnableShippingFields(true);
        }
        else
        {
            imgBtnShipping.ImageUrl = "~/images/checkbox_checked.png";
            EnableShippingFields(false);
        }
    }
    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        Address accountAddress = null;
        Address billingAddress = null;
        Address shippingAddress = null;

        SetAddresses(ref accountAddress, ref billingAddress, ref shippingAddress);

        CommLibController addressOBJ = new CommLibController();
        //CustomerTableAdapters.AddressTableAdapter addressTA = new CustomerTableAdapters.AddressTableAdapter();
        if (imgBtnBilling.ImageUrl.Equals("~/images/checkbox_checked.png"))
        {
            if (billingAddress != null)
            {
                addressOBJ.UpdateAddress(false,(int)ShoppingTrolley.Web.utils.Enums.ADDRESS_TYPE.PERSONAL ,LoggedInUserId, true, false, Enum.GetName(typeof(ShoppingTrolley.Web.utils.Enums.ADDRESS_TYPE), ShoppingTrolley.Web.utils.Enums.ADDRESS_TYPE.BILLING),
                    null, null, null, null, null, null, null, null, null, null, null, null, null, LoggedInUserId, DateTime.Now, LoggedInUserId, DateTime.Now, null, null, null, billingAddress.AddressId);
            }
            else
            {
                addressOBJ.InsertAddress(false,(int)ShoppingTrolley.Web.utils.Enums.ADDRESS_TYPE.PERSONAL, LoggedInUserId, true, false, Enum.GetName(typeof(ShoppingTrolley.Web.utils.Enums.ADDRESS_TYPE), ShoppingTrolley.Web.utils.Enums.ADDRESS_TYPE.BILLING),
                    null, null, null, null, null, null, null, null, null, null, null, null, null, LoggedInUserId, DateTime.Now, LoggedInUserId, DateTime.Now, null, null, null);
            }
        }
        else
        {
            if (billingAddress != null)
            {
                addressOBJ.UpdateAddress(false,(int)ShoppingTrolley.Web.utils.Enums.ADDRESS_TYPE.PERSONAL, LoggedInUserId, true, false, Enum.GetName(typeof(ShoppingTrolley.Web.utils.Enums.ADDRESS_TYPE), ShoppingTrolley.Web.utils.Enums.ADDRESS_TYPE.BILLING),
                    null, txtBillingAddressNo.Text, txtBillingAddressLine1.Text, txtBillingAddressLine2.Text, txtBillingAddressLine3.Text, txtBillingAddressLine4.Text, txtBillingAddressLine5.Text,
                    txtBillingPostCode.Text, null, txtBillingTele1.Text, txtBillingTele2.Text, txtBillingFax.Text, txtBillingMobile.Text, LoggedInUserId, DateTime.Now,
                    LoggedInUserId, DateTime.Now, txtBillingTown.Text, txtBillingCounty.Text, txtBillingCountry.Text, billingAddress.AddressId);
            }
            else
            {
                addressOBJ.InsertAddress(false, (int)ShoppingTrolley.Web.utils.Enums.ADDRESS_TYPE.PERSONAL, LoggedInUserId, true, false, Enum.GetName(typeof(ShoppingTrolley.Web.utils.Enums.ADDRESS_TYPE), ShoppingTrolley.Web.utils.Enums.ADDRESS_TYPE.BILLING),
                    null, txtBillingAddressNo.Text, txtBillingAddressLine1.Text, txtBillingAddressLine2.Text, txtBillingAddressLine3.Text, txtBillingAddressLine4.Text, txtBillingAddressLine5.Text,
                    txtBillingPostCode.Text, null, txtBillingTele1.Text, txtBillingTele2.Text, txtBillingFax.Text, txtBillingMobile.Text, LoggedInUserId, DateTime.Now,
                    LoggedInUserId, DateTime.Now, txtBillingTown.Text, txtBillingCounty.Text, txtBillingCountry.Text);
            }
        }
        if (imgBtnShipping.ImageUrl.Equals("~/images/checkbox_checked.png"))
        {
            if (shippingAddress != null)
            {
                addressOBJ.UpdateAddress(false, (int)ShoppingTrolley.Web.utils.Enums.ADDRESS_TYPE.PERSONAL, LoggedInUserId, true, false, Enum.GetName(typeof(ShoppingTrolley.Web.utils.Enums.ADDRESS_TYPE), ShoppingTrolley.Web.utils.Enums.ADDRESS_TYPE.SHIPPING),
                    null, null, null, null, null, null, null, null, null, null, null, null, null, LoggedInUserId, DateTime.Now, LoggedInUserId, DateTime.Now, null, null, null, shippingAddress.AddressId);
            }
            else
            {
                addressOBJ.InsertAddress(false, (int)ShoppingTrolley.Web.utils.Enums.ADDRESS_TYPE.PERSONAL, LoggedInUserId, true, false, Enum.GetName(typeof(ShoppingTrolley.Web.utils.Enums.ADDRESS_TYPE), ShoppingTrolley.Web.utils.Enums.ADDRESS_TYPE.SHIPPING),
                    null, null, null, null, null, null, null, null, null, null, null, null, null, LoggedInUserId, DateTime.Now, LoggedInUserId, DateTime.Now, null, null, null);
            }
        }
        else
        {
            if (shippingAddress != null)
            {
                addressOBJ.UpdateAddress(false, (int)ShoppingTrolley.Web.utils.Enums.ADDRESS_TYPE.PERSONAL, LoggedInUserId, true, false, Enum.GetName(typeof(ShoppingTrolley.Web.utils.Enums.ADDRESS_TYPE), ShoppingTrolley.Web.utils.Enums.ADDRESS_TYPE.SHIPPING),
                null, txtShippingAddressNo.Text, txtShippingAddressLine1.Text, txtShippingAddressLine2.Text, txtShippingAddressLine3.Text, txtShippingAddressLine4.Text, txtShippingAddressLine5.Text,
                txtShippingPostCode.Text, null, txtShippingTele1.Text, txtShippingTele2.Text, txtShippingFax.Text, txtShippingMobile.Text, LoggedInUserId, DateTime.Now,
                LoggedInUserId, DateTime.Now, txtShippingTown.Text, txtShippingCounty.Text, txtShippingCountry.Text, shippingAddress.AddressId);
            }
            else
            {
                addressOBJ.InsertAddress(false, (int)ShoppingTrolley.Web.utils.Enums.ADDRESS_TYPE.PERSONAL, LoggedInUserId, true, false, Enum.GetName(typeof(ShoppingTrolley.Web.utils.Enums.ADDRESS_TYPE), ShoppingTrolley.Web.utils.Enums.ADDRESS_TYPE.SHIPPING),
                    null, txtShippingAddressNo.Text, txtShippingAddressLine1.Text, txtShippingAddressLine2.Text, txtShippingAddressLine3.Text, txtShippingAddressLine4.Text, txtShippingAddressLine5.Text,
                    txtShippingPostCode.Text, null, txtShippingTele1.Text, txtShippingTele2.Text, txtShippingFax.Text, txtShippingMobile.Text, LoggedInUserId, DateTime.Now,
                    LoggedInUserId, DateTime.Now, txtShippingTown.Text, txtShippingCounty.Text, txtShippingCountry.Text);
            }
        }
        Response.Redirect("~/pages/ConfirmCheckout.aspx");
    }
}
