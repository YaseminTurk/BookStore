﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int GengeId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }

    }
}