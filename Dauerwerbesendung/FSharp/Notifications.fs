module Notifications

    let SendEmail(address, customer) = ()

    let SendFax(address, customer) = ()

    let SendLetter(address, customer) = ()

    type Newsletter =
    | Email of string
    | Fax of int
    | Letter of string * string * int

        member this.Send(customer : Domain.Customer) =
            match this with
            | Email address -> SendEmail(address, customer)
            | Fax number -> SendFax(number, customer)
            | Letter (s1, s2, s3) -> SendLetter(s2, customer)

    let SendNewsletter(newsletter, customer:Domain.Customer) =
        match newsletter with
        | Email address       -> SendEmail(address, customer)
        | Fax number          -> SendFax(number, customer)
        | Letter (s1, s2, s3) -> SendLetter(s2, customer)
        
        ()

    let Do() =
        let newsletter = Newsletter.Fax(1234567)
        newsletter.Send({ Firstname = "Heinz"; Lastname = "Eckert" })