[<EntryPoint>]
let main argv = 

    let reply(a:MailboxProcessor<tryOut.Message<'string>>) = 
        printfn "replied %s" <| a.PostAndReply(tryOut.ReplyMessage, 5000)

    let a = tryOut.GetAgent()
    a.Post(tryOut.TxtMessage "Today")
    reply a

    a.Post(tryOut.TxtMessage "Tomorrow")
    reply a
    reply a

    System.Console.ReadLine() |> ignore
    0