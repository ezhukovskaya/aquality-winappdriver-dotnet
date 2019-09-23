﻿using Aquality.Selenium.Core.Localization;
using OpenQA.Selenium.Appium.Windows;
using System;
using SeleniumActions = OpenQA.Selenium.Interactions.Actions;

namespace Aquality.WinAppDriver.Actions
{
    /// <summary>
    /// Abstract class for any actions against the whole application.
    /// </summary>
    public abstract class ApplicationActions
    {
        private readonly LocalizationLogger localizationLogger;
        private readonly Func<WindowsDriver<WindowsElement>> windowsDriverSupplier;


        /// <summary>
        /// Instantiates Aplication actions.
        /// </summary>
        /// <param name="localizationLogger">Logger for localized values.</param>
        /// <param name="windowsDriverSupplier">Method to get current application session.</param>
        protected ApplicationActions(LocalizationLogger localizationLogger, Func<WindowsDriver<WindowsElement>> windowsDriverSupplier)
        {
            this.localizationLogger = localizationLogger;
            this.windowsDriverSupplier = windowsDriverSupplier;
        }

        /// <summary>
        /// Performs submitted action against new <see cref="SeleniumActions"/> object.
        /// </summary>
        /// <param name="action">Action to be performed.</param>
        protected virtual void PerformAction(Func<SeleniumActions, SeleniumActions> action)
        {
            action(new SeleniumActions(windowsDriverSupplier())).Build().Perform();
        }

        /// <summary>
        /// Logs keyboard action in specific format.
        /// </summary>
        /// <param name="messageKey">Key of the localized message.</param>
        /// <param name="args">Arguments for the localized message.</param>
        protected virtual void LogAction(string messageKey, params object[] args)
        {
            localizationLogger.Info(messageKey, args);
        }
    }
}