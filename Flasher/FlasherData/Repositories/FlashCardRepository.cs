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
    public class FlashcardRepository : GenericRepository<Flashcard>, IFlashcardRepository
    {       
        public FlashcardRepository(FlasherContext context) : base(context) {}
        public FlasherContext FlasherContext
        {
            get
            {
                return _context as FlasherContext;
            }
        }

        public IEnumerable<Flashcard> GetAllFlashcardsForSubject(int subjetId)
        {
            List<Flashcard> flashcards = new List<Flashcard>();
            List<Category> categories = new List<Category>();
            categories = _context.Set<Category>().Where(c => c.SubjectId == subjetId).ToList();
            foreach (Category category in categories)
            {
                flashcards.AddRange(_context.Set<Flashcard>().Where(fc => fc.CategoryId == category.Id).ToList());
            }
            return flashcards;
        }

        public IEnumerable<Flashcard> GetAllFlashCardsForCategory(int categoryId)
        {            
            return _context.Set<Flashcard>().Where(fc => fc.CategoryId == categoryId).ToList();            
        }

        public IEnumerable<Flashcard> GetAllFlashCardsForCategories(IEnumerable<int> categoryIds)
        {
            List<Flashcard> flashcards = new List<Flashcard>();
            foreach (int categoryId in categoryIds)
            {                                        
                flashcards.AddRange(_context.Set<Flashcard>().Where(fc => fc.CategoryId == categoryId).ToList());
            }            
            return flashcards;
        }

        public IEnumerable<Flashcard> GetAllFlashcardsForCategory(int categoryId)
        {            
            return _context.Set<Flashcard>().Where(fc => fc.CategoryId == categoryId).ToList(); ;
        }

        public string GetSubjectName(int subjectId)
        {           
           return _context.Set<Subject>().Where(s => s.Id == subjectId).FirstOrDefault().Name; ;
        }

        public string GetCategoryName(int categoryId)
        {            
            return _context.Set<Category>().Where(s => s.Id == categoryId).FirstOrDefault().Name;
        }
    }
}
