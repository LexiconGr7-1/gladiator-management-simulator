using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator.Core.Entities.Base
{
    public abstract class BaseEntityWithName : BaseEntity
    {
        public virtual string Name { get; set; }
    }
}
