﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Core.Models
{
    public class Category:BaseEntity
    {
        [Required]
        [StringLength(maximumLength: 100)]
        public string Name {  get; set; }
        public List<Portfolio>? Portfolios { get; set; }
    }
}
