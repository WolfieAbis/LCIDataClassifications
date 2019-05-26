using System;
using System.Collections.Generic;
using System.Text;

namespace LCIData.Interface
{
    public interface IRepositoryWrapper
    {
        ITweetRepository Tweet { get; }
        ICategoryRepository Category { get; }
        ISubCategoryRepository SubCategory { get; }

        ITweetCountRepository TweetCounts { get; }
        void save();
    }
}
