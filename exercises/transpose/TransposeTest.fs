module TransposeTest

open Xunit
open FsUnit

open Transpose

[<Test>]
let ``Empty string`` () = 
    let input = ""
    let expected = ""

    transpose input |> should equal expected

[<Ignore("Remove to run test")>]
[<Test>]
let ``Two characters in a row`` () = 
    let input =
        "A1"

    let expected = 
        "A\n" +
        "1"

    transpose input |> should equal expected

[<Ignore("Remove to run test")>]
[<Test>]
let ``Two characters in a column`` () = 
    let input =
        "A\n" +
        "1";

    let expected = 
        "A1"

    transpose input |> should equal expected

[<Ignore("Remove to run test")>]
[<Test>]
let ``Simple`` () = 
    let input =
        "ABC\n" +
        "123"

    let expected = 
        "A1\n" +
        "B2\n" +
        "C3"

    transpose input |> should equal expected

[<Ignore("Remove to run test")>]
[<Test>]
let ``Single line`` () = 
    let input =
        "Single line."

    let expected = 
        "S\n" +
        "i\n" +
        "n\n" +
        "g\n" +
        "l\n" +
        "e\n" +
        " \n" +
        "l\n" +
        "i\n" +
        "n\n" +
        "e\n" +
        "."

    transpose input |> should equal expected

[<Ignore("Remove to run test")>]
[<Test>]
let ``First line longer than second line`` () = 
    let input = 
        "The fourth line.\n" + 
        "The fifth line."

    let expected = 
        "TT\n" +
        "hh\n" +
        "ee\n" +
        "  \n" +
        "ff\n" +
        "oi\n" +
        "uf\n" +
        "rt\n" +
        "th\n" +
        "h \n" +
        " l\n" +
        "li\n" +
        "in\n" +
        "ne\n" +
        "e.\n" +
        "."

    transpose input |> should equal expected

[<Ignore("Remove to run test")>]
[<Test>]
let ``Second line longer than first line`` () = 
    let input = 
        "The first line.\n" + 
        "The second line."

    let expected = 
        "TT\n" +
        "hh\n" +
        "ee\n" +
        "  \n" +
        "fs\n" +
        "ie\n" +
        "rc\n" +
        "so\n" +
        "tn\n" +
        " d\n" +
        "l \n" +
        "il\n" +
        "ni\n" +
        "en\n" +
        ".e\n" +
        " ."

    transpose input |> should equal expected

[<Ignore("Remove to run test")>]
[<Test>]
let ``Square`` () = 
    let input = 
        "HEART\n" +
        "EMBER\n" +
        "ABUSE\n" +
        "RESIN\n" +
        "TREND"

    let expected = 
        "HEART\n" +
        "EMBER\n" +
        "ABUSE\n" +
        "RESIN\n" +
        "TREND"

    transpose input |> should equal expected

[<Ignore("Remove to run test")>]
[<Test>]
let ``Rectangle`` () = 
    let input = 
        "FRACTURE\n" +
        "OUTLINED\n" +
        "BLOOMING\n" +
        "SEPTETTE"

    let expected = 
        "FOBS\n"+ 
        "RULE\n"+ 
        "ATOP\n"+ 
        "CLOT\n"+ 
        "TIME\n"+ 
        "UNIT\n"+ 
        "RENT\n"+ 
        "EDGE"

    transpose input |> should equal expected

[<Ignore("Remove to run test")>]
[<Test>]
let ``Triangle`` () = 
    let input = 
        "T\n" +
        "EE\n" +
        "AAA\n" +
        "SSSS\n" +
        "EEEEE\n" +
        "RRRRRR"

    let expected = 
        "TEASER\n" + 
        " EASER\n" + 
        "  ASER\n" + 
        "   SER\n" + 
        "    ER\n" + 
        "     R"

    transpose input |> should equal expected

[<Ignore("Remove to run test")>]
[<Test>]
let ``Many lines`` () = 
    let input = 
        "Chor. Two households, both alike in dignity,\n" +
        "In fair Verona, where we lay our scene,\n" +
        "From ancient grudge break to new mutiny,\n" +
        "Where civil blood makes civil hands unclean.\n" +
        "From forth the fatal loins of these two foes\n" +
        "A pair of star-cross'd lovers take their life;\n" +
        "Whose misadventur'd piteous overthrows\n" +
        "Doth with their death bury their parents' strife.\n" +
        "The fearful passage of their death-mark'd love,\n" +
        "And the continuance of their parents' rage,\n" +
        "Which, but their children's end, naught could remove,\n" +
        "Is now the two hours' traffic of our stage;\n" +
        "The which if you with patient ears attend,\n" +
        "What here shall miss, our toil shall strive to mend."

    let expected =      
        "CIFWFAWDTAWITW\n" +
        "hnrhr hohnhshh\n" +
        "o oeopotedi ea\n" +
        "rfmrmash  cn t\n" +
        ".a e ie fthow \n" +
        " ia fr weh,whh\n" +
        "Trnco miae  ie\n" +
        "w ciroitr btcr\n" +
        "oVivtfshfcuhhe\n" +
        " eeih a uote  \n" +
        "hrnl sdtln  is\n" +
        "oot ttvh tttfh\n" +
        "un bhaeepihw a\n" +
        "saglernianeoyl\n" +
        "e,ro -trsui ol\n" +
        "h uofcu sarhu \n" +
        "owddarrdan o m\n" +
        "lhg to'egccuwi\n" +
        "deemasdaeehris\n" +
        "sr als t  ists\n" +
        ",ebk 'phool'h,\n" +
        "  reldi ffd   \n" +
        "bweso tb  rtpo\n" +
        "oea ileutterau\n" +
        "t kcnoorhhnatr\n" +
        "hl isvuyee'fi \n" +
        " atv es iisfet\n" +
        "ayoior trr ino\n" +
        "l  lfsoh  ecti\n" +
        "ion   vedpn  l\n" +
        "kuehtteieadoe \n" +
        "erwaharrar,fas\n" +
        "   nekt te  rh\n" +
        "ismdsehphnnosa\n" +
        "ncuse ra-tau l\n" +
        " et  tormsural\n" +
        "dniuthwea'g t \n" +
        "iennwesnr hsts\n" +
        "g,ycoi tkrttet\n" +
        "n ,l r s'a anr\n" +
        "i  ef  'dgcgdi\n" +
        "t  aol   eoe,v\n" +
        "y  nei sl,u; e\n" +
        ",  .sf to l   \n" +
        "     e rv d  t\n" +
        "     ; ie    o\n" +
        "       f, r   \n" +
        "       e  e  m\n" +
        "       .  m  e\n" +
        "          o  n\n" +
        "          v  d\n" +
        "          e  .\n" +
        "          ,"
    
    transpose input |> should equal expected