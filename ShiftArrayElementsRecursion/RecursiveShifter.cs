﻿using System;

namespace ShiftArrayElements
{
    public static class RecursiveShifter
    {
        /// <summary>
        /// Shifts elements in a <see cref="source"/> array using <see cref="iterations"/> array for getting directions and iterations (odd elements - left direction, even elements - right direction).
        /// </summary>
        /// <param name="source">A source array.</param>
        /// <param name="iterations">An array with iterations. Odd numbers are for left direction, and even numbers are for right direction.</param>
        /// <returns>An array with shifted elements.</returns>
        /// <exception cref="ArgumentNullException">Source string is null.</exception>
        /// <exception cref="ArgumentException">Number of iterations less than 0.</exception>
        public static int[] Shift(int[] source, int[] iterations)
        {
            // TODO #2. Implement the method using recursive local functions and indexers only (don't use Array.Copy method here).
            throw new NotImplementedException();
        }
    }
}