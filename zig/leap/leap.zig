pub fn isLeapYear(year: u32) bool {
    return if (year % 100 == 0 ) year % 400 == 0 else year % 4 == 0;
}
