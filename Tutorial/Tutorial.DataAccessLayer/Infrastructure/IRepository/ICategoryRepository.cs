using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutorial.Models;

namespace Tutorial.DataAccessLayer.Infrastructure.IRepository
{
    public interface ICategoryRepository :IRepository<Category>
    {
        void update(Category category); 
    }
}
