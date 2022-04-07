using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator.Core.Exceptions.Base
{
    public class BaseException : Exception
    {
        protected BaseException(string message) : base(message)
        {
        }
    }
}
