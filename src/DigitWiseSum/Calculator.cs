namespace DigitWiseSum;

/// <summary>
/// This class contains the method to implement the digit wise sum
/// </summary>
public static class Calculator
{
  /// <summary>
  /// Computes the digit wise sum between an array of base 10 digits and a non negative integer number.
  /// </summary>
  /// <param name="left">An array of base 10 digits</param>
  /// <param name="right">A non negative integer number</param>
  /// <returns>
  /// An array of base 10 digits representing the sum of the provided parameters.
  /// </returns>
  public static uint[] Sum(uint[] left, uint right)
  {
    ArgumentNullException.ThrowIfNull(left);

    // Create a stack to write the digits composing the result.
    // Digits will be pushed from the least significative to the most significative.
    var digits = new Stack<uint>();

    // What remains to be added to left
    var remainder = right;

    // Iterate over the digits of left, from the least significative to the most significative
    for (int i = left.Length - 1; i >= 0; i--)
    {
      // take the i-th item inside the array
      var current = left[i];

      // compute the sum of i-th array item and remainder
      var sum = remainder + current;

      // compute the digit to be pushed to the stack
      var digit = sum % 10;
      digits.Push(digit);

      // compute the remainder still to be added
      remainder = sum / 10;
    }

    if (remainder > 0)
    {
      var digitsOfRemainder = remainder.ToDigitsArray();

      // digits of remainder must be pushed to the stack, from the least significative to the most significative
      for (int i = digitsOfRemainder.Length - 1; i >= 0; i--)
      {
        var current = digitsOfRemainder[i];
        digits.Push(current);
      }
    }

    // create the result array
    var result = new uint[digits.Count];

    // pop from the stack and fill the result array from the most significative digit to the least significative digit
    for (int i = 0; i < result.Length; i++)
    {
      result[i] = digits.Pop();
    }

    return result;
  }
}
