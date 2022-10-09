module SgfParsingTests

open FsUnit.Xunit
open Xunit

open SgfParsing

[<Fact>]
let ``Empty input`` () =
    let expected = None
    parse "" |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Tree with no nodes`` () =
    let expected = None
    parse "()" |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Node without tree`` () =
    let expected = None
    parse ";" |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Node without properties`` () =
    let expected = Some (Node (Map.ofList [], []))
    parse "(;)" |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Single node tree`` () =
    let expected = Some (Node (Map.ofList [("A", ["B"])], []))
    parse "(;A[B])" |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Multiple properties`` () =
    let expected = Some (Node (Map.ofList [("A", ["b"]); ("C", ["d"])], []))
    parse "(;A[b]C[d])" |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Properties without delimiter`` () =
    let expected = None
    parse "(;A)" |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``All lowercase property`` () =
    let expected = None
    parse "(;a[b])" |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Upper and lowercase property`` () =
    let expected = None
    parse "(;Aa[b])" |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Two nodes`` () =
    let expected = Some (Node (Map.ofList [("A", ["B"])], [Node (Map.ofList [("B", ["C"])], [])]))
    parse "(;A[B];B[C])" |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Two child trees`` () =
    let expected = Some (Node (Map.ofList [("A", ["B"])], [Node (Map.ofList [("B", ["C"])], []); Node (Map.ofList [("C", ["D"])], [])]))
    parse "(;A[B](;B[C])(;C[D]))" |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Multiple property values`` () =
    let expected = Some (Node (Map.ofList [("A", ["b"; "c"; "d"])], []))
    parse "(;A[b][c][d])" |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Within property values, whitespace characters such as tab are converted to spaces`` () =
    let expected = Some (Node (Map.ofList [("A", ["hello  world"])], []))
    parse "(;A[hello\t\tworld])" |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Within property values, newlines remain as newlines`` () =
    let expected = Some (Node (Map.ofList [("A", ["hello\n\nworld"])], []))
    parse "(;A[hello\n\nworld])" |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Escaped closing bracket within property value becomes just a closing bracket`` () =
    let expected = Some (Node (Map.ofList [("A", ["]"])], []))
    parse "(;A[\]])" |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Escaped backslash in property value becomes just a backslash`` () =
    let expected = Some (Node (Map.ofList [("A", ["\"])], []))
    parse "(;A[\\])" |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Opening bracket within property value doesn't need to be escaped`` () =
    let expected = Some (Node (Map.ofList [("A", ["x[y]z"; "foo"]); ("B", ["bar"])], [Node (Map.ofList [("C", ["baz"])], [])]))
    parse "(;A[x[y\]z][foo]B[bar];C[baz])" |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Semicolon in property value doesn't need to be escaped`` () =
    let expected = Some (Node (Map.ofList [("A", ["a;b"; "foo"]); ("B", ["bar"])], [Node (Map.ofList [("C", ["baz"])], [])]))
    parse "(;A[a;b][foo]B[bar];C[baz])" |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Parentheses in property value don't need to be escaped`` () =
    let expected = Some (Node (Map.ofList [("A", ["x(y)z"; "foo"]); ("B", ["bar"])], [Node (Map.ofList [("C", ["baz"])], [])]))
    parse "(;A[x(y)z][foo]B[bar];C[baz])" |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Escaped tab in property value is converted to space`` () =
    let expected = Some (Node (Map.ofList [("A", ["hello world"])], []))
    parse "(;A[hello\\tworld])" |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Escaped newline in property value is converted to nothing at all`` () =
    let expected = Some (Node (Map.ofList [("A", ["helloworld"])], []))
    parse "(;A[hello\\nworld])" |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Escaped t and n in property value are just letters, not whitespace`` () =
    let expected = Some (Node (Map.ofList [("A", ["t = t and n = n"])], []))
    parse "(;A[\t = t and \n = n])" |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Mixing various kinds of whitespace and escaped characters in property value`` () =
    let expected = Some (Node (Map.ofList [("A", ["]b\ncd  e\ ]"])], []))
    parse "(;A[\]b\nc\\nd\t\te\\ \\n\]])" |> should equal expected

