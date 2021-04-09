using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace PentingtonRails.Models
{
    [Keyless]
    [Table("CarToConfig")]
    public partial class CarToConfig
    {
        public int TrainConfig { get; set; }
        public int OrderInLine { get; set; }
        public int CarId { get; set; }

        [ForeignKey(nameof(CarId))]
        public virtual Car Car { get; set; }
        [ForeignKey(nameof(TrainConfig))]
        public virtual TrainConfig TrainConfigNavigation { get; set; }
    }
}
