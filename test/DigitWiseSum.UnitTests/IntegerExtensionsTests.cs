using FluentAssertions;

namespace DigitWiseSum.UnitTests;

public sealed class IntegerExtensionsTests
{
  [Fact]
  public void ToDigitsArray_Works_With_One_Digit_Integers()
  {
    // ARRANGE
    const uint value = 5u;

    // ACT
    var result = value.ToDigitsArray();

    // ASSERT
    result.Should().NotBeNull();
    result.Should().Equal([5u]);
  }

  [Fact]
  public void ToDigitsArray_Works_With_Two_Digits_Integers()
  {
    // ARRANGE
    const uint value = 34u;

    // ACT
    var result = value.ToDigitsArray();

    // ASSERT
    result.Should().NotBeNull();
    result.Should().Equal([3u, 4u]);
  }

  [Fact]
  public void ToDigitsArray_Works_With_Three_Digits_Integers()
  {
    // ARRANGE
    const uint value = 239u;

    // ACT
    var result = value.ToDigitsArray();

    // ASSERT
    result.Should().NotBeNull();
    result.Should().Equal([2u, 3u, 9u]);
  }

  [Fact]
  public void ToDigitsArray_Works_With_Four_Digits_Integers()
  {
    // ARRANGE
    const uint value = 1231u;

    // ACT
    var result = value.ToDigitsArray();

    // ASSERT
    result.Should().NotBeNull();
    result.Should().Equal([1u, 2u, 3u, 1u]);
  }

  [Fact]
  public void ToDigitsArray_Works_With_Zero_As_Input()
  {
    // ARRANGE
    const uint value = 0u;

    // ACT
    var result = value.ToDigitsArray();

    // ASSERT
    result.Should().NotBeNull();
    result.Should().Equal([0u]);
  }

  [Fact]
  public void ToDigitsArray_Works_With_Power_Of_Ten_As_Input()
  {
    // ARRANGE
    const uint value = 1000u;

    // ACT
    var result = value.ToDigitsArray();

    // ASSERT
    result.Should().NotBeNull();
    result.Should().Equal([1u, 0u, 0u, 0u]);
  }
}