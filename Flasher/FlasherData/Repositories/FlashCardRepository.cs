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
    public class FlashcardRepository : GenericRepository<FlashcardDm>, IFlashcardDmRepository
    {       
        public FlashcardRepository(FlasherContext context) : base(context) {}
        public FlasherContext FlasherContext
        {
            get
            {
                return _context as FlasherContext;
            }
        }

        public IEnumerable<FlashcardDm> GetAllFlashcardsForSubjectDm(int subjedtDmId)
        {
            List<FlashcardDm> flashcards = new List<FlashcardDm>();
            using (FlasherContext context = new FlasherContext())
            {
                flashcards = (from category in context.CategoryDms
                              join flashcard in context.FlashcardDms on category.Id equals flashcard.CategoryDmId
                              where category.SubjectDmId == subjedtDmId                              
                              select flashcard).ToList();
            }
            return flashcards;
        }

        public IEnumerable<FlashcardDm> GetAllFlashcardsForCategoryDm(int categoryDmId)
        {
            IEnumerable<FlashcardDm> _flashcards = _context.Set<FlashcardDm>().Where(fc => fc.CategoryDmId == categoryDmId);
            return _flashcards;
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
