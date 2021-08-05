using NsTestFrameworkUI.Helpers;
using NsTestFrameworkUI.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Madison.Helpers;

namespace Madison.Pages
{
    public class CheckoutPage
    {
        #region Selectors
        private readonly By _guestOptionRadioButton = By.CssSelector(".radio[value='guest']");
        private readonly By _continueButtonCheckoutMethod = By.CssSelector(".button#onepage-guest-register-button");
        private readonly By _continueButtonBillingInformation = By.CssSelector("#billing-buttons-container > button");
        private readonly By _shipToThisAddressRadioButton = By.CssSelector("#billing\\:use_for_shipping_yes");
        private readonly By _shipToDifferentAddressRadionButton = By.CssSelector("#billing\\:use_for_shipping_no");
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
        private readonly By _billingZipCodeInput = By.CssSelector("#billing\\:postcode");
        private readonly By _countryDropdownSelect = By.CssSelector("#billing\\:country_id");
        private readonly By _billingTelephoneInput = By.CssSelector("#billing\\:telephone");
        private readonly By _continueButtonShippingInformation = By.CssSelector("#shipping-buttons-container > button");
        private readonly By _continueButtonShippingMethod = By.CssSelector("#shipping-method-buttons-container > button");
        private readonly By _editCheckoutMethod = By.CssSelector("#opc-login > div.step-title > a");
        private readonly By _registerAndCheckoutRadioButton = By.CssSelector("#login\\:register");
        private readonly By _editShippingInformation = By.CssSelector("#opc-shipping > div.step-title > a");
        private readonly By _proceedCheckoutButton = By.CssSelector(".button.btn-proceed-checkout.btn-checkout  span span ");
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
            _continueButtonShippingMethod.ActionClick();
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

        public void ClickContinueBilling()
        {
            _continueButtonBillingInformation.ActionClick();
            WaitHelpers.WaitForDocumentReadyState();
        }

        public void ClickContinuePayment()
        {
            _continueButtonPaymentInformation.ActionClick();
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
            _freeShippingRadioButton.ActionClick();
        }

        public void ApplyFlatRateShipping()
        {
            _flatRateShippingRadionButton.ActionClick();
        }

        public void AddGift()
        {
            _addGiftCheckbox.ActionClick();
        }


        public void FillShippingForm()
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





        }

    }
}
