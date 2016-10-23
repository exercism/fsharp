module BowlingTest

open NUnit.Framework

open Bowling

let rollMany rolls game = List.fold (fun game pins -> roll pins game) game rolls

[<Test>]
let ``Should be able to score a game with all zeros`` () =
    let rolls = [0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0]
    let game = rollMany rolls newGame
    Assert.That(score game, Is.EqualTo(Some 0))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Should be able to score a game with no strikes or spares`` () =
    let rolls = [3; 6; 3; 6; 3; 6; 3; 6; 3; 6; 3; 6; 3; 6; 3; 6; 3; 6; 3; 6]
    let game = rollMany rolls newGame
    Assert.That(score game, Is.EqualTo(Some 90))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``A spare followed by zeros is worth ten points`` () =
    let rolls = [6; 4; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0]
    let game = rollMany rolls newGame
    Assert.That(score game, Is.EqualTo(Some 10))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Points scored in the roll after a spare are counted twice`` () =
    let rolls = [6; 4; 3; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0]
    let game = rollMany rolls newGame
    Assert.That(score game, Is.EqualTo(Some 16))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Consecutive spares each get a one roll bonus`` () =
    let rolls = [5; 5; 3; 7; 4; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0]
    let game = rollMany rolls newGame
    Assert.That(score game, Is.EqualTo(Some 31))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``A spare in the last frame gets a one roll bonus that is counted once`` () =
    let rolls = [0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 7; 3; 7]
    let game = rollMany rolls newGame
    Assert.That(score game, Is.EqualTo(Some 17))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``A strike earns ten points in frame with a single roll`` () =
    let rolls = [10; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0]
    let game = rollMany rolls newGame
    Assert.That(score game, Is.EqualTo(Some 10))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Points scored in the two rolls after a strike are counted twice as a bonus`` () =
    let rolls = [10; 5; 3; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0]
    let game = rollMany rolls newGame
    Assert.That(score game, Is.EqualTo(Some 26))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Consecutive strikes each get the two roll bonus`` () =
    let rolls = [10; 10; 10; 5; 3; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0]
    let game = rollMany rolls newGame
    Assert.That(score game, Is.EqualTo(Some 81))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``A strike in the last frame gets a two roll bonus that is counted once`` () =
    let rolls = [0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 10; 7; 1]
    let game = rollMany rolls newGame
    Assert.That(score game, Is.EqualTo(Some 18))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Rolling a spare with the two roll bonus does not get a bonus roll`` () =
    let rolls = [0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 10; 7; 3]
    let game = rollMany rolls newGame
    Assert.That(score game, Is.EqualTo(Some 20))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Strikes with the two roll bonus do not get bonus rolls`` () =
    let rolls = [0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 10; 10; 10]
    let game = rollMany rolls newGame
    Assert.That(score game, Is.EqualTo(Some 30))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``A strike with the one roll bonus after a spare in the last frame does not get a bonus`` () =
    let rolls = [0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 7; 3; 10]
    let game = rollMany rolls newGame
    Assert.That(score game, Is.EqualTo(Some 20))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``All strikes is a perfect game`` () =
    let rolls = [10; 10; 10; 10; 10; 10; 10; 10; 10; 10; 10; 10]
    let game = rollMany rolls newGame
    Assert.That(score game, Is.EqualTo(Some 300))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Rolls can not score negative points`` () =
    let rolls = [-1; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0]
    let game = rollMany rolls newGame
    Assert.That(score game, Is.EqualTo(None))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``A roll can not score more than 10 points`` () =
    let rolls = [11; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0]
    let game = rollMany rolls newGame
    Assert.That(score game, Is.EqualTo(None))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Two rolls in a frame can not score more than 10 points`` () =
    let rolls = [5; 6; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0]
    let game = rollMany rolls newGame
    Assert.That(score game, Is.EqualTo(None))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Two bonus rolls after a strike in the last frame can not score more than 10 points`` () =
    let rolls = [0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 10; 5; 6]
    let game = rollMany rolls newGame
    Assert.That(score game, Is.EqualTo(None))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``An unstarted game can not be scored`` () =
    let rolls = []
    let game = rollMany rolls newGame
    Assert.That(score game, Is.EqualTo(None))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``An incomplete game can not be scored`` () =
    let rolls = [0; 0]
    let game = rollMany rolls newGame
    Assert.That(score game, Is.EqualTo(None))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``A game with more than ten frames can not be scored`` () =
    let rolls = [0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0]
    let game = rollMany rolls newGame
    Assert.That(score game, Is.EqualTo(None))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Bonus rolls for a strike in the last frame must be rolled before score can be calculated`` () =
    let rolls = [0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 10]
    let game = rollMany rolls newGame
    Assert.That(score game, Is.EqualTo(None))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Both bonus rolls for a strike in the last frame must be rolled before score can be calculated`` () =
    let rolls = [0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 10; 10]
    let game = rollMany rolls newGame
    Assert.That(score game, Is.EqualTo(None))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Bonus roll for a spare in the last frame must be rolled before score can be calculated`` () =
    let rolls = [0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 7; 3]
    let game = rollMany rolls newGame
    Assert.That(score game, Is.EqualTo(None))