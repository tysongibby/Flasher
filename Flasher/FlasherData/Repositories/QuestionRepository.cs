using FlasherData.Context;
using FlasherData.DataModels;
using FlasherData.Repositories.Interfaces;

namespace FlasherData.Repositories
{
    internal class QuestionRepository : GenericRepository<Question>, IQuestionRepository
    {        
        public QuestionRepository(FlasherContext context) : base(context)
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