#load "AsyncSamples.fs"
#load "Http.fs"

["http://www.google.de"; "http://www.bing.de"; "http://www.microsoft.com";
 "http://www.spiegel.de"; "http://www.yahoo.de"; "https://www.github.com"]
|> Seq.map Http.Get
|> Async.Parallel
|> Async.RunSynchronously
|> Seq.iter (fun s -> printfn "%s" (s.Substring(0, 50)))