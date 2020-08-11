namespace LinearExpressionTests

open Flips
open Flips.Types
open Flips.SliceMap

module PerfTests =

    let numberOfNames = 1_000
    let numberOfExprs = 1_000
    let numberOfCoefficients = 1_000_000
    let maxExprSize = 10
    let rng = new System.Random()
    let decisions =
        [|1 .. numberOfNames|]
        |> Array.map string
        |> Array.map (fun x -> Decision.createContinuous x 0.0 infinity)

    let generateExpr (decisions:Decision []) (rng:System.Random) (maxExpressionSize:int) =
        let numberOfElements = rng.Next(1, maxExpressionSize)

        [|1 .. numberOfElements|]
        |> Array.sumBy (fun x -> rng.NextDouble() * 1_000_000.0 * decisions.[rng.Next(0, decisions.Length - 1)])

    let exprs =
        [|for _ in 1 .. numberOfNames -> generateExpr decisions rng maxExprSize|]


    let addition numberToAdd =
        
        [|for _ in 1 .. numberToAdd -> exprs.[rng.Next(0,numberOfExprs - 1)]|]
        |> Array.sum


    let coefficients =
        [|for i in 1..numberOfCoefficients -> i, rng.NextDouble() * 1_000_000.0 |]
        |> SliceMap.SMap.ofArray
        
    let decisionMap =
        [|for i in 1..numberOfCoefficients -> i, (Decision.createContinuous (sprintf "%i" i) 0.0 infinity)|]
        |> SliceMap.SMap.ofArray

    //let sliceRng = new System.Random(123)

    //let sliceMapGreaterThanMultiplication (startIndex) =
    //    coefficients.[GreaterOrEqual (startIndex)] .* decisionMap

    let slicing (startIndex) =
        

    let sliceMapLessThanMultiplication (startIndex) =
        coefficients.[LessOrEqual (startIndex)] .* decisionMap

    let sliceMapSumming () =
        sum (coefficients .* decisionMap)