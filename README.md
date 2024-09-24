##### [Unit Testing with xUnit](https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-dotnet-test)

### Solution Setup

`dotnet new sln -o unit-testing-using-dotnet-test`
-The dotnet new sln command creates a new solution in the unit-testing-using-dotnet-test directory.

`cd unit-testing-using-dotnet-test`
-Change directory into project folder

`dotnet new classlib -o PrimeService`
-The dotnet new classlib command creates a new class library project in the PrimeService folder. The new class library will contain the code to be tested.

```C#
//PrimeService.cs
using System;

namespace Prime.Services
{
    public class PrimeService
    {
        public bool IsPrime(int candidate)
        {
            throw new NotImplementedException("Not implemented.");
        }
    }
}
```

-Rename Class1.cs to PrimeService.cs, replace with code above.

`dotnet sln add ./PrimeService/PrimeService.csproj`
-In the unit-testing-using-dotnet-test directory, run the following command to add the class library project to the solution

`dotnet new xunit -o PrimeService.Tests`
The preceding command:

- Creates the PrimeService.Tests project in the PrimeService.Tests directory. The test project uses xUnit as the test library.
- Configures the test runner by adding the following `<PackageReference />` elements to the project file:
  - `Microsoft.NET.Test.Sdk`
  - `xunit`
  - `xunit.runner.visualstudio`
  - `coverlet.collector`

`dotnet sln add ./PrimeService.Tests/PrimeService.Tests.csproj`
-Add the test project to the solution file

`dotnet add ./PrimeService.Tests/PrimeService.Tests.csproj reference ./PrimeService/PrimeService.csproj`
-Add the PrimeService class library as a dependency to the PrimeService.Tests project

### Create a test

- Delete PrimeService.Tests/UnitTest1.cs.
- Create a PrimeService.Tests/PrimeService_IsPrimeShould.cs file.
- Replace the code in PrimeService_IsPrimeShould.cs with the following code:

```C#
using Xunit;
using Prime.Services;

namespace Prime.UnitTests.Services
{
    public class PrimeService_IsPrimeShould
    {
        [Fact]
        public void IsPrime_InputIs1_ReturnFalse()
        {
            var primeService = new PrimeService();
            bool result = primeService.IsPrime(1);

            Assert.False(result, "1 should not be prime");
        }
    }
}
```

- run `dotnet test` to build and run the test/s

  - The test will fail. Writing failing tests is a standard practice in TDD _Test Driven Development_. Write tests that fail, then write production code that makes the test pass.

- Update the test with the following working code:

```C#
public bool IsPrime(int candidate)
{
    if (candidate == 1)
    {
        return false;
    }
    throw new NotImplementedException("Not fully implemented.");
}
```

- Run `dotnet test` again. The test should now pass.

### Add more tests

When writing code, it is best to not repeat ourselves for various reasons. We can replace our original test to _assert_ other cases.

- Replace the previous class code with the following

```C#
public class PrimeService_IsPrimeShould
    {
        private readonly PrimeService _primeService;

        public PrimeService_IsPrimeShould()
        {
            _primeService = new PrimeService();
        }
        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        public void IsPrime_ValuesLessThan2_ReturnFalse(int value)
        {
            var result = _primeService.IsPrime(value);

            Assert.False(result, $"{value} should not be prime");
        }
    }
```

- To make the tests pass, replace the `IsPrime()` method code with the following:

```C#
public bool IsPrime(int candidate)
{
    if (candidate < 2)
    {
        return false;
    }
    throw new NotImplementedException("Not fully implemented.");
}
```

### Add additional packages (FluentAssertions Package)

- Ensure you are in the directory with `.csproj`
- Run `dotnet add package FluentAssertions`
