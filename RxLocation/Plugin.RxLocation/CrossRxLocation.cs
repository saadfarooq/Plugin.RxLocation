using Plugin.RxLocation.Abstractions;
using System;

namespace Plugin.RxLocation
{
  /// <summary>
  /// Cross platform RxLocation implemenations
  /// </summary>
  public class CrossRxLocation
  {
    static Lazy<IRxLocation> Implementation = new Lazy<IRxLocation>(() => CreateRxLocation(), System.Threading.LazyThreadSafetyMode.PublicationOnly);

    /// <summary>
    /// Current settings to use
    /// </summary>
    public static IRxLocation Current
    {
      get
      {
        var ret = Implementation.Value;
        if (ret == null)
        {
          throw NotImplementedInReferenceAssembly();
        }
        return ret;
      }
    }

    static IRxLocation CreateRxLocation()
    {
#if PORTABLE
        return null;
#else
        return new RxLocationImplementation();
#endif
    }

    internal static Exception NotImplementedInReferenceAssembly()
    {
      return new NotImplementedException("This functionality is not implemented in the portable version of this assembly.  You should reference the NuGet package from your main application project in order to reference the platform-specific implementation.");
    }
  }
}
