using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using SQLite;
using TimeChunkV0_1.models;

namespace TimeChunkV0_1.Resources.DataHelper
{
    public class projectDatabase
    {
        string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        public bool createDataBase()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folderPath, "ProjectsDB.db")))
                {
                    connection.CreateTable<ProjectsDB>();
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public bool InsertIntoTableProjects(ProjectsDB projectsDB)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folderPath, "ProjectsDB.db")))
                {
                    connection.Insert(projectsDB);
                    return true;
                }
            }

            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public List<string> stringListViewProjects()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folderPath, "ProjectsDB.db")))
                {
                    //return connection.Table<ProjectsDB>().ToList();
                    List<string> data = new List<string>();

                    foreach(var item in connection.Table<ProjectsDB>())
                    {
                        var place = item.ProjectName.ToString(); item.progressStatus.ToString();

                        data.Add(place);
                    }

                    return data;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return null;
            }
        }

        public bool UpdateTableProjects(ProjectsDB projectsDB)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folderPath, "ProjectsDB.db")))
                {
                    connection.Query<ProjectsDB>("UPDATE ProjectsDB set ProjectName=?, progressStatus=?, " +
                        "isComplete=? Where Id=?", projectsDB.ProjectName, projectsDB.progressStatus, projectsDB.isComplete);
                    return true;
                }
            }

            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public bool deleteTableProjects(ProjectsDB projectsDB)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folderPath, "ProjectsDB.db")))
                {
                    connection.Delete(projectsDB);
                    return true;
                }
            }

            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public bool selectQueryTableProjects(int Id)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folderPath, "ProjectsDB.db")))
                {
                    connection.Query<ProjectsDB>("SELECT * FROM Person Where Id=?", Id);
                    return true;
                }
            }

            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

    }
}