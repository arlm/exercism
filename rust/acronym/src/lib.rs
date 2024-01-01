use regex::Regex;
use std::fmt;

fn match_first_letter(input_string: &str) -> Result<String, fmt::Error> {
    let re  = Regex::new(r"^(?P<acronym1>[[:alpha:]])|(?:[_\- &&[^']])(?P<acronym2>[[:alpha:]])|(?:[[:lower:]])(?P<acronym3>[[:upper:]])").unwrap();

    let output_string: String =
        re.captures_iter(input_string)
            .map(|m| (m.name("acronym1").or(m.name("acronym2")).or(m.name("acronym3"))).unwrap())
            .filter(|o| !o.is_empty())
            .map(|c| c.as_str().to_uppercase())
        .collect();

    Ok(format!("{}", output_string))
}

pub fn abbreviate(phrase: &str) -> String {
    return match_first_letter(phrase).unwrap();
}
