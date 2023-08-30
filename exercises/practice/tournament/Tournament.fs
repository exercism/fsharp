module Tournament

type Outcome =
    | Win
    | Loss
    | Draw

    static member Invert =
        function
        | Win -> Loss
        | Loss -> Win
        | Draw -> Draw

type Results =
    { Wins: int
      Losses: int
      Draws: int }

    static member Init = { Wins = 0; Losses = 0; Draws = 0 }
    member this.MatchPlayed = this.Wins + this.Losses + this.Draws
    member this.Points = this.Wins * 3 + this.Draws * 1

type Team =
    { Name: string
      Results: Results }

let addOutcome outcome results =
    match outcome with
    | Win -> { results with Wins = results.Wins + 1 }
    | Draw ->
        { results with
            Draws = results.Draws + 1 }
    | Loss ->
        { results with
            Losses = results.Losses + 1 }

let display team =
    let pad input = $"{input, 3}"
    $"{team.Name, -31}|{team.Results.MatchPlayed |> pad} |{team.Results.Wins |> pad} |{team.Results.Draws |> pad} |{team.Results.Losses |> pad} |{team.Results.Points |> pad}"

let getTournamentResults(teams: Team list) =
    let lines =
        teams
        |> List.sortBy (fun team -> -team.Results.Points, team.Name)
        |> List.map display

    let header = "Team                           | MP |  W |  D |  L |  P"
    header :: lines

let processMatch teams homeTeam awayTeam outcome =
    let addResult teamName outcome teams =
        match (teams |> Map.tryFind teamName) with
        | Some results -> teams.Add(teamName, addOutcome outcome results)
        | None -> teams.Add(teamName, addOutcome outcome Results.Init)
        
    teams
    |> List.map (fun team -> team.Name, team.Results)
    |> Map.ofList
    |> addResult homeTeam outcome
    |> addResult awayTeam (outcome |> Outcome.Invert)
    |> Map.toList
    |> List.map (fun (name, results) -> { Name = name; Results = results })

let folder teams (row: string) =
    match row.Split(';') with
    | [| home; away; outcome |] ->
        let outcome =
            match outcome with
            | "win" -> Win
            | "draw" -> Draw
            | "loss" -> Loss
            | _ -> failwith "Invalid outcome!"

        processMatch teams home away outcome
    | _ -> teams

let tally(input: string list) =
    input |> List.fold folder list.Empty |> getTournamentResults
