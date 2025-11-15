using DBSQlite.Data;
using System;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DBSQLite
{
    public partial class App : Application
    {
        static SQLiteHelper db;
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }
        //Creanos una propiedad para la validacien de la creactos de una base de dates

        public static SQLiteHelper SQLiteDB
        { 
             get
            {

                if(db == null)
                {
                    db = new SQLiteHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DBUDC.db3"));
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
