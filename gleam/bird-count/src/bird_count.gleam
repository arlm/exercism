import gleam/list
import gleam/bool

pub fn today(days: List(Int)) -> Int {
  case days {
    [] -> 0
    [day, .._rest] -> day
  }
}

pub fn increment_day_count(days: List(Int)) -> List(Int) {
  case days {
    [] -> [1]
    [day, ..rest] -> [day + 1, ..rest]
  }
}

pub fn has_day_without_birds(days: List(Int)) -> Bool {
  list.filter(days, fn(x) { x == 0 })
  |> list.is_empty
  |> bool.negate
}

pub fn total(days: List(Int)) -> Int {
  list.fold(days, 0, fn(count, day) { count + day })
}

pub fn busy_days(days: List(Int)) -> Int {
  list.filter(days, fn(x) { x >= 5 })
  |> list.length
}
