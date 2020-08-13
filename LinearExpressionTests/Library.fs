namespace LinearExpressionTests

open Flips
open Flips.Types
open Flips.SliceMap

module PerfTests =

    let numberOfNames = 1_000
    let numberOfExprs = 1_000
    let numberOfCoefficients = 5_000
    let maxExprSize = 10
    let rng = new System.Random(123)
    let decisions =
        [|1 .. numberOfNames|]
        |> Array.map string
        |> Array.map (fun x -> Decision.createContinuous x 0.0 infinity)

    //let generateExpr (decisions:Decision []) (rng:System.Random) (maxExpressionSize:int) =
    //    let numberOfElements = rng.Next(1, maxExpressionSize)

    //    [|1 .. numberOfElements|]
    //    |> Array.sumBy (fun x -> rng.NextDouble() * 1_000_000.0 * decisions.[rng.Next(0, decisions.Length - 1)])

    //let exprs =
    //    [|for _ in 1 .. numberOfNames -> generateExpr decisions rng maxExprSize|]


    //let addition numberToAdd =
        
    //    [|for _ in 1 .. numberToAdd -> exprs.[rng.Next(0,numberOfExprs - 1)]|]
    //    |> Array.sum


    let coefficients =
        [|for i in 1..numberOfCoefficients -> i, rng.NextDouble() * 1_000_000.0 |]
        |> SliceMap.SMap.ofSeq
        
    //let decisionMap =
    //    [|for i in 1..numberOfCoefficients -> i, (Decision.createContinuous (sprintf "%i" i) 0.0 infinity)|]
    //    |> SliceMap.SMap.ofArray

    //let sliceRng = new System.Random(123)

    //let largeSlices =
    //  [|for _ in 1 .. 100 ->
    //    [1..1000]
    //    |> List.map (fun _ -> rng.Next(1, numberOfCoefficients))
    //    |> Set.ofList
    //  |]

    //let mediumSlices =
    //  [|for _ in 1 .. 100 ->
    //    [1..100]
    //    |> List.map (fun _ -> rng.Next(1, numberOfCoefficients))
    //    |> Set.ofList
    //  |]

    //let smallSlices =
    //  [|for _ in 1 .. 100 ->
    //    [1..10]
    //    |> List.map (fun _ -> rng.Next(1, numberOfCoefficients))
    //    |> Set.ofList
    //  |]

    //let sliceMapMultiplication () =
    //    coefficients .* decisionMap


    //let sliceMapLessThanMultiplication (startIndex) =
    //    coefficients.[GreaterThan (startIndex)] .* decisionMap


    //let sliceMapSumming () =
    //    sum (coefficients .* decisionMap)


    //let inSlicing_Small () =
    //  let mutable output = coefficients
      
    //  for i in 1..1_000 do
    //    output <- coefficients.[In smallSlices.[rng.Next(0, smallSlices.Length - 1)]]

    //  output.Keys.Count


    //let inSlicing_Medium () =
    //  let mutable output = coefficients
      
    //  for i in 1..1_000 do
    //    output <- coefficients.[In smallSlices.[rng.Next(0, mediumSlices.Length - 1)]]

    //  output.Keys.Count


    //let inSlicing_Large () =
    //  let mutable output = coefficients
      
    //  for i in 1..1_000 do
    //    output <- coefficients.[In smallSlices.[rng.Next(0, largeSlices.Length - 1)]]

    //  output.Keys.Count


    //let greaterThanSlicingTest () =
    //  let testRng = new System.Random(123)
    //  let mutable output = coefficients
      
    //  for i in 1..1_000 do
    //    output <- coefficients.[GreaterThan (testRng.Next(1, numberOfCoefficients))]

    //  output.Keys.Count


    let outerIndexSize = 1_000
    let innerIndexSeize = 100

    let example2D =
      [|for i in 1..outerIndexSize do 
            for j in 1..innerIndexSeize ->
              (i, j), rng.NextDouble()
      |] |> SMap2.ofSeq

    let subsetting2DSliceMapFirstIndex () =
        let testRng = new System.Random(123)
        let mutable output = coefficients

        for i in 1..5_000 do
          output <- example2D.[testRng.Next(1, outerIndexSize), All]

        output.Keys.Count

    let subsetting2DSliceMapSecondIndex () =
        let testRng = new System.Random(123)
        let mutable output = coefficients

        for i in 1..500 do
          output <- example2D.[All, testRng.Next(1, innerIndexSeize)]

        output.Keys.Count

