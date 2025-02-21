using Logic.Args;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Contracts
{
        public interface IControll<T> where T : struct
        {
                #region ___P U B L I C   M E T H O D S___ 

                void Stop( );
                #endregion

                #region ___E V E N T S___ 

                event EventHandler<StructEventArgs<T>> OnEvent;
                #endregion

                #region ___P R I V A T E   M E T H O D S___ 

                virtual void Run( ) { }
                virtual void Notify( T t ) { }
                #endregion
        }
}
