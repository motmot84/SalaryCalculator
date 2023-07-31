using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sprout.Exam.DataAccess.Interface
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(T entity);
    }
}
