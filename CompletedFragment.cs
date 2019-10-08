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
    public class CompletedFragment : Android.Support.V4.App.Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment

            //The Inflate method is does similar stuff to setContentView which we have in Activity. E155 T6.50
            return inflater.Inflate(Resource.Layout.Completed, container, false);
        }
    }
}