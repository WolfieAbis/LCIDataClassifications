using Microsoft.EntityFrameworkCore;
using LCIData.Interface;
using LCIEntities.Models;
using System.Collections.Generic;
using System.Linq;

namespace LCIData.Repositories
{
    public class SubCategoryRepository : RepositoryBase<LciSubcategory>, ISubCategoryRepository
    {
        private readonly LCIDataClassificationContext dBContext;

        public SubCategoryRepository(LCIDataClassificationContext repositoryContext)
            : base(repositoryContext)
        {
            dBContext = repositoryContext;
        }
              

    }    
}
