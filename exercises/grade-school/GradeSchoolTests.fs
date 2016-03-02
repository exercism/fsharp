module GradeSchoolTests

open NUnit.Framework
open School

type GradeSchoolTests() = 
    [<Test>]
    member tests.New_school_has_an_empty_roster() =
        let school = new School()
        Assert.That(school.roster, Has.Count.EqualTo(0))

    [<Test>]
    [<Ignore>]
    member tests.adding_a_student_adds_them_to_the_roster_for_the_given_grade() =
        let school = new School()
        school.add("Aimee", 2) |> ignore
        let expected = ["Aimee"]
        Assert.That(school.roster.[2], Is.EqualTo(expected))

    [<Test>]
    [<Ignore>]
    member tests.adding_more_students_to_the_same_grade_adds_them_to_the_roster() =
        let school = new School()
        school.add("Blair", 2) |> ignore
        school.add("James", 2) |> ignore
        school.add("Paul", 2) |> ignore
        let expected = ["Blair"; "James"; "Paul"]
        Assert.That(school.roster.[2], Is.EqualTo(expected))

    [<Test>]
    [<Ignore>]
    member tests.adding_students_to_different_grades_adds_them_to_the_roster() =
        let school = new School()
        school.add("Chelsea", 3) |> ignore
        school.add("Logan", 7) |> ignore
        Assert.That(school.roster.[3], Is.EqualTo(["Chelsea"]))
        Assert.That(school.roster.[7], Is.EqualTo(["Logan"]))

    [<Test>]
    [<Ignore>]
    member tests.Grade_returns_the_students_in_that_grade_in_alphabetical_order() =
        let school = new School()
        school.add("Franklin", 5) |> ignore
        school.add("Bradley", 5) |> ignore
        school.add("Jeff", 1) |> ignore
        let expected = ["Bradley"; "Franklin"]
        Assert.That(school.grade(5), Is.EqualTo(expected))

    [<Test>]
    [<Ignore>]
    member tests.Grade_returns_an_empty_list_if_there_are_no_students_in_that_grade() =
        let school = new School()
        Assert.That(school.grade(1), Is.EqualTo([]))

    [<Test>]
    [<Ignore>]
    member tests.Student_names_in_each_grade_in_roster_are_sorted() =
        let school = new School()
        school.add("Jennifer", 4) |> ignore
        school.add("Kareem", 6) |> ignore
        school.add("Christopher", 4) |> ignore
        school.add("Kyle", 3) |> ignore
        Assert.That(school.roster.[3], Is.EqualTo(["Kyle"]));
        Assert.That(school.roster.[4], Is.EqualTo(["Christopher"; "Jennifer"]));
        Assert.That(school.roster.[6], Is.EqualTo(["Kareem"]));