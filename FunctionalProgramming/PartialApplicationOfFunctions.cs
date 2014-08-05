//Problem Statement: Design a Domain Driven Solution for the problem of calculating the net price post discount and taxes
//Solution: The final design should be like this: tax(cardDiscount(seasonDiscount)));

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunctionalProgramming
{
    public class Program
    {
        public const double season_discount = .1;
        public const double card_discount = .2;
        public const double tax = .3;

        static void Main(string[] args)
        {
            //MyUtils.Apply(Multi);

            //var NetPrice = SeasonDiscount.

        }

        static Func<double, double, double> Multi = (x, y) =>
        {
            return x * y;
        };


        static Func<double, double> SeasonDiscount()
        {
            return Multi.Apply(1-season_discount);            
        }
          static Func<double, double> CardDiscount()
        {
            return Multi.Apply(1-season_discount);            
        }
          static Func<double, double> Tax()
        {
            return Multi.Apply(1 + tax);            
        }

    }

    public static class MyUtils
    {
        public static Func<double, double> Apply(
                this Func<double, double, double> mf, double p1)
        {
            return y => mf(p1, y);
        }

        public static Func<TS, TR> Compose<TS, TI, TR>(
                this Func<TS, TI> host, Func<TI, TR> p1)
        {
            return s => p1(host(s));
        }


        public static Func<int, Func<string, double>> Curry(
                this Func<int, string, double> mf)
        {
            return x => (y => mf(x, y));
        }
    }
}
