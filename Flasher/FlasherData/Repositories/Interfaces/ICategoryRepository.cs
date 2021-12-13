using FlasherData.DataModels;
using System.Threading.Tasks;

namespace FlasherData.Repositories.Interfaces
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        public Task<Subject> GetSubject(int id);
    }
}