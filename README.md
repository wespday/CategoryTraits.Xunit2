# CategoryTraits.Xunit2 [![Build status](https://ci.appveyor.com/api/projects/status/npw7t6hr74g0mur5/branch/master?svg=true)](https://ci.appveyor.com/project/wespday/categorytraits-xunit2/branch/master)

UnitTest and IntegrationTest attributes etc... for xUnit 2

## Usage
Install the [`CategoryTraits.Xunit2`](https://www.nuget.org/packages/CategoryTraits.Xunit2/) NuGet package using the Visual Studio NuGet Package Manager

```csharp
    using CategoryTraits.Xunit2;
    ...
        [Fact]
        [UnitTest]
        public void MyXunitTest(...)
```        
## Why?
This is an alternative to using the built in xUnit **[Trait ("Category", "Unit")]** attribute.
Fewer chances for typos etc...
Previously in xUnit you could just subclass TraitAttribute but that class is now sealed.

See: https://github.com/xunit/xunit/issues/394

## Where is my SlowTest, Milestone3Test, attribute etc...?
You can easily make your own custom attributes by adding a class inheriting from **CategoryTraitAttribute** in your project:
```csharp
    public class MyVeryOwnTestAttribute : CategoryTraitAttribute
    { 
        public MyVeryOwnTestAttribute()
            : base("MyVeryOwn")
        {
        }
    }
 ```
 
## Building from Source?
 Reqiures Visual Studio 2015.
 Run the **build.cmd** batch file.

