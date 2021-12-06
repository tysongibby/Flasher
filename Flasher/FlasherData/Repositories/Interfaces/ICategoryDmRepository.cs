using FlasherData.DataModels;
using System.Threading.Tasks;

namespace FlasherData.Repositories.Interfaces
{
    public interface ICategoryDmRepository : IGenericRepository<CategoryDm>
    {
        public Task<SubjectDm> GetSubjectDm(int id);
    }
}