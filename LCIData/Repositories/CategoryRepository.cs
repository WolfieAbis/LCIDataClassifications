using Microsoft.EntityFrameworkCore;
using LCIData.Interface;
using LCIEntities.Models;
using System.Collections.Generic;
using System.Linq;

namespace LCIData.Repositories
{
    public class CategoryRepository : RepositoryBase<LciCategory>, ICategoryRepository
    {
        private readonly LCIDataClassificationContext dBContext;

        public CategoryRepository(LCIDataClassificationContext repositoryContext)
            : base(repositoryContext)
        {
            dBContext = repositoryContext;
        }
              

    }    
}
