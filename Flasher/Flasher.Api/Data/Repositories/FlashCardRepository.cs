using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Flasher.Shared.Data.Models;
using Flasher.Server.Data.Repositories.Interfaces;
using Flasher.Server.Data;

namespace Flasher.Server.Data.Repositories
{
    public class FlashCardRepository : BaseRepository<FlashCard>, IFlashCardRepository
    {
        public FlashCardRepository(FlasherContext context) : base(context)
        {         
        }

        public FlasherContext FlasherContext
        {
            get 
            {
                return Context as FlasherContext;
            }
        }
    }
}
