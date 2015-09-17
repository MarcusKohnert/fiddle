module Pipe

    open Domain
    open System

    let Persist customer =
        Console.WriteLine((sprintf "Saved customer %s %s" customer.Firstname customer.Lastname))

    let SendConfirmation customer =
        Console.WriteLine((sprintf "Hello new customer %s %s" customer.Firstname customer.Lastname))
        customer

    let ConstructCustomerFrom (firstname, lastname) =
        { Firstname = firstname; Lastname = lastname }

    let Capitalize firstname lastname =
        let info = System.Threading.Thread.CurrentThread.CurrentUICulture.TextInfo
        (info.ToTitleCase(firstname), info.ToTitleCase(lastname))

    let ValidateInput (input:string) =
        let containsPound = input.Contains("#")
        let values = input.Split('#')
        let valid = containsPound && (values.Length = 2)
        (valid, values)

    let SaveCustomer input =
        let valid, values = ValidateInput input
        match valid with
        | false -> "Could not create from input"
        | true -> Capitalize values.[0] values.[1]
                  |> ConstructCustomerFrom
                  |> SendConfirmation
                  |> Persist
                  "Created"