module House

let subjects = 
    [("house that Jack built", "lay in");
     ("malt", "ate");
     ("rat", "killed");
     ("cat", "worried");
     ("dog", "tossed");
     ("cow with the crumpled horn", "milked");
     ("maiden all forlorn", "kissed");
     ("man all tattered and torn", "married");
     ("priest all shaven and shorn", "woke");
     ("rooster that crowed in the morn", "kept");
     ("farmer sowing his corn", "belonged to");
     ("horse and the hound and the horn", "")]

let numberOfBlocks = List.length subjects

let line number index = 
    let (subject, verb) = List.item (index - 1) subjects
    let ending = if index = 1 then "." else ""
    
    if index = number then "This is the " + subject + ending
    else "that " + verb + " the " + subject + ending
    
let verse number = 
    let lineForBlock = line number
    [number .. -1 .. 1]
    |> List.map lineForBlock
    |> List.reduce (sprintf "%s %s")

let recite startVerse endVerse = 
    [startVerse..endVerse]
    |> List.map verse