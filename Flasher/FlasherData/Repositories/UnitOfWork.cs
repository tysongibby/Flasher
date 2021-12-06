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
            FlashCardDms = new FlashCardRepository(_context);
            CategoryDms = new CategoryRepository(_context);
            SubjectDms = new SubjectRepository(_context);
        }

        public IFlashCardDmRepository FlashCardDms { get; private set; }

        public ICategoryDmRepository CategoryDms { get; private set; }

        public ISubjectDmRepository SubjectDms { get; private set; }

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
