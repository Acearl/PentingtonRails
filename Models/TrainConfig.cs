using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace PentingtonRails.Models
{
    [Table("TrainConfig")]
    public partial class TrainConfig
    {
        public TrainConfig()
        {
            Trips = new HashSet<Trip>();
        }

        [Key]
        public int Id { get; set; }
        public int Conductor { get; set; }
        public int Engine { get; set; }

        [ForeignKey(nameof(Conductor))]
        [InverseProperty("TrainConfigs")]
        public virtual Conductor ConductorNavigation { get; set; }
        [ForeignKey(nameof(Engine))]
        [InverseProperty(nameof(TrainEngine.TrainConfigs))]
        public virtual TrainEngine EngineNavigation { get; set; }
        [InverseProperty(nameof(Trip.Config))]
        public virtual ICollection<Trip> Trips { get; set; }
    }
}
