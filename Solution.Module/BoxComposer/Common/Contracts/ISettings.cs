///   N A M E S P A C E   ///
namespace Common.Contracts;


public interface ISettings
{
      string? this[ string key ] { get; }
}