module BandwagonerTests

open FsUnit.Xunit
open Xunit
open Exercism.Tests

open Bandwagoner

[<Fact>]
[<Task(2)>]
let ``Create coach that was a former player`` () =
    createCoach "Steve Kerr" true
    |> should equal
           { Name = "Steve Kerr"
             FormerPlayer = true }

[<Fact>]
[<Task(2)>]
let ``Create coach that wasn't a former player`` () =
    createCoach "Erik Spoelstra" false
    |> should equal
           { Name = "Erik Spoelstra"
             FormerPlayer = false }

[<Fact>]
[<Task(3)>]
let ``Create stats for winning team`` () =
    createStats 55 27
    |> should equal { Wins = 55; Losses = 27 }

[<Fact>]
[<Task(3)>]
let ``Create stats for losing team`` () =
    createStats 39 43
    |> should equal { Wins = 39; Losses = 43 }

[<Fact>]
[<Task(3)>]
let ``Create stats for all-time season record`` () =
    createStats 73 9
    |> should equal { Wins = 73; Losses = 9 }

[<Fact>]
[<Task(4)>]
let ``Create 60's team`` () =
    let coach = createCoach "Red Auerbach" false
    let stats = createStats 58 22
    let team = createTeam "Boston Celtics" coach stats

    team
    |> should equal
           { Name = "Boston Celtics"
             Coach =
                 { Name = "Red Auerbach"
                   FormerPlayer = false }
             Stats = { Wins = 58; Losses = 22 } }

[<Fact>]
[<Task(4)>]
let ``Create 2010's team`` () =
    let coach = createCoach "Rick Carlisle" false
    let stats = createStats 57 25

    let team =
        createTeam "Dallas Mavericks" coach stats

    team
    |> should equal
           { Name = "Dallas Mavericks"
             Coach =
                 { Name = "Rick Carlisle"
                   FormerPlayer = false }
             Stats = { Wins = 57; Losses = 25 } }

[<Fact>]
[<Task(5)>]
let ``Replace coach mid-season`` () =
    let oldCoach = createCoach "Willis Reed" true
    let newCoach = createCoach "Red Holzman" true
    let stats = createStats 6 8

    let team =
        createTeam "New York Knicks" oldCoach stats

    replaceCoach team newCoach
    |> should equal
           { Name = "New York Knicks"
             Coach =
                 { Name = "Red Holzman"
                   FormerPlayer = true }
             Stats = { Wins = 6; Losses = 8 } }

[<Fact>]
[<Task(5)>]
let ``Replace coach after season`` () =
    let oldCoach = createCoach "Rudy Tomjanovich" true
    let newCoach = createCoach "Jeff van Gundy" true
    let stats = createStats 43 39

    let team =
        createTeam "Houston Rockets" oldCoach stats

    replaceCoach team newCoach
    |> should equal
           { Name = "Houston Rockets"
             Coach =
                 { Name = "Jeff van Gundy"
                   FormerPlayer = true }
             Stats = { Wins = 43; Losses = 39 } }

[<Fact>]
[<Task(6)>]
let ``Same team is duplicate`` () =
    let coach = createCoach "Pat Riley" true
    let stats = createStats 57 25
    let team = createTeam "Los Angeles Lakers" coach stats

    isSameTeam team team
    |> should equal true

[<Fact>]
[<Task(6)>]
let ``Same team with different stats is not a duplicate`` () =
    let coach = createCoach "Pat Riley" true
    let stats = createStats 57 25
    let team = createTeam "Los Angeles Lakers" coach stats
    
    let newStats = createStats 62 20
    let teamWithDifferentStats = createTeam "Los Angeles Lakers" coach newStats

    isSameTeam team teamWithDifferentStats
    |> should equal false

[<Fact>]
[<Task(6)>]
let ``Same team with different coach is not a duplicate`` () =
    let coach = createCoach "Pat Riley" true    
    let stats = createStats 33 39    
    let team = createTeam "Los Angeles Lakers" coach stats
    
    let newCoach = createCoach "John Kundla" true
    let teamWithDifferentCoach = createTeam "Los Angeles Lakers" newCoach stats

    isSameTeam team teamWithDifferentCoach
    |> should equal false

