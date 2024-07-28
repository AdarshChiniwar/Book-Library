using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBookLibrary.Models
{
    public class BookModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Price { get; set; }
    }
}
