module GradeSchoolTest

open NUnit.Framework
open GradeSchool

[<Test>]
let ``Empty school has an empty roster`` () =
    let school = empty
    Assert.That(roster school, Is.Empty)

[<Test>]
[<Ignore("Remove to run test")>]
let ``Adding a student adds them to the roster for the given grade`` () =
    let school = empty |> add "Aimee" 2
    let expected = ["Aimee"]
    Assert.That(grade 2 school, Is.EqualTo(expected))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Adding more students to the same grade adds them to the roster`` () =
    let school = 
        empty
        |> add "Blair" 2
        |> add "James" 2
        |> add "Paul" 2
    let expected = ["Blair"; "James"; "Paul"]
    Assert.That(grade 2 school, Is.EqualTo(expected))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Adding students to different grades adds them to the roster`` () =
    let school = 
        empty
        |> add "Chelsea" 3
        |> add "Logan" 7
    Assert.That(grade 3 school, Is.EqualTo(["Chelsea"]))
    Assert.That(grade 7 school, Is.EqualTo(["Logan"]))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Grade returns the students in that grade in alphabetical order`` () =
    let school = 
        empty
        |> add "Franklin" 5
        |> add "Bradley" 5
        |> add "Jeff" 1
    let expected = ["Bradley"; "Franklin"]
    Assert.That(grade 5 school, Is.EqualTo(expected))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Grade returns an empty list if there are no students in that grade`` () =
    let school = empty
    Assert.That(grade 1 school, Is.EqualTo([]))

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

    Assert.That(roster school, Is.EqualTo(expected))