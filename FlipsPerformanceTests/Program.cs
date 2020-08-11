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

        //[Params(900000, 100000, 1000)]
        //public int StartIndex
        //{
        //    get; set;
        //}

        //[Benchmark]
        //public Flips.SliceMap.SMap<int, LinearExpression> SliceMapSliceAndSumTest()
        //{
        //    return LinearExpressionTests.PerfTests.sliceMapGreaterThanMultiplication(StartIndex);
        //}

        //[Benchmark]
        //public Flips.SliceMap.SMap<int,LinearExpression> Multiplication()
        //{
        //    return LinearExpressionTests.PerfTests.sliceMapMultiplication();
        //}

        //[Benchmark]
        //public LinearExpression SliceMapSumming()
        //{
        //    return LinearExpressionTests.PerfTests.sliceMapSumming();
        //}

        //[Benchmark]
        //public Flips.SliceMap.SMap<int, double>[] SmallInSlicing()
        //{
        //    return LinearExpressionTests.PerfTests.inSlicing_Small();
        //}

        //[Benchmark]
        //public Flips.SliceMap.SMap<int, double>[] MediumInSlicing()
        //{
        //    return LinearExpressionTests.PerfTests.inSlicing_Medium();
        //}

        //[Benchmark]
        //public Flips.SliceMap.SMap<int, double>[] LargeInSlicing()
        //{
        //    return LinearExpressionTests.PerfTests.inSlicing_Large();
        //}

        [Benchmark]
        public Flips.SliceMap.SMap<int, double>[] Subsetting2DSliceMap()
        {
            return LinearExpressionTests.PerfTests.subsetting2DSliceMap();
        }

        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Program>();
        }
    }
}
