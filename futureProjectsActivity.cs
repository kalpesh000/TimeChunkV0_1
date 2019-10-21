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
using TimeChunkV0_1.models;
using TimeChunkV0_1.Resources.DataHelper;

namespace TimeChunkV0_1
{
    [Activity(Label = "futureProjectsActivity")]
    public class futureProjectsActivity : Activity
    {
        //Defining the variables
        Android.Support.V7.Widget.Toolbar projectToolbar;
        Android.Support.Design.Widget.BottomNavigationView projectBottomNavigation;
        Android.Support.Design.Widget.FloatingActionButton floatingActionButton;
        EditText futureEditText;
        ListView listView;

        //Defining the Database Class
        projectDatabase pdb = new projectDatabase();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.futureProjects);

            //Get the Toolbar id from the resources. -E157 T4.00
            projectToolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.projectsToolbar);
            futureEditText = FindViewById<EditText>(Resource.Id.futureEditText);
            floatingActionButton = FindViewById<Android.Support.Design.Widget.FloatingActionButton>(Resource.Id.addActionButton);
            projectBottomNavigation = FindViewById<Android.Support.Design.Widget.BottomNavigationView>(Resource.Id.projectbottom_navigation);
            listView = FindViewById<ListView>(Resource.Id.futureListView);

            //Bind the Bottom Navigatoin Menu page with the Project UI
            projectBottomNavigation.InflateMenu(Resource.Menu.projectBottomNavigation);
            //Create clicked event on the toolbar. -E157 T9.00
            projectToolbar.InflateMenu(Resource.Menu.projectsMenu);

            //Create clicked event on the toolbar. -E157 T9.00
            projectToolbar.MenuItemClick += ProjectToolbar_MenuItemClick;
            floatingActionButton.Click += FloatingActionButton_Click;

            //Taking the database values and displaying that on the screen 
            var lstSource = pdb.stringListViewProjects();
            var adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, lstSource);
            listView.SetAdapter(adapter);

        }

        /// <summary>
        /// Inserting the typed edittext value inside the Database.
        /// </summary>
        private void FloatingActionButton_Click(object sender, EventArgs e)
        {
            ProjectsDB projectsDB = new ProjectsDB()
            {
                ProjectName = futureEditText.Text,
            };

            pdb.createDataBase();
            bool error = pdb.InsertIntoTableProjects(projectsDB);

            var posts = pdb.stringListViewProjects();

            if (error)
            {
                Toast.MakeText(this, "Data Inserted.", ToastLength.Long).Show();
            }
            else
            {
                Toast.MakeText(this, "Data Not Inserted.", ToastLength.Long).Show();
            }

        }

        private void ProjectToolbar_MenuItemClick(object sender, Android.Support.V7.Widget.Toolbar.MenuItemClickEventArgs e)
        {
            //Check if the settings is clicked.
            if (e.Item.ItemId == Resource.Id.action_settings)
            {
                StartActivity(typeof(SettingsActivity));
            }

            //Check if the notification is clicked.
            else if (e.Item.ItemId == Resource.Id.action_notifications)
            {
                StartActivity(typeof(NotificationsActivity));
            }
        }
    }
}