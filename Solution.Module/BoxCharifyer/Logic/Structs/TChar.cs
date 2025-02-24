using System.Text;
namespace Logic.Structs;

public static class TCharExtensions
{
      private static readonly char[] _allChars = [ .. "╵ ╷ ╶ ╴ ╹ ╻ ╺ ╸ │ ┃ ║ ╽ ╿ ╎ ╏ ┆ ┇ ┊ ┋ ─ ━ ═ ╾ ╼ ╌ ╍ ┄ ┅ ┈ ┉ ╭ ╮ ┌ ┐ ╰ ╯ └ ┘ ┍ ┑ ┎ ┒ ┕ ┙ ┖ ┚ ┏ ┓ ┗ ┛ ╒ ╕ ╓ ╖ ╘ ╛ ╙ ╜ ╔ ╗ ╚ ╝ ├ ┤ ┝ ┥ ┟ ┧ ┞ ┦ ┢ ┪ ┡ ┩ ┠ ┨ ┣ ┫ ╞ ╡ ╟ ╢ ╠ ╣ ┬ ┴ ┭ ┮ ┰ ┵ ┶ ┸ ┯ ┱ ┲ ┷ ┹ ┺ ┳ ┻ ╤ ╥ ╧ ╨ ╦  ╩ ┼ ┽ ┾ ╀ ╁ ┿ ╂ ╪ ╫ ╃ ╄ ╅ ╆ ╇ ╈ ╉ ╊ ╋ ╬" ];

      public static char[] AllBoxChars => _allChars;

      public static string ReturnAllBoxChars( ) => string.Concat( AllBoxChars );
      public static void PrintAllBoxChars( )
      {
            Console.OutputEncoding = Encoding.UTF8;
            foreach(char c in _allChars) Console.Write( c + " " );
      }
}
public struct TChar
{
      public char Char;
      public static void PrintAllBoxChars( ) => TCharExtensions.PrintAllBoxChars( );
}