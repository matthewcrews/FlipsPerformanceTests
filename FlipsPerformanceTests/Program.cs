using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Flips.Types;

namespace FlipsPerformanceTests
{
    public class Program
    {

        //[Params(10, 100, 1000, 10000)]
        //public int NumberToAdd
        //{
        //    get; set;
        //}

        //[Benchmark]
        //public LinearExpression AdditionTest()
        //{
        //    return LinearExpressionTests.PerfTests.addition(NumberToAdd);
        //}

        [Params(10, 100, 1000, 10000, 90900)]
        public int StartIndex
        {
            get; set;
        }

        //[Benchmark]
        //public Flips.SliceMap.SMap<int, LinearExpression> SliceMapSliceAndSumTest()
        //{
        //    return LinearExpressionTests.PerfTests.sliceMapGreaterThanMultiplication(StartIndex);
        //}

        [Benchmark]
        public Flips.SliceMap.SMap<int,LinearExpression> SliceMapLessThanMultiplication()
        {
            return LinearExpressionTests.PerfTests.sliceMapLessThanMultiplication(StartIndex);
        }

        [Benchmark]
        public LinearExpression SliceMapSumming()
        {
            return LinearExpressionTests.PerfTests.sliceMapSumming();
        }

        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Program>();
        }
    }
}
