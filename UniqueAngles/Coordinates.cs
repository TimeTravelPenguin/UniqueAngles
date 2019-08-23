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

        public int UpperBound { get; set; }

        public int LowerBound { get; set; }

        public int Dimensions { get; }

        /// <summary>
        ///     Creates a collection of coordinates
        /// </summary>
        /// <param name="dimensions">The number of dimensions</param>
        /// <param name="lowerBound">The inclusive lower bound value</param>
        /// <param name="upperBound">The inclusive upper bound value</param>
        public Coordinates(int dimensions, int lowerBound, int upperBound)
        {
            Dimensions = dimensions;
            CoordinateValues = new int[dimensions];
            UpperBound = upperBound;
            LowerBound = lowerBound;

            // Check bounds
            if (lowerBound > upperBound)
            {
                throw new Exception("lowerBound value cannot be larger than the upperBound value");
            }

            // Check and assign values within bounds
            for (var i = 0; i < dimensions; i++)
            {
                CoordinateValues[i] = LowerBound;
            }
        }

        /// <summary>
        ///     Creates a collection of coordinates
        /// </summary>
        /// <param name="coordinateValues">The coordinate values</param>
        /// <param name="lowerBound">The inclusive lower bound value</param>
        /// <param name="upperBound">The inclusive upper bound value</param>
        public Coordinates(int[] coordinateValues, int lowerBound, int upperBound)
        {
            CoordinateValues = coordinateValues;
            Dimensions = coordinateValues.Length;
            UpperBound = upperBound;
            LowerBound = lowerBound;

            // Check coordinates are within bounds
            if (CoordinateValues.Any(coordinateValue => coordinateValue < lowerBound || coordinateValue > upperBound))
            {
                throw new Exception("The coordinateValues are not within the given bounds");
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

            if (CoordinateValues[index] > UpperBound)
            {
                CoordinateValues[index] = LowerBound;
                Increment(index + 1);
            }
        }
    }
}