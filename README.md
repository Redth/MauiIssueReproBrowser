# MauiIssueReproBrowser

## How to test with a specific MAUI PR

1. Clone the repo and checkout the PR branch
2. `dotnet tool restore`
3. `dotnet cake --target=VS --pack --sln="C:\path\to\MauiIssueReproBrowser\MauiReproBrowser.sln"`

## Adding a repro
1. Create a new folder inside the `MauiReproBrowser\Issues\` directory named with the corresponding github issue number
2. Add a new XAML file (eg: Issue12345.xaml)
3. Add the `[Issue(12345, "Title of issue")]` attribute to the root page class for the repro.
4. Add your repro code
