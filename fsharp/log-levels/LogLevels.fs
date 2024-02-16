module LogLevels

open System

let toLower (x: string) = x.ToLower()
let trim (x: string) = x.Trim()
let getTokens (x: string) = x.Split([|'['; ']'; ':'|], StringSplitOptions.RemoveEmptyEntries)

let message (logLine: string): string = 
    logLine
    |> getTokens
    |> Array.tryLast
    |> function
        | Some x -> x |> trim
        | None -> ""

let logLevel(logLine: string): string =
    logLine
    |> getTokens
    |> Array.tryHead
    |> function
        | Some x -> x |> trim |> toLower
        | None -> ""

let reformat(logLine: string): string = 
    $"{message logLine} ({logLevel logLine})"
