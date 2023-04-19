namespace MauiReproBrowser.Issues._14296;

[Issue(14296, "Label no longer wrapping / measuring correctly inside Grid when available size shrinks enough")]
public partial class Issue14296 : ContentPage
{
	public Issue14296()
	{
		InitializeComponent();
	}

	private async void Button_Clicked(object sender, EventArgs e)
	{
		await DisplayAlert("Clicked", "Button was clicked", "OK");
	}
}