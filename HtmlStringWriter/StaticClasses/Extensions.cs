namespace HtmlStringWriter.StaticClasses
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Text;
    using Interfaces;

    public static class Extensions
    {
        public static bool HasValue<T>(this IList<T> list)
        {
            return list != null && list.Count > 0;
        }

        public static IList<T> AddElement<T>(this IList<T> list, T item)
        {
            list ??= new Collection<T>();
            list.Add(item);
            return list;
        }

        public static void AddValues<T>(this IList<T> htmlElements, StringBuilder sb) where T : IHtmlElement
        {
            if (htmlElements == null)
                throw new ArgumentNullException();

            for (var i = 0; i < htmlElements.Count; i++)
            {
                var htmlElement = htmlElements[i];
                htmlElement.ToHtmlString(sb);

                if (i != htmlElements.Count - 1) sb.Append(' ');
            }
        }

        public static void AddValuesFromList<T>(this IList<T> htmlElements, StringBuilder sb) where T : IHtmlElement
        {
            if (!htmlElements.HasValue()) return;

            foreach (var child in htmlElements) child.ToHtmlString(sb);
        }
    }
}