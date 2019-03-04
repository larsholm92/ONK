﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Model
{
    public class Portfolio
    {
        public int Id { get; set; }
        [Required]
        public List<StockBundle> StockBundles { get; set; }

    }
}
