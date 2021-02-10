using System;

namespace ShiftArrayElements
{
    public static class RecursiveShifter
    {
        /// <summary>
        /// Shifts elements in a <see cref="source"/> array using <see cref="iterations"/> array for getting directions and iterations (odd elements - left direction, even elements - right direction).
        /// </summary>
        /// <param name="source">A source array.</param>
        /// <param name="iterations">An array with iterations.</param>
        /// <returns>An array with shifted elements.</returns>
        /// <exception cref="ArgumentNullException">source array is null.</exception>
        /// <exception cref="ArgumentNullException">iterations array is null.</exception>
        public static int[] Shift(int[] source, int[] iterations)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (iterations is null)
            {
                throw new ArgumentNullException(nameof(iterations));
            }

            bool predicate = true;

            // If the predicate is true, then the array is shifted to the left, if false, then to the right.
            ShiftByPredicate(source, iterations, predicate);
            void ShiftByPredicate(int[] source, int[] iterations, bool predicate)
            {
                if (iterations.Length == 0 || source.Length == 0)
                {
                    return;
                }

                int count = iterations[0] % source.Length;

                if (predicate)
                {
                    LeftShift(source, source[1..], source[0], count);
                }
                else
                {
                    RightShift(source, source[..^1], source[^1], count);
                }

                ShiftByPredicate(source, iterations[1..], !predicate);
            }

            return source;

            // #2. Implement the method using recursive local functions and indexers only (don't use Array.Copy method here).
            void LeftShift(int[] destination, int[] shiftRange, int firstElement, int count)
            {
                if (count > 0)
                {
                    destination[^1] = firstElement;
                    Array.Copy(shiftRange, destination, destination.Length - 1);
                    LeftShift(destination, destination[1..], destination[0], count - 1);
                }
            }

            void RightShift(int[] destination, int[] shiftRange, int lastElement, int count)
            {
                if (count > 0)
                {
                    destination[0] = lastElement;
                    Array.Copy(shiftRange, 0, destination, 1, destination.Length - 1);
                    RightShift(destination, destination[..^1], destination[^1], count - 1);
                }
            }
        }
    }
}
