# Raindrops

Welcome to Raindrops on Exercism's Scheme Track.
If you need help running the tests or submitting your code, check out `HELP.md`.

## Introduction

Raindrops is a slightly more complex version of the FizzBuzz challenge, a classic interview question.

## Instructions

Your task is to convert a number into its corresponding raindrop sounds.

If a given number:

- is divisible by 3, add "Pling" to the result.
- is divisible by 5, add "Plang" to the result.
- is divisible by 7, add "Plong" to the result.
- **is not** divisible by 3, 5, or 7, the result should be the number as a string.

## Examples

- 28 is divisible by 7, but not 3 or 5, so the result would be `"Plong"`.
- 30 is divisible by 3 and 5, but not 7, so the result would be `"PlingPlang"`.
- 34 is not divisible by 3, 5, or 7, so the result would be `"34"`.

~~~~exercism/note
A common way to test if one number is evenly divisible by another is to compare the [remainder][remainder] or [modulus][modulo] to zero.
Most languages provide operators or functions for one (or both) of these.

[remainder]: https://exercism.org/docs/programming/operators/remainder
[modulo]: https://en.wikipedia.org/wiki/Modulo_operation
~~~~


## Running and testing your solutions


### From the command line

Simply type `make chez` if you're using ChezScheme or `make guile` if you're using GNU Guile\.
Sometimes the name for the scheme binary on your system will differ from the defaults\.
When this is the case, you'll need to tell make by running `make chez chez=your-chez-binary` or `make guile guile=your-guile-binary`\.

### From a REPL

* Enter `(load "test.scm")` at the repl prompt\.
* Develop your solution in `raindrops.scm` reloading as you go\.
* Run `(test)` to check your solution\.

### Failed Test Cases

If some of the test cases fail, you should see the failing input and the expected output\.
The failing input is presented as a list because the tests call your solution by `(apply raindrops input-list)`\.
To learn more about `apply` see [The Scheme Programming Language -- Chapter 5](https://www.scheme.com/tspl4/control.html#./control:h1)

## Source

### Created by

- @canweriotnow

### Contributed to by

- @cyborgsphinx
- @guygastineau
- @jitwit
- @kytrinyx

### Based on

A variation on FizzBuzz, a famous technical interview question that is intended to weed out potential candidates. That question is itself derived from Fizz Buzz, a popular children's game for teaching division. - https://en.wikipedia.org/wiki/Fizz_buzz