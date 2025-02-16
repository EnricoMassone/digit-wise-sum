namespace DigitWiseSum;

/// <summary>
/// This class contains extension methods for integral types.
/// </summary>
public static class IntegerExtensions
{
  /// <summary>
  /// This method splits a non negative integer into its base 10 digits and returns the array
  /// containing the digits, ordered from the most significative one to the least significative one.
  /// </summary>
  /// <param name="value">
  /// A non negative integer value that must be splitted into its base 10 digits.
  /// </param>
  /// <returns>
  /// The array containing the base 10 digits of the input number, ordered from the
  /// most significative one to the least significative one.
  /// </returns>
  public static uint[] ToDigitsArray(this uint value)
  {
    // find the smallest power of ten which is greater than value
    var numberOfDigits = 1;

    while (Math.Pow(10, numberOfDigits) <= value)
    {
      // keep looking
      numberOfDigits++;
    }

    var result = new uint[numberOfDigits];

    var exponent = numberOfDigits - 1; // this is the greatest power of 10 which is less than or equal to value
    var remainder = value;

    for (var i = 0; i < numberOfDigits; i++)
    {
      var powerOfTen = (uint)Math.Pow(10, exponent);

      var digit = remainder / powerOfTen; // this is the i-th element of the result array
      remainder = remainder % powerOfTen; // this is what remains out of the input value, still to be splitted in base-10 digits.

      result[i] = digit;

      exponent--;
    }

    return result;
  }
}
