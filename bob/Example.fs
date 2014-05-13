module Bob

type Bob(statement: string) =
    let isSilence(statement: string) =
        System.String.IsNullOrWhiteSpace(statement)
    
    let isYelling(statement: string) =
        statement.ToUpper() = statement && System.Text.RegularExpressions.Regex.IsMatch(statement, "[a-zA-Z]+")

    let isQuestion(statement: string) =
        statement.EndsWith("?")

    member this.Statement = statement

    member this.hey() =
        match isSilence(this.Statement) with
            | true -> "Fine. Be that way!"
            | false -> (match isYelling(this.Statement) with
                            | true -> "Woah, chill out!"
                            | false -> (match isQuestion(this.Statement) with
                                            | true -> "Sure."
                                            | false -> "Whatever."))