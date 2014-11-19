module FSharpAsync

open Microsoft.FSharp.Control

// Async.AwaitEvent, creates an async object directly from the event, without needing a lambda

// Async.RunSynchronously, blocks on the async object until it has completed

let Sample1() =
    
    let myTask = async {
        System.Threading.Thread.Sleep(System.TimeSpan.FromSeconds(5.0))
        printfn "Done"
    }

    Async.Start myTask
        
    printfn "Test Test"

do System.Console.ReadLine() |> ignore