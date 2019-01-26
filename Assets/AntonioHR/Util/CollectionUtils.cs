using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntonioHR.Util
{
    public static class CollectionUtils
    {


        public static IEnumerable<T> CycleStartingAt<T>(this T[] array, int i, bool includeSelfAtEnd = true)
        {
            int len = array.Length;
            var indices = Enumerable.Range(0, includeSelfAtEnd ? len : len - 1).Select(x => (x + i) % len);
            return indices.Select(x => array[x]);
        }
    }
}
