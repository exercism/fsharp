module BobTests

open NUnit.Framework
open Bob

[<TestFixture>]
type BobTest() =
    
    [<Test>]
    member tests.Stating_something() =
        Assert.That(Bob("Tom-ay-to, tom-aaaah-to.").hey(), Is.EqualTo("Whatever."))

    [<Test>]
    [<Ignore>]
    member tests.Shouting() =
        Assert.That(Bob("WATCH OUT!").hey(), Is.EqualTo("Whoa, chill out!"))

    [<Test>]
    [<Ignore>]
    member tests.Asking_a_question() =
        Assert.That(Bob("Does this cryogenic chamber make me look fat?").hey(), Is.EqualTo("Sure."))

    [<Test>]
    [<Ignore>]
    member tests.Asking_a_numeric_question() =
        Assert.That(Bob("You are, what, like 15?").hey(), Is.EqualTo("Sure."))

    [<Test>]
    [<Ignore>]
    member tests.Forceful_questions() =
        Assert.That(Bob("WHAT THE HELL WERE YOU THINKING?").hey(), Is.EqualTo("Whoa, chill out!"))

    [<Test>]
    [<Ignore>]
    member tests.Shouting_numbers() =
        Assert.That(Bob("1, 2, 3 GO!").hey(), Is.EqualTo("Whoa, chill out!"))

    [<Test>]
    [<Ignore>]
    member tests.Only_numbers() =
        Assert.That(Bob("1, 2, 3").hey(), Is.EqualTo("Whatever."))

    [<Test>]
    [<Ignore>]
    member tests.Question_only_with_numbers() =
        Assert.That(Bob("4?").hey(), Is.EqualTo("Sure."))

    [<Test>]
    [<Ignore>]
    member tests.Shouting_with_special_characters() =
        Assert.That(Bob("ZOMG THE %^*@#$(*^ ZOMBIES ARE COMING!!11!!1!").hey(), Is.EqualTo("Whoa, chill out!"))

    [<Test>]
    [<Ignore>]
    member tests.Shouting_with_no_exlamation_mark() =
        Assert.That(Bob("I HATE YOU").hey(), Is.EqualTo("Whoa, chill out!"))

    [<Test>]
    [<Ignore>]
    member tests.Statement_containing_question_mark() =
        Assert.That(Bob("Ending with ? means a question.").hey(), Is.EqualTo("Whatever."))

    [<Test>]
    [<Ignore>]
    member tests.Prattling_on() =
        Assert.That(Bob("Wait! Hang on. Are you going to be OK?").hey(), Is.EqualTo("Sure."))

    [<Test>]
    [<Ignore>]
    member tests.Silence() =
        Assert.That(Bob("").hey(), Is.EqualTo("Fine. Be that way!"))

    [<Test>]
    [<Ignore>]
    member tests.Prolonged_silence() =
        Assert.That(Bob("    ").hey(), Is.EqualTo("Fine. Be that way!"))

    [<Test>]
    [<Ignore>]
    member tests.Multiple_line_question() =
        Assert.That(Bob("Does this cryogenic chamber make me look fat?\nno").hey(), Is.EqualTo("Whatever."))
