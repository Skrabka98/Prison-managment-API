﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PrisonBack.Domain.Models
{
    [Table("Prison")]
    public class Prison
    {
        [Key]
        public int Id { get; set; }
        public string PrisonName { get; set; }

    }
}