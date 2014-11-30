module tryOut

type Message<'a> =
| TxtMessage of string
| ReplyMessage of string option * AsyncReplyChannel<'a>

let agent = MailboxProcessor.Start(fun inbox ->
    let rec messageLoop lastMsg = async {
        
        let! msg = inbox.Receive()
        printfn "ThreadId: %i" <| System.Threading.Thread.CurrentThread.ManagedThreadId
        match msg with

        | TxtMessage m -> 
            printfn "received: %s" m
            return! messageLoop m

        | ReplyMessage (msg, channel) ->
            match msg with
            | Some m -> 
                printfn "received: %s" m
                channel.Reply ("agent replied " + m)
                return! messageLoop m
            | None -> 
                channel.Reply lastMsg
                return! messageLoop lastMsg            
    }

    messageLoop ""
)

let GetAgent() = agent

let test() =
    [1..100]
    |> List.map (fun i -> async { agent.Post <| TxtMessage (i.ToString()) })
    |> Async.Parallel
    |> Async.RunSynchronously
    |> ignore
    
    agent.Post <| TxtMessage "moinsen"
    
    printfn "replied %s" <| agent.PostAndReply((fun r -> ReplyMessage(Some "Hello", r)), 5000)