#  dotnetUtils
Utils for dotnet development.

##  Prerequisites
- .NET 8.0 or later versions

##  Create project an test structure

###  2024-12-07 11:42
Based on [Unit testing C# with NUnit and .NET Core](https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-nunit) and [# Organize your project to support both .NET Framework and .NET](https://learn.microsoft.com/en-us/dotnet/core/porting/project-structure)
- dotnet new sln
- md src
- cd src
- dotnet new classlib
- ren Class1.cs ListUtil.cs
- // write code for ListUtil.cs
- cd ..
- dotnet sln add src/src.csproj
- md tests
- cd tests
- dotnet new nunit
- dotnet add reference ../src/src.csproj
- cd ..
- dotnet sln add tests/tests.csproj
- cd tests
- ren UnitTest1.cs ListUtilTest.cs
- // write testcode for ListUtilTest.cs
- cd ..
- dotnet build test