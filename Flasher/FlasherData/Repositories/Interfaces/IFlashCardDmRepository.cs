using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlasherData.DataModels;

namespace FlasherData.Repositories.Interfaces
{
    public interface IFlashcardDmRepository : IGenericRepository<FlashcardDm>
    {        
        public IEnumerable<FlashcardDm> GetAllFlashcardsForSubjectDm(int subjectId);
        public IEnumerable<FlashcardDm> GetAllFlashcardsForCategoryDm(int categoryId);
        public string GetSubjectDmTitle(int subjectId);
        public string GetCategoryDmTitle(int categoryId);
    }
}
