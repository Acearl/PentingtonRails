using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace PentingtonRails.Models
{
    public partial class TrainEngine
    {
        public TrainEngine()
        {
            TrainConfigs = new HashSet<TrainConfig>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string FuelType { get; set; }
        public double? MaxLoad { get; set; }
        public double? MaxSpeed { get; set; }

        [InverseProperty(nameof(TrainConfig.EngineNavigation))]
        public virtual ICollection<TrainConfig> TrainConfigs { get; set; }
    }
}
