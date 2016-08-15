module DotDslTest

open NUnit.Framework

open DotDsl

[<Test>]
let ``Empty graph`` () =
    let g = graph []

    Assert.That(nodes g, Is.Empty)
    Assert.That(edges g, Is.Empty)
    Assert.That(attrs g, Is.Empty)
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Graph with one node`` () =
    let g = graph [
                node "a" []
            ]            

    Assert.That(nodes g, Is.EqualTo([node "a" []]))
    Assert.That(edges g, Is.Empty)
    Assert.That(attrs g, Is.Empty)
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Graph with one node with keywords`` () =    
    let g = graph [
                node "a" [("color", "green")]
            ]            

    Assert.That(nodes g, Is.EqualTo([node "a" [("color", "green")]]))
    Assert.That(edges g, Is.Empty)
    Assert.That(attrs g, Is.Empty)

[<Test>]
[<Ignore("Remove to run test")>]
let ``Graph with one edge`` () =    
    let g = graph [
                edge "a" "b" []
            ]             

    Assert.That(nodes g, Is.Empty)
    Assert.That(edges g, Is.EqualTo([edge "a" "b" []]))
    Assert.That(attrs g, Is.Empty)

[<Test>]
[<Ignore("Remove to run test")>]
let ``Graph with one attribute`` () = 
    let g = graph [
                attr "foo" "1"
            ]             

    Assert.That(nodes g, Is.Empty)
    Assert.That(edges g, Is.Empty)
    Assert.That(attrs g, Is.EqualTo([attr "foo" "1"]))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Graph with attributes`` () =    
    let g = graph [
                attr "foo" "1"
                attr "title" "Testing Attrs"
                node "a" [("color", "green")]
                node "c" []
                node "b" [("label", "Beta!")]                
                edge "b" "c" []
                edge "a" "b" [("color", "blue")]                
                attr "bar" "true"
            ]             

    Assert.That(nodes g, Is.EqualTo([node "a" [("color", "green")]; node "b" [("label", "Beta!")]; node "c" []]))
    Assert.That(edges g, Is.EqualTo([edge "a" "b" [("color", "blue")]; edge "b" "c" []]))
    Assert.That(attrs g, Is.EqualTo([attr "bar" "true"; attr "foo" "1"; attr "title" "Testing Attrs"]))