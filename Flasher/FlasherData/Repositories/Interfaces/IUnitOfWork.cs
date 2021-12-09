using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlasherData.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable, IAsyncDisposable
    {
        
        IFlashcardDmRepository FlashcardDms { get; }
        ICategoryDmRepository CategoryDms { get; }
        ISubjectDmRepository SubjectDms { get; }

        int UpdateDb();

        Task<int> UpdateDbAsync();

    }
}
