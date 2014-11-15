module TypeProvModule

open FSharp.Data

    type saxSysRepo = JsonProvider<"https://api.github.com/users/saxsys/repos">

    type contributorDoc = JsonProvider<"https://api.github.com/repos/saxsys/CinemaKata/contributors">

    let GetContributors url:string = 
        contributorDoc.Load url
        |> Seq.iter (fun c -> printfn "%s" (c.ToString()))

    let Get() =
        saxSysRepo.Load "https://api.github.com/users/saxsys/repos"
        |> Seq.iter (fun r -> printfn "Name: %s" r.Name)

        saxSysRepo.Load "https://api.github.com/users/saxsys/repos"
        |> Seq.iter (fun r -> contributorDoc.Load r.ContributorsUrl)

//        contributorDoc.Load "https://api.github.com/repos/saxsys/CinemaKata/contributors"
//        |> Seq.iter (fun r -> printfn "Name: %s" r.Login)