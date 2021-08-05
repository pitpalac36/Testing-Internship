using NsTestFrameworkUI.Helpers;
using NsTestFrameworkUI.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Madison.Helpers;
using OpenQA.Selenium.Support.UI;

namespace Madison.Pages
{
    public class CheckoutPage
    {
        #region Selectors
        private readonly By _guestOptionRadioButton = By.CssSelector(".radio[value='guest']");
        private readonly By _continueButtonCheckoutMethod = By.CssSelector(".button#onepage-guest-register-button");
        private readonly By _continueFromBillingInfoButton = By.CssSelector("#billing-buttons-container > button");
        private readonly By _shipToThisAddressRadioButton = By.CssSelector("#billing\\:use_for_shipping_yes");
        private readonly By _shipToDifferentAddressRadionButton = By.CssSelector("#billing\\:use_for_shipping_no");
        private readonly By _freeShippingRadioButton = By.Id("s_method_freeshipping_freeshipping");
        private readonly By _flatRateShippingRadionButton = By.Id("s_method_flatrate_flatrate");
        private readonly By _addGiftCheckbox = By.CssSelector("allow_gift_messages");
        private readonly By _continueButtonFromPaymentInformation = By.CssSelector("#payment-buttons-container .button");
        private readonly By _billingFirstNameInput = By.CssSelector("#billing\\:firstname");
        private readonly By _billingLastNameInput = By.CssSelector("#billing\\:lastname");
        private readonly By _billingEmailInput = By.CssSelector("#billing\\:email");
        private readonly By _placeOrderButton = By.CssSelector("button.btn-checkout");
        private readonly By _billingAddressInput = By.CssSelector("#billing\\:street1");
        private readonly By _billingCityInput = By.CssSelector("#billing\\:city");
        private readonly By _billingStateDropdownSelect = By.CssSelector("#billing\\:region_id");
        private readonly By _billingZipCodeInput = By.CssSelector("#billing\\:postcode");
        private readonly By _billingCountryDropdownSelect = By.CssSelector("#billing\\:country_id");
        private readonly By _billingTelephoneInput = By.CssSelector("#billing\\:telephone");
        private readonly By _continueButtonShippingInformation = By.CssSelector("#shipping-buttons-container > button");
        private readonly By _continueButtonFromShippingMethod = By.CssSelector("#shipping-method-buttons-container > button");
        private readonly By _editCheckoutMethod = By.CssSelector("#opc-login > div.step-title > a");
        private readonly By _registerAndCheckoutRadioButton = By.CssSelector("#login\\:register");
        private readonly By _editShippingInformation = By.CssSelector("#opc-shipping > div.step-title > a");
        private readonly By _proceedCheckoutButton = By.CssSelector(".button.btn-proceed-checkout.btn-checkout  span span ");
        private readonly By _shippingFirstNameInput = By.CssSelector("#shipping\\:firstname");
        private readonly By _shippingLastNameInput = By.CssSelector("#shipping\\:lastname");
        private readonly By _shippingAddressInput = By.CssSelector("#shipping\\:street1");
        private readonly By _shippingCityInput = By.CssSelector("#shipping\\:city");
        private readonly By _shippingStateDropdownSelect = By.CssSelector("#shipping\\:region_id");
        private readonly By _shippingZipCodeInput = By.CssSelector("#shipping\\:postcode");
        private readonly By _shippingCountryDropdownSelect = By.CssSelector("#shipping\\:country_id");
        private readonly By _shippingTelephoneInput = By.CssSelector("#shipping\\:telephone");
        private readonly By _checkoutSuccessMessage = By.CssSelector(".sub-title");
        #endregion

        public void ClickCheckoutAsGuest()
        {
            _guestOptionRadioButton.ActionClick();
            WaitHelpers.WaitForDocumentReadyState();
        }

        public void ClickRegisterAndCheckout()
        {
            _registerAndCheckoutRadioButton.ActionClick();
        }

        public void ClickEditShippingInformation()
        {
            _editShippingInformation.ActionClick();
        }

