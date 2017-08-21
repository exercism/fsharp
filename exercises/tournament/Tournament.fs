module Tournament

open System.Text.RegularExpressions

type Team = string
type Result = Win | Draw | Loss
type MatchResult = { team: Team; result: Result }
type TeamResults = { name: Team; played: int; wins: int; draws: int; losses: int; points: int }
type Standings = Map<Team, TeamResults>

let invertResult =
    function
    | Win  -> Loss
    | Draw -> Draw
    | Loss -> Win

let parseResult =
    function
    | "win"  -> Win
    | "draw" -> Draw
    | "loss" -> Loss
    | _ -> failwith "Invalid game result"
        
let parseTeamResults (m: Match) = 
    let result = parseResult m.Groups.[3].Value
    [ { team = m.Groups.[1].Value; result = result };
      { team = m.Groups.[2].Value; result = invertResult result } ]

let parseGame line = 
    let m = Regex.Match(line, "(.+?);(.+?);(win|draw|loss)")
    match m.Success with
    | false -> None
    | true  -> Some (parseTeamResults m)
    
let emptyTeamResult team = { name = team; played = 0; wins = 0; draws = 0; losses = 0; points = 0 }
    
let updateTeamResult teamResult =
    function
    | Win  -> { teamResult with played = teamResult.played + 1; wins   = teamResult.wins   + 1; points = teamResult.points + 3 }
    | Draw -> { teamResult with played = teamResult.played + 1; draws  = teamResult.draws  + 1; points = teamResult.points + 1 }
    | Loss -> { teamResult with played = teamResult.played + 1; losses = teamResult.losses + 1 }
 
let compareTeamResults { name = team1; points = points1; wins = wins1 } { name = team2; points = points2; wins = wins2 } =
    match compare points2 points1 with
    | 0 -> 
        match compare wins2 wins1 with
        | 0 -> compare team1 team2
        | a -> a
    | z -> z
    
let calculateStandings (games: MatchResult list) =
    let folder acc { team = team; result = result } =
        let currentTeamResult = defaultArg (Map.tryFind team acc) (emptyTeamResult team)
        Map.add team (updateTeamResult currentTeamResult result) acc

    games
    |> List.fold folder Map.empty<Team, TeamResults>
    |> Map.toList
    |> List.map snd
    |> List.sortWith compareTeamResults

let formatTeamResult teamResult =  
    sprintf "%-30s | %2i | %2i | %2i | %2i | %2i" teamResult.name teamResult.played teamResult.wins teamResult.draws teamResult.losses teamResult.points

let formatTable standings = 
    let header =  sprintf "%-30s | %2s | %2s | %2s | %2s | %2s" "Team" "MP" "W" "D" "L" "P"
    let teams = standings |> List.map formatTeamResult
    header::teams
    
let tally (input: string list) = 
    input
    |> List.choose parseGame
    |> List.concat
    |> calculateStandings
    |> formatTable