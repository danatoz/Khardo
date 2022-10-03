﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceParseServices
{
    public class PriceModel
    {
	    public string VendorCode { get; set; }
	    public int Amount { get; set; }
	    public decimal Price { get; set; }
	    public string Manufacturer { get; set; }

    }
}