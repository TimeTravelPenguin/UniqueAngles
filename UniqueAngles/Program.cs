#region Title Header

// Name: Phillip Smith
// 
// Solution: UniqueAngles
// Project: UniqueAngles
// File Name: Program.cs
// 
// Current Data:
// 2019-08-18 11:44 PM
// 
// Creation Date:
// 2019-08-17 3:52 PM

#endregion

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace UniqueAngles
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var inputDimensions = 4;
            int[] inputUpperBound = {50, 116, 154, 65};
            int[] inputLowerBound = {30, 4, 8, 0};

            Calculate(inputDimensions, inputUpperBound, inputLowerBound);

            Console.ReadKey(true);
        }

        /// <summary>
        ///     Calculated the number of points within a N-dimensioned region such that a line from the origin to the point
        ///     crosses no other points. The origin to the origin is an inclusive line.
        /// </summary>
        /// <param name="dimensions">The number of dimensions greater than zero that the integer-space resides</param>
        /// <param name="upperBounds">The inclusive upper bounds that any coordinate point can be</param>
        /// <param name="lowerBounds">The inclusive lower bounds that any coordinate point can be</param>
        private static void Calculate(int dimensions, int[] upperBounds, int[] lowerBounds)
        {
            // Create n-dimensional array of (lowerBound, lowerBound, ...)
            var coords = new Coordinates(dimensions, lowerBounds, upperBounds);

            // DEMO CODE

            // Loop through all points within range lowerBound -> upperBound, inclusive
            /*
                    LOGIC
                    Add one to index-0 until > upperBound, then set to lowerBound, and +1 to index-1, etc
                    while all values are <= upperBound
             */

            var stopwatch = Stopwatch.StartNew();

            var combs = new List<string> {coords.StringValue()};
            var count = 1; // inclusive of the origin 

            var limit = 1;
            for (var i = 0; i < coords.Dimensions; i++)
            {
                limit *= coords.UpperBounds[i] - coords.LowerBounds[i] + 1;
            }

            for (var i = 0; i < limit - 1; i++)
            {
                //foreach (var coordsCoordinateValue in coords.CoordinateValues)
                //{
                //    Console.Write(coordsCoordinateValue + " ");
                //}

                //Console.WriteLine();

                coords.Increment(0);

                //combs.Add(coords.StringValue());
                count++;
            }

            stopwatch.Stop();

            //foreach (var coordsCoordinateValue in coords.CoordinateValues)
            //{
            //    Console.Write(coordsCoordinateValue + " ");
            //}

            Console.WriteLine(
                $"\nDone! Count = {count} ({combs.Count}) in {stopwatch.ElapsedMilliseconds} milliseconds");
        }
    }
}