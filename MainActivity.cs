﻿using System;
using Android.Content;
using Android.Views;

using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;

namespace TimeChunkV0_1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        //Defination of Helloworld related variable. -E129
        EditText emailEditText, passwordEditText;
        Button signinButton, registerButton;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            //Search for the values of EditText and Button from xml files as it is 
            //not simply linked similar to Forms application. -E129 T3.05
            emailEditText = FindViewById<EditText>(Resource.Id.emailEditText);
            passwordEditText = FindViewById<EditText>(Resource.Id.passwordEditText);
            signinButton = FindViewById<Button>(Resource.Id.signinButton);
            registerButton = FindViewById<Button>(Resource.Id.registerButton);

            //Linking the button clicked event with event handler. -E133 T5.50
            signinButton.Click += SigninButton_Click;
            registerButton.Click += RegisterButton_Click;
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            //Going to the Register Activiy Page. -E135 T2.00
            var intent = new Intent(this, typeof(RegisterActivity));
            //Pass typed Email to intent which needs to be delivered to register activity. -E136 T1.00
            intent.PutExtra("Email", emailEditText.Text);
            StartActivity(intent);
        }

        private void SigninButton_Click(object sender, EventArgs e)
        {
            var email = emailEditText.Text;
            var password = passwordEditText.Text;

            bool isEmailEmpty = string.IsNullOrEmpty(email);
            bool isPasswordEmpty = string.IsNullOrEmpty(password);

            if (isEmailEmpty || isPasswordEmpty)
            {
                Toast.MakeText(this, "Try Again..!!!", ToastLength.Long).Show();
            }
            else
            {
                Toast.MakeText(this, "Welcome", ToastLength.Long).Show();
                var intent = new Intent(this, typeof(ProjectsActivity));
                StartActivity(intent);
                //Remove the Login Page activity from the stack so user cannot go 
                //back to the Login Page onces entered in the app. -E156 T2.00
                Finish();
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}