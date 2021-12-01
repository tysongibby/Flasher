using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlasherData.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable, IAsyncDisposable
    {
        
        IFlashCardRepository FlashCards { get; }
        ISetRepository Sets { get; }
        ISupersetRepository Supersets { get; }

        int UpdateDb();

        Task<int> UpdateDbAsync();

    }
}
