use std::fmt;

fn match_first_letter(input_string: &str) -> Result<String, fmt::Error> {
    let result = input_string.split(|c: char|  c.is_whitespace() || c == '_' || c == '-')
        .map(|word| {
            if word.chars().all(|c| c.is_uppercase()) {
                return word.chars().take(1).collect::<String>();
            } else  {
                return word.chars()
                        .take(1)
                        .chain(
                            word.chars()
                                .skip(1)
                                .skip_while(|c| c.is_lowercase() || c.is_ascii_punctuation() || *c == '\'')
                                .take(1)
                            )
                        .collect::<String>();
            }
        })
        .collect::<String>()
        .to_uppercase();

        Ok(result)
}

pub fn abbreviate(phrase: &str) -> String {
    return match_first_letter(phrase).unwrap();
}
