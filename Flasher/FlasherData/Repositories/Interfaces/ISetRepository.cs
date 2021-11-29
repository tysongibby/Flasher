using FlasherData.Models;
using System.Threading.Tasks;

namespace FlasherData.Repositories.Interfaces
{
    public interface ISetRepository : IBaseRepository<Set>
    {
        public Task<Superset> GetSuperset(int id);
    }
}