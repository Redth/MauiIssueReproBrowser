namespace MauiReproBrowser;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class IssueAttribute : Attribute
{
	public IssueAttribute(int number, string title)
	{
		Number = number;
		Title = title;
	}

	public int Number { get; set; }
	public string Title { get; set; }

	public string Url => $"https://github.com/dotnet/maui/issues/{Number}";
}