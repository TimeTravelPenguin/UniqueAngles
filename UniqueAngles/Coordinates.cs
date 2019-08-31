#region Title Header

// Name: Phillip Smith
// 
// Solution: UniqueAngles
// Project: UniqueAngles
// File Name: Coordinates.cs
// 
// Current Data:
// 2019-08-18 11:44 PM
// 
// Creation Date:
// 2019-08-17 4:14 PM

#endregion

using System;
using System.Linq;

namespace UniqueAngles
{
    internal class Coordinates
    {
        public int[] CoordinateValues { get; set; }

        public int[] UpperBounds { get; set; }

        public int[] LowerBounds { get; set; }

        public int Dimensions { get; }

        /// <summary>
        ///     Creates a collection of coordinates
        /// </summary>
        /// <param name="dimensions">The number of dimensions</param>
        /// <param name="lowerBounds">The inclusive lower bound value</param>
        /// <param name="upperBounds">The inclusive upper bound value</param>
        public Coordinates(int dimensions, int[] lowerBounds, int[] upperBounds)
        {
            Dimensions = dimensions;
            CoordinateValues = new int[dimensions];
            UpperBounds = upperBounds;
            LowerBounds = lowerBounds;

            // Check bounds
            for (var i = 0; i < dimensions; i++)
            {
                if (lowerBounds[i] > upperBounds[i])
                {
                    throw new Exception("lowerBound value cannot be larger than the upperBound value");
                }
            }

            // Check and assign values within bounds
            for (var i = 0; i < dimensions; i++)
            {
                CoordinateValues[i] = LowerBounds[i];
            }
        }

        /// <summary>
        ///     Creates a collection of coordinates
        /// </summary>
        /// <param name="coordinateValues">The coordinate values</param>
        /// <param name="lowerBounds">The inclusive lower bound value</param>
        /// <param name="upperBounds">The inclusive upper bound value</param>
        public Coordinates(int[] coordinateValues, int[] lowerBounds, int[] upperBounds)
        {
            CoordinateValues = coordinateValues;
            Dimensions = coordinateValues.Length;
            UpperBounds = upperBounds;
            LowerBounds = lowerBounds;

            // Check coordinates are within bounds
            for (var i = 0; i < Dimensions; i++)
            {
                if (CoordinateValues.Any(coordinateValue =>
                    coordinateValue < lowerBounds[Dimensions] || coordinateValue > upperBounds[Dimensions]))
                {
                    throw new Exception("The coordinateValues are not within the given bounds");
                }
            }
        }

        /// <summary>
        ///     Increments a coordinate in accordance to the given bounds
        /// </summary>
        /// <param name="index">The index of the coordinate to increment</param>
        public void Increment(int index)
        {
            // Add one to index value, then check if within bounds
            // If not, increment the next index's value, repeating this process

            if (index < 0 || index > Dimensions)
            {
                throw new Exception("The given index is invalid");
            }

            CoordinateValues[index]++;

            if (CoordinateValues[index] > UpperBounds[index])
            {
                CoordinateValues[index] = LowerBounds[index];
                Increment(index + 1);
            }
        }

        internal string StringValue()
        {
            var value = string.Empty;

            foreach (var val in CoordinateValues)
            {
                value += $"{val} ";
            }

            return value;
        }
    }
}