using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace People
{
    public partial class App : Application
    {
        string dbPath => FileAccessHelper.GetLocalFilePath("people.db3");

        // Holds a PersonRepository object - so it's a link to our database I think
        public static PersonRepository PersonRepo;

        public App()
        {
            InitializeComponent();
            // Initialise the PersonRepo object
            PersonRepo = new PersonRepository(dbPath);

            MainPage = new People.MainPage
            {                
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
