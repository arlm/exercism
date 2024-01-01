use std::fmt::{Display, Formatter, Result};

pub struct Roman {
    number: u32,
}

impl Display for Roman {
    fn fmt(&self, _f: &mut Formatter<'_>) -> Result {
        let mut result: String = String::new();

        let thousands = (self.number / 1000) % 10;
        let hundreds = (self.number / 100) % 10;
        let tens = (self.number / 10) % 10;
        let units = (self.number / 1) % 10;

        for _ in 0..thousands {
            result += "M";
        }

        result += &to_romans(hundreds, "C", "D", "M");
        result += &to_romans(tens, "X", "L", "C");
        result += &to_romans(units, "I", "V", "X");

        write!(_f, "{}", result)
    }
}

fn to_romans(number: u32, lower: &str, higher: &str, next: &str) -> String {
    let number_to_use = number % 10;
    let mut result = String::new();

    match number_to_use {
        1..=3 => {
            for _ in 0..number_to_use {
                result += lower;
            }
        }

        4 => {
            result += lower;
            result += higher;
        }

        5 => result += higher,

        6..=8 => {
            result += higher;

            for _ in 0..(number_to_use - 5) {
                result += lower;
            }
        }

        9 => {
            result += lower;
            result += next;
        }

        0 => (),

        _ => panic!("Unexpected hundreds digit."),
    }

    return result;
}

impl From<u32> for Roman {
    fn from(num: u32) -> Self {
        return Roman { number: num };
    }
}
