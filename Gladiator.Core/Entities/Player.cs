﻿using Gladiator.Core.Entities.Base;

namespace Gladiator.Core.Entities
{
    public class Player : BaseEntityWithName
    {
        public ICollection<Arena> Arenas { get; set; }
        public ICollection<School> Schools { get; set; }
        public ICollection<Gladiator> Gladiators { get; set; }
    }
}
