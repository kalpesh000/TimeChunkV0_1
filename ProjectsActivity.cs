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
    [Activity(Label = "ProjectsActivity")]
    public class ProjectsActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set Projects View in layout folder as Content view for "ProjectsActivity.cs". -E154 T4.30
            SetContentView(Resource.Layout.Projects);
        }
    }
}