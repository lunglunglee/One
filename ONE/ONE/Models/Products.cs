namespace ONE.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Products
    {
        [Key]
        public int ProductID { get; set; }

        public int 貨品名稱 { get; set; }

        public int 供應商 { get; set; }

        public int 原料或工資名稱 { get; set; }

        [StringLength(20)]
        public string QuantityPerUnit { get; set; }

        [Column(TypeName = "money")]
        public decimal? UnitPrice { get; set; }

        public short? UnitsInStock { get; set; }

        public short? UnitsOnOrder { get; set; }

        public short? ReorderLevel { get; set; }

        public bool? 缺貨 { get; set; }

        public string 備註 { get; set; }

        public virtual Suppliers Suppliers { get; set; }
    }
}
