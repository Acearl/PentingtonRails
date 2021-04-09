using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace PentingtonRails.Models
{
    public partial class Car
    {
        [Key]
        public int Id { get; set; }
        public double Weight { get; set; }
        public double MaxWeight { get; set; }
        public int? MaxPassengers { get; set; }
        public int? Beds { get; set; }
        public bool Refrigeration { get; set; }
        public double? Volume { get; set; }
        [StringLength(1000)]
        public string Notes { get; set; }
    }
}
