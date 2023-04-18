namespace MauiReproBrowser.Issues._12103;

[Issue(12103, "Grid: [Windows] Auto Row definition does not fully visualise its elements")]
public partial class Index12103 : ContentPage
{
	public Index12103()
	{
		InitializeComponent();
	}

	private void Button_Clicked(object sender, EventArgs e)
	{
		Button button = (Button)sender;
		button.HeightRequest = button.HeightRequest == 100 ? 50 : 100;
	}
}