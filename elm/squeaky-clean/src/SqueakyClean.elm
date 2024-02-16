module SqueakyClean exposing (clean, clean1, clean2, clean3, clean4)

import Regex

clean1 : String -> String
clean1 str =
    let
        regex = Regex.fromString "[ \\p{Zs}]"
            |> Maybe.withDefault Regex.never
    in
        Regex.replace regex (\_ -> "_") str

clean2 : String -> String
clean2 str =
    let
        regex = Regex.fromString "[\\u0000-\\u001F]"
            |> Maybe.withDefault Regex.never
    in
    str
        |> clean1
        |> Regex.replace regex (\_ -> "[CTRL]")

clean3 : String -> String
clean3 str =
    let
        regexLetter = Regex.fromString "-(\\D)"
            |> Maybe.withDefault Regex.never
        regexDash = Regex.fromString "-"
            |> Maybe.withDefault Regex.never
    in
    str
        |> clean2
        |> Regex.replace regexLetter (.match >> String.toUpper)
        |> Regex.replace regexDash (\_ -> "")

clean4 : String -> String
clean4 str =
    let
        regex = Regex.fromString "\\d"
            |> Maybe.withDefault Regex.never
    in
    str
        |> clean3
        |> Regex.replace regex (\_ -> "")

clean : String -> String
clean str =
    let
        regex = Regex.fromString "[α-ω]"
            |> Maybe.withDefault Regex.never
    in
    str
        |> clean4
        |> Regex.replace regex (\_ -> "")
