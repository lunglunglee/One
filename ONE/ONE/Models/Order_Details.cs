namespace ONE.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order Details")]
    public partial class Order_Details
    {
        [Key]
        public int OrderID { get; set; }

        [Column(TypeName = "date")]
        public DateTime 訂購日期 { get; set; }

        public int 訂購代理 { get; set; }

        public int 訂購貨品 { get; set; }

        [Column(TypeName = "money")]
        public decimal UnitPrice { get; set; }

        public short Quantity { get; set; }

        public float? Discount { get; set; }

        [StringLength(50)]
        public string 支付方式 { get; set; }

        [StringLength(50)]
        public string 相關客戶 { get; set; }

        [StringLength(50)]
        public string 貨品狀況 { get; set; }

        public string More { get; set; }

        public virtual Categories Categories { get; set; }

        public virtual Main_Employees Main_Employees { get; set; }

        public virtual Orders Orders { get; set; }
    }
}
