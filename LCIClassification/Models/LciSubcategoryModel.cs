using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LCIClassification
{
  
    public  class LciSubcategoryModel
    {
        public int Subcategoryid { get; set; }
      
        public string Subcategoryname { get; set; }
        
        public int Categoryid { get; set; }

        
    }
}
