module Stats

open FSharp.Data

type NugetProfile = HtmlProvider<"https://www.nuget.org/profiles/MarcusKohnert/">

let WriteStats() =
    let statNumbers = (fun (n:HtmlNode) -> n.Descendants(fun descendants -> descendants.HasClass("stat-number")))

    let packageStats = NugetProfile().Html
                                     .Descendants(fun n -> n.HasId("stats"))
                                     |> Seq.collect statNumbers
                                     |> Seq.last
    use writer = System.IO.File.AppendText("stats")
    writer.Write(System.DateTime.Now.ToString())
    writer.Write("\t")
    let downloads = packageStats.InnerText()
    writer.WriteLine(downloads)
    printfn "Downloads: %s" downloads