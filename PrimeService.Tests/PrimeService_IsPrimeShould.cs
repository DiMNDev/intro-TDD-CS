using Xunit;
using Prime.Services;
using FluentAssertions;

namespace Prime.UnitTests.Services
{
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
    public class PrimeService_IsAssertedFluently
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        public void PrimeService_IsPrimeShould(int value)
        {
            PrimeService Fluent_PrimeService = new PrimeService();

            Fluent_PrimeService.IsPrime(value).Should().Be(false).Should().NotBe(null);
        }
    }
}
