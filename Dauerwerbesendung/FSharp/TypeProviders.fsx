#r @"D:\MKK\src\fiddle\Dauerwerbesendung\packages\FSharp.Data.2.2.5\lib\net40\FSharp.Data.dll"

open FSharp.Data

type SaxSysRepos = JsonProvider<"https://api.github.com/users/saxsys/repos">
SaxSysRepos.GetSamples()
|> Seq.map (fun r -> r.Name)
|> Seq.iter (fun n -> printfn "%s" n)

let worldbank = WorldBankData.GetDataContext()
worldbank.Countries.Germany.Indicators.``Population (Total)``.Item(2014)