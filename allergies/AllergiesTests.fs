module AllergiesTests

open System
open NUnit.Framework
open Allergies

[<TestFixture>]
type AllergiesTests() =

    [<Test>]
    member tests.No_allergies_means_not_allergic() =
        let allergies = Allergies(0);
        Assert.That(allergies.allergicTo(Allergen.Peanuts), Is.False);
        Assert.That(allergies.allergicTo(Allergen.Cats), Is.False);
        Assert.That(allergies.allergicTo(Allergen.Strawberries), Is.False)

    [<Test>]
    [<Ignore>]
    member tests.Allergic_to_eggs() =
        let allergies = Allergies(1);
        Assert.That(allergies.allergicTo(Allergen.Eggs), Is.True)

    [<Test>]
    [<Ignore>]
    member tests.Allergic_to_eggs_in_addition_to_other_stuff() =
        let allergies = Allergies(5);
        Assert.That(allergies.allergicTo(Allergen.Eggs), Is.True);
        Assert.That(allergies.allergicTo(Allergen.Shellfish), Is.True);
        Assert.That(allergies.allergicTo(Allergen.Strawberries), Is.False)

    [<Test>]
    [<Ignore>]
    member tests.No_allergies_at_all() =
        let allergies = Allergies(0);
        Assert.That(allergies.list(), Is.Empty)

    [<Test>]
    [<Ignore>]
    member tests.Allergic_to_just_eggs() =
        let allergies = Allergies(1);
        Assert.That(allergies.list(), Is.EqualTo([Allergen.Eggs]))

    [<Test>]
    [<Ignore>]
    member tests.Allergic_to_just_peanuts() =
        let allergies = Allergies(2);
        Assert.That(allergies.list(), Is.EqualTo([Allergen.Peanuts]))

    [<Test>]
    [<Ignore>]
    member tests.Allergic_to_eggs_and_peanuts() =
        let allergies = Allergies(3);
        Assert.That(allergies.list(), Is.EqualTo([Allergen.Eggs; Allergen.Peanuts]))

    [<Test>]
    [<Ignore>]
    member tests.Allergic_to_lots_of_stuff() =
        let allergies = Allergies(248);
        Assert.That(allergies.list(),
            Is.EqualTo([Allergen.Strawberries; Allergen.Tomatoes; Allergen.Chocolate; Allergen.Pollen; Allergen.Cats]))

    [<Test>]
    [<Ignore>]
    member tests.Allergic_to_everything() =
        let allergies = Allergies(255);
        Assert.That(allergies.list(),
            Is.EqualTo([Allergen.Eggs;
                        Allergen.Peanuts;
                        Allergen.Shellfish;
                        Allergen.Strawberries;
                        Allergen.Tomatoes;
                        Allergen.Chocolate;
                        Allergen.Pollen;
                        Allergen.Cats]))

    [<Test>]
    [<Ignore>]
    member tests.Ignore_non_allergen_score_parts() =
        let allergies = Allergies(509);
        Assert.That(allergies.list(),
            Is.EqualTo([Allergen.Eggs;
                        Allergen.Shellfish;
                        Allergen.Strawberries;
                        Allergen.Tomatoes;
                        Allergen.Chocolate;
                        Allergen.Pollen;
                        Allergen.Cats]))