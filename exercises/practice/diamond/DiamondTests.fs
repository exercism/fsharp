module DiamondTests

open FsUnit.Xunit
open Xunit

open Diamond

[<Fact>]
let ``Degenerate case with a single 'A' row`` () =
    rows "A" |> should equal ["A"]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Degenerate case with no row containing 3 distinct groups of spaces`` () =
    rows "B" |> should equal [" A "; "B B"; " A "]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Smallest non-degenerate case with odd diamond side length`` () =
    rows "C" |> should equal ["  A  "; " B B "; "C   C"; " B B "; "  A  "]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Smallest non-degenerate case with even diamond side length`` () =
    rows "D" |> should equal ["   A   "; "  B B  "; " C   C "; "D     D"; " C   C "; "  B B  "; "   A   "]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Largest possible diamond`` () =
    rows "Z" |> should equal ["                         A                         "; "                        B B                        "; "                       C   C                       "; "                      D     D                      "; "                     E       E                     "; "                    F         F                    "; "                   G           G                   "; "                  H             H                  "; "                 I               I                 "; "                J                 J                "; "               K                   K               "; "              L                     L              "; "             M                       M             "; "            N                         N            "; "           O                           O           "; "          P                             P          "; "         Q                               Q         "; "        R                                 R        "; "       S                                   S       "; "      T                                     T      "; "     U                                       U     "; "    V                                         V    "; "   W                                           W   "; "  X                                             X  "; " Y                                               Y "; "Z                                                 Z"; " Y                                               Y "; "  X                                             X  "; "   W                                           W   "; "    V                                         V    "; "     U                                       U     "; "      T                                     T      "; "       S                                   S       "; "        R                                 R        "; "         Q                               Q         "; "          P                             P          "; "           O                           O           "; "            N                         N            "; "             M                       M             "; "              L                     L              "; "               K                   K               "; "                J                 J                "; "                 I               I                 "; "                  H             H                  "; "                   G           G                   "; "                    F         F                    "; "                     E       E                     "; "                      D     D                      "; "                       C   C                       "; "                        B B                        "; "                         A                         "]

