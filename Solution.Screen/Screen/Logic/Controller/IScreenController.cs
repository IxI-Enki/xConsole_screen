using Logic.Args;
using Logic.Structs;

namespace Logic.Controller
{
        internal interface IController<T> where T : struct
        {
                T Struct { get; }

                event EventHandler<StructEventArgs<T>>? OnEvent;

                void Run( );
                void Stop( );
        }






        internal abstract class TScreenController : IController<Screen>
        {
                public Screen Struct => throw new NotImplementedException( );

                public event EventHandler<StructEventArgs<Screen>>? OnEvent;

                public void Run( )
                {
                        throw new NotImplementedException( );
                }

                public void Stop( )
                {
                        throw new NotImplementedException( );
                }
        }
}