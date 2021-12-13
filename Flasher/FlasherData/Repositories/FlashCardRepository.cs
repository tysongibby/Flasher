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
            List<CategoryDm> categories = new List<CategoryDm>();
            categories = _context.Set<CategoryDm>().Where(c => c.SubjectId == subjedtDmId).ToList();
            foreach (CategoryDm category in categories)
            {
                flashcards.AddRange(_context.Set<FlashcardDm>().Where(fc => fc.CategoryId == category.Id).ToList());
            }
            return flashcards;
        }

        public IEnumerable<FlashcardDm> GetAllFlashCardsForCategory(int categoryId)
        {            
            return _context.Set<FlashcardDm>().Where(fc => fc.CategoryId == categoryId).ToList();            
        }

        public IEnumerable<FlashcardDm> GetAllFlashCardsForCategories(IEnumerable<int> categoryIds)
        {
            List<FlashcardDm> flashcards = new List<FlashcardDm>();
            foreach (int categoryId in categoryIds)
            {                                        
                flashcards.AddRange(_context.Set<FlashcardDm>().Where(fc => fc.CategoryId == categoryId).ToList());
            }            
            return flashcards;
        }

        public IEnumerable<FlashcardDm> GetAllFlashcardsForCategoryDm(int categoryDmId)
        {            
            return _context.Set<FlashcardDm>().Where(fc => fc.CategoryId == categoryDmId).ToList(); ;
        }

        public string GetSubjectDmTitle(int subjectDmId)
        {           
           return _context.Set<SubjectDm>().Where(s => s.Id == subjectDmId).FirstOrDefault().Name; ;
        }

        public string GetCategoryDmTitle(int categoryDmId)
        {            
            return _context.Set<CategoryDm>().Where(s => s.Id == categoryDmId).FirstOrDefault().Name;
        }
    }
}
