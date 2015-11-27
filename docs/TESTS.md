## Running Tests

### Windows
After installing Visual Studio Express for Windows Desktop and the F# tools run Visual Studio and it will display a start screen.

Click on "New Project" and you should see an entry for Visual F# and click on "Class Library".

![New Project](http://x.exercism.io/v3/tracks/fsharp/docs/img/newProject.png)

Install [NUnit](http://nunit.org/index.php?p=download) via NuGet package manager with the NUnit.Runners package. This will add the reference to the project.

![NuGet Package Manager](http://x.exercism.io/v3/tracks/fsharp/docs/img/manageNugetPackages.png)

![Installing NUnit](http://x.exercism.io/v3/tracks/fsharp/docs/img/installingNunit.png)

Drag and drop the test file of your chosen exercise into the project in Visual Studio. You can create your own Example file (or drag and drop the one included) and give the exercise a try.

Compile the project (Build -> Build Solution or F7) to generate the DLL file.

If you installed the NUnit runner through NuGet, the runner will be located in the ```\packages\NUnit.Runners(version number)\tools``` folder where your project is.

If you installed NUnit manually the runner will be in the ```Program Files (x86)\NUnit(version number)\bin``` folder.

Once you have been able to compile the code it will create a DLL in the ```\bin\Debug``` folder of your project. In the NUnit runner, select "Open Project" and select the DLL that was created from compiling. This will load all the tests and allow you to run them.

Now you can have fun learning F# and run your code against the tests!

### Mac
Xamarin Studio also ships with NUnit. From the new project dialog, just select an NUnit class library.

![Xamarin NUnit](http://x.exercism.io/v3/tracks/fsharp/docs/img/xamarin-fsharp-nunit.jpeg)

From here you can write NUnit tests right away. To run the tests open the `Unit Tests` pad within
Xamarin (View -> Pads -> Unit Tests).
