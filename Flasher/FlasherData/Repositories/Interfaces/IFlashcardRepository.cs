using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlasherData.DataModels;

namespace FlasherData.Repositories.Interfaces
{
    public interface IFlashcardRepository : IGenericRepository<Flashcard>
    {        
        public IEnumerable<Flashcard> GetAllFlashcardsForSubject(int subjectId);
        public IEnumerable<Flashcard> GetAllFlashcardsForCategory(int categoryId);
        public string GetSubjectName(int subjectId);
        public string GetCategoryName(int categoryId);
    }
}
