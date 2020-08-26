using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Flips.Types;

namespace FlipsPerformanceTests
{
    [MemoryDiagnoser]
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

        //[Benchmark]
        //public int subsetting2DSliceMapFirstIndex()
        //{
        //    return LinearExpressionTests.PerfTests.subsetting2DSliceMapFirstIndex();
        //}

        //[Benchmark]
        //public int subsetting2DSliceMapSecondIndex()
        //{
        //    return LinearExpressionTests.PerfTests.subsetting2DSliceMapSecondIndex();
        //}

        //[Params(100, 200, 1000, 2000)]
        //public int NumberItems
        //{
        //    get; set;
        //}

        //[Params(10, 20, 100, 200)]
        //public int NumberLocations
        //{
        //    get; set;
        //}

        //[Params(1)]
        //public int NumberIterations
        //{
        //    get; set;
        //}

        //[Benchmark]
        //public int buildModel()
        //{
        //    return LinearExpressionTests.ModelBuilderTests.buildModel(NumberIterations, NumberItems, NumberLocations);
        //}

        [Benchmark]
        public int smap4Addition()
        {
            return LinearExpressionTests.PerfTests.smap4Addition();
        }

        [Benchmark]
        public int smap4Product()
        {
            return LinearExpressionTests.PerfTests.smap4Product();
        }

        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Program>();
        }
    }
}
