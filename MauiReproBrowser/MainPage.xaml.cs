using System.Reflection;

namespace MauiReproBrowser;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();

		BindingContext = new MainViewModel();
	}

	private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
	{
		var url = (sender as Label)?.Text;

		if (!string.IsNullOrEmpty(url))
			await Browser.OpenAsync(url);
	}

	private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		if (e.CurrentSelection.FirstOrDefault() is IssuePageInfo issue)
		{
			Navigation.PushAsync((Page)Activator.CreateInstance(issue.Type));
		}


		var cv = sender as CollectionView;
		if (cv is not null)
			cv.SelectedItem = null;
	}
}

public class MainViewModel
{
	public MainViewModel()
	{
		Issues = this.GetType().Assembly.GetTypes()
			.Where(t => t.IsAssignableTo(typeof(Page)))
			.Select(t => new IssuePageInfo(t, t.GetCustomAttribute<IssueAttribute>()))
			.Where(t => t.Issue is not null).ToList();
	}

	public List<IssuePageInfo> Issues { get; set; } = new List<IssuePageInfo>();
}

public record IssuePageInfo(Type Type, IssueAttribute Issue);
