using System;

class Program
{
    // Recursive function to calculate future value
    static double PredictFutureValue(double initialValue, double growthRate, int years)
    {
        if (years == 0)
            return initialValue;
        return PredictFutureValue(initialValue * (1 + growthRate), growthRate, years - 1);
    }

    static void Main()
    {
        double initialValue = 1000.0; // Initial investment
        double growthRate = 0.05;     // 5% annual growth
        int years = 10;               // Forecast for 10 years

        double futureValue = PredictFutureValue(initialValue, growthRate, years);
        Console.WriteLine($"Predicted value after {years} years: {futureValue:F2}");
    }
}
