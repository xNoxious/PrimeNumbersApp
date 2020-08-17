using System;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using PrimeNumbers.API.Repositories;
using PrimeNumbers.API.Services;
using Xunit;

public class NumbersServiceFixture
{
    private Mock<IPrimeNumberCoupleRepository> m_RepositoryMock;

    public NumbersServiceFixture()
    {
        m_RepositoryMock = new Mock<IPrimeNumberCoupleRepository>();
    }

    [Theory]
    [InlineData(2)]
    [InlineData(17)]
    [InlineData(9419)]
    public void IsPrime_ReturnsTrue(int number)
    {
        var numbersService = new NumbersService(m_RepositoryMock.Object);

        var result = numbersService.IsNumberPrime(number);

        m_RepositoryMock.Verify(x => x.GetNextPrimeNumberViaDb(number), Times.Never);
        result.Should().Be(true);
    }

    [Theory]
    [InlineData(-5)]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(12)]
    [InlineData(9420)]
    public void IsPrime_ReturnsFalse(int number)
    {
        var numbersService = new NumbersService(m_RepositoryMock.Object);

        var result = numbersService.IsNumberPrime(number);

        m_RepositoryMock.Verify(x => x.GetNextPrimeNumberViaDb(number), Times.Never);
        result.Should().Be(false);
    }

    [Theory]
    [InlineData(-1, 2)]
    [InlineData(17, 19)]
    [InlineData(9419, 9421)]
    [InlineData(9420, 9421)]
    public void GetNextPrimeNumber_ReturnsNextPrimeNumber(int givenNumber, int returnedNumber)
    {
        var numbersService = new NumbersService(m_RepositoryMock.Object);

        var result = numbersService.GetNextPrimeNumber(givenNumber);

        m_RepositoryMock.Verify(x => x.GetNextPrimeNumberViaDb(givenNumber), Times.Never);
        result.Should().Be(returnedNumber);
    }

    [Fact]
    public async Task FetchNextPrimeNumberFromDb_GetsInvoked()
    {
        var numbersService = new NumbersService(m_RepositoryMock.Object);
        m_RepositoryMock.Setup(x => x.GetNextPrimeNumberViaDb(It.IsAny<int>()))
            .ReturnsAsync(It.IsAny<int>());

        var result = await numbersService.FetchNextPrimeNumberFromDb(It.IsAny<int>());

        m_RepositoryMock.Verify(x => x.GetNextPrimeNumberViaDb(It.IsAny<int>()), Times.Once);
    }
}