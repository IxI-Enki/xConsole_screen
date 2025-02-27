///   N A M E S P A C E   ///
namespace Common.Modules.Configuration;


/// <summary>
/// Singleton class to manage application settings.
/// </summary>
public sealed class AppSettings : ISettings
{
      #region FIELDS
      private static readonly Lazy<AppSettings> _instance = new( );
      private static IConfigurationRoot _configurationRoot;
      #endregion

      #region PROPERTIES
      /// <summary>
      /// Gets the singleton instance of the AppSettings class.
      ///   - lazily initialized with thread safety
      /// </summary>
      public static AppSettings Instance => _instance.Value;
      #endregion

      #region CONSTRUCTORS
      /// <summary>
      /// Static constructor to initialize the configuration.
      /// </summary>
      static AppSettings( )
      {
            var environmentName = Environment.GetEnvironmentVariable( "ASPNETCORE_ENVIRONMENT" );

            var builder
                  = new ConfigurationBuilder( )
                        .AddJsonFile( "appsettings.json" , optional: false , reloadOnChange: true )
                        .AddJsonFile( $"appsettings{environmentName ?? "Development"}.json" , optional: true )
                        .AddEnvironmentVariables( );

            _configurationRoot = builder.Build( );
      }
      /// <summary>
      /// Private constructor to prevent instantiation.
      /// </summary>
      private AppSettings( ) { }
      #endregion

      #region METHODS
      /// <summary>
      /// Indexer to get the configuration value by key.
      /// </summary>
      /// <param name="key">The configuration key.</param>
      /// <returns>The configuration value.</returns>
      public string? this[ string key ] => _configurationRoot[ key ];
      #endregion
}

