using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Business.Aspects
{
  
    public class CacheAttribute : AttributeBase
    {
        public TimeSpan ExpirationTime { get; set; }
        public CacheAttribute(int seconds)
        {
            ExpirationTime = TimeSpan.FromSeconds(seconds);
        }

    }
}
