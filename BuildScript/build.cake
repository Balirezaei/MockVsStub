var solutionPath = Argument("SolutionPath", "../MockVsStub.sln");
var unitTestProjects = GetFiles("../**/*Tests.csproj");

Task("Clean")
    .Does(()=>{


DotNetCoreClean(solutionPath);
    //   foreach(var project in allProjects) {
    //       DotNetCoreClean(project.FullPath);
    //   }
});






Task("Build")
    .Does(()=>
    {
        DotNetCoreBuild(solutionPath);
        // foreach(var project in allProjects) {
        //     DotNetCoreBuild(project.FullPath);
        // }
    });


Task("Run-Unit-Tests")
    .Does(() =>
    {
        foreach(var file in unitTestProjects) {
            DotNetCoreTest(file.FullPath);
        }
});




  Task("Default")
    .IsDependentOn("Clean")
    .IsDependentOn("Run-Unit-Tests")
    ;

RunTarget("Default");  