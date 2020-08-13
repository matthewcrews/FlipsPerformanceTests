// Learn more about F# at http://fsharp.org

open System
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

    0 // return an integer exit code
