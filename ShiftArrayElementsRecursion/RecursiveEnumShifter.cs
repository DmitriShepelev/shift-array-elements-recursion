using System;

namespace ShiftArrayElements
{
    public static class RecursiveEnumShifter
    {
        /// <summary>
        /// Shifts elements in a <see cref="source"/> array using directions from <see cref="directions"/> array, one element shift per each direction array element.
        /// </summary>
        /// <param name="source">A source array.</param>
        /// <param name="directions">An array with directions.</param>
        /// <returns>An array with shifted elements.</returns>
        /// <exception cref="ArgumentNullException">source array is null.</exception>
        /// <exception cref="ArgumentNullException">directions array is null.</exception>
        /// <exception cref="InvalidOperationException">direction array contains an element that is not <see cref="Direction.Left"/> or <see cref="Direction.Right"/>.</exception>
        public static int[] Shift(int[] source, Direction[] directions)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (directions is null)
            {
                throw new ArgumentNullException(nameof(directions));
            }

            if (directions.Length == 0)
            {
                return source;
            }

            if (directions[0] == Direction.Left)
            {
                LeftShift(source, source[1..], source[0]);
            }
            else if (directions[0] == Direction.Right)
            {
                RightShift(source, source[..^1], source[^1]);
            }
            else
            {
                throw new InvalidOperationException($"Incorrect {directions[0]} enum value.");
            }

            return Shift(source, directions[1..]);

            // #1. Implement the method using recursive local functions and Array.Copy method.
            void LeftShift(int[] destination, int[] shiftRange, int firstElement)
            {
                destination[^1] = firstElement;
                Array.Copy(shiftRange, destination, destination.Length - 1);
            }

            void RightShift(int[] destination, int[] shiftRange, int lastElement)
            {
                destination[0] = lastElement;
                Array.Copy(shiftRange, 0, destination, 1, destination.Length - 1);
            }
        }
    }
}
