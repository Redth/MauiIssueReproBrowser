#if WINDOWS
using Microsoft.UI.Xaml.Controls;

namespace MauiApp1.Platforms.Windows;

public sealed partial class NativeUserControl : UserControl
{
	public NativeUserControl()
	{
		InitializeComponent();
	}
}

#endif