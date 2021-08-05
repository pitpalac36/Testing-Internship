using NsTestFrameworkUI.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madison.Pages
{
    public class CheckoutPage
    {
        #region Selectors
        private readonly By _guestOptionRadioButton = By.CssSelector(".radio[value='guest']");
        private readonly By _continueButtonCheckoutMethod = By.CssSelector(".button#onepage-guest-register-button");
        private readonly By _continueButtonBillingInformation = By.CssSelector("#billing-buttons-container > button");
        private readonly By _shipToThisAdressRadioButton = By.CssSelector("#billing\\:use_for_shipping_yes");
        private readonly By _shipToDifferentAdressRadionButton = By.CssSelector("#billing\\:use_for_shipping_no");
        private readonly By _freeShippingRadioButton = By.Id("s_method_freeshipping_freeshipping");
        private readonly By _flatRateShippingRadionButton = By.Id("s_method_flatrate_flatrate");
        private readonly By _addGiftCheckbox = By.CssSelector("allow_gift_messages");
        private readonly By _continueButtonPaymentInformation = By.CssSelector("#payment-buttons-container .button");
        private readonly By _billingFirstNameInput = By.CssSelector("#billing\\:firstname");
        private readonly By _billingLastNameInput = By.CssSelector("#billing\\:lastname");
        private readonly By _billingEmailInput = By.CssSelector("#billing\\:email");
        private readonly By _placeOrderButton = By.CssSelector("button btn-checkout");
        private readonly By _billingAddressInput = By.CssSelector("#billing\\:street1");
        private readonly By _billingCityInput = By.CssSelector("#billing\\:city");
        private readonly By _stateDropdownSelect = By.CssSelector("#billing\\:region_id");
        private readonly By _ZipCodeInput = By.CssSelector("#billing\\:postcode");
        private readonly By _countryDropdownSelect = By.CssSelector("#billing\\:country_id");
        private readonly By _billingTelephoneInput = By.CssSelector("#billing\\:telephone");
        private readonly By _continueButtonShippingInformation = By.CssSelector("#shipping-buttons-container > button");
        private readonly By _continueButtonShippingMethod = By.CssSelector("#shipping-method-buttons-container > button");
        private readonly By _editCheckoutMethod = By.CssSelector("#opc-login > div.step-title > a");
        private readonly By _registerAndCheckoutRadioButton = By.CssSelector("#login\\:register");
        private readonly By _editShippingMethod = By.CssSelector("#opc-shipping > div.step-title > a");
        #endregion

        public void ClickCheckoutAsGuest()
        {
            _guestOptionRadioButton.ActionClick();
        }
    }
}
