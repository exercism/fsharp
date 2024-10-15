module GradeSchoolTests

open FsUnit.Xunit
open Xunit

open GradeSchool

[<Fact>]
let ``Roster is empty when no student is added`` () =
    let school = empty
    roster school |> should be Empty

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Student is added to the roster`` () =
    let school = 
        empty
        |> add "Aimee" 2
    roster school |> should equal ["Aimee"]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Multiple students in the same grade are added to the roster`` () =
    let school = 
        empty
        |> add "Blair" 2
        |> add "James" 2
        |> add "Paul" 2
    roster school |> should equal ["Blair"; "James"; "Paul"]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Student not added to same grade in the roster more than once`` () =
    let school = 
        empty
        |> add "Blair" 2
        |> add "James" 2
        |> add "James" 2
        |> add "Paul" 2
    roster school |> should equal ["Blair"; "James"; "Paul"]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Students in multiple grades are added to the roster`` () =
    let school = 
        empty
        |> add "Chelsea" 3
        |> add "Logan" 7
    roster school |> should equal ["Chelsea"; "Logan"]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Student not added to multiple grades in the roster`` () =
    let school = 
        empty
        |> add "Blair" 2
        |> add "James" 2
        |> add "James" 3
        |> add "Paul" 3
    roster school |> should equal ["Blair"; "James"; "Paul"]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Students are sorted by grades in the roster`` () =
    let school = 
        empty
        |> add "Jim" 3
        |> add "Peter" 2
        |> add "Anna" 1
    roster school |> should equal ["Anna"; "Peter"; "Jim"]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Students are sorted by name in the roster`` () =
    let school = 
        empty
        |> add "Peter" 2
        |> add "Zoe" 2
        |> add "Alex" 2
    roster school |> should equal ["Alex"; "Peter"; "Zoe"]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Students are sorted by grades and then by name in the roster`` () =
    let school = 
        empty
        |> add "Peter" 2
        |> add "Anna" 1
        |> add "Barb" 1
        |> add "Zoe" 2
        |> add "Alex" 2
        |> add "Jim" 3
        |> add "Charlie" 1
    roster school |> should equal ["Anna"; "Barb"; "Charlie"; "Alex"; "Peter"; "Zoe"; "Jim"]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Grade is empty if no students in the roster`` () =
    let school = empty
    grade 1 school |> should be Empty

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Grade is empty if no students in that grade`` () =
    let school = 
        empty
        |> add "Peter" 2
        |> add "Zoe" 2
        |> add "Alex" 2
        |> add "Jim" 3
    grade 1 school |> should be Empty

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Student not added to same grade more than once`` () =
    let school = 
        empty
        |> add "Blair" 2
        |> add "James" 2
        |> add "James" 2
        |> add "Paul" 2
    grade 2 school |> should equal ["Blair"; "James"; "Paul"]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Student not added to multiple grades`` () =
    let school = 
        empty
        |> add "Blair" 2
        |> add "James" 2
        |> add "James" 3
        |> add "Paul" 3
    grade 2 school |> should equal ["Blair"; "James"]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Student not added to other grade for multiple grades`` () =
    let school = 
        empty
        |> add "Blair" 2
        |> add "James" 2
        |> add "James" 3
        |> add "Paul" 3
    grade 3 school |> should equal ["Paul"]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Students are sorted by name in a grade`` () =
    let school = 
        empty
        |> add "Franklin" 5
        |> add "Bradley" 5
        |> add "Jeff" 1
    grade 5 school |> should equal ["Bradley"; "Franklin"]

