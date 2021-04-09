using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace PentingtonRails.Models
{
    [Table("Trip")]
    public partial class Trip
    {
        [Key]
        public int Id { get; set; }
        public int? ConfigId { get; set; }
        public int? Source { get; set; }
        public int? Destination { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ExpDepature { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DepartureTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ExpArrival { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ArrivalTime { get; set; }
        public TimeSpan? EstTransitTime { get; set; }

        [ForeignKey(nameof(ConfigId))]
        [InverseProperty(nameof(TrainConfig.Trips))]
        public virtual TrainConfig Config { get; set; }
        [ForeignKey(nameof(Destination))]
        [InverseProperty(nameof(Station.TripDestinationNavigations))]
        public virtual Station DestinationNavigation { get; set; }
        [ForeignKey(nameof(Source))]
        [InverseProperty(nameof(Station.TripSourceNavigations))]
        public virtual Station SourceNavigation { get; set; }
    }
}
