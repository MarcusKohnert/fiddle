﻿module TypeProvModule

open System.Net
open FSharp.Data

    type saxSysRepo = JsonProvider<"https://api.github.com/users/saxsys/repos">

    let Get() =
        saxSysRepo.Load("https://api.github.com/users/saxsys/repos")
        |> Seq.iter (fun r -> printfn "Name: %s ForksCount: %i" r.Name r.ForksCount)