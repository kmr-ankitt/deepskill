using System;
using System.Collections.Generic;

namespace FinancialForecastingExample
{
    public class FinancialForecaster
    {

        public static double CalculateFutureValue(double presentValue, double growthRate, int years)
        {
            // Base case
            if (years == 0)
            {
                return presentValue;
            }

            // Recursive case: build up from year (n-1) to year n
            return CalculateFutureValue(presentValue, growthRate, years - 1) * (1 + growthRate);
        }

        public static double CalculateFutureValueMemoized(
            double presentValue, double growthRate, int years, Dictionary<int, double> memo)
        {
            if (years == 0)
            {
                return presentValue;
            }

            if (memo.ContainsKey(years))
            {
                return memo[years]; // Return cached result
            }

            double result = CalculateFutureValueMemoized(presentValue, growthRate, years - 1, memo) * (1 + growthRate);
            memo[years] = result; // Cache the result
            return result;
        }
    }


    // Test - Demonstration

    class Program
    {
        static void Main(string[] args)
        {
            double presentValue = 100000;   // Initial investment (e.g., Rs. 1,00,000)
            double growthRate = 0.08;       // 8% annual growth rate
            int years = 10;

            Console.WriteLine("---- Simple Recursive Approach ----");
            double futureValue = FinancialForecaster.CalculateFutureValue(presentValue, growthRate, years);
            Console.WriteLine($"Present Value: {presentValue}");
            Console.WriteLine($"Growth Rate: {growthRate * 100}%");
            Console.WriteLine($"Years: {years}");
            Console.WriteLine($"Future Value: {futureValue:F2}");

            Console.WriteLine();
            Console.WriteLine("---- Memoized Recursive Approach ----");
            Dictionary<int, double> memo = new Dictionary<int, double>();
            double futureValueMemoized = FinancialForecaster.CalculateFutureValueMemoized(presentValue, growthRate, years, memo);
            Console.WriteLine($"Future Value (Memoized): {futureValueMemoized:F2}");

            Console.WriteLine();
            Console.WriteLine("---- Year-by-Year Forecast ----");
            for (int year = 0; year <= years; year++)
            {
                double yearValue = FinancialForecaster.CalculateFutureValue(presentValue, growthRate, year);
                Console.WriteLine($"Year {year}: {yearValue:F2}");
            }
        }
    }
}
