using Escola.Shared.Entities;
using System.Linq.Expressions;

namespace Escola.Domain.Queries
{
    public static class GenericQueries<T> where T : BaseEntity
    {
        public static Expression<Func<T, bool>> GetById(int id)
        {
            return x => x.Id == id;
        }
    }
}
