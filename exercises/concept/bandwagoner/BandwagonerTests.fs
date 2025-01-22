source("./bandwagoner.R")
library(testthat)

[<Task(2)>]
let ``Create coach that was a former player`` () =
    createCoach "Steve Kerr" true
    |> should equal
           { Name = "Steve Kerr"
             FormerPlayer = true }

[<Task(2)>]
let ``Create coach that wasn't a former player`` () =
    createCoach "Erik Spoelstra" false
    |> should equal
           { Name = "Erik Spoelstra"
             FormerPlayer = false }

[<Task(3)>]
let ``Create stats for winning team`` () =
    createStats 55 27
    |> should equal { Wins = 55; Losses = 27 }

[<Task(3)>]
let ``Create stats for losing team`` () =
    createStats 39 43
    |> should equal { Wins = 39; Losses = 43 }

[<Task(3)>]
let ``Create stats for all-time season record`` () =
    createStats 73 9
    |> should equal { Wins = 73; Losses = 9 }

[<Task(4)>]
let ``Create 60's team`` () =
    coach <- createCoach "Red Auerbach" false
    stats <- createStats 58 22
    team <- createTeam "Boston Celtics" coach stats

    team
    |> should equal
           { Name = "Boston Celtics"
             Coach =
                 { Name = "Red Auerbach"
                   FormerPlayer = false }
             Stats = { Wins = 58; Losses = 22 } }

[<Task(4)>]
let ``Create 2010's team`` () =
    coach <- createCoach "Rick Carlisle" false
    stats <- createStats 57 25

    team <-
        createTeam "Dallas Mavericks" coach stats

    team
    |> should equal
           { Name = "Dallas Mavericks"
             Coach =
                 { Name = "Rick Carlisle"
                   FormerPlayer = false }
             Stats = { Wins = 57; Losses = 25 } }

[<Task(5)>]
let ``Replace coach mid-season`` () =
    oldCoach <- createCoach "Willis Reed" true
    newCoach <- createCoach "Red Holzman" true
    stats <- createStats 6 8

    team <-
        createTeam "New York Knicks" oldCoach stats

    replaceCoach team newCoach
    |> should equal
           { Name = "New York Knicks"
             Coach =
                 { Name = "Red Holzman"
                   FormerPlayer = true }
             Stats = { Wins = 6; Losses = 8 } }

[<Task(5)>]
let ``Replace coach after season`` () =
    oldCoach <- createCoach "Rudy Tomjanovich" true
    newCoach <- createCoach "Jeff van Gundy" true
    stats <- createStats 43 39

    team <-
        createTeam "Houston Rockets" oldCoach stats

    replaceCoach team newCoach
    |> should equal
           { Name = "Houston Rockets"
             Coach =
                 { Name = "Jeff van Gundy"
                   FormerPlayer = true }
             Stats = { Wins = 43; Losses = 39 } }

[<Task(6)>]
let ``Same team is duplicate`` () =
    coach <- createCoach "Pat Riley" true
    stats <- createStats 57 25
    team <- createTeam "Los Angeles Lakers" coach stats

    isSameTeam team team
    |> should equal true

[<Task(6)>]
let ``Same team with different stats is not a duplicate`` () =
    coach <- createCoach "Pat Riley" true
    stats <- createStats 57 25
    team <- createTeam "Los Angeles Lakers" coach stats
    
    newStats <- createStats 62 20
    teamWithDifferentStats <- createTeam "Los Angeles Lakers" coach newStats

    isSameTeam team teamWithDifferentStats
    |> should equal false

[<Task(6)>]
let ``Same team with different coach is not a duplicate`` () =
    coach <- createCoach "Pat Riley" true    
    stats <- createStats 33 39    
    team <- createTeam "Los Angeles Lakers" coach stats
    
    newCoach <- createCoach "John Kundla" true
    teamWithDifferentCoach <- createTeam "Los Angeles Lakers" newCoach stats

    isSameTeam team teamWithDifferentCoach
    |> should equal false

