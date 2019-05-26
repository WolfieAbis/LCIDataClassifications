using System;
using LCIEntities.Models;
namespace LCIBusinessLayer
{
    public interface ILCIBusiness
    {
        void createTweet(LciTweets tweet);
        int GetCategoryCountById(int categoryId);
    }

}
