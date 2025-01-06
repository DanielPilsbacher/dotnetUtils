#  dotnetUtils
## Utils for dotnet development
This project might be helpfull for C# developers who run into similar problems and solution problems as the developer of this project do.

##  Prerequisites
- .NET 8.0 or later versions

## Clone repo
```
git clone https://github.com/DanielPilsbacher/dotnetUtils.git
```

## Build project and run the Testcode
Build the project with .NET command `dotnet build`.
```
PS C:\Users\devop\repo\dotnetUtils> dotnet build
```
```
  Determining projects to restore...
  Restored D:\repos\dotnetUtils\src\DotnetUtils.csproj (in 50 ms).
  Restored D:\repos\dotnetUtils\tests\DotnetUtils.Tests.csproj (in 576 ms).
  DotnetUtils -> D:\repos\dotnetUtils\src\bin\Debug\net8.0\DotnetUtils.dll
  DotnetUtils.Tests -> D:\repos\dotnetUtils\tests\bin\Debug\net8.0\DotnetUtils.Tests.dll

Build succeeded.
    0 Warning(s)
    0 Error(s)
```
If the build succeeds the tests can be run with `dotnet test`.
```
PS C:\Users\devop\repo\dotnetUtils> dotnet test
```
```
  Determining projects to restore...
  All projects are up-to-date for restore.
  DotnetUtils -> D:\repos\dotnetUtils\src\bin\Debug\net8.0\DotnetUtils.dll
  DotnetUtils.Tests -> D:\repos\dotnetUtils\tests\bin\Debug\net8.0\DotnetUtils.Tests.dll
Test run for D:\repos\dotnetUtils\tests\bin\Debug\net8.0\DotnetUtils.Tests.dll (.NETCoreApp,Version=v8.0)
VSTest version 17.11.1 (x64)

Starting test execution, please wait...
A total of 1 test files matched the specified pattern.

Passed!  - Failed:     0, Passed:     3, Skipped:     0, Total:     3, Duration: 12 ms - DotnetUtils.Tests.dll (net8.0)
```
If the tests are passing all is set up to use.

##  Create project and test structure
###  LOG entry 2024-12-07 11:42
Based on [Unit testing C# with NUnit and .NET Core](https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-nunit) and [Organize your project to support both .NET Framework and .NET](https://learn.microsoft.com/en-us/dotnet/core/porting/project-structure) the project is created:

```
dotnet new sln
md src
cd src
dotnet new classlib
ren Class1.cs ListUtil.cs
# write code for ListUtil.cs
cd ..
dotnet sln add src/DotnetUtils.csproj
md tests
cd tests
# add NUnit framework to project
dotnet new nunit
dotnet add reference ../src/DotnetUtils.csproj
cd ..
dotnet sln add tests/DotnetUtils.Tests.csproj
cd tests
ren UnitTest1.cs ListUtilTest.cs
# write testcode for ListUtilTest.cs
cd ..
```

## Changes
###  LOG entry 2025-01-06 13:57

Add DictionaryUtil and StringUtil.