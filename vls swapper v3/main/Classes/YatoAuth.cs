
  
/*
 * Copyright © 2020, YATO.RE
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the “Software”), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
 * 
 * The Software is provided “as is”, without warranty of any kind, express or implied, including but not limited to the warranties of merchantability, fitness for a particular purpose and noninfringement. In no event shall the authors or copyright holders X be liable for any claim, damages or other liability, whether in an action of contract, tort or otherwise, arising from, out of or in connection with the software or the use or other dealings in the Software.
 * 
 * Except as contained in this notice, the name of YATO.RE shall not be used in advertising or otherwise to promote the sale, use or other dealings in this Software without prior written authorization from YATO.RE.
 */

// I know that's a lot of using but yea 1.6k lines of code ya know
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Security;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

internal static class Yato
{
    internal static class Auth
    {
        private static User user;

        public static bool Login(string username, string password, string otp_code = "", Action<string> otp_callback = null) // Explanation of Action: https://stackoverflow.com/a/41870053
        {
            Application.checkInitialized();

            if (!Application.isLoginEnabled())
            {
                if (Application.shouldShowMessages()) MessageBox.Show("Login is disabled!", Utils.formatTitle("Login"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (Application.isFreemode())
            {
                if (Application.shouldShowMessages()) MessageBox.Show($"{Application.getName()} has freemode enbaled, you have been logged in for free!", Utils.formatTitle("Login"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                if (Application.shouldShowMessages()) MessageBox.Show("The username and the password can't be empty!", Utils.formatTitle("Login"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            var webClient = new WebClient
            {
                Proxy = null,
                Headers = { [HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded", ["Yato-API"] = Application.getApiKey() }
            };

            Encryption.regenerateKeyAndIV();
            Security.startSession();

            var output = string.Empty;
            try
            {
                output = webClient.UploadString(Globals.API_ENDPOINT + "login", string.Concat(
                    "username=",
                    WebUtility.UrlEncode(Encryption.Encrypt(username)),
                    "&password=",
                    WebUtility.UrlEncode(Encryption.Encrypt(password)),
                    "&hwid=",
                    WebUtility.UrlEncode(Encryption.Encrypt(Globals.getHWID())),
                    "&otp_code=",
                    WebUtility.UrlEncode(Encryption.Encrypt(otp_code)),
                    "&app_secret=",
                    WebUtility.UrlEncode(Encryption.Encrypt(Application.getSecret(), false)),
                    Encryption.formatUrl()
                ));
            }
            catch (Exception e)
            {
                if (Application.shouldShowMessages()) MessageBox.Show($"An error occured, please contact support if you encounter this multiple times!\n\nException Message: {e.Message}", Utils.formatTitle("Login"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(-1);
            }

            LoginAnswer answer;
            try
            {
                answer = JsonConvert.DeserializeObject<LoginAnswer>(Encryption.Decrypt(output));
            }
            catch (Exception e)
            {
                if (Application.shouldShowMessages()) MessageBox.Show($"An error occured, please contact support if you encounter this multiple times!\n\nException Message: {e.Message}", Utils.formatTitle("Login"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(-1);
                return false;
            }

            Security.verifyTimestamp(answer.timestamp);
            Security.endSession();

            switch (answer.code)
            {
                case "invalid_request":
                    if (Application.shouldShowMessages()) MessageBox.Show("An error occured, please contact support if you encounter this multiple times!", Utils.formatTitle("Login"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(-1);
                    return false;
                case "invalid_salt":
                    if (Application.shouldShowMessages()) MessageBox.Show("The provided salt is invalid, please check on your YATO.RE application's settings!", Utils.formatTitle("Login"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(-1);
                    return false;
                case "invalid_api_key":
                    if (Application.shouldShowMessages()) MessageBox.Show("The provided API Key is invalid, please check on your YATO.RE profile!", Utils.formatTitle("Login"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(-1);
                    return false;
                case "invalid_creds":
                    if (Application.shouldShowMessages()) MessageBox.Show("The creditentials given are invalid!", Utils.formatTitle("Login"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                case "application_banned":
                    if (Application.shouldShowMessages()) MessageBox.Show($"{Application.getName()} is banned from YATO.RE, please read TOS next time to avoid this to happen!", Utils.formatTitle("Login"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(0);
                    return false;
                case "application_down":
                    if (Application.shouldShowMessages()) MessageBox.Show($"{Application.getName()} is down at the moment, please come back later!", Utils.formatTitle("Login"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Environment.Exit(0);
                    return false;
                case "banned_hwid":
                    if (Application.shouldShowMessages()) MessageBox.Show($"Your Harware ID is banned from {Application.getName()}!", Utils.formatTitle("Login"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(-1);
                    return false;
                case "banned_user":
                    if (Application.shouldShowMessages()) MessageBox.Show($"You are banned from {Application.getName()}!", Utils.formatTitle("Login"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(-1);
                    return false;
                case "expired_user":
                    if (Application.shouldShowMessages()) MessageBox.Show($"Your subscription to {Application.getName()} has expired!", Utils.formatTitle("Login"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                case "invalid_hwid":
                    if (Application.shouldShowMessages()) MessageBox.Show("Your Hardware ID doesn't match the one on our servers, if this is incorrect you should request an hwid reset!", Utils.formatTitle("Login"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                case "invalid_otp":
                    if (Application.shouldShowMessages()) MessageBox.Show("The 2FA code given is invalid!", Utils.formatTitle("Login"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                case "success":
                    break;
                default:
                    return false;
            }

            if (!string.IsNullOrEmpty(answer.otp_notification))
            {
                if (otp_callback != null)
                {
                    otp_callback(answer.otp_activation_url);
                }
                else
                {
                    if (MessageBox.Show("Your account doesn't have 2FA enabled, do you want to enabled it now?",
                            Utils.formatTitle("Login"), MessageBoxButtons.YesNo, MessageBoxIcon.Information) ==
                        DialogResult.Yes)
                    {
                        Process.Start(answer.otp_activation_url);
                    }
                }
            }

            if (string.IsNullOrEmpty(answer.username) || string.IsNullOrEmpty(answer.password) || string.IsNullOrEmpty(answer.hwid) || answer.username != username || answer.password != password || answer.hwid != Globals.getHWID())
            {
                if (Application.shouldShowMessages()) MessageBox.Show("An error occured, please contact support if you encounter this multiple times!", Utils.formatTitle("Login"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(-1);
                return false;
            }

            user = new User(answer.username, answer.hwid, answer.expiration, _OTPEnabled: answer.otp_enabled, answer.discord_linked);

            //MessageBox.Show($"You successfully logged into {Application.getName()}!", Utils.formatTitle("Login"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }

        private class LoginAnswer : Globals.ApiAnswer
        {
            [JsonProperty("otp_notification")]
            public string otp_notification { get; set; }

            [JsonProperty("otp_activate_url")]
            public string otp_activation_url { get; set; }

            [JsonProperty("username")]
            public string username { get; set; }

            [JsonProperty("password")]
            public string password { get; set; }

            [JsonProperty("hwid")]
            public string hwid { get; set; }

            [JsonProperty("expiration")]
            public string expiration { get; set; }

            [JsonProperty("otp_enabled")]
            public bool otp_enabled { get; set; }

            [JsonProperty("discord_linked")]
            public bool discord_linked { get; set; }
        }

        public static bool Register(string username, string password, string token)
        {
            Application.checkInitialized();

            if (!Application.isRegisterEnabled())
            {
                if (Application.shouldShowMessages()) MessageBox.Show("Register is disabled!", Utils.formatTitle("Register"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(token))
            {
                if (Application.shouldShowMessages()) MessageBox.Show("All fields are required!", Utils.formatTitle("Register"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            var webClient = new WebClient
            {
                Proxy = null,
                Headers = { [HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded", ["Yato-API"] = Application.getApiKey() }
            };

            Encryption.regenerateKeyAndIV();
            Security.startSession();

            var output = string.Empty;
            try
            {
                output = webClient.UploadString(Globals.API_ENDPOINT + "register", string.Concat(
                    "username=",
                    WebUtility.UrlEncode(Encryption.Encrypt(username)),
                    "&password=",
                    WebUtility.UrlEncode(Encryption.Encrypt(password)),
                    "&token=",
                    WebUtility.UrlEncode(Encryption.Encrypt(token)),
                    "&app_secret=",
                    WebUtility.UrlEncode(Encryption.Encrypt(Application.getSecret(), false)),
                    Encryption.formatUrl()
                ));
            }
            catch (Exception e)
            {
                if (Application.shouldShowMessages()) MessageBox.Show($"An error occured, please contact support if you encounter this multiple times!\n\nException Message: {e.Message}", Utils.formatTitle("Register"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(-1);
            }

            RegisterAnswer answer;
            try
            {
                answer = JsonConvert.DeserializeObject<RegisterAnswer>(Encryption.Decrypt(output));
            }
            catch (Exception e)
            {
                if (Application.shouldShowMessages()) MessageBox.Show($"An error occured, please contact support if you encounter this multiple times!\n\nException Message: {e.Message}", Utils.formatTitle("Register"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(-1);
                return false;
            }

            Security.verifyTimestamp(answer.timestamp);
            Security.endSession();

            switch (answer.code)
            {
                case "invalid_request":
                    if (Application.shouldShowMessages()) MessageBox.Show("An error occured, please contact support if you encounter this multiple times!", Utils.formatTitle("Register"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(-1);
                    return false;
                case "invalid_salt":
                    if (Application.shouldShowMessages()) MessageBox.Show("The provided salt is invalid, please check on your YATO.RE application's settings!", Utils.formatTitle("Register"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(-1);
                    return false;
                case "invalid_api_key":
                    if (Application.shouldShowMessages()) MessageBox.Show("The provided API Key is invalid, please check on your YATO.RE profile!", Utils.formatTitle("Register"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(-1);
                    return false;
                case "application_banned":
                    if (Application.shouldShowMessages()) MessageBox.Show($"{Application.getName()} is banned from YATO.RE, please read TOS next time to avoid this to happen!", Utils.formatTitle("Register"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(0);
                    return false;
                case "application_down":
                    if (Application.shouldShowMessages()) MessageBox.Show($"{Application.getName()} is down at the moment, please come back later!", Utils.formatTitle("Register"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Environment.Exit(0);
                    return false;
                case "invalid_token":
                    if (Application.shouldShowMessages()) MessageBox.Show("The token provided doesn't exists or is already used!", Utils.formatTitle("Register"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                case "invalid_username":
                    if (Application.shouldShowMessages()) MessageBox.Show("This username is already taken!", Utils.formatTitle("Register"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                case "reached_max_user":
                    if (Application.shouldShowMessages()) MessageBox.Show($"{Application.getName()} has reached the maximum user for the free plan, please consider buying! https://YATO.RE/buy", Utils.formatTitle("Register"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                case "success":
                    break;
                default:
                    return false;
            }

            if (string.IsNullOrEmpty(answer.username) || string.IsNullOrEmpty(answer.password) || string.IsNullOrEmpty(answer.token) || answer.username != username || answer.password != password || answer.token != token)
            {
                if (Application.shouldShowMessages()) MessageBox.Show("An error occured, please contact support if you encounter this multiple times!", Utils.formatTitle("Register"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(-1);
                return false;
            }

            //MessageBox.Show($"You successfully registerd into {Application.getName()}!", Utils.formatTitle("Register"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }

        private class RegisterAnswer : Globals.ApiAnswer
        {
            [JsonProperty("username")]
            public string username { get; set; }

            [JsonProperty("password")]
            public string password { get; set; }

            [JsonProperty("token")]
            public string token { get; set; }
        }

        public static bool Use(string username, string password, string token, string otp_code = "")
        {
            Application.checkInitialized();

            if (!Application.isUseEnabled())
            {
                if (Application.shouldShowMessages()) MessageBox.Show("Use Token is disabled!", Utils.formatTitle("Use"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(token))
            {
                if (Application.shouldShowMessages()) MessageBox.Show("All fields are required!", Utils.formatTitle("Use"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            var webClient = new WebClient
            {
                Proxy = null,
                Headers = { [HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded", ["Yato-API"] = Application.getApiKey() }
            };

            Encryption.regenerateKeyAndIV();
            Security.startSession();

            var output = string.Empty;
            try
            {
                output = webClient.UploadString(Globals.API_ENDPOINT + "use", string.Concat(
                    "username=",
                    WebUtility.UrlEncode(Encryption.Encrypt(username)),
                    "&password=",
                    WebUtility.UrlEncode(Encryption.Encrypt(password)),
                    "&token=",
                    WebUtility.UrlEncode(Encryption.Encrypt(token)),
                    "&hwid=",
                    WebUtility.UrlEncode(Encryption.Encrypt(Globals.getHWID())),
                    "&otp_code=",
                    WebUtility.UrlEncode(Encryption.Encrypt(otp_code)),
                    "&app_secret=",
                    WebUtility.UrlEncode(Encryption.Encrypt(Application.getSecret(), false)),
                    Encryption.formatUrl()
                ));
            }
            catch (Exception e)
            {
                if (Application.shouldShowMessages()) MessageBox.Show($"An error occured, please contact support if you encounter this multiple times!\n\nException Message: {e.Message}", Utils.formatTitle("Use"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(-1);
            }

            UseAnswer answer;
            try
            {
                answer = JsonConvert.DeserializeObject<UseAnswer>(Encryption.Decrypt(output));
            }
            catch (Exception e)
            {
                if (Application.shouldShowMessages()) MessageBox.Show($"An error occured, please contact support if you encounter this multiple times!\n\nException Message: {e.Message}", Utils.formatTitle("Use"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(-1);
                return false;
            }

            Security.verifyTimestamp(answer.timestamp);
            Security.endSession();

            switch (answer.code)
            {
                case "invalid_request":
                    if (Application.shouldShowMessages()) MessageBox.Show("An error occured, please contact support if you encounter this multiple times!", Utils.formatTitle("Use"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(-1);
                    return false;
                case "invalid_salt":
                    if (Application.shouldShowMessages()) MessageBox.Show("The provided salt is invalid, please check on your YATO.RE application's settings!", Utils.formatTitle("Use"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(-1);
                    return false;
                case "invalid_api_key":
                    if (Application.shouldShowMessages()) MessageBox.Show("The provided API Key is invalid, please check on your YATO.RE profile!", Utils.formatTitle("Use"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(-1);
                    return false;
                case "application_banned":
                    if (Application.shouldShowMessages()) MessageBox.Show($"{Application.getName()} is banned from YATO.RE, please read TOS next time to avoid this to happen!", Utils.formatTitle("Use"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(0);
                    return false;
                case "application_down":
                    if (Application.shouldShowMessages()) MessageBox.Show($"{Application.getName()} is down at the moment, please come back later!", Utils.formatTitle("Use"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Environment.Exit(0);
                    return false;
                case "invalid_operation":
                    if (Application.shouldShowMessages()) MessageBox.Show("You are already lifetime!", Utils.formatTitle("Use"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                case "invalid_creds":
                    if (Application.shouldShowMessages()) MessageBox.Show("The creditentials given are invalid!", Utils.formatTitle("Use"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                case "invalid_token":
                    if (Application.shouldShowMessages()) MessageBox.Show("The token provided doesn't exists or is already used!", Utils.formatTitle("Use"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                case "banned_user":
                    if (Application.shouldShowMessages()) MessageBox.Show($"You are banned from {Application.getName()}!", Utils.formatTitle("Use"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(-1);
                    return false;
                case "expired_user":
                    if (Application.shouldShowMessages()) MessageBox.Show($"Your subscription to {Application.getName()} has expired!", Utils.formatTitle("Use"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                case "invalid_hwid":
                    if (Application.shouldShowMessages()) MessageBox.Show("Your Hardware ID doesn't match the one on our servers, if this is incorrect you should request an hwid reset!", Utils.formatTitle("Use"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                case "invalid_otp":
                    if (Application.shouldShowMessages()) MessageBox.Show("The 2FA code given is invalid!", Utils.formatTitle("Use"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                case "success":
                    break;
                default:
                    return false;
            }

            if (string.IsNullOrEmpty(answer.username) || string.IsNullOrEmpty(answer.password) || string.IsNullOrEmpty(answer.hwid) || string.IsNullOrEmpty(answer.token) || answer.username != username || answer.password != password || answer.hwid != Globals.getHWID() || answer.token != token)
            {
                if (Application.shouldShowMessages()) MessageBox.Show("An error occured, please contact support if you encounter this multiple times!", Utils.formatTitle("Use"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(-1);
                return false;
            }

            MessageBox.Show("You successfully used your token !", Utils.formatTitle("Use"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }

        private class UseAnswer : Globals.ApiAnswer
        {

            [JsonProperty("username")]
            public string username { get; set; }

            [JsonProperty("password")]
            public string password { get; set; }

            [JsonProperty("hwid")]
            public string hwid { get; set; }

            [JsonProperty("token")]
            public string token { get; set; }
        }

        public static bool ChangePassword(string username, string password, string newpassword, string newpassword_confirmation, string otp_code = "")
        {
            Application.checkInitialized();

            if (!Application.isChangePasswordEnabled())
            {
                if (Application.shouldShowMessages()) MessageBox.Show("Change Password is disabled!", Utils.formatTitle("Change Password"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(newpassword_confirmation))
            {
                if (Application.shouldShowMessages()) MessageBox.Show("All fields are required!", Utils.formatTitle("Change Password"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            var webClient = new WebClient
            {
                Proxy = null,
                Headers = { [HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded", ["Yato-API"] = Application.getApiKey() }
            };

            Encryption.regenerateKeyAndIV();
            Security.startSession();

            var output = string.Empty;
            try
            {
                output = webClient.UploadString(Globals.API_ENDPOINT + "change/password", string.Concat(
                    "username=",
                    WebUtility.UrlEncode(Encryption.Encrypt(username)),
                    "&password=",
                    WebUtility.UrlEncode(Encryption.Encrypt(password)),
                    "&newpassword=",
                    WebUtility.UrlEncode(Encryption.Encrypt(newpassword)),
                    "&newpassword_confirmation=",
                    WebUtility.UrlEncode(Encryption.Encrypt(newpassword_confirmation)),
                    "&otp_code=",
                    WebUtility.UrlEncode(Encryption.Encrypt(otp_code)),
                    "&app_secret=",
                    WebUtility.UrlEncode(Encryption.Encrypt(Application.getSecret(), false)),
                    Encryption.formatUrl()
                ));
            }
            catch (Exception e)
            {
                if (Application.shouldShowMessages()) MessageBox.Show($"An error occured, please contact support if you encounter this multiple times!\n\nException Message: {e.Message}", Utils.formatTitle("Change Password"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(-1);
            }

            ChangePasswordAnswer answer;
            try
            {
                answer = JsonConvert.DeserializeObject<ChangePasswordAnswer>(Encryption.Decrypt(output));
            }
            catch (Exception e)
            {
                if (Application.shouldShowMessages()) MessageBox.Show($"An error occured, please contact support if you encounter this multiple times!\n\nException Message: {e.Message}", Utils.formatTitle("Change Password"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(-1);
                return false;
            }

            Security.verifyTimestamp(answer.timestamp);
            Security.endSession();

            switch (answer.code)
            {
                case "invalid_request":
                    if (Application.shouldShowMessages()) MessageBox.Show("An error occured, please contact support if you encounter this multiple times!", Utils.formatTitle("Change Password"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(-1);
                    return false;
                case "invalid_salt":
                    if (Application.shouldShowMessages()) MessageBox.Show("The provided salt is invalid, please check on your YATO.RE application's settings!", Utils.formatTitle("Change Password"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(-1);
                    return false;
                case "invalid_api_key":
                    if (Application.shouldShowMessages()) MessageBox.Show("The provided API Key is invalid, please check on your YATO.RE profile!", Utils.formatTitle("Change Password"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(-1);
                    return false;
                case "application_banned":
                    if (Application.shouldShowMessages()) MessageBox.Show($"{Application.getName()} is banned from YATO.RE, please read TOS next time to avoid this to happen!", Utils.formatTitle("Change Password"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(0);
                    return false;
                case "application_down":
                    if (Application.shouldShowMessages()) MessageBox.Show($"{Application.getName()} is down at the moment, please come back later!", Utils.formatTitle("Change Password"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Environment.Exit(0);
                    return false;
                case "invalid_creds":
                    if (Application.shouldShowMessages()) MessageBox.Show("The creditentials given are invalid!", Utils.formatTitle("Change Password"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                case "invalid_otp":
                    if (Application.shouldShowMessages()) MessageBox.Show("The 2FA code given is invalid!", Utils.formatTitle("Change Password"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                case "banned_user":
                    if (Application.shouldShowMessages()) MessageBox.Show($"You are banned from {Application.getName()}!", Utils.formatTitle("Change Password"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(-1);
                    return false;
                case "expired_user":
                    if (Application.shouldShowMessages()) MessageBox.Show($"Your subscription to {Application.getName()} has expired!", Utils.formatTitle("Change Password"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                case "invalid_password_confirmation":
                    if (Application.shouldShowMessages()) MessageBox.Show("The passwords doesn't matches!", Utils.formatTitle("Change Password"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                case "invalid_new_password":
                    if (Application.shouldShowMessages()) MessageBox.Show("The new password needs to be different from actual one!", Utils.formatTitle("Change Password"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                case "success":
                    break;
                default:
                    return false;
            }

            if (string.IsNullOrEmpty(answer.username) || string.IsNullOrEmpty(answer.password) || string.IsNullOrEmpty(answer.newpassword) || answer.username != username || answer.password != password || answer.newpassword != newpassword)
            {
                if (Application.shouldShowMessages()) MessageBox.Show("An error occured, please contact support if you encounter this multiple times!", Utils.formatTitle("Change Password"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(-1);
                return false;
            }

            MessageBox.Show("You successfully changed your password!", Utils.formatTitle("Change Password"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }

        private class ChangePasswordAnswer : Globals.ApiAnswer
        {
            [JsonProperty("username")]
            public string username { get; set; }

            [JsonProperty("password")]
            public string password { get; set; }

            [JsonProperty("newpassword")]
            public string newpassword { get; set; }
        }

        public static User getUser()
        {
            if (user != null)
                return user;

            //MessageBox.Show("You haven't logged in, we'll return an empty user!", "YATO.RE - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return new User("undefined", "undefined", "undefined", false, false);
        }

        public static bool hasPassedLogin()
        {
            return user != null;
        }
    }

    internal static class Application
    {
        // Don't ask me why I like to make my own setters and getters

        #region Fields
        private static bool developmentMode;
        private static bool showMessages = true;
        private static string secret;
        private static string salt;
        private static string api_key;
        private static string name = "Default Name";
        private static string hash;
        private static string jsonHash;
        private static bool init;

        private static Dictionary<string, string> variables = new Dictionary<string, string>();

        private static bool active;
        private static bool banned;
        private static bool hwidProtected;
        private static bool otpEnabled;
        private static bool loginEnabled;
        private static bool registerEnabled;
        private static bool useEnabled;
        private static bool changePasswordEnabled;
        private static bool freemodeEnabled;
        #endregion

        #region Getter/Setter

        public static void setDevelopmentMode(bool state)
        {
            developmentMode = state;
        }

        public static bool isDevelopmentMode()
        {
            return developmentMode;
        }

        public static void setShowMessages(bool state)
        {
            showMessages = state;
        }

        public static bool shouldShowMessages()
        {
            return showMessages;
        }

        private static void setSecret(string input)
        {
            secret = input;
        }

        public static string getSecret()
        {
            return secret;
        }

        private static void setSalt(string input)
        {
            salt = input;
        }

        public static string getSalt()
        {
            return salt;
        }

        private static void setApiKey(string input)
        {
            api_key = input;
        }

        public static string getApiKey()
        {
            return api_key;
        }

        public static void setName(string input)
        {
            name = input;
        }

        public static string getName()
        {
            return name;
        }

        public static void setHash(string input)
        {
            hash = input;
        }

        public static string getHash()
        {
            return hash;
        }

        public static void setJsonHash(string input)
        {
            jsonHash = input;
        }

        public static string getJsonHash()
        {
            return jsonHash;
        }

        private static void setActive(bool state)
        {
            active = state;
        }

        public static bool isActive()
        {
            return active;
        }

        private static void setBanned(bool state)
        {
            banned = state;
        }

        public static bool isBanned()
        {
            return banned;
        }

        private static void setHWIDProtected(bool state)
        {
            hwidProtected = state;
        }

        public static bool isHWIDProtected()
        {
            return hwidProtected;
        }

        private static void setOTPEnabled(bool state)
        {
            otpEnabled = state;
        }

        public static bool isOTPEnabled()
        {
            return otpEnabled;
        }

        private static void setLoginEnabled(bool state)
        {
            loginEnabled = state;
        }

        public static bool isLoginEnabled()
        {
            return loginEnabled;
        }

        private static void setRegisterEnabled(bool state)
        {
            registerEnabled = state;
        }

        public static bool isRegisterEnabled()
        {
            return registerEnabled;
        }

        private static void setUseEnabled(bool state)
        {
            useEnabled = state;
        }

        public static bool isUseEnabled()
        {
            return useEnabled;
        }

        private static void setChangePasswordEnabled(bool state)
        {
            changePasswordEnabled = state;
        }

        public static bool isChangePasswordEnabled()
        {
            return changePasswordEnabled;
        }

        private static void setFreemode(bool state)
        {
            freemodeEnabled = state;
        }

        public static bool isFreemode()
        {
            return freemodeEnabled;
        }

        #endregion

        private static bool isSettingsSet()
        {
            return !string.IsNullOrEmpty(getSecret()) && !string.IsNullOrEmpty(getName()) && !string.IsNullOrEmpty((getSalt())) && !string.IsNullOrEmpty(getApiKey());
        }

        public static void checkInitialized()
        {
            if (init && isSettingsSet())
                return;

            MessageBox.Show("Check that the application settings are correctly set!", "YATO.RE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Environment.Exit(-1);
        }

        public static void Initialize(string secret, string salt, string api_key)
        {
            setSecret(secret);
            setSalt(salt);
            setApiKey(api_key);

            if (!isSettingsSet())
            {
                MessageBox.Show("Check that the application settings are correctly set!", "YATO.RE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(-1);
            }

            Security.run();

            var webClient = new WebClient
            {
                Proxy = null,
                Headers = { [HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded", ["Yato-API"] = Application.getApiKey() }
            };

            Encryption.regenerateKeyAndIV();
            Security.startSession();

            var output = string.Empty;
            try
            {
                output = webClient.UploadString(Globals.API_ENDPOINT + "app_infos", string.Concat(
                    "hwid=",
                    WebUtility.UrlEncode(Encryption.Encrypt(Globals.getHWID())),
                    "&app_secret=",
                    WebUtility.UrlEncode(Encryption.Encrypt(Application.getSecret(), false)),
                    Encryption.formatUrl()
                ));
            }
            catch (Exception e)
            {
                if (Application.shouldShowMessages()) MessageBox.Show($"An error occured, please contact support if you encounter this multiple times!\n\nException Message: {e.Message}", Utils.formatTitle("Application Infos"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(-1);
            }

            AppInfosAnswer answer = null;
            try
            {
                answer = JsonConvert.DeserializeObject<AppInfosAnswer>(Encryption.Decrypt(output));
            }
            catch (Exception e)
            {
                if (Application.shouldShowMessages()) MessageBox.Show($"An error occured, please contact support if you encounter this multiple times!\n\nException Message: {e.Message}", Utils.formatTitle("Application Infos"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(-1);
            }

            Security.verifyTimestamp(answer.timestamp);
            Security.endSession();

            switch (answer.code)
            {
                case "invalid_request":
                    if (Application.shouldShowMessages()) MessageBox.Show("An error occured, please contact support if you encounter this multiple times!", Utils.formatTitle("Application Infos"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(-1);
                    return;
                case "invalid_salt":
                    if (Application.shouldShowMessages()) MessageBox.Show("The provided salt is invalid, please check on your YATO.RE application's settings!", Utils.formatTitle("Application Infos"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(-1);
                    return;
                case "invalid_api_key":
                    if (Application.shouldShowMessages()) MessageBox.Show("The provided API Key is invalid, please check on your YATO.RE profile!", Utils.formatTitle("Application Infos"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(-1);
                    return;
                case "application_banned":
                    if (Application.shouldShowMessages()) MessageBox.Show($"{getName()} is banned from YATO.RE, please read TOS next time to avoid this to happen!", Utils.formatTitle("Application Infos"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(0);
                    return;
                case "application_down":
                    if (Application.shouldShowMessages()) MessageBox.Show($"{getName()} is down at the moment, please come back later!", Utils.formatTitle("Application Infos"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Environment.Exit(0);
                    return;
                case "banned_hwid":
                    if (Application.shouldShowMessages()) MessageBox.Show($"Your Harware ID is banned from {getName()}!", Utils.formatTitle("Security"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(-1);
                    return;
                case "success":
                    break;
                default:
                    return;
            }

            setActive(answer.app_active);
            setBanned(answer.app_banned);
            setHWIDProtected(answer.app_hwid_protected);
            setOTPEnabled(answer.app_otp_enabled);
            setLoginEnabled(answer.app_login_enabled);
            setRegisterEnabled(answer.app_register_enabled);
            setUseEnabled(answer.app_use_enabled);
            setChangePasswordEnabled(answer.app_change_password);
            setFreemode(answer.app_freemode);
            setHash(answer.app_hash);

            if (Application.isBanned())
            {
                if (Application.shouldShowMessages()) MessageBox.Show($"{Application.getName()} is banned from YATO.RE, please read TOS next time to avoid this to happen!", Utils.formatTitle("Constant Checks"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(-1);
                return;
            }

            if (!Application.isActive())
            {
                if (Application.shouldShowMessages()) MessageBox.Show($"{Application.getName()} is down at the moment, please come back later!", Utils.formatTitle("Constant Checks"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                Environment.Exit(0);
                return;
            }

            Security.hashCheck();

            init = true;
        }

        private class AppInfosAnswer : Globals.ApiAnswer
        {
            [JsonProperty("app_active")]
            public bool app_active { get; set; }

            [JsonProperty("app_banned")]
            public bool app_banned { get; set; }

            [JsonProperty("app_hwid_protected")]
            public bool app_hwid_protected { get; set; }

            [JsonProperty("app_otp_enabled")]
            public bool app_otp_enabled { get; set; }

            [JsonProperty("app_login_enabled")]
            public bool app_login_enabled { get; set; }

            [JsonProperty("app_register_enabled")]
            public bool app_register_enabled { get; set; }

            [JsonProperty("app_use_enabled")]
            public bool app_use_enabled { get; set; }

            [JsonProperty("app_change_password")]
            public bool app_change_password { get; set; }

            [JsonProperty("app_freemode")]
            public bool app_freemode { get; set; }

            [JsonProperty("app_hash")]
            public string app_hash { get; set; } = "";

        }

        public static string getVariable(string key)
        {
            if (variables.ContainsKey(key))
                return variables[key];

            checkInitialized();

            if (string.IsNullOrEmpty(key))
            {
                if (Application.shouldShowMessages()) MessageBox.Show("You need to provide a key name in order to get a variable!", Utils.formatTitle("Server Variables"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "undefined";
            }

            var webClient = new WebClient
            {
                Proxy = null,
                Headers = { [HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded", ["Yato-API"] = Application.getApiKey() }
            };

            Encryption.regenerateKeyAndIV();
            Security.startSession();

            var output = string.Empty;
            try
            {
                output = webClient.UploadString(Globals.API_ENDPOINT + "variable", string.Concat(
                    "var_name=",
                    WebUtility.UrlEncode(Encryption.Encrypt(key)),
                    "&app_secret=",
                    WebUtility.UrlEncode(Encryption.Encrypt(Application.getSecret(), false)),
                    Encryption.formatUrl()
                ));
            }
            catch (Exception e)
            {
                if (Application.shouldShowMessages()) MessageBox.Show($"An error occured, please contact support if you encounter this multiple times!\n\nException Message: {e.Message}", Utils.formatTitle("Server Variables"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(-1);
            }

            VariableAnswer answer;
            try
            {
                answer = JsonConvert.DeserializeObject<VariableAnswer>(Encryption.Decrypt(output));
            }
            catch (Exception e)
            {
                if (Application.shouldShowMessages()) MessageBox.Show($"An error occured, please contact support if you encounter this multiple times!\n\nException Message: {e.Message}", Utils.formatTitle("Server Variables"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(-1);
                return "undefined";
            }

            Security.verifyTimestamp(answer.timestamp);
            Security.endSession();

            switch (answer.code)
            {
                case "invalid_request":
                case "invalid_salt":
                    if (Application.shouldShowMessages()) MessageBox.Show("An error occured, please contact support if you encounter this multiple times!", Utils.formatTitle("Server Variables"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(-1);
                    return "undefined";
                case "application_banned":
                    if (Application.shouldShowMessages()) MessageBox.Show($"{getName()} is banned from YATO.RE, please read TOS next time to avoid this to happen!", Utils.formatTitle("Server Variables"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(0);
                    return "undefined";
                case "application_down":
                    if (Application.shouldShowMessages()) MessageBox.Show($"{getName()} is down at the moment, please come back later!", Utils.formatTitle("Server Variables"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Environment.Exit(0);
                    return "undefined";
                case "invalid_var_name":
                    if (Application.shouldShowMessages()) MessageBox.Show($"The variable with the name {key} could not be found!", Utils.formatTitle("Server Variables"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "undefined";
                case "success":
                    break;
                default:
                    return "undefined";
            }

            if (string.IsNullOrEmpty(answer.var_name) || answer.var_name != key)
            {
                if (Application.shouldShowMessages()) MessageBox.Show("An error occured, please contact support if you encounter this multiple times!", Utils.formatTitle("Server Variables"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(-1);
                return "undefined";
            }

            variables.Add(answer.var_name, answer.var_value);

            return answer.var_value;
        }

        private class VariableAnswer : Globals.ApiAnswer
        {
            [JsonProperty("var_name")]
            public string var_name { get; set; }

            [JsonProperty("var_value")]
            public string var_value { get; set; }
        }

        public enum Links
        {
            Discord = 1,
            OTP = 2
        }

        public static string generateLink(Links link)
        {
            if (!Auth.hasPassedLogin())
                return "undefined";

            checkInitialized();

            var webClient = new WebClient
            {
                Proxy = null,
                Headers =
                {
                    [HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded",
                    ["Yato-API"] = Application.getApiKey()
                }
            };

            Encryption.regenerateKeyAndIV();
            Security.startSession();

            var output = string.Empty;
            try
            {
                output = webClient.UploadString(Globals.API_ENDPOINT + "link/generate", string.Concat(
                    "username=",
                    WebUtility.UrlEncode(Encryption.Encrypt(Auth.getUser().getUsername())),
                    "&type=",
                    WebUtility.UrlEncode(Encryption.Encrypt(link.ToString())),
                    "&app_secret=",
                    WebUtility.UrlEncode(Encryption.Encrypt(Application.getSecret(), false)),
                    Encryption.formatUrl()
                ));
            }
            catch (Exception e)
            {
                if (Application.shouldShowMessages())
                    MessageBox.Show(
                        $"An error occured, please contact support if you encounter this multiple times!\n\nException Message: {e.Message}",
                        Utils.formatTitle(Utils.linksToString(link)), MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(-1);
            }

            LinkAnswer answer;
            try
            {
                answer = JsonConvert.DeserializeObject<LinkAnswer>(Encryption.Decrypt(output));
            }
            catch (Exception e)
            {
                if (Application.shouldShowMessages())
                    MessageBox.Show(
                        $"An error occured, please contact support if you encounter this multiple times!\n\nException Message: {e.Message}",
                        Utils.formatTitle(Utils.linksToString(link)), MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(-1);
                return "undefined";
            }

            Security.verifyTimestamp(answer.timestamp);
            Security.endSession();

            switch (answer.code)
            {
                case "invalid_request":
                case "invalid_salt":
                case "invalid_username":
                    if (Application.shouldShowMessages())
                        MessageBox.Show(
                            "An error occured, please contact support if you encounter this multiple times!",
                            Utils.formatTitle(Utils.linksToString(link)), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(-1);
                    return "undefined";
                case "application_banned":
                    if (Application.shouldShowMessages())
                        MessageBox.Show(
                            $"{getName()} is banned from YATO.RE, please read TOS next time to avoid this to happen!",
                            Utils.formatTitle(Utils.linksToString(link)), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(0);
                    return "undefined";
                case "application_down":
                    if (Application.shouldShowMessages())
                        MessageBox.Show($"{getName()} is down at the moment, please come back later!",
                            Utils.formatTitle(Utils.linksToString(link)), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Environment.Exit(0);
                    return "undefined";
                case "free_plan":
                    if (Application.shouldShowMessages())
                        MessageBox.Show("This application does not have access to this feature, please consider upgrading to get access to it!",
                            Utils.formatTitle(Utils.linksToString(link)), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "undefined";
                case "banned_user":
                    if (Application.shouldShowMessages()) MessageBox.Show($"You are banned from {Application.getName()}!", Utils.formatTitle(Utils.linksToString(link)), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(-1);
                    return "undefined";
                case "expired_user":
                    if (Application.shouldShowMessages()) MessageBox.Show($"Your subscription to {Application.getName()} has expired!", Utils.formatTitle(Utils.linksToString(link)), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return "undefined";
                case "success":
                    break;
                default:
                    return "undefined";
            }

            if (string.IsNullOrEmpty(answer.link))
            {
                if (Application.shouldShowMessages())
                    MessageBox.Show("An error occured, please contact support if you encounter this multiple times!",
                        Utils.formatTitle(Utils.linksToString(link)), MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(-1);
                return "undefined";
            }

            return answer.link;
        }

        private class LinkAnswer : Globals.ApiAnswer
        {
            [JsonProperty("link")]
            public string link { get; set; }
        }
    }

    internal class User
    {
        private readonly string username;
        private readonly string hwid;
        private readonly string expirationDate;
        private readonly bool OTPEnabled;
        private readonly bool DiscordLinked;

        public User(string _username, string _hwid, string _expirationDate, bool _OTPEnabled, bool _DiscordLinked)
        {
            username = _username;
            hwid = _hwid;
            expirationDate = _expirationDate;
            OTPEnabled = _OTPEnabled;
            DiscordLinked = _DiscordLinked;
        }

        public string getUsername()
        {
            return username;
        }

        public string getHWID()
        {
            return hwid;
        }

        public string getExpirationDate()
        {
            return expirationDate;
        }

        public bool isOTPEnabled()
        {
            return OTPEnabled;
        }

        public bool hasDiscordLinked()
        {
            return DiscordLinked;
        }
    }

    private static class Globals
    {
        public const string API_ENDPOINT = "https://api.yato.re/v1/csharp/";
        public static string getHWID() // https://stackoverflow.com/questions/2333149/how-to-fast-get-hardware-id-in-c
        {
            var sb = new StringBuilder();

            ManagementObjectCollection bios = new ManagementObjectSearcher("SELECT * FROM Win32_bios").Get();
            foreach (ManagementBaseObject o in bios)
            {
                var obj = (ManagementObject)o;
                sb.Append(obj["Version"]);
                break;
            }

            ManagementObjectCollection hdd = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive").Get();
            foreach (ManagementBaseObject o in hdd)
            {
                var obj = (ManagementObject)o;
                sb.Append(obj["SerialNumber"]);
                break;
            }

            byte[] bytes = Encoding.UTF8.GetBytes(sb.ToString());
            return Convert.ToBase64String(bytes).Substring(12);
        }

        public abstract class ApiAnswer
        {
            [JsonProperty("code")]
            public string code { get; set; }

            [JsonProperty("message")]
            public string message { get; set; }

            [JsonProperty("timestamp")]
            public long timestamp { get; set; }
        }
    }

    private static class Encryption
    {
        private static string encryptionKey;
        private static string encryptionIV;

        public static void regenerateKeyAndIV()
        {
            encryptionKey = Utils.generateRandomString(132);
            encryptionIV = Utils.generateRandomString(16);
        }

        public static string Encrypt(string input, bool secondPart = true)
        {
            var sha256Service = SHA256.Create();
            byte[] key = sha256Service.ComputeHash(Encoding.ASCII.GetBytes(encryptionKey));
            byte[] iv = Encoding.ASCII.GetBytes(encryptionIV);

            var aesSettings = Aes.Create();
            aesSettings.Mode = CipherMode.CBC;
            aesSettings.Key = key;
            aesSettings.IV = iv;

            ICryptoTransform aesEncryptor = aesSettings.CreateEncryptor();
            var memoryStream = new MemoryStream();
            var cryptoStream = new CryptoStream(memoryStream, aesEncryptor, CryptoStreamMode.Write);

            byte[] inputBytes = Encoding.ASCII.GetBytes(input);

            cryptoStream.Write(inputBytes, 0, inputBytes.Length);
            cryptoStream.FlushFinalBlock();

            byte[] outputBytes = memoryStream.ToArray();

            memoryStream.Close();
            cryptoStream.Close();

            return secondPart ? EncryptSecondPart(processString(Convert.ToBase64String(outputBytes, 0, outputBytes.Length))) : processString(Convert.ToBase64String(outputBytes, 0, outputBytes.Length));
        }

        public static string Decrypt(string input)
        {
            var sha256Service = SHA256.Create();
            byte[] key = sha256Service.ComputeHash(Encoding.ASCII.GetBytes(encryptionKey));
            byte[] iv = Encoding.ASCII.GetBytes(encryptionIV);

            var aesSettings = Aes.Create();
            aesSettings.Mode = CipherMode.CBC;
            aesSettings.Key = key;
            aesSettings.IV = iv;

            ICryptoTransform aesDecryptor = aesSettings.CreateDecryptor();
            var memoryStream = new MemoryStream();
            var cryptoStream = new CryptoStream(memoryStream, aesDecryptor, CryptoStreamMode.Write);

            byte[] inputBytes = Convert.FromBase64String(processString(DecryptSecondPart(input), true));

            cryptoStream.Write(inputBytes, 0, inputBytes.Length);
            cryptoStream.FlushFinalBlock();

            byte[] outputBytes = memoryStream.ToArray();

            memoryStream.Close();
            cryptoStream.Close();

            return Encoding.ASCII.GetString(outputBytes, 0, outputBytes.Length);
        }

        private static string EncryptSecondPart(string input)
        {
            var sha256Service = SHA256.Create();
            byte[] key = sha256Service.ComputeHash(Encoding.ASCII.GetBytes(Application.getSalt()));
            var iv = new byte[16];
            Buffer.BlockCopy(key, 0, iv, 0, 16);

            var aesSettings = Aes.Create();
            aesSettings.Mode = CipherMode.CBC;
            aesSettings.Key = key;
            aesSettings.IV = iv;

            ICryptoTransform aesEncryptor = aesSettings.CreateEncryptor();
            var memoryStream = new MemoryStream();
            var cryptoStream = new CryptoStream(memoryStream, aesEncryptor, CryptoStreamMode.Write);

            byte[] inputBytes = Encoding.ASCII.GetBytes(input);

            cryptoStream.Write(inputBytes, 0, inputBytes.Length);
            cryptoStream.FlushFinalBlock();

            byte[] outputBytes = memoryStream.ToArray();

            memoryStream.Close();
            cryptoStream.Close();

            return processString(Convert.ToBase64String(outputBytes, 0, outputBytes.Length));
        }

        private static string DecryptSecondPart(string input)
        {
            var sha256Service = SHA256.Create();
            byte[] key = sha256Service.ComputeHash(Encoding.ASCII.GetBytes(Application.getSalt()));
            var iv = new byte[16];
            Buffer.BlockCopy(key, 0, iv, 0, 16);

            var aesSettings = Aes.Create();
            aesSettings.Mode = CipherMode.CBC;
            aesSettings.Key = key;
            aesSettings.IV = iv;

            ICryptoTransform aesDecryptor = aesSettings.CreateDecryptor();
            var memoryStream = new MemoryStream();
            var cryptoStream = new CryptoStream(memoryStream, aesDecryptor, CryptoStreamMode.Write);

            byte[] inputBytes = Convert.FromBase64String(processString(input, true));

            cryptoStream.Write(inputBytes, 0, inputBytes.Length);
            cryptoStream.FlushFinalBlock();

            byte[] outputBytes = memoryStream.ToArray();

            memoryStream.Close();
            cryptoStream.Close();

            return Encoding.ASCII.GetString(outputBytes, 0, outputBytes.Length);
        }

        public static string formatUrl()
        {
            return $"&current_id={WebUtility.UrlEncode(processString(Convert.ToBase64String(Encoding.UTF8.GetBytes(encryptionKey))))}&current_secret={WebUtility.UrlEncode(processString(Convert.ToBase64String(Encoding.UTF8.GetBytes(encryptionIV))))}";
        }

        private static string processString(string input, bool decrypt = false)
        {
            return decrypt ? input.Replace("!", "/").Replace("?", "=").Replace("$", "+") : input.Replace("/", "!").Replace("=", "?").Replace("+", "$");
        }
    }

    private static class Security
    {
        // Credits goes to Outbuilt for the ARP poisoning checks
        private static class ARPPoisoning
        {
            private static System.Threading.Timer timer;
            private static string lastGateway;

            public static void run()
            {
                lastGateway = getGatewayMAC();
                timer = new System.Threading.Timer(_ => onCallback(), null, 5000, Timeout.Infinite);
            }

            private static void onCallback()
            {
                timer.Dispose();
                if (getGatewayMAC() != lastGateway)
                {
                    MessageBox.Show("Security breach detected! Closing...", Utils.formatTitle("Security"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(-1);
                    return;
                }

                lastGateway = getGatewayMAC();
                timer = new System.Threading.Timer(_ => onCallback(), null, 5000, Timeout.Infinite);
            }

            private static IPAddress getDefaultGateway()
            {
                return NetworkInterface
                    .GetAllNetworkInterfaces()
                    .Where(n => n.OperationalStatus == OperationalStatus.Up)
                    .Where(n => n.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                    .SelectMany(n => n.GetIPProperties()?.GatewayAddresses)
                    .Select(g => g?.Address)
                    .FirstOrDefault(a => a != null);
            }

            private static string getARPTable()
            {
                var start = new ProcessStartInfo
                {
                    FileName = @"C:\Windows\System32\arp.exe",
                    Arguments = "-a",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                };

                using (Process process = Process.Start(start))
                {
                    if (process == null)
                        return string.Empty;

                    using (StreamReader reader = process.StandardOutput)
                    {
                        return reader.ReadToEnd();
                    }
                }
            }

            private static string getGatewayMAC()
            {
                return new Regex($@"({getDefaultGateway()} [\W]*) ([a-z0-9-]*)").Match(getARPTable()).Groups[2].ToString();
            }
        }

        public static void run()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            hashWrite();

            if (Application.isDevelopmentMode())
            {
                if (!File.Exists("hash_write.yato"))
                    File.WriteAllText("hash_write.yato", "");
                MessageBox.Show("You enabled development mode, meaning you are bypassing every security checks!\n\nAdditionnally, the hash of the current executable has been written to hash.txt!", Utils.formatTitle("Security"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ARPPoisoning.run();

            const string hostsPath = "C:\\Windows\\System32\\drivers\\etc\\hosts";
            if (File.Exists(hostsPath))
            {
                using (var streamReader = new StreamReader(hostsPath))
                {
                    if (streamReader.ReadToEnd().Contains("yato.re"))
                    {
                        MessageBox.Show("Security breach detected! Closing...", Utils.formatTitle("Security"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Environment.Exit(-1);
                        return;
                    }
                }
            }

            if (string.IsNullOrEmpty(Application.getJsonHash()) ||
                getJsonDllHash() == Application.getJsonHash()) return;

            MessageBox.Show("Security breach detected! Closing...", Utils.formatTitle("Security"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            Environment.Exit(-1);
        }

        public static void hashCheck()
        {
            //if (Application.isDevelopmentMode())
            //    return;

            //string hash = Application.getHash();
            //if (hash == hashFile(Assembly.GetExecutingAssembly().Location))
            //    return;

            //MessageBox.Show("The current hash of the file doesn't match our one, file possibly corrupted/manipulated!", Utils.formatTitle("Security"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //Environment.Exit(-1);
        }

        private static void hashWrite()
        {
            if (File.Exists("hash_write.yato"))
                File.WriteAllText("hash.txt", $"MD5 Checksum: {hashFile(Assembly.GetExecutingAssembly().Location)}");
        }

        public static void startSession()
        {
            ServicePointManager.ServerCertificateValidationCallback += certificateIntegrity;
        }

        public static void endSession()
        {
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
        }

        public static void verifyTimestamp(long timestamp)
        {
            return; // Temporarly disabled
            long actual = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds(); // https://stackoverflow.com/a/48130905
            if (actual - timestamp <= 5L)
                return;

            MessageBox.Show("Security breach detected! Closing...", Utils.formatTitle("Security"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            Environment.Exit(-1);
        }

        public static string hash(string value)
        {
            using (var md5Service = MD5.Create())
            {
                return BitConverter.ToString(md5Service.ComputeHash(Encoding.UTF8.GetBytes(value))).Replace("-", "");
            }
        }

        public static string hashFile(string filename)
        {
            using (var md5Service = MD5.Create())
            {
                using (FileStream fileStream = File.OpenRead(filename))
                {
                    return BitConverter.ToString(md5Service.ComputeHash(fileStream)).Replace("-", "").ToLowerInvariant();
                }
            }
        }

        private static bool certificateIntegrity(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) // https://docs.microsoft.com/fr-fr/dotnet/api/system.security.cryptography.x509certificates.x509certificate
        {
            return certificate != null && certificate.GetPublicKeyString() == "3082010A0282010100C168E56F1BE04769B18729D69C460EF5EDF6FBC904E4342D89C35A085F8A4433A68D4A7C6BF7CCAD175E471AED82B268D69D717BE3F7F0E934AF3C5A12B5225D881BBCE90AAF0D141524A4C37C03D7F1D7AA4871B70A78729B175BBE87A64648152605867A1A573B91833130D47BCA498BD9E31F7C0DADBF2A914F5FE63DD93C73DAECC314EAA52C39C717E55DC70D0EC7A50B36810576DBD199294CF30B0F3257A6793898A5969B58CA50C1995FA6149DA4F897B96A0A44EBA703A4D98B9684583044428EA1DA5802BE13B5CC44D35D008810C30D661041D71ACA63F21F289510CAA1A713A3589C50C7B26EECBD78863414D9C0C28ABA9D74BFDC8D817648950203010001";
        }
    }

    private static class Utils
    {
        private static readonly Random random = new Random();
        public static string generateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string formatTitle(string feature)
        {
            return $"{Application.getName()} - {feature}";
        }

        public static string linksToString(Application.Links link)
        {
            switch (link)
            {
                case Application.Links.Discord:
                    return "Discord Link";
                case Application.Links.OTP:
                    return "2FA";
                default:
                    return "undefined";
            }
        }
    }

    public static string getJsonDllHash()
    {
        return Security.hashFile("Newtonsoft.Json.dll");
    }
}
