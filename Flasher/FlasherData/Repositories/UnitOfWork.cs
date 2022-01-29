using FlasherData.Context;
using FlasherData.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlasherData.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FlasherContext _context;

        public UnitOfWork(FlasherContext context)
        {
            _context = context;
            Flashcards = new FlashcardRepository(_context);
            Categories = new CategoryRepository(_context);
            Subjects = new SubjectRepository(_context);
            Tests = new TestRepository(_context);
            Questions = new QuestionRepository(_context);
        }

        public IFlashcardRepository Flashcards { get; private set; }

        public ICategoryRepository Categories { get; private set; }

        public ISubjectRepository Subjects { get; private set; }

        public ITestRepository Tests { get; private set; }

        public IQuestionRepository Questions { get; private set; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public ValueTask DisposeAsync()
        {
            return _context.DisposeAsync();
        }

        public int UpdateDb()
        {            
            return _context.SaveChanges();
        }

        public Task<int> UpdateDbAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
