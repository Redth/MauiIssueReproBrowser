namespace MauiReproBrowser.Issues._14624;

[Issue(14624, "[regression/7.0.81] ScrollView content with Buttons rendered offscreen do not respond on iOS")]
public partial class Issue14624 : ContentPage
{
	public Issue14624()
	{
		InitializeComponent();

		for (int i = 0; i < 30; i++)
		{
			var btn = new Button { Text = $"Button {i}" };
            btn.Clicked += Btn_Clicked;
			stack.Add(btn);
		}
	}

    async void Btn_Clicked(object sender, EventArgs e)
    {
		var btn = sender as Button;

		if (btn is null)
			return;

		await DisplayAlert("Clicked", $"{btn.Text} clicked", "OK");
    }
}
