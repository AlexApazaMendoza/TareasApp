using System;
using System.IO;
using TareasApp.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TareasApp
{
    public partial class App : Application
    {
        //
        //public static string DatabaseLocation = string.Empty;
        static SQLiteHelper db;
        //
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        public static SQLiteHelper SQLiteDB
        {
            get
            {
                if (db == null)
                {
                    db = new SQLiteHelper(
                        Path.Combine(
                            Environment.GetFolderPath(
                                Environment.SpecialFolder.LocalApplicationData
                                ), "tareas_db.sqlite"
                                )
                        );
                }
                return db;
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
