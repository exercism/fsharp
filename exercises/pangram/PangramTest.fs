module PangramTest

open Xunit
open FsUnit

open Pangram

[<Test>]
let ``Empty sentence`` () =
    let input = ""
    isPangram input |> should equal false

[<Test>]
[<Ignore("Remove to run test")>]
let ``Pangram with only lower case`` () =
    let input = "the quick brown fox jumps over the lazy dog"
    isPangram input |> should equal true

[<Test>]
[<Ignore("Remove to run test")>]
let ``Missing character 'x'`` () =
    let input = "a quick movement of the enemy will jeopardize five gunboats"
    isPangram input |> should equal false

[<Test>]
[<Ignore("Remove to run test")>]
let ``Another missing character 'x'`` () =
    let input = "the quick brown fish jumps over the lazy dog"
    isPangram input |> should equal false

[<Test>]
[<Ignore("Remove to run test")>]
let ``Pangram with underscores`` () =
    let input = "the_quick_brown_fox_jumps_over_the_lazy_dog"
    isPangram input |> should equal true

[<Test>]
[<Ignore("Remove to run test")>]
let ``Pangram with numbers`` () =
    let input = "the 1 quick brown fox jumps over the 2 lazy dogs"
    isPangram input |> should equal true

[<Test>]
[<Ignore("Remove to run test")>]
let ``Missing letters replaced by numbers`` () =
    let input = "7h3 qu1ck brown fox jumps ov3r 7h3 lazy dog"
    isPangram input |> should equal false
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Pangram with mixed case and punctuation`` () =
    let input = "\"Five quacking Zephyrs jolt my wax bed.\""
    isPangram input |> should equal true

[<Test>]
[<Ignore("Remove to run test")>]
let ``Pangram with non ascii characters`` () =
    let input = "Victor jagt zwölf Boxkämpfer quer über den großen Sylter Deich."
    isPangram input |> should equal true

[<Test>]
[<Ignore("Remove to run test")>]
let ``Panagram in alphabet other than ASCII`` () =
    let input = "Широкая электрификация южных губерний даст мощный толчок подъёму сельского хозяйства."
    isPangram input |> should equal false
    
