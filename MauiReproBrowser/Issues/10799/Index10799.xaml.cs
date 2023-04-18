using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace MauiReproBrowser.Issues._10799;

[Issue(10799, "WinUI Dynamic height in grid does not work when nothing else changes")]
public partial class Index10799 : ContentPage
{
	int count = 0;

	public Index10799()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);

		//Work around for button missing for some reason when the boxview is enlarged
		var vm = BindingContext as MainPageVM;
		vm?.ChangeHeightOfBoxViewCmd?.Execute(null);

	}
}
public class BindableBase : INotifyPropertyChanged
{
	public event PropertyChangedEventHandler PropertyChanged;

	protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] String propertyName = null)
	{
		if (Equals(storage, value))
		{
			return false;
		}

		storage = value;
		OnPropertyChanged(propertyName);
		return true;
	}

	protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
	{
		PropertyChangedEventHandler eventHandler = this.PropertyChanged;
		if (eventHandler != null)
		{
			eventHandler(this, new PropertyChangedEventArgs(propertyName));
			var now = DateTime.Now;
			//Logger.WriteLine($"BindableBase.OnPropertyChanged: VM:{TypeDescriptor.GetClassName(this)}, propertyName:{propertyName}, timestamp{now.ToString("hh:mm:ss")}");
		}
	}
}

public class MainPageVM : BindableBase
{
	public ICommand ChangeHeightOfBoxViewCmd { get; set; }

	private double _boxHeight = 200d;
	public double BoxHeight
	{
		get => _boxHeight;
		set => SetProperty(ref _boxHeight, value);
	}

	public MainPageVM()
	{
		ChangeHeightOfBoxViewCmd = new Command(() =>
		{
			BoxHeight = BoxHeight >= 200d ? 30d : 200d;
			System.Diagnostics.Debug.WriteLine($"Height of box changed to {BoxHeight}");
		});
	}
}