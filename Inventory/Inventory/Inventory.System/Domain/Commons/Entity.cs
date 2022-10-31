using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.System.Domain.Commons
{
    public abstract class Entity
    {
        private Guid id;
        
        public virtual Guid Id
        {
            get
            {
                return this.id;
            }

            protected set
            {
                this.id = value;
            }
        }
    }
}
