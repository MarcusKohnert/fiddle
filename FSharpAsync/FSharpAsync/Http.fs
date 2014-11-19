module Http

open System.Net
open System.IO

let Get(url:string) =
    async {
        let request = WebRequest.CreateHttp(url)
        let! response = Async.AwaitTask(request.GetResponseAsync())
        printfn "Got response from %s" url
        let stream = response.GetResponseStream()
        use reader = new StreamReader(stream)
        return! Async.AwaitTask(reader.ReadToEndAsync())
    }