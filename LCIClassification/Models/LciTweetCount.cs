using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LCIClassification.Models
{
    [Table("LCI_TweetCount")]
    public partial class LciTweetCount
    {
        [Column("tweetcountid")]
        public int Tweetcountid { get; set; }
        [Column("categoryid")]
        public int? Categoryid { get; set; }

        [ForeignKey("Categoryid")]
        [InverseProperty("LciTweetCount")]
        public virtual LciCategory Category { get; set; }
    }
}
