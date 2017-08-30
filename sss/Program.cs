using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace sss
{





    class sss
    {

        Dictionary<double, double> split_into_shares(double divisions , List<double> polynomials)
        {

            double result=0;
            Dictionary<double, double> shares = new Dictionary<double, double>();
            for (double i = 1; i <= divisions; i++)
            {
                for (double j = 0; j < polynomials.Count(); j++)
                {
                    result = result + (polynomials[(int)j] *Math.Pow(i,j));
                }

                shares.Add(i, result);
                result = 0;
            }

            return shares;
        }


        double reconstruct_seceret(double required_shares)
        {
            double[] x;
            x = new double[10];
            double[] y;
            y = new double[10];
            double temp = 1;
            double[] f;
            f = new double[10];
            double sum = 0;

            int i, j, k = 0;
            Console.WriteLine("Please Enter The Number Of Shares You Want To Enter");
            int n = Convert.ToInt32(Console.ReadLine());
            for (i = 0; i < n; i++)
            {
                Console.WriteLine("Enter x{0}",i);
                x[i] = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter y{0}",i);
                y[i] = Convert.ToInt32(Console.ReadLine());
            }
            double p = 0;

            if (n < required_shares)
            {
                return 0;
            }

            else
            {
                for (i = 0; i < n; i++)
                {
                    temp = 1;
                    k = i;
                    for (j = 0; j < n; j++)
                    {
                        if (k == j)
                        {
                            continue;
                        }
                        else
                        {
                            temp = temp * ((p - x[j]) / (x[k] - x[j]));
                        }
                    }
                    f[i] = y[i] * temp;
                }

                for (i = 0; i < n; i++)
                {
                    sum = sum + f[i];
                }
                return sum;
            }
        }


        void Open_Safe(double seceret,double generated_seceret)
        {
           

            if (generated_seceret== seceret)
            {
                Console.WriteLine("Safe Opened");
            }

            else
            {
                Console.WriteLine("Ringing Alarm");
            }

        }

        static void Main(string[] args)
        {

            double seceret = 1234;           // The Pasword that you want to keep as a secret
            double divisions = 6;            // Number of people to whom you want to give a password share
            double sufficient_shares = 3;    // Minimum number of shares from which you can retrieve the password
            double rand_1 = 166;             // Random number 1 for quadratric equation
            double rand_2 = 94;             // Rand number 2 for quadratric equation

            List<double> polynomial = new List<double>();
            polynomial.Add(seceret);
            polynomial.Add(rand_1);
            polynomial.Add(rand_2);

            Dictionary<double, double> shares = new Dictionary<double, double>();
            sss s = new sss();

            shares = s.split_into_shares(divisions,polynomial);

            foreach (var pair in shares)
            {
                Console.WriteLine("({0}, {1})",
                pair.Key,
                pair.Value);
            }

            double generate_seceret = s.reconstruct_seceret(sufficient_shares);

            if (generate_seceret == 0)
            {
                Console.WriteLine("Cannot Reconstruct Seceret");
                Console.WriteLine("Ringing Alarm");
            }

            else
            {
                s.Open_Safe(seceret, generate_seceret);
            }


          


            Console.Read();



        }
    }
}