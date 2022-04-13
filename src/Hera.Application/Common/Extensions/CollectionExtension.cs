namespace Hera.Application.Common.Extensions
{
    public static class CollectionExtension
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> genericEnumerable)
        {
            return ((genericEnumerable == null) || (!genericEnumerable.Any()));
        }

        public static bool IsNullOrEmpty<T>(this ICollection<T> genericCollection)
        {
            if (genericCollection == null)
            {
                return true;
            }
            return genericCollection.Count < 1;
        }
    }
}
