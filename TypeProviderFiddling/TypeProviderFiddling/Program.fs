// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.

open System.Net

[<EntryPoint>]
let main argv = 
    printfn "%A" argv

    let proxy = WebRequest.GetSystemWebProxy()
    proxy.Credentials <- CredentialCache.DefaultNetworkCredentials
    WebRequest.DefaultWebProxy <- proxy

    TypeProvModule.Get()

    System.Console.ReadLine() |> ignore
    0 // return an integer exit code