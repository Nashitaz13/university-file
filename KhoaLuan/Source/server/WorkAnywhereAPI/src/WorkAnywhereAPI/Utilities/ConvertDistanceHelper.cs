using System;

namespace WorkAnywhereAPI.Utilities
{
    public static class ConvertDistanceHelper
    {
        /// <summary>
        /// Convert meters to kilometers
        /// </summary>
        /// <param name="meters">The meters</param>
        /// <returns>The kilometers</returns>
        public static double ConvertMeterToKilometers(double meters)
        {
            return Convert.ToDouble((meters * 0.001).ToString("F2"));
        }

    }
}
