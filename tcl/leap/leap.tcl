#!/usr/bin/env tclsh

proc isLeapYear {year} {
    return [expr { $year % 100 == 0 ? $year % 400 == 0 : $year % 4 == 0 }]
}
