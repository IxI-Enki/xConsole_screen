using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Contracts
{
        internal abstract class IControllerBase<T>( ) where T : struct
        {
                internal IController<T>? Controller { get; }
        }
}
