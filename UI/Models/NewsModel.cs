﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Models
{
    public class NewsModel
    {
		public int Id { get; set; }
		public string Title { get; set; }
		public string Url { get; set; }
		public string Content { get; set; }
		public DateTime CreationDate { get; set; }
	}
}
