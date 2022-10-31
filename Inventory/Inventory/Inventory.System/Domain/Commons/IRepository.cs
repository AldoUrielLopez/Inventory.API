using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.System.Domain.Commons
{
    public interface IRepository<T> where T : IAggregateRoot { }
}
