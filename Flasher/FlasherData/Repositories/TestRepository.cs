using FlasherData.Context;
using FlasherData.DataModels;
using FlasherData.Repositories.Interfaces;

namespace FlasherData.Repositories
{
    public class TestRepository : GenericRepository<Test>, ITestRepository
    {
        public TestRepository(FlasherContext context) : base(context)
        {  
        }
        public FlasherContext FlasherContext
        {
            get
            {
                return _context as FlasherContext;
            }
        }
    }
}