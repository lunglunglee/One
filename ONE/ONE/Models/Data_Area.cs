namespace ONE.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Data_Area
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AreaCode { get; set; }

        [Required]
        [StringLength(50)]
        public string AreaName { get; set; }

        public int CityCode { get; set; }

        [StringLength(50)]
        public string CityName { get; set; }

        public virtual Data_City Data_City { get; set; }
    }
}
