using System;
using LCIEntities.Models;
using LCIData.Interface;
using LCIData.Repositories;
using LCIData;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
                List<LciCategory> objCategory = RepoWrapper.Category.FindAll();

                List<LciSubcategory> objSubCategory = RepoWrapper.SubCategory.FindAll();

                int categoryId = GetCategoryId(tweet.Tweettext, objCategory);
                
                if(categoryId ==0)
                 categoryId = GetSubCategoryId(tweet.Tweettext, objSubCategory);

                RepoWrapper.Tweet.Create(tweet);
                RepoWrapper.save();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        private int GetCategoryId(string tweetTxt, List<LciCategory> Categories)
        {
            int CatId = 0;
            tweetTxt = tweetTxt.Replace("#", "");

            try
            {
                var objMatchingCategory = (from objCategory in Categories
                                           where objCategory.Categoryname.ToLower().Contains(tweetTxt.ToLower())
                                           select objCategory.Categoryid).FirstOrDefault();

                CatId = objMatchingCategory;

                return CatId;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        private int GetSubCategoryId(string tweetTxt, List<LciSubcategory> SubCategories)
        {
            int SubCatId = 0;
            tweetTxt = tweetTxt.Replace("#", "");

            try
            {
                var objMatchingSubCategory = (from objSubCategory in SubCategories
                                              where objSubCategory.Subcategoryname.ToLower().Contains(tweetTxt.ToLower())
                                           select objSubCategory.Categoryid).FirstOrDefault();

              
                    SubCatId = objMatchingSubCategory;

                return SubCatId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

   
}
