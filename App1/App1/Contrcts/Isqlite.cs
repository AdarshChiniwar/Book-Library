using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBookLibrary.Contrcts
{
    public interface Isqlite
    {
        SQLiteConnection GetConnection();
        string GetFullPath();

        string GetDirectoryPath();
    }

    public interface IFileService
    {
        void CopyFileToDownloads(string sourceFilePath, string fileName);
        void CreateDBDirectory();
        void CreateDBFile();
        void CopyDatabase(string dbPath);
    }
}
