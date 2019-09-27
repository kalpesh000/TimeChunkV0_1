using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace TimeChunkV0_1
{
    [Activity(Label = "RegisterActivity")]
    public class RegisterActivity : Activity
    {
        EditText registerEmailEditText, registerPasswordEditText, confirmEditText;
        Button registerUserButton;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set Register View in layout folder as Content view for "RegisterActivity.cs". -E134 T4.25
            SetContentView(Resource.Layout.Register);

            //Link the variables with the xml file respective data. -E134 T5.22
            registerEmailEditText = FindViewById<EditText>(Resource.Id.registerEmailEditText);
            registerPasswordEditText = FindViewById<EditText>(Resource.Id.registerPasswordEditText);
            confirmEditText = FindViewById<EditText>(Resource.Id.confirmEditText);
            registerUserButton = FindViewById<Button>(Resource.Id.registerUserButton);

            registerUserButton.Click += RegisterUserButton_Click;

            //Taking the value of Email from Main activity. -E136 T3.30
            string Email = Intent.GetStringExtra("Email");
            //Adding the taken Email value from Main activity to Register Email EditText -E136 T4.00
            registerEmailEditText.Text = Email;
        }

        private void RegisterUserButton_Click(object sender, EventArgs e)
        {
            
        }
    }
}