[<Fact>]
[<Task(6)>]
let ``Different team with same coach and stats`` () =
    let stats = createStats 0 0
    let coach = createCoach "Mike d'Antoni" true
    
    let team = createTeam "Denver Nuggets" coach stats
    let otherTeam = createTeam "Phoenix Suns" coach stats

    isSameTeam team otherTeam
    |> should equal false

[<Fact>]
[<Task(6)>]
let ``Different team with different coach and stats`` () =
    let stats = createStats 42 40
    let coach = createCoach "Dave Joerger" true    
    let team = createTeam "Memphis Grizzlies" coach stats
    
    let otherStats = createStats 63 19
    let otherCoach = createCoach "Larry Costello" true
    let otherTeam = createTeam "Milwaukee Bucks" otherCoach otherStats

    isSameTeam team otherTeam
    |> should equal false

[<Fact>]
[<Task(7)>]
let ``Root for team with favorite coach and winning stats`` () =
    let stats = createStats 60 22
    let coach = createCoach "Gregg Popovich" false    
    let team = createTeam "San Antonio Spurs" coach stats

    rootForTeam team
    |> should equal true    

[<Fact>]
[<Task(7)>]
let ``Root for team with favorite coach and losing stats`` () =
    let stats = createStats 17 47
    let coach = createCoach "Gregg Popovich" false    
    let team = createTeam "San Antonio Spurs" coach stats

    rootForTeam team
    |> should equal true    

[<Fact>]
[<Task(7)>]
let ``Root for team with coach is former player and winning stats`` () =
    let stats = createStats 49 33
    let coach = createCoach "Jack Ramsay" true    
    let team = createTeam "Portland Trail Blazers" coach stats

    rootForTeam team
    |> should equal true    

[<Fact>]
[<Task(7)>]
let ``Root for team with coach is former player and losing stats`` () =
    let stats = createStats 0 7
    let coach = createCoach "Jack Ramsay" true    
    let team = createTeam "Indiana Pacers" coach stats

    rootForTeam team
    |> should equal true  

[<Fact>]
[<Task(7)>]
let ``Root for favorite team and winning stats`` () =
    let stats = createStats 61 21
    let coach = createCoach "Phil Jackson" true    
    let team = createTeam "Chicago Bulls" coach stats

    rootForTeam team
    |> should equal true

[<Fact>]
[<Task(7)>]
let ``Root for favorite team and losing stats`` () =
    let stats = createStats 24 58
    let coach = createCoach "Dick Motta" false    
    let team = createTeam "Chicago Bulls" coach stats

    rootForTeam team
    |> should equal true

[<Fact>]
[<Task(7)>]
let ``Root for team with sixty or more wins and former player coach`` () =
    let stats = createStats 65 17
    let coach = createCoach "Billy Cunningham" true    
    let team = createTeam "Philadelphia 76'ers" coach stats

    rootForTeam team
    |> should equal true

[<Fact>]
[<Task(7)>]
let ``Root for team with sixty or more wins and non former player coach`` () =
    let stats = createStats 60 22
    let coach = createCoach "Mike Budenholzer" false    
    let team = createTeam "Milwaukee Bucks" coach stats

    rootForTeam team
    |> should equal true

[<Fact>]
[<Task(7)>]
let ``Root for team with more losses than wins and former player coach`` () =
    let stats = createStats 40 42
    let coach = createCoach "Wes Unseld" true    
    let team = createTeam "Washington Bullets" coach stats

    rootForTeam team
    |> should equal true

[<Fact>]
[<Task(7)>]
let ``Root for team with more losses than wins and non former player coach`` () =
    let stats = createStats 29 43
    let coach = createCoach "Kenny Atkinson" false    
    let team = createTeam "Rochester Royals" coach stats

    rootForTeam team
    |> should equal true

[<Fact>]
[<Task(7)>]
let ``Don't root for team not matching criteria`` () =
    let stats = createStats 51 31
    let coach = createCoach "Frank Layden" false    
    let team = createTeam "Utah Jazz" coach stats

    rootForTeam team
    |> should equal false
