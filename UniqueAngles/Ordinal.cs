#region Title Header

// Name: Phillip Smith
// 
// Solution: UniqueAngles
// Project: UniqueAngles
// File Name: Ordinal.cs
// 
// Current Data:
// 2019-08-17 4:31 PM
// 
// Creation Date:
// 2019-08-17 4:04 PM

#endregion

namespace UniqueAngles
{
    public static class Ordinal
    {
        /// <summary>
        ///     Converts an int value to it's ordinal form (1st, 2nd, 3rd, 4th, ...)
        /// </summary>
        /// <param name="num">Int value greater than zero</param>
        /// <returns>String value of the ordinalized form</returns>
        public static string AddOrdinal(this int num)
        {
            if (num < 0)
            {
                return num.ToString();
            }

            switch (num % 100)
            {
                case 11:
                case 12:
                case 13:
                    return num + "th";
            }

            switch (num % 10)
            {
                case 1:
                    return num + "st";
                case 2:
                    return num + "nd";
                case 3:
                    return num + "rd";
                default:
                    return num + "th";
            }
        }
    }
}