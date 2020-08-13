namespace LinearExpressionTests

open System
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


module ModelBuilderTests =

  let numberOfItems = 10_000
  let numberOfLocations = 1_000
  let rng = System.Random(123)
  let items = [for i in 1..numberOfItems -> sprintf "Item:%i" i]
  let locations = [for l in 1..numberOfLocations -> sprintf "Location:%i" l]

  // Create Decision Variable which is keyed by the tuple of Item and Location.
  // The resulting type is a Map<(string*string),Decision> 
  // to represent how much of each item we should pack for each location
  // with a Lower Bound of 0.0 and an Upper Bound of Infinity


  let buildModel (numIterations, numItems, numLocations) =
    let mutable result = Result.Ok ()
    let rng = System.Random(123)
    for i in 1..numIterations do

        let items = items.[..numItems]
        let locations = locations.[..numLocations]

        let profit = 
            [|
              for i in items do
                for l in locations ->
                  (i, l), rng.NextDouble() * 100.0
            |] |> SMap2.ofArray

        let maxIngredients = SMap.ofList [for item in items -> item, Math.Round(rng.NextDouble() * 1_000.0, 2)]
        let itemWeight = SMap.ofList [for item in items -> item, Math.Round(rng.NextDouble() * 2.0, 2)]
        let maxTruckWeight = SMap.ofList [for location in locations -> location, Math.Round(rng.NextDouble() * 10_000.0, 2)]
        
        let numberOfItem =
            [|for item in items do
                for location in locations do
                    let decName = sprintf "NumberOf_%s_At_%s" item location
                    let decision = Decision.createContinuous decName 0.0 infinity
                    (location, item), decision |]
            |> SMap2.ofArray

        // Create the Linear Expression for the objective
        let objectiveExpression = sum (profit .* numberOfItem)

        // Create an Objective with the name "MaximizeRevenue" the goal of Maximizing
        // the Objective Expression
        let objective = Objective.create "MaximizeRevenue" Maximize objectiveExpression
    
        // Create Total Item Maximum constraints for each item
        let maxItemConstraints =
            ConstraintBuilder "MaxItemTotal" { 
              for item in items ->
                sum (1.0 * numberOfItem.[All, item]) <== maxIngredients.[item]
            }


        // Create a Constraint for the Max combined weight of items for each Location
        let maxWeightConstraints = 
            ConstraintBuilder "MaxTotalWeight" {
              for location in locations -> 
                let lhsProduct = itemWeight .* numberOfItem.[location, All]
                let lhs = sum lhsProduct
                let rhs = maxTruckWeight.[location]
                lhs <== rhs
            }

        // Create a Model type and pipe it through the addition of the constraints
        let model =
            Model.create objective
            |> Model.addConstraints maxItemConstraints
            |> Model.addConstraints maxWeightConstraints

        // Create a Settings type which tells the Solver which types of underlying solver to use,
        // the time alloted for solving, and whether to write an LP file to disk
        let settings = {
            SolverType = SolverType.CBC
            MaxDuration = 10_000L
            WriteLPFile = None
        }

        // Call the `solve` function in the Solve module to evaluate the model
        result <- Solver.solve settings model

    match result with
    | Ok _ -> 1
    | Error _ -> 0