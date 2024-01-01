pub fn check(candidate: &str) -> bool {
    let mut result = true;
    let prepared_candidate = candidate.to_lowercase();

    for c in prepared_candidate.chars().filter(|c| c.is_alphabetic()) {
        result &= prepared_candidate.chars().filter(|&x| x == c).count() == 1;
    }

    return result;
}
