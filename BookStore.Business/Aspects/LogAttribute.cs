using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Business.Aspects
{
    public class LogAttribute : AttributeBase
    {
        public LogLevel Level { get; set; }
    }
}
