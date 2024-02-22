using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using System.Diagnostics;
using System.Reflection;

namespace BookStore.Business.Aspects
{
   
    public class CacheInterceptor : InterceptorBase<CacheAttribute>
    {
        private readonly IMemoryCache _cache;
       
        
        public CacheInterceptor(IMemoryCache cache)
        {
            _cache = cache;
           
        }
      
        protected override void OnAfter(IInvocation invocation, CacheAttribute attribute)
        {
            if (attribute != null)
            {
                var cacheKey = $"{invocation.Method.DeclaringType.FullName}.{invocation.Method.Name}";

                if (invocation.ReturnValue != null)
                {
                    _cache.Set(cacheKey, invocation.ReturnValue, attribute.ExpirationTime);
                }
            }
        }
        

    }
}
