using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FlasherData.DataModels;
using FlasherData.Repositories.Interfaces;
using FlasherData;
using FlasherData.Context;

namespace FlasherData.Repositories
{
    public class FlashCardRepository : GenericRepository<FlashCardDm>, IFlashCardDmRepository
    {       
        public FlashCardRepository(FlasherContext context) : base(context) {}
        public FlasherContext FlasherContext
        {
            get
            {
                return _context as FlasherContext;
            }
        }

        public IEnumerable<FlashCardDm> GetAllFlashCardsForSubjectDm(int subjedtDmId)
        {           
            IEnumerable<FlashCardDm> _flashCards = _context.Set<FlashCardDm>().Where(fc => fc.SubjectDmId == subjedtDmId);         
            return _flashCards;
        }

        public IEnumerable<FlashCardDm> GetAllFlashCardsForCategoryDm(int categoryDmId)
        {
            IEnumerable<FlashCardDm> _flashCards = _context.Set<FlashCardDm>().Where(fc => fc.CategoryDmId == categoryDmId);
            return _flashCards;
        }

        public string GetSubjectDmTitle(int subjectDmId)
        {
           var title = _context.Set<SubjectDm>().Where(s => s.Id == subjectDmId).FirstOrDefault().Title;
           return title;
        }

        public string GetCategoryDmTitle(int categoryDmId)
        {
            var title = _context.Set<CategoryDm>().Where(s => s.Id == categoryDmId).FirstOrDefault().Title;
            return title;
        }


    }
}
