namespace MauiReproBrowser.Issues._14537;

public partial class CustomViewContainer : ContentView
{
	public CustomViewContainer()
	{
		InitializeComponent();
	}

	private void ContentView_Loaded(object sender, EventArgs e)
	{
		ContentContainer.Content = new NativeControl();
	}
}