[<EntryPoint>]
let main args = 
    
    do System.Net.WebRequest.DefaultWebProxy.Credentials <- System.Net.CredentialCache.DefaultNetworkCredentials
    Stats.WriteStats()

    System.Console.WriteLine("Done")
//    System.Console.ReadLine() |> ignore
    0 // return an integer exit code