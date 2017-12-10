using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewsServiceApi.DAL.Models;

namespace NewsServiceApi.DAL.Repositories.Categories
{
    interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();


    }
}
