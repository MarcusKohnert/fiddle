module Domain

    open System    
    open System.Collections.Generic

    // record types

    type Customer = 
        { Firstname : string; Lastname : string }

        override __.ToString() =
            sprintf "Hello %s %s" __.Firstname __.Lastname

    // discriminated unions

    type Zahlungsmittel =
    | Bar of decimal
    | Kreditkarte of int * DateTime
    | Paypal of string

    let DruckeRechnung zahlungsmittel =
        match zahlungsmittel with
        | Bar betrag -> sprintf "Bar: %A" betrag
        | _ -> ""