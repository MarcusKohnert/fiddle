module Tests

    // Microsoft.VisualStudio.QualityTools.UnitTestFramework.dll
    open Microsoft.VisualStudio.TestTools.UnitTesting

    [<TestClass>]
    type ``Given a customer``() =
        
        [<TestMethod>]
        member __.``Then it's persited in the database``() =
            ()