module tryOut

type Message =
| TxtMessage of string
| ReplyMessage of AsyncReplyChannel<string>

let agent = MailboxProcessor.Start(fun inbox ->
    let rec messageLoop = async {
        let! msg = inbox.Receive()
        match msg with
        | TxtMessage m -> printfn "received: %s" m
        | ReplyMessage channel -> channel.Reply("received ")
        
        return! messageLoop
    }
    messageLoop
)

[1..100]
|> List.map (fun i -> async { agent.Post <| TxtMessage (i.ToString()) })
|> Async.Parallel
|> Async.RunSynchronously
|> ignore

agent.Post <| TxtMessage "moinsen"

printfn "%s" <| agent.PostAndReply(ReplyMessage, 5000)