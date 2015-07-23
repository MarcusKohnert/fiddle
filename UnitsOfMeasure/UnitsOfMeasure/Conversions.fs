module Conversions

    [<Measure>] type m

    [<Measure>] 
    type km =
        static member inMetre = 1000<m/km>

    let Do() =
        let oneKm = 1<km>

        let inM = oneKm * km.inMetre

        ()