#!/usr/bin/env bats
load bats-extra

# local version: 1.2.0.1

@test "an empty string" {
  run bash reverse_string.sh ""

  assert_success
  assert_output ""
}

@test "a word" {
  run bash reverse_string.sh "robot"

  assert_success
  assert_output "tobor"
}

@test "a capitalised word" {
  run bash reverse_string.sh "Ramen"

  assert_success
  assert_output "nemaR"
}

@test "a sentence with punctuation" {
  run bash reverse_string.sh "I'm hungry!"

  assert_success
  assert_output "!yrgnuh m'I"
}

@test "a palindrome" {
  run bash reverse_string.sh "racecar"

  assert_success
  assert_output "racecar"
}

@test "an even-sized word" {
  run bash reverse_string.sh "drawer"

  assert_success
  assert_output "reward"
}

# bash-specific test: Focus the student's attention on the effects of
# word splitting and filename expansion:
# https://www.gnu.org/software/bash/manual/bash.html#Shell-Expansions

@test "avoid globbing" {
  run bash reverse_string.sh " a *  b"

  assert_success
  assert_output "b  * a "
}
