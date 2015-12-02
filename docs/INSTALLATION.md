#### Mac

Install [Xamarin Studio](http://xamarin.com/download).

While Xamarin is most known for creating iOS and Android applications, it's still a perfect IDE to create F# console
or library projects which is all that's needed for Exercism.

Once installed and running, click on new solution and you'll find the library project to select. Don't forget to click the
lanugage drop down to select F# since it defaults to C#.

![Xamarin New Project](http://x.exercism.io/v3/tracks/fsharp/docs/img/xamarin-fsharp.jpg)

#### Linux
The [F# Foundation](http://fsharp.org/) has detailed instructions on different options to install F# on [Linux](http://fsharp.org/use/linux/).

#### In Browser
You can also create and share F# scripts in your browser at [Try F#](http://www.tryfsharp.org/Create). Silverlight plugin is required.

Can also try it out at [.NET Fiddle](https://dotnetfiddle.net/) which has the option of letting you bring in [NuGet](https://www.nuget.org/) packages.

#### Windows
Install [Visual Studio Express for Windows Desktop](http://www.visualstudio.com/downloads/download-visual-studio-vs#d-express-windows-desktop).

Install the [F# tools for Visual Studio](http://www.microsoft.com/en-us/download/details.aspx?id=41654).

You can either start by creating your own project for working with the Exercism problems or if you have a **paid version** of Visual Studio you can download a Visual Studio solution that is already set up to work on the problems in as many languages as Visual Studio supports.

![Solution Explorer](/img/setup/visualstudio/SolutionExplorer.png)

The following instructions are for using the Visual Studio template with a **paid version** of Visual Studio.

By default, Visual Studio does not allow you to organize F# files by folder. This is a problem because Exercism fetches the exercises to sub-folders. To get around this, install the Visual [F# Power Tools extension](http://fsprojects.github.io/VisualFSharpPowerTools/) which enables folder organization and makes writing F# code much easier in Visual Studio.

1. Download the [Exercism.io Visual Studio Template](https://github.com/rprouse/Exercism.VisualStudio) from GitHub by clicking the Download Zip button on the page.
2. Unzip the template into your exercises directory, for example `C:\src\exercises`
2. Install the [Exercism CLI](http://help.exercism.io/installing-the-cli.html)
3. Open a command prompt to your exercise directory
4. Add your API key to exercism `exercism configure --key=YOUR_API_KEY`
5. Configure your source directory in exercism `exercism configure --dir=C:\src\exercises`
6. [Fetch your first exercise](http://help.exercism.io/fetching-exercises.html) `exercism fetch fsharp`
7. Open the Exercism solution in Visual Studio
8. Expand the Exercism.FSharp project
9. Right click on the project and select **F# Power Tools | New Folder**. Enter the name for the **existing** exercise folder.
10. Right click on the folder and select **Add | Existing item...** and select the problem files in the folder.
11. Get coding...

The NUnit NuGet package is included in the project, so you will not need to install it.

Install the [NUnit Visual Studio Test Adapter](https://visualstudiogallery.msdn.microsoft.com/6ab922d0-21c0-4f06-ab5f-4ecd1fe7175d). This will allow you to run the tests from within Visual Studio. If you have ReSharper installed, you can also [run the tests using ReSharper](https://www.jetbrains.com/resharper/features/unit_testing.html).

![Test Explorer](/img/setup/visualstudio/TestExplorer.png)

You can also run the tests from the command line by installing [NUnit 2.6.3](http://www.nunit.org/). See the instructions for C#.

