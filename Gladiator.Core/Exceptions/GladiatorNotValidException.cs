using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator.Core.Exceptions
{
    public class GladiatorNotValidException : NotValidException
    {
        public GladiatorNotValidException() {}
        public GladiatorNotValidException(string message) : base(message) {}
        public GladiatorNotValidException(string message, Exception inner) : base(message, inner) {}
    }
}
