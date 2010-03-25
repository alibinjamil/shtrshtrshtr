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

public partial class pages_AccountAddress : AuthenticatedPage
{
    private void SetAddresses(ref Customer.AddressEntityRow accountAddress,ref Customer.AddressEntityRow billingAddress,ref Customer.AddressEntityRow shippingAddress)
    {
        CustomerTableAdapters.AddressTableAdapter addressesTA = new CustomerTableAdapters.AddressTableAdapter();
        IEnumerator<Customer.AddressEntityRow> addresses = addressesTA.GetAddressByUser(LoggedInUserId).GetEnumerator();
        while (addresses.MoveNext())
        {
            if (addresses.Current.multi_add_type.Equals(Enum.GetName(typeof(ShoppingTrolley.Web.utils.Enums.ADDRESS_TYPE), ShoppingTrolley.Web.utils.Enums.ADDRESS_TYPE.PERSONAL)))
            {
                accountAddress = addresses.Current;
            }
            else if (addresses.Current.multi_add_type.Equals(Enum.GetName(typeof(ShoppingTrolley.Web.utils.Enums.ADDRESS_TYPE), ShoppingTrolley.Web.utils.Enums.ADDRESS_TYPE.BILLING)))
            {
                billingAddress = addresses.Current;
            }
            else if (addresses.Current.multi_add_type.Equals(Enum.GetName(typeof(ShoppingTrolley.Web.utils.Enums.ADDRESS_TYPE), ShoppingTrolley.Web.utils.Enums.ADDRESS_TYPE.SHIPPING)))
            {
                shippingAddress = addresses.Current;
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            Customer.AddressEntityRow accountAddress = null;
            Customer.AddressEntityRow billingAddress = null;
            Customer.AddressEntityRow shippingAddress = null;

            SetAddresses(ref accountAddress, ref billingAddress, ref shippingAddress);

            if (billingAddress != null && billingAddress.flg_same_as_customer == false)
            {
                imgBtnBilling.ImageUrl = "~/images/checkbox_unchecked.png";
                EnableBillingFields(true);
                txtBillingAddressLine1.Text = billingAddress.address_line1;
                txtBillingAddressLine2.Text = billingAddress.address_line2;
                txtBillingAddressLine3.Text = billingAddress.address_line3;
                txtBillingAddressLine4.Text = billingAddress.address_line4;
                txtBillingAddressLine5.Text = billingAddress.address_line5;
                txtBillingAddressNo.Text = billingAddress.address_no;
                txtBillingCountry.Text = billingAddress.country;
                txtBillingCounty.Text = billingAddress.county;
                txtBillingFax.Text = billingAddress.fax;
                txtBillingMobile.Text = billingAddress.cell_number;
                txtBillingPostCode.Text = billingAddress.address_post_code;
                txtBillingTele1.Text = billingAddress.telephone1;
                txtBillingTele2.Text = billingAddress.telephone2;
                txtBillingTown.Text = billingAddress.town;
            }
            else
            {
                imgBtnBilling.ImageUrl = "~/images/checkbox_checked.png";
                EnableBillingFields(false);
                txtBillingAddressLine1.Text = accountAddress.address_line1;
                txtBillingAddressLine2.Text = accountAddress.address_line2;
                txtBillingAddressLine3.Text = accountAddress.address_line3;
                txtBillingAddressLine4.Text = accountAddress.address_line4;
                txtBillingAddressLine5.Text = accountAddress.address_line5;
                txtBillingAddressNo.Text = accountAddress.address_no;
                txtBillingCountry.Text = accountAddress.country;
                txtBillingCounty.Text = accountAddress.county;
                txtBillingFax.Text = accountAddress.fax;
                txtBillingMobile.Text = accountAddress.cell_number;
                txtBillingPostCode.Text = accountAddress.address_post_code;
                txtBillingTele1.Text = accountAddress.telephone1;
                txtBillingTele2.Text = accountAddress.telephone2;
                txtBillingTown.Text = accountAddress.town;
            }

            if (shippingAddress != null && shippingAddress.flg_same_as_customer == false)
            {
                imgBtnShipping.ImageUrl = "~/images/checkbox_unchecked.png";
                EnableShippingFields(true);
                txtShippingAddressLine1.Text = shippingAddress.address_line1;
                txtShippingAddressLine2.Text = shippingAddress.address_line2;
                txtShippingAddressLine3.Text = shippingAddress.address_line3;
                txtShippingAddressLine4.Text = shippingAddress.address_line4;
                txtShippingAddressLine5.Text = shippingAddress.address_line5;
                txtShippingAddressNo.Text = shippingAddress.address_no;
                txtShippingCountry.Text = shippingAddress.country;
                txtShippingCounty.Text = shippingAddress.county;
                txtShippingFax.Text = shippingAddress.fax;
                txtShippingMobile.Text = shippingAddress.cell_number;
                txtShippingPostCode.Text = shippingAddress.address_post_code;
                txtShippingTele1.Text = shippingAddress.telephone1;
                txtShippingTele2.Text = shippingAddress.telephone2;
                txtShippingTown.Text = shippingAddress.town;
            }
            else
            {
                imgBtnShipping.ImageUrl = "~/images/checkbox_checked.png";
                EnableShippingFields(false);
                txtShippingAddressLine1.Text = accountAddress.address_line1;
                txtShippingAddressLine2.Text = accountAddress.address_line2;
                txtShippingAddressLine3.Text = accountAddress.address_line3;
                txtShippingAddressLine4.Text = accountAddress.address_line4;
                txtShippingAddressLine5.Text = accountAddress.address_line5;
                txtShippingAddressNo.Text = accountAddress.address_no;
                txtShippingCountry.Text = accountAddress.country;
                txtShippingCounty.Text = accountAddress.county;
                txtShippingFax.Text = accountAddress.fax;
                txtShippingMobile.Text = accountAddress.cell_number;
                txtShippingPostCode.Text = accountAddress.address_post_code;
                txtShippingTele1.Text = accountAddress.telephone1;
                txtShippingTele2.Text = accountAddress.telephone2;
                txtShippingTown.Text = accountAddress.town;
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
        Customer.AddressEntityRow accountAddress = null;
        Customer.AddressEntityRow billingAddress = null;
        Customer.AddressEntityRow shippingAddress = null;
        
        SetAddresses(ref accountAddress, ref billingAddress, ref shippingAddress);

        CustomerTableAdapters.AddressTableAdapter addressTA = new CustomerTableAdapters.AddressTableAdapter();
        if (imgBtnBilling.ImageUrl.Equals("~/images/checkbox_checked.png"))
        {
            if (billingAddress != null)
            {
                addressTA.Update(false, LoggedInUserId, true, false, Enum.GetName(typeof(ShoppingTrolley.Web.utils.Enums.ADDRESS_TYPE), ShoppingTrolley.Web.utils.Enums.ADDRESS_TYPE.BILLING),
                    null, null, null, null, null, null, null, null, null, null, null, null, null, LoggedInUserId, DateTime.Now, LoggedInUserId, DateTime.Now, null, null, null, billingAddress.address_id);
            }
            else
            {
                addressTA.Insert(false, LoggedInUserId, true, false, Enum.GetName(typeof(ShoppingTrolley.Web.utils.Enums.ADDRESS_TYPE), ShoppingTrolley.Web.utils.Enums.ADDRESS_TYPE.BILLING),
                    null, null, null, null, null, null, null, null, null, null, null, null, null, LoggedInUserId, DateTime.Now, LoggedInUserId, DateTime.Now, null, null, null);
            }
        }
        else
        {
            if (billingAddress != null)
            {
                addressTA.Update(false, LoggedInUserId, true, false, Enum.GetName(typeof(ShoppingTrolley.Web.utils.Enums.ADDRESS_TYPE), ShoppingTrolley.Web.utils.Enums.ADDRESS_TYPE.BILLING),
                    null, txtBillingAddressNo.Text, txtBillingAddressLine1.Text, txtBillingAddressLine2.Text, txtBillingAddressLine3.Text, txtBillingAddressLine4.Text, txtBillingAddressLine5.Text,
                    txtBillingPostCode.Text, null, txtBillingTele1.Text, txtBillingTele2.Text, txtBillingFax.Text, txtBillingMobile.Text, LoggedInUserId, DateTime.Now,
                    LoggedInUserId, DateTime.Now, txtBillingTown.Text, txtBillingCounty.Text, txtBillingCountry.Text, billingAddress.address_id);
            }
            else
            {
                addressTA.Insert(false, LoggedInUserId, true, false, Enum.GetName(typeof(ShoppingTrolley.Web.utils.Enums.ADDRESS_TYPE), ShoppingTrolley.Web.utils.Enums.ADDRESS_TYPE.BILLING),
                    null, txtBillingAddressNo.Text, txtBillingAddressLine1.Text, txtBillingAddressLine2.Text, txtBillingAddressLine3.Text, txtBillingAddressLine4.Text, txtBillingAddressLine5.Text,
                    txtBillingPostCode.Text, null, txtBillingTele1.Text, txtBillingTele2.Text, txtBillingFax.Text, txtBillingMobile.Text, LoggedInUserId, DateTime.Now,
                    LoggedInUserId, DateTime.Now, txtBillingTown.Text, txtBillingCounty.Text, txtBillingCountry.Text);
            }
        }
        if (imgBtnShipping.ImageUrl.Equals("~/images/checkbox_checked.png"))
        {
            if (shippingAddress != null)
            {
                addressTA.Update(false, LoggedInUserId, true, false, Enum.GetName(typeof(ShoppingTrolley.Web.utils.Enums.ADDRESS_TYPE), ShoppingTrolley.Web.utils.Enums.ADDRESS_TYPE.SHIPPING),
                    null, null, null, null, null, null, null, null, null, null, null, null, null, LoggedInUserId, DateTime.Now, LoggedInUserId, DateTime.Now, null, null, null, shippingAddress.address_id);
            }
            else
            {
                addressTA.Insert(false, LoggedInUserId, true, false, Enum.GetName(typeof(ShoppingTrolley.Web.utils.Enums.ADDRESS_TYPE), ShoppingTrolley.Web.utils.Enums.ADDRESS_TYPE.SHIPPING),
                    null, null, null, null, null, null, null, null, null, null, null, null, null, LoggedInUserId, DateTime.Now, LoggedInUserId, DateTime.Now, null, null, null);
            }
        }
        else
        {
            if (shippingAddress != null)
            {
                addressTA.Update(false, LoggedInUserId, true, false, Enum.GetName(typeof(ShoppingTrolley.Web.utils.Enums.ADDRESS_TYPE), ShoppingTrolley.Web.utils.Enums.ADDRESS_TYPE.SHIPPING),
                null, txtShippingAddressNo.Text, txtShippingAddressLine1.Text, txtShippingAddressLine2.Text, txtShippingAddressLine3.Text, txtShippingAddressLine4.Text, txtShippingAddressLine5.Text,
                txtShippingPostCode.Text, null, txtShippingTele1.Text, txtShippingTele2.Text, txtShippingFax.Text, txtShippingMobile.Text, LoggedInUserId, DateTime.Now,
                LoggedInUserId, DateTime.Now, txtShippingTown.Text, txtShippingCounty.Text, txtShippingCountry.Text, shippingAddress.address_id);
            }
            else
            {
                addressTA.Insert(false, LoggedInUserId, true, false, Enum.GetName(typeof(ShoppingTrolley.Web.utils.Enums.ADDRESS_TYPE), ShoppingTrolley.Web.utils.Enums.ADDRESS_TYPE.SHIPPING),
                    null, txtShippingAddressNo.Text, txtShippingAddressLine1.Text, txtShippingAddressLine2.Text, txtShippingAddressLine3.Text, txtShippingAddressLine4.Text, txtShippingAddressLine5.Text,
                    txtShippingPostCode.Text, null, txtShippingTele1.Text, txtShippingTele2.Text, txtShippingFax.Text, txtShippingMobile.Text, LoggedInUserId, DateTime.Now,
                    LoggedInUserId, DateTime.Now, txtShippingTown.Text, txtShippingCounty.Text, txtShippingCountry.Text);
            }
        }
        Response.Redirect("~/pages/ConfirmCheckout.aspx");
    }
}
