namespace MauiReproBrowser.Issues._11453;

[Issue(11453, "VerticalStackLayout does not trigger parent Grid resize properly when children are added")]
public partial class Index11453 : ContentPage
{
	public Index11453()
	{
		InitializeComponent();
	}

	private void AddLabel_Clicked(object sender, EventArgs e)
	{
		Label label = new() { Text = $"{Guid.NewGuid()}" };
		StackLayout.Add(label);
	}

	private void InvalidateMeasure_Clicked(object sender, EventArgs e)
	{
		this.InvalidateMeasure();
	}
}