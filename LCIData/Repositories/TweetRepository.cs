using Microsoft.EntityFrameworkCore;
using LCIData.Interface;
using LCIEntities.Models;
using System.Collections.Generic;
using System.Linq;

namespace LCIData.Repositories
{
    public class TweetRepository : RepositoryBase<LciTweets>, ITweetRepository
    {
        private readonly LCIDataClassificationContext dBContext;

        public TweetRepository(LCIDataClassificationContext repositoryContext)
            : base(repositoryContext)
        {
            dBContext = repositoryContext;
        }
              

    }    
}
