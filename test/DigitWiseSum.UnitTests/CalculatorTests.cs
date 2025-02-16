using FluentAssertions;
using static DigitWiseSum.Calculator;

namespace DigitWiseSum.UnitTests;

public sealed class CalculatorTests
{
  [Fact]
  public void Sum_Throws_ArgumentNullException_When_Left_Is_Null()
  {
    // ARRANGE
    const uint right = 5;

    // ACT
    var act = () => Sum(null!, right);

    // ASSERT
    act.Should().ThrowExactly<ArgumentNullException>().WithParameterName("left");
  }

  [Fact]
  public void Sum_Works_When_Right_Is_Zero()
  {
    // ARRANGE
    var left = new uint[] { 1, 2, 3 };
    const uint right = 0;

    // ACT
    var result = Sum(left, right);

    // ASSERT
    result.Should().NotBeNull();
    result.Should().Equal([1, 2, 3]);
  }

  [Fact]
  public void Sum_Works_When_Left_Is_Zero()
  {
    // ARRANGE
    var left = new uint[] { 0 };
    const uint right = 6;

    // ACT
    var result = Sum(left, right);

    // ASSERT
    result.Should().NotBeNull();
    result.Should().Equal([6]);
  }

  [Fact]
  public void Sum_Works_When_Only_Least_Significative_Digit_Of_Left_Is_Changed()
  {
    // ARRANGE
    var left = new uint[] { 1, 2, 3 };
    const uint right = 5;

    // ACT
    var result = Sum(left, right);

    // ASSERT
    result.Should().NotBeNull();
    result.Should().Equal([1, 2, 8]);
  }

  [Fact]
  public void Sum_Works_When_Last_Two_Digits_Of_Left_Are_Changed()
  {
    // ARRANGE
    var left = new uint[] { 1, 2, 3 };
    const uint right = 8;

    // ACT
    var result = Sum(left, right);

    // ASSERT
    result.Should().NotBeNull();
    result.Should().Equal([1, 3, 1]);
  }

  [Fact]
  public void Sum_Works_When_All_Digits_Of_Left_Are_Changed()
  {
    // ARRANGE
    var left = new uint[] { 1, 2, 3 };
    const uint right = 302;

    // ACT
    var result = Sum(left, right);

    // ASSERT
    result.Should().NotBeNull();
    result.Should().Equal([4, 2, 5]);
  }

  [Fact]
  public void Sum_Works_When_All_Digits_Of_Left_Are_Changed_And_There_Is_One_Digit_Remainder()
  {
    // ARRANGE
    var left = new uint[] { 1, 2, 3 };
    const uint right = 926;

    // ACT
    var result = Sum(left, right);

    // ASSERT
    result.Should().NotBeNull();
    result.Should().Equal([1, 0, 4, 9]);
  }

  [Fact]
  public void Sum_Works_When_All_Digits_Of_Left_Are_Changed_And_There_Is_Two_Digits_Remainder()
  {
    // ARRANGE
    var left = new uint[] { 1, 2, 3 };
    const uint right = 11233;

    // ACT
    var result = Sum(left, right);

    // ASSERT
    result.Should().NotBeNull();
    result.Should().Equal([1, 1, 3, 5, 6]);
  }

  [Fact]
  public void Sum_Works_When_All_Digits_Of_Left_Are_Changed_And_There_Is_Three_Digits_Remainder()
  {
    // ARRANGE
    var left = new uint[] { 1, 2, 3 };
    const uint right = 230600;

    // ACT
    var result = Sum(left, right);

    // ASSERT
    result.Should().NotBeNull();
    result.Should().Equal([2, 3, 0, 7, 2, 3]);
  }
}
