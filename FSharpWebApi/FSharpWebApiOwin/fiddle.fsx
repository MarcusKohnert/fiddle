open System.Net
open System.Text

let execParallel noTimes f =
    [0..noTimes]
    |> Seq.map (fun _ -> f)
    |> Async.Parallel
    |> Async.RunSynchronously
    
let callController meth (message:string) =
    async {
        let request = WebRequest.CreateHttp("http://localhost:48213/Request")
        request.Method <- meth

        let raw = Encoding.UTF8.GetBytes(message)
        request.ContentType <- "application/json"
        request.ContentLength <- raw.LongLength

        use stream = request.GetRequestStream()
        stream.Write(raw, 0, raw.Length)

        return! request.AsyncGetResponse()
    }

let postToController = callController "POST"

postToController """ "brand new #text" """
|> Async.RunSynchronously