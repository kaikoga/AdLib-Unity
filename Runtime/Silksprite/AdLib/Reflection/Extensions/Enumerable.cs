using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Silksprite.AdLib.Reflection.Base;

namespace Silksprite.AdLib.Reflection.Extensions
{
    public static class Enumerable
    {
        public static List<TAccess?>? ToAccessList<TAccess>(this object source, Func<object?, TAccess?> toAccess)
        where TAccess : ObjectAccessBase
        {
            return source is IEnumerable<object?> list ? list.Select(toAccess).ToList() : null;
        }

        public static object ToDynamicList(this IEnumerable<ObjectAccessBase?> source, Type type)
        {
            var listType = typeof(List<>).MakeGenericType(type);
            var list = (IList)Activator.CreateInstance(listType);
            foreach (var item in source)
            {
                list.Add(item?.ActualObject);
            }
            return list;
        }
    }
}
