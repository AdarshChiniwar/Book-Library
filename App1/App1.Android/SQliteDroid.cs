using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using App1.Droid;
using Java.IO;
using Java.Nio;
using MyBookLibrary.Contrcts;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQliteDroid))]
namespace App1.Droid
{
  
    public class SQliteDroid : Isqlite
    {
       public static string path;
        public static string dbpath;
        public SQLiteConnection GetConnection()
        {
            var dbase = "library.sql";
            dbpath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);
            path = Path.Combine(dbpath, dbase);
            var connection = new SQLiteConnection(path);
            return connection;

        }
        //public string GetDownloadsFolderPath()
        //{
        //    return System.Environment.GetExternalStoragePublicDirectory(Environment.DirectoryDownloads).AbsolutePath;
        //}

        public string GetFullPath()
        {
            return path;
        }
        public string GetDirectoryPath()
        {
            return dbpath;
        }
        public void CopySqliteFile()
        {
            var context = Android.App.Application.Context;
           string v = context.FilesDir.AbsolutePath;
            string downloadsPath = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads).AbsolutePath;
            string destinationFilePath = Path.Combine(downloadsPath, "library.db");
            //Java.IO.File dir = new Java.IO.File(System.Environment.SpecialFolder.d);
            //this.directory = dir.getPath();
            try
            {
                FileInputStream fis = new FileInputStream(path);
                OutputStream backup = new FileOutputStream(destinationFilePath);

                byte[] buffer = new byte[32768];
                int length;
                while ((length = fis.Read(buffer)) > 0)
                {
                    backup.Write(buffer, 0, length);
                }
                backup.Flush();
                backup.Close();
                fis.Close();
            }
            catch (System.IO.IOException e)
            {
                //e.printStackTrace();
                //confirmaction = false;
            }
        }
    }
}