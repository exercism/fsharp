import "all_your_base"

let ``Single bit one to decimal`` () =
    let digits = [1]
    let input_base = 2
    let output_base = 10
    let expected = Some [1]
    rebase digits inputBase outputBase |> should equal expected

let ``Binary to single decimal`` () =
    let digits = [1, 0, 1]
    let input_base = 2
    let output_base = 10
    let expected = Some [5]
    rebase digits inputBase outputBase |> should equal expected

let ``Single decimal to binary`` () =
    let digits = [5]
    let input_base = 10
    let output_base = 2
    let expected = Some [1, 0, 1]
    rebase digits inputBase outputBase |> should equal expected

let ``Binary to multiple decimal`` () =
    let digits = [1, 0, 1, 0, 1, 0]
    let input_base = 2
    let output_base = 10
    let expected = Some [4, 2]
    rebase digits inputBase outputBase |> should equal expected

let ``Decimal to binary`` () =
    let digits = [4, 2]
    let input_base = 10
    let output_base = 2
    let expected = Some [1, 0, 1, 0, 1, 0]
    rebase digits inputBase outputBase |> should equal expected

let ``Trinary to hexadecimal`` () =
    let digits = [1, 1, 2, 0]
    let input_base = 3
    let output_base = 16
    let expected = Some [2, 10]
    rebase digits inputBase outputBase |> should equal expected

let ``Hexadecimal to trinary`` () =
    let digits = [2, 10]
    let input_base = 16
    let output_base = 3
    let expected = Some [1, 1, 2, 0]
    rebase digits inputBase outputBase |> should equal expected

let ``15-bit integer`` () =
    let digits = [3, 46, 60]
    let input_base = 97
    let output_base = 73
    let expected = Some [6, 10, 45]
    rebase digits inputBase outputBase |> should equal expected

let ``Empty list`` () =
    let digits = []
    let input_base = 2
    let output_base = 10
    let expected = Some [0]
    rebase digits inputBase outputBase |> should equal expected

let ``Single zero`` () =
    let digits = [0]
    let input_base = 10
    let output_base = 2
    let expected = Some [0]
    rebase digits inputBase outputBase |> should equal expected

let ``Multiple zeros`` () =
    let digits = [0, 0, 0]
    let input_base = 10
    let output_base = 2
    let expected = Some [0]
    rebase digits inputBase outputBase |> should equal expected

let ``Leading zeros`` () =
    let digits = [0, 6, 0]
    let input_base = 7
    let output_base = 10
    let expected = Some [4, 2]
    rebase digits inputBase outputBase |> should equal expected

let ``Input base is one`` () =
    let digits = [0]
    let input_base = 1
    let output_base = 10
    let expected = None
    rebase digits inputBase outputBase |> should equal expected

let ``Input base is zero`` () =
    let digits = []
    let input_base = 0
    let output_base = 10
    let expected = None
    rebase digits inputBase outputBase |> should equal expected

let ``Input base is negative`` () =
    let digits = [1]
    let input_base = -2
    let output_base = 10
    let expected = None
    rebase digits inputBase outputBase |> should equal expected

let ``Negative digit`` () =
    let digits = [1; -1, 1, 0, 1, 0]
    let input_base = 2
    let output_base = 10
    let expected = None
    rebase digits inputBase outputBase |> should equal expected

let ``Invalid positive digit`` () =
    let digits = [1, 2, 1, 0, 1, 0]
    let input_base = 2
    let output_base = 10
    let expected = None
    rebase digits inputBase outputBase |> should equal expected

let ``Output base is one`` () =
    let digits = [1, 0, 1, 0, 1, 0]
    let input_base = 2
    let output_base = 1
    let expected = None
    rebase digits inputBase outputBase |> should equal expected

let ``Output base is zero`` () =
    let digits = [7]
    let input_base = 10
    let output_base = 0
    let expected = None
    rebase digits inputBase outputBase |> should equal expected

let ``Output base is negative`` () =
    let digits = [1]
    let input_base = 2
    let output_base = -7
    let expected = None
    rebase digits inputBase outputBase |> should equal expected

let ``Both bases are negative`` () =
    let digits = [1]
    let input_base = -2
    let output_base = -7
    let expected = None
    rebase digits inputBase outputBase |> should equal expected

