using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlasherData.DataModels;

namespace FlasherData.Repositories.Interfaces
{
    public interface IFlashCardDmRepository : IGenericRepository<FlashCardDm>
    {        
        public IEnumerable<FlashCardDm> GetAllFlashCardsForSubjectDm(int subjectId);
        public IEnumerable<FlashCardDm> GetAllFlashCardsForCategoryDm(int categoryId);
        public string GetSubjectDmTitle(int subjectId);
        public string GetCategoryDmTitle(int categoryId);
    }
}
