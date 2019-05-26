using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LCIClassification
{
 
    public  class LciTweetCount
    {

        public int Tweetcountid { get; set; }
        
        public int Categoryid { get; set; }

   
       
    }
}
