module GradeSchoolTests

open FsUnit.Xunit
open Xunit

open GradeSchool

let studentsToSchool (students: List<string*int>):School =
    let schoolFolder school (name,grade) =
        add name grade school
    List.fold schoolFolder empty students

[<Fact>]
let ``Roster is empty when no student is added`` () =
    let school = studentsToSchool []
    roster school |> should be Empty

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Add a student`` () =
    add [["Aimee"; 2]] |> should equal [true]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Student is added to the roster`` () =
    let school = studentsToSchool [("Aimee", 2)]
    roster school |> should equal ["Aimee"]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Adding multiple students in the same grade in the roster`` () =
    add [["Blair"; 2]; ["James"; 2]; ["Paul"; 2]] |> should equal [true; true; true]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Multiple students in the same grade are added to the roster`` () =
    let school = studentsToSchool [("Blair", 2); ("James", 2); ("Paul", 2)]
    roster school |> should equal ["Blair"; "James"; "Paul"]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Cannot add student to same grade in the roster more than once`` () =
    add [["Blair"; 2]; ["James"; 2]; ["James"; 2]; ["Paul"; 2]] |> should equal [true; true; false; true]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Student not added to same grade in the roster more than once`` () =
    let school = studentsToSchool [("Blair", 2); ("James", 2); ("James", 2); ("Paul", 2)]
    roster school |> should equal ["Blair"; "James"; "Paul"]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Adding students in multiple grades`` () =
    add [["Chelsea"; 3]; ["Logan"; 7]] |> should equal [true; true]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Students in multiple grades are added to the roster`` () =
    let school = studentsToSchool [("Chelsea", 3); ("Logan", 7)]
    roster school |> should equal ["Chelsea"; "Logan"]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Cannot add same student to multiple grades in the roster`` () =
    add [["Blair"; 2]; ["James"; 2]; ["James"; 3]; ["Paul"; 3]] |> should equal [true; true; false; true]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Student not added to multiple grades in the roster`` () =
    let school = studentsToSchool [("Blair", 2); ("James", 2); ("James", 3); ("Paul", 3)]
    roster school |> should equal ["Blair"; "James"; "Paul"]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Students are sorted by grades in the roster`` () =
    let school = studentsToSchool [("Jim", 3); ("Peter", 2); ("Anna", 1)]
    roster school |> should equal ["Anna"; "Peter"; "Jim"]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Students are sorted by name in the roster`` () =
    let school = studentsToSchool [("Peter", 2); ("Zoe", 2); ("Alex", 2)]
    roster school |> should equal ["Alex"; "Peter"; "Zoe"]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Students are sorted by grades and then by name in the roster`` () =
    let school = studentsToSchool [("Peter", 2); ("Anna", 1); ("Barb", 1); ("Zoe", 2); ("Alex", 2); ("Jim", 3); ("Charlie", 1)]
    roster school |> should equal ["Anna"; "Barb"; "Charlie"; "Alex"; "Peter"; "Zoe"; "Jim"]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Grade is empty if no students in the roster`` () =
    let school = studentsToSchool []
    grade 1 school |> should be Empty

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Grade is empty if no students in that grade`` () =
    let school = studentsToSchool [("Peter", 2); ("Zoe", 2); ("Alex", 2); ("Jim", 3)]
    grade 1 school |> should be Empty

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Student not added to same grade more than once`` () =
    let school = studentsToSchool [("Blair", 2); ("James", 2); ("James", 2); ("Paul", 2)]
    grade 2 school |> should equal ["Blair"; "James"; "Paul"]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Student not added to multiple grades`` () =
    let school = studentsToSchool [("Blair", 2); ("James", 2); ("James", 3); ("Paul", 3)]
    grade 2 school |> should equal ["Blair"; "James"]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Student not added to other grade for multiple grades`` () =
    let school = studentsToSchool [("Blair", 2); ("James", 2); ("James", 3); ("Paul", 3)]
    grade 3 school |> should equal ["Paul"]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Students are sorted by name in a grade`` () =
    let school = studentsToSchool [("Franklin", 5); ("Bradley", 5); ("Jeff", 1)]
    grade 5 school |> should equal ["Bradley"; "Franklin"]

