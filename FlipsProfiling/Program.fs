// Learn more about F# at http://fsharp.org

open System
open Flips
open Flips.Types
open Flips.SliceMap

[<EntryPoint>]
let main argv =
    printfn "Flips Profiling"

    //let numberOfCoefficients = 5_000
    //let rng = new System.Random(123)

    //printfn "Generating Coefficients"

    //let coefficients =
    //  [|for i in 1..numberOfCoefficients -> i, rng.NextDouble() * 1_000_000.0 |]
    //  |> SMap.ofArray


    //let mutable output = coefficients


    //let stopwatch = System.Diagnostics.Stopwatch()

    //printfn "Warm up"
    //for i in 1..1_000 do
    //  output <- coefficients.[GreaterThan (rng.Next(1, numberOfCoefficients))]

    //printfn "Running"

    //stopwatch.Start()
    //for i in 1..100_000 do
    //  output <- coefficients.[GreaterThan (rng.Next(1, numberOfCoefficients))]

    //stopwatch.Stop()

    //printfn "%A" output.Keys.Count
    //printfn "Elapsed ms: %A" stopwatch.ElapsedMilliseconds

    // Declare the parameters for our model

    let numberOfItems = 10_000
    let numberOfLocations = 100
    let rng = System.Random(123)
    let items = [for i in 1..numberOfItems -> sprintf "Item:%i" i]
    let locations = [for l in 1..numberOfLocations -> sprintf "Location:%i" l]
    let profit = 
        [
          for i in items do
            for l in locations ->
              (i, l), rng.NextDouble() * 100.0
        ] |> SMap2.ofList

    let maxIngredients = SMap.ofList [for item in items -> item, Math.Round(rng.NextDouble() * 1_000.0, 2)]
    let itemWeight = SMap.ofList [for item in items -> item, Math.Round(rng.NextDouble() * 2.0, 2)]
    let maxTruckWeight = SMap.ofList [for location in locations -> location, Math.Round(rng.NextDouble() * 10_000.0, 2)]

    // Create Decision Variable which is keyed by the tuple of Item and Location.
    // The resulting type is a Map<(string*string),Decision> 
    // to represent how much of each item we should pack for each location
    // with a Lower Bound of 0.0 and an Upper Bound of Infinity
    let numberOfItem =
        [for item in items do
            for location in locations do
                let decName = sprintf "NumberOf_%s_At_%s" item location
                let decision = Decision.createContinuous decName 0.0 infinity
                (location, item), decision]
        |> SMap2.ofList

    let mutable result = Result.Ok ()


    printfn "Running Warmup"
    for i in 1..5 do
        printfn "Warmup: %i" i

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
                sum (itemWeight .* numberOfItem.[location, All]) <== maxTruckWeight.[location]
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


    printfn "Running Loops"
    for i in 1..1000 do
        if i % 5 = 0 then printfn "Loop: %i" i

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
                sum (itemWeight .* numberOfItem.[location, All]) <== maxTruckWeight.[location]
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

    printfn "%A" result
    0 // return an integer exit code
