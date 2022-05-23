using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using DavidCabezasS7.Droid;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(SqliteClient))]

namespace DavidCabezasS7.Droid
{
    public class SqliteClient : DataBase
    {
        public SQLiteAsyncConnection GetConnection()
        {

            var documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentPath, "uisrael.db3");

            return new SQLiteAsyncConnection(path);
        }
        //Base de datos sobre el dispositivo movil

    }
}