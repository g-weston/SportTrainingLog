using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace SportTrainingLog
{
    public partial class App : Application
    {
        public static SessionLogDataBase database;

        public static SessionLogDataBase Database
        {
            get
            {
                if (database == null)
                {
                    database = new SessionLogDataBase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TrainingSessions.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new LogTabPage();
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
