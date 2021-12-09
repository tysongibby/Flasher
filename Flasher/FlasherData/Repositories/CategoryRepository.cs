using FlasherData.Repositories.Interfaces;
using FlasherData.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlasherData.Context;

namespace FlasherData.Repositories
{
    public class CategoryRepository : GenericRepository<CategoryDm>, ICategoryDmRepository
    {
        public CategoryRepository(FlasherContext context) : base(context) { }
        public FlasherContext FlasherContext
        {
            get
            {
                return _context as FlasherContext;
            }
        }

        public async Task<SubjectDm> GetSubjectDm(int id)
        {
            CategoryDm categoryDm = FlasherContext.CategoryDms.FindAsync(id).Result;
            if (categoryDm is not null)
            {
                SubjectDm subject = await FlasherContext.SubjectDms.FindAsync(categoryDm.SubjectId);
                return subject;
            }
            else
            {
                throw new Exception($"Subject {id} could not be found.");
            }
        }

    }
}
