namespace MauiReproBrowser.Issues._14305;

[Issue(14305, "Grid star (Image?) behaviour inconsistent across platforms")]
public partial class Issue14305 : ContentPage
{
	public Issue14305()
	{
		InitializeComponent();
	}

	private async void Button_Clicked(object sender, EventArgs e)
	{
		await DisplayAlert("Clicked", "Button was clicked", "OK");
	}
}