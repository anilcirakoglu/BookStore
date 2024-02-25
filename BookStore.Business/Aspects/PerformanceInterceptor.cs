using Castle.DynamicProxy;
using Core.Dependencies;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Business.Aspects
{
    public class PerformanceInterceptor : InterceptorBase<PerformanceAttribute>
    {
        private readonly ILogger<PerformanceInterceptor> _logger;
        private readonly Stopwatch _stopwatch;

        public PerformanceInterceptor(ILogger<PerformanceInterceptor> logger)
        {
            _logger = logger;
            _stopwatch = new Stopwatch();
        }

        protected override void OnBefore(IInvocation invocation, PerformanceAttribute attribute)
        {
            _stopwatch.Start();
        }

        protected override void OnAfter(IInvocation invocation, PerformanceAttribute attribute)
        {
            if (_stopwatch.Elapsed.TotalMilliseconds > attribute.Interval)
            {
                _logger.LogInformation($"{invocation.Method.Name} elapsed {_stopwatch.Elapsed.TotalSeconds} second(s).");
                Log.Information($"{invocation.Method.Name} elapsed {_stopwatch.Elapsed.TotalSeconds} second(s).");
            }
            _stopwatch.Stop();
        }

        

    }
}
