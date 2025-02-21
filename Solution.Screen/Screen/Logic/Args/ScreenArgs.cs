using Logic.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Args;

public class ScreenArgs( Screen oldValue , Screen newValue ) : StructEventArgs<Logic.Structs.Screen>( oldValue , newValue ) { }

// Generische EventArgs-Klasse für die Benachrichtigung
public class StructEventArgs<T>( T oldValue , T newValue ) : EventArgs where T : struct
{
        public T OldValue { get; } = oldValue;
        public T NewValue { get; } = newValue;
}