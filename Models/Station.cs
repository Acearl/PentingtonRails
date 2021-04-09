using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace PentingtonRails.Models
{
    public partial class Station
    {
        public Station()
        {
            TripDestinationNavigations = new HashSet<Trip>();
            TripSourceNavigations = new HashSet<Trip>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public double? PosX { get; set; }
        public double? PosY { get; set; }

        [InverseProperty(nameof(Trip.DestinationNavigation))]
        public virtual ICollection<Trip> TripDestinationNavigations { get; set; }
        [InverseProperty(nameof(Trip.SourceNavigation))]
        public virtual ICollection<Trip> TripSourceNavigations { get; set; }
    }
}
