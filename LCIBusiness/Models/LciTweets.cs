using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LCIBusinessLayer.Models
{
    [Table("LCI_Tweets")]
    public partial class LciTweets
    {
        [Column("tweetid")]
        public int Tweetid { get; set; }
        [Column("tweettext")]
        [StringLength(255)]
        public string Tweettext { get; set; }
        [Column("categoryid")]
        public int? Categoryid { get; set; }

        [ForeignKey("Categoryid")]
        [InverseProperty("LciTweets")]
        public virtual LciCategory Category { get; set; }
    }
}
