module TwoFer

let getResponse input =
    sprintf "One for %s, one for me." (defaultArg input "you")