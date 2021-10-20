using FlasherApi.Data.Models;
using System.Threading.Tasks;

namespace FlasherApi.Data.Repositories.Interfaces
{
    public interface ISetRepository : IBaseRepository<Set>
    {
        public Superset GetSuperset(int id);
    }
}