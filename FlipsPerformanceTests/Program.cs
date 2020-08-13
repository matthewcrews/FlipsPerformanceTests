using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Flips.Types;

namespace FlipsPerformanceTests
{
    public class Program
    {

        //[Params(10, 100, 1000, 10000)]
        //public int StartIndex
        //{
        //    get; set;
        //}

        //[Benchmark]
        //public int greaterThanSlicingTest()
        //{
        //    return LinearExpressionTests.PerfTests.greaterThanSlicingTest();
        //}

        //[Benchmark]
        //public LinearExpression AdditionTest()
        //{
        //    return LinearExpressionTests.PerfTests.addition(NumberToAdd);
        //}

        //[Benchmark]
        //public Flips.SliceMap.SMap<int, double>[] greaterThanSlice()
        //{
        //    return LinearExpressionTests.PerfTests.greaterThanSlice(StartIndex);
        //}

        //[Benchmark]
        //public Flips.SliceMap.SMap<int, LinearExpression> SliceMapSliceAndSumTest()
        //{
        //    return LinearExpressionTests.PerfTests.sliceMapLessThanMultiplication(450_000);
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
        //public int SmallInSlicing()
        //{
        //    return LinearExpressionTests.PerfTests.inSlicing_Small();
        //}

        //[Benchmark]
        //public int MediumInSlicing()
        //{
        //    return LinearExpressionTests.PerfTests.inSlicing_Medium();
        //}

        //[Benchmark]
        //public int LargeInSlicing()
        //{
        //    return LinearExpressionTests.PerfTests.inSlicing_Large();
        //}

        //[Benchmark]
        //public int greaterThanSlicingTest()
        //{
        //    return LinearExpressionTests.PerfTests.greaterThanSlicingTest();
        //}

        [Benchmark]
        public int subsetting2DSliceMapFirstIndex()
        {
            return LinearExpressionTests.PerfTests.subsetting2DSliceMapFirstIndex();
        }

        [Benchmark]
        public int subsetting2DSliceMapSecondIndex()
        {
            return LinearExpressionTests.PerfTests.subsetting2DSliceMapSecondIndex();
        }

        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Program>();
        }
    }
}
