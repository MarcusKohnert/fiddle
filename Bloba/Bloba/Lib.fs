namespace Bloba

open System
open Microsoft.FSharp.Data.TypeProviders

module Lib =

    type NoteText = Text of string

    type Tag = Tag of string

    type Note = { Created: DateTimeOffset; Updated: DateTimeOffset; Expires: DateTimeOffset option;
                  Text: NoteText; Tags: Tag list }

    type internal SqlConnection = SqlEntityConnection<ConnectionString="Data Source=(localdb)\BrainRelief;Initial Catalog=BrainRelief;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False">
    
    let internal Persist note =
        use context = SqlConnection.GetDataContext()
        let NoteText(text) = note.Text
        let note = SqlConnection.ServiceTypes.Notes(Text = match note.Text with | NoteText.Text(t) -> t)
        context.Notes.Attach(note)
        context.DataContext.SaveChanges() |> ignore
        ()
        

    let GetTags (note:string) =
        note.Split(' ')
        |> Seq.filter (fun x -> x.StartsWith("#"))
        |> Seq.map Tag
        |> Seq.toList

    let CreateNote (value:string) expires =
        { 
            Created = DateTimeOffset.Now;
            Updated = DateTimeOffset.Now;
            Expires = expires;
            Text = NoteText.Text(value);
            Tags = GetTags value;
        }

    let Do value expires =
        CreateNote value expires
        |> Persist
        ()