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
using System.Linq;

namespace UniqueAngles
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            #region User Input

            Console.Write("How many dimensions: ");
            var inputDimensionsString = Console.ReadLine();

            Console.Write(Environment.NewLine + "What is the coordinate upper bound value: ");
            var inputUpperBoundString = Console.ReadLine();

            Console.Write(Environment.NewLine + "What is the coordinate lower bound value: ");
            var inputLowerBoundString = Console.ReadLine();

            var inputDimensions = 0;
            var inputUpperBound = 0;
            var inputLowerBound = 0;
            var validInput = false;

            #endregion

            // Basic error handling
            try
            {
                inputDimensions = int.Parse(inputDimensionsString ?? throw new InvalidOperationException());
                inputUpperBound = int.Parse(inputUpperBoundString ?? throw new InvalidOperationException());
                inputLowerBound = int.Parse(inputLowerBoundString ?? throw new InvalidOperationException());

                validInput = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                if (validInput)
                {
                    Console.Clear();
                    Calculate(inputDimensions, inputUpperBound, inputLowerBound);
                }
            }

            Console.ReadKey(true);
        }

        /// <summary>
        ///     Calculated the number of points within a N-dimensioned region such that a line from the origin to the point
        ///     crosses no other points. The origin to the origin is an inclusive line.
        /// </summary>
        /// <param name="dimensions">The number of dimensions greater than zero that the integer-space resides</param>
        /// <param name="upperBound">The inclusive upper bound that any coordinate point can be</param>
        /// <param name="lowerBound">The inclusive lower bound that any coordinate point can be</param>
        private static void Calculate(int dimensions, int upperBound, int lowerBound = 0)
        {
            // Create n-dimensional array of (lowerBound, lowerBound, ...)
            var coords = new Coordinates(dimensions, lowerBound, upperBound);

            // DEMO CODE

            // Loop through all points within range lowerBound -> upperBound, inclusive
            /*
                    LOGIC
                    Add one to index-0 until > upperBound, then set to lowerBound, and +1 to index-1, etc
                    while all values are <= upperBound
             */

            var count = 0;

            while (true)
            {
                foreach (var coordsCoordinateValue in coords.CoordinateValues)
                {
                    Console.Write(coordsCoordinateValue + " ");
                }

                Console.WriteLine();

                coords.Increment(0);

                count++;

                if (coords.CoordinateValues.All(x => x >= coords.UpperBound))
                {
                    break;
                }
            }

            foreach (var coordsCoordinateValue in coords.CoordinateValues)
            {
                Console.Write(coordsCoordinateValue + " ");
            }

            Console.WriteLine($"\nDone! Count = {count}");
        }
    }
}