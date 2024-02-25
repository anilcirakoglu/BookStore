using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Business.Aspects
{
    [AttributeUsage(AttributeTargets.Method)]
    public class CacheAttribute : AttributeBase
    {
        public int Duration { get; set; }
        public CacheAttribute(int seconds)
        {
            Duration = seconds;
        }
    }
}
