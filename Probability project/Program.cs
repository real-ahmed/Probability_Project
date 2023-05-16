using System;
using System.IO;
using System.Collections;


namespace Probability_Project

{
        class Program
        {
            static void Main(string[] args)
            {
                Console.Write("Enter the number of items: ");
                int n = int.Parse(Console.ReadLine());
                double[] values = new double[n];

                for (int i = 0; i < n; i++)
                {
                    Console.Write("Enter value #" + (i + 1) + ": ");
                    values[i] = double.Parse(Console.ReadLine());
                }

                Array.Sort(values);

                double median = GetMedian(values);
                double mode = GetMode(values);
                double range = GetRange(values);
                double q1 = GetPercentile(values, 0.25);
                double q3 = GetPercentile(values, 0.75);
                double p90 = GetPercentile(values, 0.9);
                double iqr = q3 - q1;
                double lowerBound = q1 - 1.5 * iqr;
                double upperBound = q3 + 1.5 * iqr;

                Console.WriteLine("Median: " + median);
                Console.WriteLine("Mode: " + mode);
                Console.WriteLine("Range: " + range);
                Console.WriteLine("First Quartile: " + q1);
                Console.WriteLine("Third Quartile: " + q3);
                Console.WriteLine("P90: " + p90);
                Console.WriteLine("Interquartile Range: " + iqr);
                Console.WriteLine("Outlier Boundaries: " + lowerBound + " - " + upperBound);

                Console.Write("Enter a value to check if it's an outlier: ");
                double input = double.Parse(Console.ReadLine());

                if (IsOutlier(input, lowerBound, upperBound))
                {
                    Console.WriteLine(input + " is an outlier.");
                }
                else
                {
                    Console.WriteLine(input + " is not an outlier.");
                }
            }

            static double GetMedian(double[] values)
            {
                int n = values.Length;
                if (n % 2 == 0)
                {
                    return (values[n / 2] + values[n / 2 - 1]) / 2.0;
                }
                else
                {
                    return values[n / 2];
                }
            }

            static double GetMode(double[] values)
            {
                int n = values.Length;
                int modeCount = 0;
                double mode = double.NaN;

                for (int i = 0; i < n; i++)
                {
                    int count = 0;
                    for (int j = 0; j < n; j++)
                    {
                        if (values[j] == values[i])
                        {
                            count++;
                        }
                    }

                    if (count > modeCount)
                    {
                        modeCount = count;
                        mode = values[i];
                    }
                }

                return mode;
            }

            static double GetRange(double[] values)
            {
                return values[values.Length - 1] - values[0];
            }


            static double GetPercentile(double[] values, double p)
            {
                int n = values.Length;
                int k = (int)Math.Floor(p * (n - 1));
                double d = p * (n - 1) - k;
                return (1 - d) * values[k] + d * values[k + 1];
            }
            static bool IsOutlier(double value, double lowerBound, double upperBound)
            {
                return value < lowerBound || value > upperBound;
            }
        }

    }

