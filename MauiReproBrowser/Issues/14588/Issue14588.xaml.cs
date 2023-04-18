namespace MauiReproBrowser.Issues._14588;

[Issue(14588, "[regression/7.0.81] label created dynamically in code doesn't stretch like it should")]
public partial class Issue14588 : ContentPage
{
	public Issue14588()
	{
		InitializeComponent();

		CollectionView leveeAskedCollectionView = new CollectionView();
		//string bindPath = nameof(Joueurs) + $"[{i}].LeveeAsked";
		leveeAskedCollectionView.Background = Colors.Orange;
		leveeAskedCollectionView.ItemsSource = Items;
		//leveeAskedCollectionView.SetBinding(ItemsView.ItemsSourceProperty, ".");
		leveeAskedCollectionView.ItemTemplate = new DataTemplate(() =>
		{
			Label leveeAskedLabel = new Label();
			leveeAskedLabel.Background = Brush.Red;
			leveeAskedLabel.HorizontalTextAlignment = TextAlignment.Center;
			leveeAskedLabel.SetBinding(Label.TextProperty, ".");
			Grid.SetColumn(leveeAskedLabel, 0);
			return leveeAskedLabel;
		});

		grid.Add(leveeAskedCollectionView);
	}

	public List<string> Items = new List<string>
	{
		"First Label",
		"Second Label",
		"Third Label"
	};
}