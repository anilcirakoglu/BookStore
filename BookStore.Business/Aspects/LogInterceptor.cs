using BookStore.Business.Aspects;
using Castle.DynamicProxy;
using Core.Dependencies;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace BookStore.Business.Aspects
{
    public class LogInterceptor : InterceptorBase<LogAttribute>
    {
        private readonly ILogger<LogInterceptor> _logger;

        public LogInterceptor(ILogger<LogInterceptor> logger)
        {
            _logger = logger;
        }

        protected override void OnBefore(IInvocation invocation, LogAttribute attribute)
        {
            _logger.LogInformation($"{invocation.Method.Name}_OnBefore");
            Log.Information($"{invocation.Method.Name}_OnBefore");
        }

        protected override void OnAfter(IInvocation invocation, LogAttribute attribute)
        {
            _logger.LogInformation($"{invocation.Method.Name}_OnAfter");
            Log.Information($"{invocation.Method.Name}_OnAfter");
        }
    }
}