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
using SQLite;

namespace TimeChunkV0_1.models
{
    public class ProjectsDB
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(250)]
        public string ProjectName { get; set; }

        public int progressStatus { get; set; }

        public bool isComplete { get; set; }
    }
}