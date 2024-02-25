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
using Serilog.Core;
using Castle.Core.Logging;
using Serilog;
using Microsoft.EntityFrameworkCore.Diagnostics.Internal;
using Core.Dependencies;

namespace BookStore.Business.Aspects
{

    public class CacheInterceptor : InterceptorBase<CacheAttribute>
    {
        readonly private IMemoryCache _cache;



        public CacheInterceptor(IMemoryCache cache)
        {
            _cache = cache;

        }

        protected override void OnAfter(IInvocation invocation, CacheAttribute attribute)
        {
            invocation.Proceed();

            if (attribute != null)
            {
                var cacheKey = $"{invocation.Method.DeclaringType.FullName}.{invocation.Method.Name}";

                if (invocation.ReturnValue != null)
                {
                    var options = new MemoryCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(attribute.Duration)
                    };
                    _cache.Set(cacheKey, invocation.ReturnValue, options);

                    Log.Information($"Data cached with key: {cacheKey}");
                    Log.Debug("This is a debug message.");
                }
            }
        }
    }
}

