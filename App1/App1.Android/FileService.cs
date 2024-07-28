using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.IO;
using MyBookLibrary.Contrcts;
using System;
using Android.Content;
using Android.OS;
using Java.IO;
using Xamarin.Forms;
using System.IO;
using App1.Droid;

[assembly: Dependency(typeof(FileService))]
namespace App1.Droid
{
    public class FileService : IFileService
    {
        #region Public Variables
        string rootPath;
        string dbCopyFilePath;
        string dbFile;
        #endregion
        public void CopyFileToDownloads(string sourceFilePath, string fileName)
        {
            var context = Android.App.Application.Context;
            string localstorage = context.FilesDir.AbsolutePath;
            string downloadsPath = Path.Combine(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads).AbsolutePath, fileName);
            //string downloadsPath = Path.Combine()
            try
            {
                using (FileInputStream fis = new FileInputStream(sourceFilePath))
                using (FileOutputStream fos = new FileOutputStream(downloadsPath))
                {
                    byte[] buffer = new byte[32768];
                    int length;
                    while ((length = fis.Read(buffer)) > 0)
                    {
                        fos.Write(buffer, 0, length);
                    }
                }
            }
            catch (Java.IO.IOException e)
            {
                // Handle the exception
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }

        public void CreateDBDirectory()
        {
            rootPath = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath, Android.OS.Environment.DirectoryDownloads);
            dbCopyFilePath = Path.Combine(rootPath, "BookLibrary");
            if(Directory.Exists(dbCopyFilePath))
            {
                foreach (var item in Directory.GetFiles(dbCopyFilePath,"*.*"))
                {
                    System.IO.File.Delete(item);
                }
                foreach (var file in Directory.GetDirectories(rootPath))
                {
                    Directory.Delete(file);
                }
            }
            if(!Directory.Exists(dbCopyFilePath))
            {
                Directory.CreateDirectory(dbCopyFilePath);
            }
        }

        public void CreateDBFile()
        {
            if(!System.IO.File.Exists(dbCopyFilePath))
            {
                Directory.CreateDirectory(dbCopyFilePath);
                dbFile = Path.Combine(dbCopyFilePath, "");
            }
        }
        public void CopyDatabase(string dbPath)
        {
            foreach (var newPath in Directory.GetFiles(dbPath,"*.*"))
            {
                var copyFile = newPath.Replace(dbPath, dbFile);
                if(System.IO.File.Exists(copyFile))
                {
                   System.IO.File.Copy(newPath,copyFile,true);
                }
                else
                {
                    try
                    {
                        System.IO.File.Copy (newPath,copyFile,true);
                    }
                    catch (Exception ex)
                    { 
                    }
                }
            }

        }
    }
}