﻿using LibraryManagementWithWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementWithWebAPI
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Edition { get; set; }
        public string BarCode { get; set; }
        public int CopyCount { get; set; }

    }
}
