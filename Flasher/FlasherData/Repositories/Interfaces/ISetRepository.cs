using FlasherData.Models;
using System.Threading.Tasks;

namespace FlasherData.Repositories.Interfaces
{
    public interface ISetRepository : IGenericRepository<SetModel>
    {
        public Task<SupersetModel> GetSuperset(int id);
    }
}