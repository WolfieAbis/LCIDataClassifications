using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LCIEntities.Models;
using LCIBusinessLayer;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace LCIClassification.Controllers
{
    
    [ApiController]
    public class LCIController : ControllerBase
    {
        private readonly ILCIBusiness businessLayer;
        public string Result { get; set; }
        private IMapper iMapper;

        public LCIController(ILCIBusiness businessLayer)
        {
            this.businessLayer = businessLayer;

            var config = new MapperConfiguration(cfg => {

                cfg.CreateMap<LciTweetsModel, LciTweets>();
                
            });

            iMapper = config.CreateMapper();
        }

        [HttpPost]
        [Route("LCI/CreateTweet")]
        public IActionResult CreateTweet([FromBody]LciTweetsModel tweet)
        {
            try
            {
                LciTweets objtweet = iMapper.Map<LciTweetsModel, LciTweets>(tweet);

                businessLayer.createTweet(objtweet);
                return Ok();
            }
            catch (Exception ex)
            {
                
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("LCI/TweetCount")]
        public int GetCategoryCountById(int categoryId)
        {
            try
            {
                return businessLayer.GetCategoryCountById(categoryId);
            }
            catch (Exception ex)
            {

                return -1;
            }
        }
    }
}
