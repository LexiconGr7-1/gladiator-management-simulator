using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator.Core.Exceptions.Base
{
    public class GladaitorException : Exception
    {
        protected GladaitorException(string message) : base(message)
        {
        }
    }
}
