~ "SOLUTION" ~ Proverb

let ``Zero pieces`` () =
    let strings: string list = []
    let expected: string list = []
    recite strings |> should equal expected

let ``One piece`` () =
    let strings = ["nail"]
    let expected = ["And all for the want of a nail."]
    recite strings |> should equal expected

let ``Two pieces`` () =
    let strings = ["nail"; "shoe"]
    let expected = 
        [ "For want of a nail the shoe was lost.";
          "And all for the want of a nail." ]
    recite strings |> should equal expected

let ``Three pieces`` () =
    let strings = ["nail"; "shoe"; "horse"]
    let expected = 
        [ "For want of a nail the shoe was lost.";
          "For want of a shoe the horse was lost.";
          "And all for the want of a nail." ]
    recite strings |> should equal expected

let ``Full proverb`` () =
    let strings = ["nail"; "shoe"; "horse"; "rider"; "message"; "battle"; "kingdom"]
    let expected = 
        [ "For want of a nail the shoe was lost.";
          "For want of a shoe the horse was lost.";
          "For want of a horse the rider was lost.";
          "For want of a rider the message was lost.";
          "For want of a message the battle was lost.";
          "For want of a battle the kingdom was lost.";
          "And all for the want of a nail." ]
    recite strings |> should equal expected

let ``Four pieces modernized`` () =
    let strings = ["pin"; "gun"; "soldier"; "battle"]
    let expected = 
        [ "For want of a pin the gun was lost.";
          "For want of a gun the soldier was lost.";
          "For want of a soldier the battle was lost.";
          "And all for the want of a pin." ]
    recite strings |> should equal expected

