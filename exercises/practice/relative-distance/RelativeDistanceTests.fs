module RelativeDistanceTests

open FsUnit.Xunit
open Xunit

open RelativeDistance

[<Fact>]
let ``Direct parent-child relation`` () =
    let familyTree =
        [ ("Vera", [ "Tomoko" ])
          ("Tomoko", [ "Aditi" ]) ]
        |> Map.ofList

    degreeOfSeparation familyTree "Vera" "Tomoko"
    |> should equal
    <| Some 1

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Sibling relationship`` () =
    let familyTree = [ ("Dalia", [ "Olga"; "Yassin" ]) ] |> Map.ofList

    degreeOfSeparation familyTree "Olga" "Yassin"
    |> should equal
    <| Some 1

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Two degrees of separation, grandchild`` () =
    let familyTree =
        [ ("Khadija", [ "Mateo" ])
          ("Mateo", [ "Rami" ]) ]
        |> Map.ofList

    degreeOfSeparation familyTree "Khadija" "Rami"
    |> should equal
    <| Some 2

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Unrelated individuals`` () =
    let familyTree =
        [ ("Priya", [ "Rami" ])
          ("Kaito", [ "Elif" ]) ]
        |> Map.ofList

    degreeOfSeparation familyTree "Priya" "Kaito"
    |> should equal None

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Complex graph, cousins`` () =
    let familyTree =
        [ ("Aiko", [ "Bao"; "Carlos" ])
          ("Bao", [ "Dalia"; "Elias" ])
          ("Carlos", [ "Fatima"; "Gustavo" ])
          ("Dalia", [ "Hassan"; "Isla" ])
          ("Elias", [ "Javier" ])
          ("Fatima", [ "Khadija"; "Liam" ])
          ("Gustavo", [ "Mina" ])
          ("Hassan", [ "Noah"; "Olga" ])
          ("Isla", [ "Pedro" ])
          ("Javier", [ "Quynh"; "Ravi" ])
          ("Khadija", [ "Sofia" ])
          ("Liam", [ "Tariq"; "Uma" ])
          ("Mina", [ "Viktor"; "Wang" ])
          ("Noah", [ "Xiomara" ])
          ("Olga", [ "Yuki" ])
          ("Pedro", [ "Zane"; "Aditi" ])
          ("Quynh", [ "Boris" ])
          ("Ravi", [ "Celine" ])
          ("Sofia", [ "Diego"; "Elif" ])
          ("Tariq", [ "Farah" ])
          ("Uma", [ "Giorgio" ])
          ("Viktor", [ "Hana"; "Ian" ])
          ("Wang", [ "Jing" ])
          ("Xiomara", [ "Kaito" ])
          ("Yuki", [ "Leila" ])
          ("Zane", [ "Mateo" ])
          ("Aditi", [ "Nia" ])
          ("Boris", [ "Oscar" ])
          ("Celine", [ "Priya" ])
          ("Diego", [ "Qi" ])
          ("Elif", [ "Rami" ])
          ("Farah", [ "Sven" ])
          ("Giorgio", [ "Tomoko" ])
          ("Hana", [ "Umar" ])
          ("Ian", [ "Vera" ])
          ("Jing", [ "Wyatt" ])
          ("Kaito", [ "Xia" ])
          ("Leila", [ "Yassin" ])
          ("Mateo", [ "Zara" ])
          ("Nia", [ "Antonio" ])
          ("Oscar", [ "Bianca" ])
          ("Priya", [ "Cai" ])
          ("Qi", [ "Dimitri" ])
          ("Rami", [ "Ewa" ])
          ("Sven", [ "Fabio" ])
          ("Tomoko", [ "Gabriela" ])
          ("Umar", [ "Helena" ])
          ("Vera", [ "Igor" ])
          ("Wyatt", [ "Jun" ])
          ("Xia", [ "Kim" ])
          ("Yassin", [ "Lucia" ])
          ("Zara", [ "Mohammed" ]) ]
        |> Map.ofList

    degreeOfSeparation familyTree "Dimitri" "Fabio"
    |> should equal
    <| Some 9

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Complex graph, no shortcut, far removed nephew`` () =
    let familyTree =
        [ ("Aiko", [ "Bao"; "Carlos" ])
          ("Bao", [ "Dalia"; "Elias" ])
          ("Carlos", [ "Fatima"; "Gustavo" ])
          ("Dalia", [ "Hassan"; "Isla" ])
          ("Elias", [ "Javier" ])
          ("Fatima", [ "Khadija"; "Liam" ])
          ("Gustavo", [ "Mina" ])
          ("Hassan", [ "Noah"; "Olga" ])
          ("Isla", [ "Pedro" ])
          ("Javier", [ "Quynh"; "Ravi" ])
          ("Khadija", [ "Sofia" ])
          ("Liam", [ "Tariq"; "Uma" ])
          ("Mina", [ "Viktor"; "Wang" ])
          ("Noah", [ "Xiomara" ])
          ("Olga", [ "Yuki" ])
          ("Pedro", [ "Zane"; "Aditi" ])
          ("Quynh", [ "Boris" ])
          ("Ravi", [ "Celine" ])
          ("Sofia", [ "Diego"; "Elif" ])
          ("Tariq", [ "Farah" ])
          ("Uma", [ "Giorgio" ])
          ("Viktor", [ "Hana"; "Ian" ])
          ("Wang", [ "Jing" ])
          ("Xiomara", [ "Kaito" ])
          ("Yuki", [ "Leila" ])
          ("Zane", [ "Mateo" ])
          ("Aditi", [ "Nia" ])
          ("Boris", [ "Oscar" ])
          ("Celine", [ "Priya" ])
          ("Diego", [ "Qi" ])
          ("Elif", [ "Rami" ])
          ("Farah", [ "Sven" ])
          ("Giorgio", [ "Tomoko" ])
          ("Hana", [ "Umar" ])
          ("Ian", [ "Vera" ])
          ("Jing", [ "Wyatt" ])
          ("Kaito", [ "Xia" ])
          ("Leila", [ "Yassin" ])
          ("Mateo", [ "Zara" ])
          ("Nia", [ "Antonio" ])
          ("Oscar", [ "Bianca" ])
          ("Priya", [ "Cai" ])
          ("Qi", [ "Dimitri" ])
          ("Rami", [ "Ewa" ])
          ("Sven", [ "Fabio" ])
          ("Tomoko", [ "Gabriela" ])
          ("Umar", [ "Helena" ])
          ("Vera", [ "Igor" ])
          ("Wyatt", [ "Jun" ])
          ("Xia", [ "Kim" ])
          ("Yassin", [ "Lucia" ])
          ("Zara", [ "Mohammed" ]) ]
        |> Map.ofList

    degreeOfSeparation familyTree "Lucia" "Jun"
    |> should equal
    <| Some 14

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Complex graph, some shortcuts, cross-down and cross-up, cousins several times removed, with unrelated family tree``
    ()
    =
    let familyTree =
        [ ("Aiko", [ "Bao"; "Carlos" ])
          ("Bao", [ "Dalia" ])
          ("Carlos", [ "Fatima"; "Gustavo" ])
          ("Dalia", [ "Hassan"; "Isla" ])
          ("Fatima", [ "Khadija"; "Liam" ])
          ("Gustavo", [ "Mina" ])
          ("Hassan", [ "Noah"; "Olga" ])
          ("Isla", [ "Pedro" ])
          ("Javier", [ "Quynh"; "Ravi" ])
          ("Khadija", [ "Sofia" ])
          ("Liam", [ "Tariq"; "Uma" ])
          ("Mina", [ "Viktor"; "Wang" ])
          ("Noah", [ "Xiomara" ])
          ("Olga", [ "Yuki" ])
          ("Pedro", [ "Zane"; "Aditi" ])
          ("Quynh", [ "Boris" ])
          ("Ravi", [ "Celine" ])
          ("Sofia", [ "Diego"; "Elif" ])
          ("Tariq", [ "Farah" ])
          ("Uma", [ "Giorgio" ])
          ("Viktor", [ "Hana"; "Ian" ])
          ("Wang", [ "Jing" ])
          ("Xiomara", [ "Kaito" ])
          ("Yuki", [ "Leila" ])
          ("Zane", [ "Mateo" ])
          ("Aditi", [ "Nia" ])
          ("Boris", [ "Oscar" ])
          ("Celine", [ "Priya" ])
          ("Diego", [ "Qi" ])
          ("Elif", [ "Rami" ])
          ("Farah", [ "Sven" ])
          ("Giorgio", [ "Tomoko" ])
          ("Hana", [ "Umar" ])
          ("Ian", [ "Vera" ])
          ("Jing", [ "Wyatt" ])
          ("Kaito", [ "Xia" ])
          ("Leila", [ "Yassin" ])
          ("Mateo", [ "Zara" ])
          ("Nia", [ "Antonio" ])
          ("Oscar", [ "Bianca" ])
          ("Priya", [ "Cai" ])
          ("Qi", [ "Dimitri" ])
          ("Rami", [ "Ewa" ])
          ("Sven", [ "Fabio" ])
          ("Tomoko", [ "Gabriela" ])
          ("Umar", [ "Helena" ])
          ("Vera", [ "Igor" ])
          ("Wyatt", [ "Jun" ])
          ("Xia", [ "Kim" ])
          ("Yassin", [ "Lucia" ])
          ("Zara", [ "Mohammed" ]) ]
        |> Map.ofList

    degreeOfSeparation familyTree "Wyatt" "Xia"
    |> should equal
    <| Some 12
