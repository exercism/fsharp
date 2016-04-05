module ConnectTest

open NUnit.Framework
open System

open Connect

let makeBoard (board: string list) = 
    board
    |> List.map (fun x -> x.Replace(" ", ""))
    |> List.reduce (fun x y -> x + "\n" + y)

[<Test>]
let ``Empty board has no winner`` () =
    let lines = [". . . . .    ";
                 " . . . . .   ";
                 "  . . . . .  ";
                 "   . . . . . ";
                 "    . . . . ."]
    let board = makeBoard lines
    Assert.That(resultFor board, Is.EqualTo(None))

[<Test>]
[<Ignore("Remove to run test")>]
let ``1x1 board with black stone`` () =
    let lines = ["X"]
    let board = makeBoard lines  
    Assert.That(resultFor board, Is.EqualTo(Some Black))

[<Test>]
[<Ignore("Remove to run test")>]
let ``1x1 board with white stone`` () =
    let lines = ["O"]
    let board = makeBoard lines  
    Assert.That(resultFor board, Is.EqualTo(Some White))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Convoluted path`` () =
    let lines = [". X X . .    ";
                 " X . X . X   ";
                 "  . X . X .  ";
                 "   . X X . . ";
                 "    O O O O O"]
    let board = makeBoard lines  
    Assert.That(resultFor board, Is.EqualTo(Some Black))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Rectangle, black wins`` () =
    let lines = [". O . .    ";
                 " O X X X   ";
                 "  O X O .  ";
                 "   X X O X ";
                 "    . O X ."]
    let board = makeBoard lines  
    Assert.That(resultFor board, Is.EqualTo(Some Black))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Rectangle, white wins`` () =
    let lines = [". O . .    ";
                 " O X X X   ";
                 "  O O O .  ";
                 "   X X O X ";
                 "    . O X ."]
    let board = makeBoard lines  
    Assert.That(resultFor board, Is.EqualTo(Some White))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Spiral, black wins`` () =
    let lines = ["OXXXXXXXX";
                 "OXOOOOOOO";
                 "OXOXXXXXO";
                 "OXOXOOOXO";
                 "OXOXXXOXO";
                 "OXOOOXOXO";
                 "OXXXXXOXO";
                 "OOOOOOOXO";
                 "XXXXXXXXO"]
    let board = makeBoard lines
    Assert.That(resultFor board, Is.EqualTo(Some Black))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Spiral, nobody wins`` () =
    let lines = ["OXXXXXXXX";
                 "OXOOOOOOO";
                 "OXOXXXXXO";
                 "OXOXOOOXO";
                 "OXOX.XOXO";
                 "OXOOOXOXO";
                 "OXXXXXOXO";
                 "OOOOOOOXO";
                 "XXXXXXXXO"]
    let board = makeBoard lines
    Assert.That(resultFor board, Is.EqualTo(None))