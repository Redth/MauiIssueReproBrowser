using Microsoft.Extensions.Logging;

namespace MauiReproBrowser;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			// BEGIN Issue 14537
#if WINDOWS
			 .ConfigureMauiHandlers(x => x.AddHandler<Issues._14537.NativeControl, Issues._14537.NativeControlHandler>())
#endif
			// END Issue 14537
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
