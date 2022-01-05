using FlasherData.Repositories.Interfaces;
using FlasherData.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlasherData.Context;

namespace FlasherData.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(FlasherContext context) : base(context) { }
        public FlasherContext FlasherContext
        {
            get
            {
                return _context as FlasherContext;
            }
        }

        public async Task<Subject> GetSubject(int id)
        {
            Category category = FlasherContext.Categories.FindAsync(id).Result;
            if (category is not null)
            {
                Subject subject = await FlasherContext.Subjects.FindAsync(category.SubjectId);
                return subject;
            }
            else
            {
                throw new Exception($"Subject {id} could not be found.");
            }
        }

    }
}
