#r @"D:\MKK\src\fiddle\Dauerwerbesendung\packages\FSharp.Data.2.2.5\lib\net40\FSharp.Data.dll"
#r @"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.6\System.Data.Linq.dll"
#r @"C:\Program Files (x86)\Reference Assemblies\Microsoft\FSharp\.NETFramework\v4.0\4.3.0.0\Type Providers\FSharp.Data.TypeProviders.dll"

open FSharp.Data
open Microsoft.FSharp.Data.TypeProviders

// CSV

type MobileDevices = CsvProvider<"http://viewportsizes.com/devices.csv">
let data = MobileDevices.GetSample()
data.Rows
|> Seq.filter (fun r -> r.``Device Name``.StartsWith("Noki"))
|> Seq.iter (fun r -> printfn "%A" r)


// HTML

type Nuget = HtmlProvider<"https://www.nuget.org/profiles/MarcusKohnert/">
Nuget.GetSample().Lists.Packages.Values
|> Seq.iter (fun p -> printfn "%A" p)


// JSON

type SaxSysRepos = JsonProvider<"https://api.github.com/users/saxsys/repos">
SaxSysRepos.GetSamples()
|> Seq.map (fun r -> r.Name)
|> Seq.iter (fun n -> printfn "%s" n)


// WORLDBANK

let worldbank = WorldBankData.GetDataContext()
worldbank.Countries.Germany.Indicators.``Population (Total)``.Item(2014)

// SQL, don't do this in script

type DB = SqlDataConnection<ConnectionString="""Data Source=(localdb)\v11.0;Initial Catalog=TestDb;Integrated Security=True""",ForceUpdate=true>
DB.GetDataContext().Customer
|> Seq.iter (fun c -> printfn "+++ %s %s %s" c.Firstname c.Middlename c.Lastname)