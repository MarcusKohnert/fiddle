module Domain

    open System    
    open System.Collections.Generic

    // record types

    type Customer = { Firstname : string; Lastname : string }

    // type inference

    let GetFirstname customer =
        customer.Firstname

    type Zahlungsmittel =
    | Bar of decimal
    | Kreditkarte of int * DateTime
    | Paypal of string

    let DruckeRechnung(mittel:Zahlungsmittel) =
        match mittel with
        | Bar betrag -> sprintf "Bar: %A" betrag
        | _ -> ""