module Stats

open FSharp.Data

type NugetProfile = HtmlProvider<"https://www.nuget.org/profiles/MarcusKohnert/">

let WriteStats() =
    let downloads = NugetProfile().Html
                                  .Descendants(fun n -> n.HasId("stats"))
                                  |> Seq.collect (fun n -> 
                                                      n.Descendants(fun descendants -> descendants.HasClass("stat-number")))
                                  |> Seq.last
    use writer = System.IO.File.AppendText("stats")
    writer.Write(System.DateTime.Now.ToString())
    writer.Write("\t")
    writer.WriteLine(downloads.InnerText())