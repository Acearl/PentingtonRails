using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace PentingtonRails.Models
{
    public partial class Conductor
    {
        public Conductor()
        {
            TrainConfigs = new HashSet<TrainConfig>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DateOfBirth { get; set; }

        [InverseProperty(nameof(TrainConfig.ConductorNavigation))]
        public virtual ICollection<TrainConfig> TrainConfigs { get; set; }
    }
}
