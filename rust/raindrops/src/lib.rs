pub fn raindrops(n: u32) -> String {
    let mut result = String::new();
    let is_multiple_of_3 =n % 3 == 0;
    let is_multiple_of_5 =n % 5 == 0;
    let is_multiple_of_7 =n % 7 == 0;

    if is_multiple_of_3 {
        result += "Pling";
    }

    if is_multiple_of_5 {
        result += "Plang";
    }

    if is_multiple_of_7 {
        result += "Plong";
    }

    if !is_multiple_of_3 && !is_multiple_of_5 && !is_multiple_of_7 {
        result = n.to_string();
    }

    return result;
}
