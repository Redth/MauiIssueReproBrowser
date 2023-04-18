namespace MauiReproBrowser.Issues._14522;

[Issue(14522, "[regression/7.0.81] 7.0.81 Service Release 4 breaks CascadeInputTransparency")]
public partial class Issue14522 : ContentPage
{
	public Issue14522()
	{
		InitializeComponent();
	}

	private async void Button_Clicked(object sender, EventArgs e)
	{
		await DisplayAlert("Clicked", "Button was clicked", "OK");
	}
}