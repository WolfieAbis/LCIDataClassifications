using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LCIEntities.Models
{
    [Table("LCI_Subcategory")]
    public partial class LciSubcategory
    {
        [Column("subcategoryid")]
        public int Subcategoryid { get; set; }
        [Column("subcategoryname")]
        [StringLength(255)]
        public string Subcategoryname { get; set; }
        [Column("categoryid")]
        public int? Categoryid { get; set; }

        [ForeignKey("Categoryid")]
        [InverseProperty("LciSubcategory")]
        public virtual LciCategory Category { get; set; }
    }
}
