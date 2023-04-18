#if WINDOWS
using Microsoft.Maui.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiReproBrowser.Issues._14537
{
	public class NativeControlHandler : ViewHandler<INativeControl, MauiApp1.Platforms.Windows.NativeUserControl>
	{
		public static IPropertyMapper<INativeControl, NativeControlHandler> Mapper = new PropertyMapper<INativeControl, NativeControlHandler>(ViewHandler.ViewMapper)
		{
		};

		public NativeControlHandler() : base(Mapper)
		{
		}

		protected override MauiApp1.Platforms.Windows.NativeUserControl CreatePlatformView()
		{
			return new MauiApp1.Platforms.Windows.NativeUserControl();
		}
	}
}
#endif