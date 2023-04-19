using System.ComponentModel;
using System.Windows.Input;

namespace MauiReproBrowser.Issues._14562;

[Issue(14562, "Entry Layout broken after Update .NET MAUI to 7.0.81 (2nd Repro in commments)")]
public partial class Issue14562B : ContentPage
{
	public Issue14562B()
	{
		InitializeComponent();

		BindingContext = viewModel = new ViewModel();
	}

	ViewModel viewModel;
}

public class ViewModel : ViewModelBase
{
	public bool IsUpperLimitActive { get; set; }

	public bool IsLowerLimitActive { get; set; }

	public string UpperLimitValue { get; set; } = "There's no limit";

	public string LowerLimitValue { get; set; } = "Friends in low places";

	public ICommand MakeVisibleCommand => new Command(() =>
	{
		IsUpperLimitActive = true;
		IsLowerLimitActive = true;
		NotifyPropertyChanged(nameof(IsUpperLimitActive));
		NotifyPropertyChanged(nameof(IsLowerLimitActive));
	});
}