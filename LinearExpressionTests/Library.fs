namespace LinearExpressionTests

open Flips
open Flips.Types
open Flips.SliceMap

module PerfTests =

    //let numberOfNames = 1_000
    //let numberOfExprs = 1_000
    //let numberOfCoefficients = 500_000
    //let maxExprSize = 10
    let rng = new System.Random()
    //let decisions =
    //    [|1 .. numberOfNames|]
    //    |> Array.map string
    //    |> Array.map (fun x -> Decision.createContinuous x 0.0 infinity)

    //let generateExpr (decisions:Decision []) (rng:System.Random) (maxExpressionSize:int) =
    //    let numberOfElements = rng.Next(1, maxExpressionSize)

    //    [|1 .. numberOfElements|]
    //    |> Array.sumBy (fun x -> rng.NextDouble() * 1_000_000.0 * decisions.[rng.Next(0, decisions.Length - 1)])

    //let exprs =
    //    [|for _ in 1 .. numberOfNames -> generateExpr decisions rng maxExprSize|]


    //let addition numberToAdd =
        
    //    [|for _ in 1 .. numberToAdd -> exprs.[rng.Next(0,numberOfExprs - 1)]|]
    //    |> Array.sum


    //let coefficients =
    //    [|for i in 1..numberOfCoefficients -> i, rng.NextDouble() * 1_000_000.0 |]
    //    |> SliceMap.SMap.ofArray
        
    //let decisionMap =
    //    [|for i in 1..numberOfCoefficients -> i, (Decision.createContinuous (sprintf "%i" i) 0.0 infinity)|]
    //    |> SliceMap.SMap.ofArray

    ////let sliceRng = new System.Random(123)

    //let largeSlice =
    //  [for _ in 1 .. 10_000 -> rng.Next(1, numberOfCoefficients)]
    //  |> Set.ofList

    //let mediumSlice =
    //  [for _ in 1 .. 100 -> rng.Next(1, numberOfCoefficients)]
    //  |> Set.ofList

    //let smallSlice =
    //  [for _ in 1 .. 10 -> rng.Next(1, numberOfCoefficients)]
    //  |> Set.ofList

    //let sliceMapMultiplication () =
    //    coefficients .* decisionMap

    //let greaterThanSlice (startIndex) =
    //    coefficients.[GreaterThan (startIndex)]

    ////let sliceMapLessThanMultiplication (startIndex) =
    ////    coefficients.[LessOrEqual (startIndex)] .* decisionMap

    //let sliceMapSumming () =
    //    sum (coefficients .* decisionMap)

    //let inSlicing_Small () =
    //  let x1 = coefficients.[In smallSlice]
    //  let x2 = coefficients.[In smallSlice]
    //  let x3 = coefficients.[In smallSlice]
    //  let x4 = coefficients.[In smallSlice]
    //  let x5 = coefficients.[In smallSlice]
    //  let x6 = coefficients.[In smallSlice]
    //  let x7 = coefficients.[In smallSlice]
    //  [|x1; x2; x3; x4; x5; x6; x7|]

    //let inSlicing_Medium () =
    //  let x1 = coefficients.[In mediumSlice]
    //  let x2 = coefficients.[In mediumSlice]
    //  let x3 = coefficients.[In mediumSlice]
    //  let x4 = coefficients.[In mediumSlice]
    //  let x5 = coefficients.[In mediumSlice]
    //  let x6 = coefficients.[In mediumSlice]
    //  let x7 = coefficients.[In mediumSlice]
    //  [|x1; x2; x3; x4; x5; x6; x7|]

    //let inSlicing_Large () =
    //  let x1 = coefficients.[In largeSlice]
    //  let x2 = coefficients.[In largeSlice]
    //  let x3 = coefficients.[In largeSlice]
    //  let x4 = coefficients.[In largeSlice]
    //  let x5 = coefficients.[In largeSlice]
    //  let x6 = coefficients.[In largeSlice]
    //  let x7 = coefficients.[In largeSlice]
    //  [|x1; x2; x3; x4; x5; x6; x7|]


    let example2D =
      [|for i in 1..1_000 do 
            for j in 1..10_000 ->
              (i, j), rng.NextDouble()
      |] |> SMap2.ofSeq

    let subsetting2DSliceMap () =
      let x1 = example2D.[rng.Next(1, 10_000), All]
      //let x2 = example2D.[rng.Next(1, 10_000), All]
      //let x3 = example2D.[rng.Next(1, 10_000), All]
      //let x4 = example2D.[rng.Next(1, 10_000), All]

      //let x5 = example2D.[All, rng.Next(1, 10_000)]
      //let x6 = example2D.[All, rng.Next(1, 10_000)]
      //let x7 = example2D.[All, rng.Next(1, 10_000)]
      //let x8 = example2D.[All, rng.Next(1, 10_000)]
      //[|x1; x2; x3; x4; x5; x6; x7; x8|]
      [|x1|]
