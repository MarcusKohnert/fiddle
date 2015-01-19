[<EntryPoint>]
let main args = 
    
    do System.Net.WebRequest.DefaultWebProxy.Credentials <- System.Net.CredentialCache.DefaultNetworkCredentials

    try
        Stats.WriteStats()
    with
        :? System.Net.WebException -> printfn "no internet connection"

    System.Console.WriteLine("Done")
    Async.RunSynchronously((Async.Sleep 2000))
    0