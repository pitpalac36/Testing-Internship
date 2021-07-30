﻿using Madison.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madison.Pages
{
    public class MyCartPage
    {
        #region Selectors
        private readonly By _shoppingCartHeader = By.CssSelector("h1");
        private readonly By _emptyCartButton = By.CssSelector(".button2.btn-update:nth-child(3)");
        private readonly By _continueShopping = By.CssSelector(".button2.btn-continue");
        private readonly By _couponCodeInputArea = By.CssSelector("#coupon_code");
        private readonly By _shoppingCartTable = By.CssSelector("#shopping-cart-table");
        private readonly By _cartLabel = By.CssSelector(".count");
        private readonly By _errorMessage = By.CssSelector(".error-msg");
        #endregion
        
        public string GetHeaderMessage()
        {
            return Driver.webDriver.FindElement(_shoppingCartHeader).Text;
        }
    }
}