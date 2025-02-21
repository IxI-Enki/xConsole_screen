using Logic.Args;
using Logic.Contracts;
using Logic.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Controller
{
        public class ScreenController : IControll<Logic.Structs.Screen>
        {
                public Screen Info => new( );
                public static ScreenController Instance
                {
                        get
                        {
                                lock(_lock)
                                        return _instance ?? new( );
                        }
                        private set;
                }
                public event EventHandler<StructEventArgs<Screen>>? OnEvent;

                public void Run( )
                {
                        _running = true;
                        Console.WriteLine( "running" );

                        OnEvent += SetLastScreen!;
                        OnEvent += Print;

                        while(_running)
                        {
                                Screen currentScreen = Info;

                                if(!currentScreen.Equals( LastScreen ))
                                {
                                        currentScreen.Update( );

                                        Notify( currentScreen );
                                }
                                Thread.Sleep( 200 );
                        }
                }
                public void Stop( ) => _running = false;

                ///------------------------------------------------------------------------

                internal Screen LastScreen { get; private set; } = default;

                internal void SetLastScreen( object? s , StructEventArgs<Screen> sI ) => LastScreen = sI.NewValue;
                internal protected void Notify( Screen s ) => OnEvent?.Invoke( this , new ScreenArgs( LastScreen , s ) );
                private static void Print( object? sender , StructEventArgs<Screen> e )
                {
                        Console.SetCursorPosition( 0 , 0 );
                        Console.Write( $"{e.NewValue.WindowSize,30}" );
                }

                private static readonly ScreenController? _instance;
                private volatile bool _running = false;
                private static readonly object _lock = new( );

                static ScreenController( )
                {
                        Instance = new( );

                        Thread listen = new( Instance.Run ) { IsBackground = true };

                        listen.Start( );
                }
                private ScreenController( ) { }
        }
}