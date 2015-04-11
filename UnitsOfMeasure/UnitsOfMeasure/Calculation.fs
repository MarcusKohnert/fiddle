module Calculation
    
    [<Measure>] type km
    [<Measure>] type h
    [<Measure>] type kg
    [<Measure>] type KW
    [<Measure>] type KWh = KW * h

    let calculate() =
        
        let geschwindigkeit = 3<km/h>

        let distanz = geschwindigkeit * 2<h>

        System.Console.WriteLine(distanz.ToString()) // 6

        let verbrauch = 70<KW>

        let verbrauchProStunde = verbrauch * 1<h>
        let verbrauchProStunde2 = 70<KWh>

        let result = verbrauchProStunde = verbrauchProStunde2  // true

//        let error = 7<km> + 7<h> // error

        ()