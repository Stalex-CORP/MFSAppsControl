using System.Text;

namespace MFSAppsControl.Converters
{
    public static class CollectionLogConverter
    {

        /// <summary>
        /// Method to convert a collection to a log-friendly string representation for logs.
        /// </summary>
        /// <param name="collection"> The collection to convert.</param>
        public static string ToLogString<T>(this IEnumerable<T> collection)
        {
            if (collection == null) return "null";
            var sb = new StringBuilder();
            sb.Append("[");
            bool first = true;
            foreach (var item in collection)
            {
                if (!first) sb.Append(", ");
                sb.Append(item?.ToString());
                first = false;
            }
            sb.Append("]");
            return sb.ToString();
        }
    }
}
