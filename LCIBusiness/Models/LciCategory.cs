using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LCIBusinessLayer.Models
{
    [Table("LCI_Category")]
    public partial class LciCategory
    {
        public LciCategory()
        {
            LciSubcategory = new HashSet<LciSubcategory>();
            LciTweetCount = new HashSet<LciTweetCount>();
            LciTweets = new HashSet<LciTweets>();
        }

        [Column("categoryid")]
        public int Categoryid { get; set; }
        [Column("categoryname")]
        [StringLength(255)]
        public string Categoryname { get; set; }

        [InverseProperty("Category")]
        public virtual ICollection<LciSubcategory> LciSubcategory { get; set; }
        [InverseProperty("Category")]
        public virtual ICollection<LciTweetCount> LciTweetCount { get; set; }
        [InverseProperty("Category")]
        public virtual ICollection<LciTweets> LciTweets { get; set; }
    }
}
