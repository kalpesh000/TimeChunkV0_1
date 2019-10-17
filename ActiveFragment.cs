using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace TimeChunkV0_1
{
    //We change Fragment -> Android.Support.V4.App.Fragment so that the Frgament
    //thing can be available in previous version of android. E155 T6.20
    public class ActiveFragment : Android.Support.V4.App.Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment herevar
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            //The Inflate method is does similar stuff to setContentView which we have in Activity. E155 T6.50
            View view = inflater.Inflate(Resource.Layout.Active, container, false);

            //Adding a Button Click Event
            Button futureButton = view.FindViewById<Button>(Resource.Id.futureButton);
            futureButton.Click += FutureProjectButton_Click;

            //Return your custom view for this Fragment
            return view;
        }

        private void FutureProjectButton_Click(object sender, EventArgs e)
        {
            //Jumping to the Future Projects Activity inside Button Click event
            var intent = new Intent(Activity, typeof(futureProjectsActivity));
            StartActivity(intent);
        }
    }
}