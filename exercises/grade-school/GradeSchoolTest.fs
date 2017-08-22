module GradeSchoolTest

open NUnit.Framework
open FsUnit
open GradeSchool

[<Test>]
let ``Empty school has an empty roster`` () =
    let school = empty
    roster school |> should be Empty

[<Test>]
[<Ignore("Remove to run test")>]
let ``Adding a student adds them to the roster for the given grade`` () =
    let school = empty |> add "Aimee" 2
    let expected = ["Aimee"]
    grade 2 school |> should equal expected

[<Test>]
[<Ignore("Remove to run test")>]
let ``Adding more students to the same grade adds them to the roster`` () =
    let school = 
        empty
        |> add "Blair" 2
        |> add "James" 2
        |> add "Paul" 2
    let expected = ["Blair"; "James"; "Paul"]
    grade 2 school |> should equal expected

[<Test>]
[<Ignore("Remove to run test")>]
let ``Adding students to different grades adds them to the roster`` () =
    let school = 
        empty
        |> add "Chelsea" 3
        |> add "Logan" 7
    grade 3 school |> should equal ["Chelsea"]
    grade 7 school |> should equal ["Logan"]

[<Test>]
[<Ignore("Remove to run test")>]
let ``Grade returns the students in that grade in alphabetical order`` () =
    let school = 
        empty
        |> add "Franklin" 5
        |> add "Bradley" 5
        |> add "Jeff" 1
    let expected = ["Bradley"; "Franklin"]
    grade 5 school |> should equal expected

[<Test>]
[<Ignore("Remove to run test")>]
let ``Grade returns an empty list if there are no students in that grade`` () =
    let school = empty
    grade 1 school |> should equal []

[<Test>]
[<Ignore("Remove to run test")>]
let ``Student names and grades in roster are sorted`` () =
    let school =
        empty        
        |> add "Jennifer" 4
        |> add "Kareem" 6
        |> add "Christopher" 4
        |> add "Kyle" 3

    let expected = 
        [(3, ["Kyle"]);
         (4, ["Christopher"; "Jennifer"]);
         (6, ["Kareem"])]

    roster school |> should equal expected