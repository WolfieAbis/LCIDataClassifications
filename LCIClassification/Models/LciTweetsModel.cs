using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LCIClassification
{
    public partial class LciTweetsModel
    {
      
        public int Tweetid { get; set; }
      
        public string Tweettext { get; set; }
      
        public int Subcategoryid { get; set; }

      
    }
}
