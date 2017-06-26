/*
 * Created by Ryan Doiron (doir0008@algonquinlive.com)
 * 01/30/2017
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace LoginApp
{

    public sealed partial class MainPage : Page
    {
        private const byte maxNumAttempts = 3;
        private string username;
        private string password;
        private bool locked;
        private byte loginAttempts;

        public MainPage()
        {
            this.InitializeComponent();
            // init our variables
            username = "Ryan";
            password = "password";
            locked = false;
            loginAttempts = 1;
        }

        private void usernameBox_GotFocus(object sender, RoutedEventArgs e)
        {
            // clear the field when in focus, if account is not locked
            if (locked != true)
            {
                usernameBox.Text = "";
            }
        }

        private void passwordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            // clear the field when in focus, if account is not locked
            if (locked != true)
            {
                passwordBox.Password = "";
            }
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            // validate username and password
            if (usernameBox.Text == username && passwordBox.Password.ToString() == password)
            {
                messageBox.Foreground = new SolidColorBrush(Windows.UI.Colors.Blue);
                messageBox.Text = "Access Granted";
                // reset counter
                loginAttempts = 1;
            }
            else
            {
                // if we have reached max login attempts, lock account and disable fields
                if (loginAttempts == maxNumAttempts)
                {
                    locked = true;
                    messageBox.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
                    messageBox.Text = "Account Locked";
                    // disable all fields and buttons
                    usernameBox.IsEnabled = false;
                    passwordBox.IsEnabled = false;
                    loginButton.IsEnabled = false;
                }
                // else access denied
                else
                {
                    messageBox.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
                    messageBox.Text = "Access Denied";
                    // increase counter by one
                    loginAttempts++;
                }
            }
        }
    }
}
