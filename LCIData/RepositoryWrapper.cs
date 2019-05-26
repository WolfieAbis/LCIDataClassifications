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
        private ICategoryRepository _category;
        private ISubCategoryRepository _subCategory;
        private ITweetCountRepository _tweetcount;


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

        public ITweetCountRepository TweetCounts
        {
            get
            {
                if (_tweetcount == null)
                {
                    _tweetcount = new TweetCountRepository(_repoContext);
                }

                return _tweetcount;
            }
        }
        public ISubCategoryRepository SubCategory
        {
            get
            {
                if (_subCategory == null)
                {
                    _subCategory = new SubCategoryRepository(_repoContext);
                }

                return _subCategory;
            }
        }

        public ICategoryRepository Category
        {
            get
            {
                if (_category == null)
                {
                    _category = new CategoryRepository(_repoContext);
                }

                return _category;
            }
        }

        

        public void save()
        {
            _repoContext.SaveChanges();
        }

    }
}
