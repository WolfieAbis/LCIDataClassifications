using System;
using System.Collections.Generic;
using System.Text;
using LCIData.Repositories;
using LCIEntities.Models;


namespace LCIData.Interface
{
    public interface ITweetRepository : IRepositoryBase<LciTweets>
    {
        /// <summary>
        /// A method to get movie details by Id
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns>Movie</returns>
        //Movie GetMovieDetailsById(int movieId);

       
    }
}
