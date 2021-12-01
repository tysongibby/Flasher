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
            FlashCards = new FlashCardRepository(_context);
            Sets = new SetRepository(_context);
            Supersets = new SupersetRepository(_context);
        }

        public IFlashCardRepository FlashCards { get; private set; }

        public ISetRepository Sets { get; private set; }

        public ISupersetRepository Supersets { get; private set; }

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
