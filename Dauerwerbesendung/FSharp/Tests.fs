module Tests

    // Microsoft.VisualStudio.QualityTools.UnitTestFramework.dll
    open Microsoft.VisualStudio.TestTools.UnitTesting
    open Domain

    [<TestClass>]
    type ``Given a customer``() =
        
        [<TestMethod>]
        member __.``Then it's persited in the database``() =
            ()

        [<TestMethod>]
        member __.``compared to another is equal``() =
            let first = { Firstname = "Marcus"; Lastname = "Kohnert" }
            let second = { Firstname = "Marcus"; Lastname = "Kohnert" }

            Assert.AreEqual(first, second)

        [<TestMethod>]
        member __.``compared to another is not equal``() =
            let first = { Firstname = "Marcus"; Lastname = "Kohnert" }
            let second = { Firstname = "Marcus2"; Lastname = "Kohnert" }

            Assert.AreNotEqual(first, second)