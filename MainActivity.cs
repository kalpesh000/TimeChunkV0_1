using System;
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
        EditText nameEditText;
        Button helloButton;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            //Search for the values of EditText and Button from xml files as it is 
            //not simply linked similar to Forms application. -E129 T3.05
            nameEditText = FindViewById<EditText>(Resource.Id.nameEditText);
            helloButton = FindViewById<Button>(Resource.Id.helloButton);

            //Linking the button clinked event with event handler. -E129 T6.05
            helloButton.Click += HelloButton_Click;
        }

        //Event handler for Hello Butoon Clicked Event.  -E129 T6.05 
        private vo
            
            
            HelloButton_Click(object sender, EventArgs e)
        {
            //Displaying a Toast Message. -E129 T6.30
            Toast.MakeText(this, $"Hello {nameEditText.Text}", ToastLength.Long).Show();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}