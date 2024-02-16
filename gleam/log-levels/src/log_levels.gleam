import gleam/string
import gleam/list
import gleam/result

pub fn message(log_line: String) -> String {
  let result = log_line |> string.split_once(on: "]: ")
  let #(_, msg) = result |> result.unwrap(#("", ""))
  msg |> string.trim
}

pub fn log_level(log_line: String) -> String {
  let result = log_line |> string.split_once(on: "]: ")
  let #(level, _) = result |> result.unwrap(#("", ""))
  level |> string.drop_left(1)  |>  string.trim |> string.lowercase
}

pub fn reformat(log_line: String) -> String {
  message(log_line) <> " (" <> log_level(log_line) <> ")"
}
