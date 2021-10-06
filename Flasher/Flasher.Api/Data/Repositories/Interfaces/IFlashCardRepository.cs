using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flasher.Shared.Data.Models;

namespace Flasher.Server.Data.Repositories.Interfaces
{
    public interface IFlashCardRepository : IBaseRepository<FlashCard>
    {
        Task<FlashCard> Update(FlashCard flashCard);
    }
}
