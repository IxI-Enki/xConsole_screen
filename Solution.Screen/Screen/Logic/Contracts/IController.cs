using Logic.Args;
using Logic.Structs;
using System.Drawing;
using System.Linq;
using System.Threading;

namespace Logic.Contracts
{
        internal interface IController<T> where T : struct
        {
                T Struct { get; }

                event EventHandler<StructEventArgs<T>>? OnEvent;

                void Run( );
                void Stop( );
        }

        internal sealed class ScreenController : IControllerBase<Screen>
        {
                public static ScreenController Instance
                {
                        get
                        {
                                lock(_lock)
                                        return _instance ?? new( );
                        }
                        private set;
                }

                static ScreenController( )
                {
                        Instance = new( );

                        Thread listen = new( Instance.Run ) { IsBackground = true };

                        listen.Start( );
                }
                internal ScreenController( ) : base( ) { }
                private static ScreenController? _instance;
                private static readonly object _lock = new( );
                public void Run( ) { }

                //internal sealed partial class InputController( IController<Screen>? controller ) : IControllerBase<Screen>( controller ) { }
                //internal sealed partial class Controller( IController<Screen>? controller ) : IControllerBase<Screen>( controller ) { }
        }
}