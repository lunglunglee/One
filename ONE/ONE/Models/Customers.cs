namespace ONE.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Customers
    {
        [Key]
        public int CustomerID { get; set; }

        [Required]
        [StringLength(30)]
        public string 客戶名稱 { get; set; }

        [Column(TypeName = "date")]
        public DateTime 訂購日期 { get; set; }

        public int 所屬代理 { get; set; }

        [StringLength(60)]
        public string 送貨地址 { get; set; }

        public int? 區域 { get; set; }

        public int? 城市 { get; set; }

        public int? 省府 { get; set; }

        [StringLength(15)]
        public string Country { get; set; }

        [StringLength(24)]
        public string 相關圖片 { get; set; }

        public string 備註 { get; set; }
    }
}