        public void ClickEditCheckoutMethod()
        {
            _editCheckoutMethod.ActionClick();
        }

        public void ClickContinueFromShippingMethod()
        {
            _continueButtonFromShippingMethod.ActionClick();
        }

        public void ClickContinueFromShippingInformation()
        {
            _continueButtonShippingInformation.ActionClick();
        }

        public void ClickContinueCheckout()
        {
            _continueButtonCheckoutMethod.ActionClick();
            WaitHelpers.WaitForDocumentReadyState();
        }

        public void ClickContinueFromBilling()
        {
            _continueFromBillingInfoButton.ActionClick();
            WaitHelpers.WaitForDocumentReadyState();
        }

        public void ClickContinuePayment()
        {
            _continueButtonFromPaymentInformation.ActionClick();
            WaitHelpers.WaitForDocumentReadyState();
        }

        public void ChooseShipToThisAddress()
        {
            _shipToThisAddressRadioButton.ActionClick();
        }

        public void ChooseShipToDifferentAddress()
        {
            _shipToDifferentAddressRadionButton.ActionClick();
        }

        public void ApplyFreeShipping()
        {
            if(_freeShippingRadioButton.IsElementPresent())
                _freeShippingRadioButton.ActionClick();
        }

        public void ApplyFlatRateShipping()
        {
            if (_flatRateShippingRadionButton.IsElementPresent())
                _flatRateShippingRadionButton.ActionClick();
        }

        public void AddGift()
        {
            _addGiftCheckbox.ActionClick();
        }


        public void FillBillingForm()
        {
            _billingFirstNameInput.ClearField();
            _billingLastNameInput.ClearField();
            _billingEmailInput.ClearField();
            _billingAddressInput.ClearField();
            _billingCityInput.ClearField();
            _billingZipCodeInput.ClearField();
            _billingTelephoneInput.ClearField();

            _billingFirstNameInput.ActionSendKeys(BillingInformation.FirstName);
            _billingLastNameInput.ActionSendKeys(BillingInformation.LastName);
            _billingEmailInput.ActionSendKeys(BillingInformation.EmailAddress);
            _billingAddressInput.ActionSendKeys(BillingInformation.Address);
            _billingCityInput.ActionSendKeys(BillingInformation.City);
            _billingZipCodeInput.ActionSendKeys(BillingInformation.ZIP);
            _billingTelephoneInput.ActionSendKeys(BillingInformation.Telephone);
            SelectElement cityDropdown = new SelectElement(Browser.WebDriver.FindElement(_billingStateDropdownSelect));
            cityDropdown.SelectByIndex(2);
        }

        public bool IsSuccessMessageDisplayedAfterCheckout()
        {
            new WebDriverWait(Browser.WebDriver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(_checkoutSuccessMessage));
            return _checkoutSuccessMessage.IsElementPresent();    
        }

        public void FillShippingForm()
        {
            _shippingFirstNameInput.ClearField();
            _shippingLastNameInput.ClearField();
            _shippingAddressInput.ClearField();
            _shippingCityInput.ClearField();
            _shippingZipCodeInput.ClearField();
            _shippingTelephoneInput.ClearField();

            _shippingFirstNameInput.ActionSendKeys(BillingInformation.FirstName);
            _shippingLastNameInput.ActionSendKeys(BillingInformation.LastName);
            _shippingAddressInput.ActionSendKeys(BillingInformation.Address);
            _shippingCityInput.ActionSendKeys(BillingInformation.City);
            _shippingZipCodeInput.ActionSendKeys(BillingInformation.ZIP);
            _shippingTelephoneInput.ActionSendKeys(BillingInformation.Telephone);
            SelectElement cityDropdown = new SelectElement(Browser.WebDriver.FindElement(_shippingStateDropdownSelect));
            cityDropdown.DeselectByIndex(2);
        }


        public void PlaceOrder()
        {
            _placeOrderButton.ActionClick();
            WaitHelpers.WaitForDocumentReadyState();
        }
    }
}
