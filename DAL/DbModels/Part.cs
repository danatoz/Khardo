﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DbModels
{
    public class Part : IDbModel
    {
	    public int Id { get; set; }
	    public string Name { get; set; }
	    public int CatalogId { get; set; }
	    public Catalog Catalog { get; set; }
    }
}