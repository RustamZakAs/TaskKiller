using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TaskKiller
{
    public static class Extensions
    {
        public static bool IsOneOf<T>(this T self, IEnumerable<T> elements)
        {
            return self == null || elements == null ? false : elements.Contains(self);
        }
    }
}
