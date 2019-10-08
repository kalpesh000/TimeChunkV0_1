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

using Android.Support.Design.Widget;

namespace TimeChunkV0_1
{
    [Activity(Label = "ProjectsActivity")]
    //To perform navigation in fragment we need to be inherting from FragmentActivity E155 T13.00
    public class ProjectsActivity : Android.Support.V4.App.FragmentActivity
    {
        TabLayout tabLayout;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set Projects View in layout folder as Content view for "ProjectsActivity.cs". -E154 T4.30
            SetContentView(Resource.Layout.Projects);

            //Get tabs Id and create Tab selected event to change conent. -E155 T10.30
            tabLayout = FindViewById<TabLayout>(Resource.Id.projectTabLayout);
            tabLayout.TabSelected += TabLayout_TabSelected;

            //Default display Active Fragement when activity is displayed. -E155 T12.20
            FragmentNavigate(new ActiveFragment());
        }

        private void TabLayout_TabSelected(object sender, TabLayout.TabSelectedEventArgs e)
        {
            switch (e.Tab.Position)
            {
                case 0:
                    FragmentNavigate(new ActiveFragment());
                    break;
                case 1:
                    FragmentNavigate(new CompletedFragment());
                    break;
            }
        }

        /// <summary>
        /// Method which helps to navigate from one Tab's fragment to another.
        /// </summary>
        /// <param name="fragment"></param>
        private void FragmentNavigate(Android.Support.V4.App.Fragment fragment)
        {
            var transaction = SupportFragmentManager.BeginTransaction();
            transaction.Replace(Resource.Id.projectcontentFrame, fragment);
            transaction.Commit();
        }
    }
}