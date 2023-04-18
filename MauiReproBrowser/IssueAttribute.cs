using System.Text;

namespace MauiReproBrowser;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class IssueAttribute : Attribute
{
	public IssueAttribute(int number, string title, IssuePlatform platforms = IssuePlatform.All)
	{
		Number = number;
		Title = title;
		Platforms = platforms;
	}

	public int Number { get; set; }
	public string Title { get; set; }
	public IssuePlatform Platforms { get; set; }

	public string Url => $"https://github.com/dotnet/maui/issues/{Number}";

	public string IssuePlatforms
	{
		get
		{
			if (Platforms.HasFlag(IssuePlatform.All))
				return "Windows, Android, iOS, MacCatalyst";


			var platforms = new List<string>();
			if (OperatingSystem.IsWindows() && Platforms.HasFlag(IssuePlatform.Windows))
				platforms.Add("Windows");

			if (OperatingSystem.IsAndroid() && Platforms.HasFlag(IssuePlatform.Android))
				platforms.Add("Android");

			if (OperatingSystem.IsIOS() && Platforms.HasFlag(IssuePlatform.iOS))
				platforms.Add("iOS");

			if (OperatingSystem.IsMacCatalyst() && Platforms.HasFlag(IssuePlatform.MacCatalyst))
				platforms.Add("MacCatalyst");

			return string.Join(", ", platforms);
		}
	}

	public bool IsCompatibleWithRunningPlatform()
	{
		if (Platforms.HasFlag(IssuePlatform.All))
			return true;

		if (OperatingSystem.IsWindows() && Platforms.HasFlag(IssuePlatform.Windows))
			return true;

		if (OperatingSystem.IsAndroid() && Platforms.HasFlag(IssuePlatform.Android))
			return true;

		if (OperatingSystem.IsMacCatalyst() && Platforms.HasFlag(IssuePlatform.MacCatalyst))
			return true;

		if (OperatingSystem.IsIOS() && Platforms.HasFlag(IssuePlatform.iOS))
			return true;

		return false;
	}
}

[Flags]
public enum IssuePlatform
{
	All = 1,
	Android = 2,
	iOS = 4,
	MacCatalyst = 8,
	Windows = 16,
}