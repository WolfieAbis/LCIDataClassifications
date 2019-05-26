using LCIData.Interface;
using LCIData.Repositories;
using LCIEntities;
using LCIEntities.Models;

namespace LCIData
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly LCIDataClassificationContext _repoContext;
        private ITweetRepository _tweet;
      

        public RepositoryWrapper(LCIDataClassificationContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public ITweetRepository Tweet
        {
            get
            {
                if (_tweet == null)
                {
                    _tweet = new TweetRepository(_repoContext);
                }

                return _tweet;
            }
        }
       
        public void save()
        {
            _repoContext.SaveChanges();
        }

    }
}
