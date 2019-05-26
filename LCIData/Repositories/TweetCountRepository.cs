using Microsoft.EntityFrameworkCore;
using LCIData.Interface;
using LCIEntities.Models;
using System.Collections.Generic;
using System.Linq;

namespace LCIData.Repositories
{
    public class TweetCountRepository : RepositoryBase<LciTweetCount>, ITweetCountRepository
    {
        private readonly LCIDataClassificationContext dBContext;

        public TweetCountRepository(LCIDataClassificationContext repositoryContext)
            : base(repositoryContext)
        {
            dBContext = repositoryContext;
        }
              

    }    
}
