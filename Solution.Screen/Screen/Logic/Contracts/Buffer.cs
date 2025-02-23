using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Contracts
{
        public class Buffer<TData>( int maxSize )
        {
                private TData[]? _data = new TData[ maxSize ];
                private static int _last = 0;

                public void Put( TData s ) => _data![ _last++ ] = s;
                public TData? Get( ) => _data![ _last-- ];
        }
}