[<Task(6)>]
let ``Different team with same coach and stats`` () =
    stats <- createStats 0 0
    coach <- createCoach "Mike d'Antoni" true
    
    team <- createTeam "Denver Nuggets" coach stats
    otherTeam <- createTeam "Phoenix Suns" coach stats

    isSameTeam team otherTeam
    |> should equal false

[<Task(6)>]
let ``Different team with different coach and stats`` () =
    stats <- createStats 42 40
    coach <- createCoach "Dave Joerger" true    
    team <- createTeam "Memphis Grizzlies" coach stats
    
    otherStats <- createStats 63 19
    otherCoach <- createCoach "Larry Costello" true
    otherTeam <- createTeam "Milwaukee Bucks" otherCoach otherStats

    isSameTeam team otherTeam
    |> should equal false

[<Task(7)>]
let ``Root for team with favorite coach and winning stats`` () =
    stats <- createStats 60 22
    coach <- createCoach "Gregg Popovich" false    
    team <- createTeam "San Antonio Spurs" coach stats

    rootForTeam team
    |> should equal true    

[<Task(7)>]
let ``Root for team with favorite coach and losing stats`` () =
    stats <- createStats 17 47
    coach <- createCoach "Gregg Popovich" false    
    team <- createTeam "San Antonio Spurs" coach stats

    rootForTeam team
    |> should equal true    

[<Task(7)>]
let ``Root for team with coach is former player and winning stats`` () =
    stats <- createStats 49 33
    coach <- createCoach "Jack Ramsay" true    
    team <- createTeam "Portland Trail Blazers" coach stats

    rootForTeam team
    |> should equal true    

[<Task(7)>]
let ``Root for team with coach is former player and losing stats`` () =
    stats <- createStats 0 7
    coach <- createCoach "Jack Ramsay" true    
    team <- createTeam "Indiana Pacers" coach stats

    rootForTeam team
    |> should equal true  

[<Task(7)>]
let ``Root for favorite team and winning stats`` () =
    stats <- createStats 61 21
    coach <- createCoach "Phil Jackson" true    
    team <- createTeam "Chicago Bulls" coach stats

    rootForTeam team
    |> should equal true

[<Task(7)>]
let ``Root for favorite team and losing stats`` () =
    stats <- createStats 24 58
    coach <- createCoach "Dick Motta" false    
    team <- createTeam "Chicago Bulls" coach stats

    rootForTeam team
    |> should equal true

[<Task(7)>]
let ``Root for team with sixty or more wins and former player coach`` () =
    stats <- createStats 65 17
    coach <- createCoach "Billy Cunningham" true    
    team <- createTeam "Philadelphia 76'ers" coach stats

    rootForTeam team
    |> should equal true

[<Task(7)>]
let ``Root for team with sixty or more wins and non former player coach`` () =
    stats <- createStats 60 22
    coach <- createCoach "Mike Budenholzer" false    
    team <- createTeam "Milwaukee Bucks" coach stats

    rootForTeam team
    |> should equal true

[<Task(7)>]
let ``Root for team with more losses than wins and former player coach`` () =
    stats <- createStats 40 42
    coach <- createCoach "Wes Unseld" true    
    team <- createTeam "Washington Bullets" coach stats

    rootForTeam team
    |> should equal true

[<Task(7)>]
let ``Root for team with more losses than wins and non former player coach`` () =
    stats <- createStats 29 43
    coach <- createCoach "Kenny Atkinson" false    
    team <- createTeam "Rochester Royals" coach stats

    rootForTeam team
    |> should equal true

[<Task(7)>]
let ``Don't root for team not matching criteria`` () =
    stats <- createStats 51 31
    coach <- createCoach "Frank Layden" false    
    team <- createTeam "Utah Jazz" coach stats

    rootForTeam team
    |> should equal false
