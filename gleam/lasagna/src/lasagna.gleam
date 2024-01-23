// Please define the expected_minutes_in_oven function
pub fn expected_minutes_in_oven() -> Int {
  40
}

// Please define the remaining_minutes_in_oven function
pub fn remaining_minutes_in_oven(time_in_oven: Int) -> Int {
  expected_minutes_in_oven() - time_in_oven
}

// Please define the preparation_time_in_minutes function
pub fn minutes_per_layer() -> Int {
  2
}

pub fn preparation_time_in_minutes(layers: Int) -> Int {
  layers * minutes_per_layer()
}

// Please define the total_time_in_minutes function
pub fn total_time_in_minutes(layers: Int, time_in_oven: Int) -> Int {
  time_in_oven + preparation_time_in_minutes(layers)
}

// Please define the alarm function
pub fn alarm() -> String {
  "Ding!"
}
