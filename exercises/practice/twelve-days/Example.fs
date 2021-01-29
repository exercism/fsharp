module TwelveDays

let numberToStr = 
    function
    | 0  -> "a"
    | 1  -> "and a"
    | 2  -> "two"
    | 3  -> "three"
    | 4  -> "four"
    | 5  -> "five"
    | 6  -> "six"
    | 7  -> "seven"
    | 8  -> "eight"
    | 9  -> "nine"
    | 10 -> "ten"
    | 11 -> "eleven"
    | 12 -> "twelve"
    | _  -> failwith "Invalid day"

let countToStr = 
    function
    | 1  -> "first"
    | 2  -> "second"
    | 3  -> "third"
    | 4  -> "fourth"
    | 5  -> "fifth"
    | 6  -> "sixth"
    | 7  -> "seventh"
    | 8  -> "eighth"
    | 9  -> "ninth"
    | 10  -> "tenth"
    | 11 -> "eleventh"
    | 12 -> "twelfth"
    | _  -> failwith "Invalid count"

let subject = 
    function
    | 0  -> "Partridge in a Pear Tree";
    | 1  -> "Partridge in a Pear Tree";
    | 2  -> "Turtle Doves"; 
    | 3  -> "French Hens"; 
    | 4  -> "Calling Birds"; 
    | 5  -> "Gold Rings"; 
    | 6  -> "Geese-a-Laying"; 
    | 7  -> "Swans-a-Swimming";
    | 8  -> "Maids-a-Milking";
    | 9  -> "Ladies Dancing"; 
    | 10 -> "Lords-a-Leaping"; 
    | 11 -> "Pipers Piping";
    | 12 -> "Drummers Drumming"
    | _  -> failwith "Invalid subject"

let subjectToStr number = sprintf "%s %s" (numberToStr number) (subject number)

let verseBegin number = sprintf "On the %s day of Christmas my true love gave to me: " (countToStr number)

let verseEnd = 
    function
    | 1 -> 
        subjectToStr 0
    | number -> 
        [number .. -1 .. 1] 
        |> List.map subjectToStr 
        |> List.reduce (fun x y -> x + ", " + y)

let verse number = sprintf "%s%s." (verseBegin number) (verseEnd number)

let recite start stop = List.map verse [start..stop]