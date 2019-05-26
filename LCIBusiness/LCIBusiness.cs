using System;
using LCIEntities.Models;
using LCIData.Interface;
using LCIData.Repositories;
using LCIData;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
namespace LCIBusinessLayer
{
    public class LCIBusiness : ILCIBusiness
    {
        private IRepositoryWrapper RepoWrapper;
        public LCIBusiness(IRepositoryWrapper repoWrapper)
        {
            this.RepoWrapper = repoWrapper;
        }

        public int GetCategoryCountById(int categoryID)
        {
            try
            {
                List<LciTweetCount> objCount = RepoWrapper.TweetCounts.FindAll();
                var count = (from category in objCount
                             where category.Categoryid == categoryID
                             select category.Tweetcounts).FirstOrDefault();
                if (count != null)
                    return Convert.ToInt32(count);
                else
                    return 0;
            }
            catch
            {
                throw;
                
            }
        }
        public void createTweet(LciTweets tweet)
        {
            try
            {
                List<LciCategory> objCategory = RepoWrapper.Category.FindAll();

                List<LciSubcategory> objSubCategory = RepoWrapper.SubCategory.FindAll();

                int categoryId = GetCategoryId(tweet.Tweettext, objCategory, objSubCategory);

                //if(categoryId ==0)
                // categoryId = GetSubCategoryId(tweet.Tweettext, objSubCategory);
                tweet.Categoryid = categoryId;
                RepoWrapper.Tweet.Create(tweet);
                RepoWrapper.save();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void TweetCount(int categoryid)
            {
            try
            {
                List<LciTweetCount> objCountCategory = RepoWrapper.TweetCounts.FindAll();
                LciTweetCount lcitweetcount = (from objcount in objCountCategory
                                    where objcount.Categoryid == categoryid
                                    select objcount).FirstOrDefault();
                if (lcitweetcount != null)
                {
                    
                    lcitweetcount.Tweetcounts = lcitweetcount.Tweetcounts + 1;
                    RepoWrapper.TweetCounts.Update(lcitweetcount);
                }
                else
                { 
                    LciTweetCount objNewTweet = new LciTweetCount();
                    objNewTweet.Categoryid = categoryid;
                    objNewTweet.Tweetcounts = 1;
                    RepoWrapper.TweetCounts.Create(objNewTweet);
                }

                RepoWrapper.save();

            }
            catch(Exception e)
            {
            throw;
            }
            }

    private int GetCategoryId(string tweetTxt, List<LciCategory> Categories, List<LciSubcategory> subcategories)
        {
            int CatId = 0;


            try
            {
                var regex = new Regex(@"(?<=#)\w+");
                var matches = regex.Matches(tweetTxt);

                foreach (Match m in matches)
                {
                    var objMatchingCategory = (from objCategory in Categories
                                               where m.Value.ToLower().Contains(objCategory.Categoryname.ToLower())
                                               select objCategory.Categoryid).FirstOrDefault();
                   

                    CatId = objMatchingCategory;
                    if (CatId == 0)
                    {
                        CatId = GetSubCategoryId(m.Value, subcategories);
                    }
                    // adds the tweet count part here
                    TweetCount(CatId);

                }




                return CatId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       

        private int GetSubCategoryId(string tweetTxt,List<LciSubcategory> SubCategories)
        {
            

            try
            {
                int SubCatId = 0;  
                var objMatchingSubCategory = (from objSubCategory in SubCategories
                                              where tweetTxt.ToLower().Contains(objSubCategory.Subcategoryname.ToLower())
                                           select objSubCategory.Categoryid).FirstOrDefault();

              
                   SubCatId = Convert.ToInt32(objMatchingSubCategory);
                if(SubCatId==0)
                {
                    SubCatId = 1;
                    //if the # value doesn't comes under category and subcategory it will fall under others category 
                }
                return SubCatId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

   
}
