using System.Linq.Expressions;
using System.Reflection;

namespace Hera.Application.Common.Helper
{
    public static class SortHelper<T>
    {
        public static Expression<Func<T, object>> GetOrderExpression(string sortColumn)
        {
            var propertyInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var objectProperty = propertyInfos.FirstOrDefault(pi => pi.Name.Equals(sortColumn, StringComparison.InvariantCultureIgnoreCase));
            if (objectProperty == null)
                return null;
            return t => t.GetType().GetProperty(sortColumn).GetValue(t, null);
        }

        public static IEnumerable<T> SortBy(IEnumerable<T> source, string sortColumn = "", string sortOrder = "")
        {
            var orderExp = GetOrderExpression(sortColumn);
            return sortOrder == "asc" ? source.AsQueryable().OrderBy(orderExp) : source.AsQueryable().OrderByDescending(orderExp);
        }
    }
}
