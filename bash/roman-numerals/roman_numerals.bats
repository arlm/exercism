#!/usr/bin/env bats
load bats-extra

# local version: 1.2.0.0

@test "1 is a single I" {
  run bash roman_numerals.sh 1
  assert_success
  assert_output "I"
}

@test "2 is two I's" {
  run bash roman_numerals.sh 2
  assert_success
  assert_output "II"
}

@test "3 is three I's" {
  run bash roman_numerals.sh 3
  assert_success
  assert_output "III"
}

@test "4, being 5 - 1, is IV" {
  run bash roman_numerals.sh 4
  assert_success
  assert_output "IV"
}

@test "5 is a single V" {
  run bash roman_numerals.sh 5
  assert_success
  assert_output "V"
}

@test "6, being 5 + 1, is VI" {
  run bash roman_numerals.sh 6
  assert_success
  assert_output "VI"
}

@test "9, being 10 - 1, is IX" {
  run bash roman_numerals.sh 9
  assert_success
  assert_output "IX"
}

@test "20 is two X's" {
  run bash roman_numerals.sh 27
  assert_success
  assert_output "XXVII"
}

@test "48 is not 50 - 2 but rather 40 + 8" {
  run bash roman_numerals.sh 48
  assert_success
  assert_output "XLVIII"
}

@test "49 is not 40 + 5 + 4 but rather 50 - 10 + 10 - 1" {
  run bash roman_numerals.sh 49
  assert_success
  assert_output "XLIX"
}

@test "50 is a single L" {
  run bash roman_numerals.sh 59
  assert_success
  assert_output "LIX"
}

@test "90, being 100 - 10, is XC" {
  run bash roman_numerals.sh 93
  assert_success
  assert_output "XCIII"
}

@test "100 is a single C" {
  run bash roman_numerals.sh 141
  assert_success
  assert_output "CXLI"
}

@test "60, being 50 + 10, is LX" {
  run bash roman_numerals.sh 163
  assert_success
  assert_output "CLXIII"
}

@test "400, being 500 - 100, is CD" {
  run bash roman_numerals.sh 402
  assert_success
  assert_output "CDII"
}

@test "500 is a single D" {
  run bash roman_numerals.sh 575
  assert_success
  assert_output "DLXXV"
}

@test "900, being 1000 - 100, is CM" {
  run bash roman_numerals.sh 911
  assert_success
  assert_output "CMXI"
}

@test "1000 is a single M" {
  run bash roman_numerals.sh 1024
  assert_success
  assert_output "MXXIV"
}

@test "3000 is three M's" {
  run bash roman_numerals.sh 3000
  assert_success
  assert_output "MMM"
}

@test "3001 is three MMMI" {
  run bash roman_numerals.sh 3001
  assert_success
  assert_output "MMMI"
}

@test "3999 is three MMMCMXCIX" {
  run bash roman_numerals.sh 3999
  assert_success
  assert_output "MMMCMXCIX"
}

# testing numbers with all roman numerals below a threshold

@test "16 is XVI" {
  run bash roman_numerals.sh 16
  assert_success
  assert_output "XVI"
}

@test "66 is LXVI" {
  run bash roman_numerals.sh 66
  assert_success
  assert_output "LXVI"
}

@test "166 is CLXVI" {
  run bash roman_numerals.sh 166
  assert_success
  assert_output "CLXVI"
}

@test "666 is DCLXVI" {
  run bash roman_numerals.sh 666
  assert_success
  assert_output "DCLXVI"
}

@test "1666 is MDCLXVI" {
  run bash roman_numerals.sh 1666
  assert_success
  assert_output "MDCLXVI"
}
