namespace Dauerwerbesendung

open Xunit
open Swensen.Unquote

module Implementation =
    let foo () = ""

module ``Calculator tests`` =

    [<Fact>]
    let ``Given a wonderful spec Calculate() returns the correct result`` () =
        let expected = "-1"
        let result = Implementation.foo()
        test <@ expected = result @>
        ()