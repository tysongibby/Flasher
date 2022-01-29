using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlasherData.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable, IAsyncDisposable
    {
        
        IFlashcardRepository Flashcards { get; }
        ICategoryRepository Categories { get; }
        ISubjectRepository Subjects { get; }

        int UpdateDb();

        Task<int> UpdateDbAsync();

    }
}
