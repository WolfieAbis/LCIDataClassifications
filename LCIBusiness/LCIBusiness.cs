using System;
using LCIEntities.Models;
using LCIData.Interface;
using LCIData.Repositories;
using LCIData;
namespace LCIBusinessLayer
{
    public class LCIBusiness:ILCIBusiness
    {
        private IRepositoryWrapper RepoWrapper;
        public LCIBusiness(IRepositoryWrapper repoWrapper)
        {
            this.RepoWrapper = repoWrapper;
        }
               

        public void createTweet(LciTweets tweet)
        {
            try
            {
                RepoWrapper.Tweet.Create(tweet);
                RepoWrapper.save();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
