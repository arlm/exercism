#!/usr/bin/env bats
# generated on 2024-01-24T19:54:13Z
load bats-extra

@test '1 is I' {
    run jq -r -f roman-numerals.jq <<<'{"number": 1}'
    assert_success
    expected='I'
    assert_equal "$output" "$expected"
}

@test '2 is II' {
    run jq -r -f roman-numerals.jq <<<'{"number": 2}'
    assert_success
    expected='II'
    assert_equal "$output" "$expected"
}

@test '3 is III' {
    run jq -r -f roman-numerals.jq <<<'{"number": 3}'
    assert_success
    expected='III'
    assert_equal "$output" "$expected"
}

@test '4 is IV' {
    run jq -r -f roman-numerals.jq <<<'{"number": 4}'
    assert_success
    expected='IV'
    assert_equal "$output" "$expected"
}

@test '5 is V' {
    run jq -r -f roman-numerals.jq <<<'{"number": 5}'
    assert_success
    expected='V'
    assert_equal "$output" "$expected"
}

@test '6 is VI' {
    run jq -r -f roman-numerals.jq <<<'{"number": 6}'
    assert_success
    expected='VI'
    assert_equal "$output" "$expected"
}

@test '9 is IX' {
    run jq -r -f roman-numerals.jq <<<'{"number": 9}'
    assert_success
    expected='IX'
    assert_equal "$output" "$expected"
}

@test '16 is XVI' {
    run jq -r -f roman-numerals.jq <<<'{"number": 16}'
    assert_success
    expected='XVI'
    assert_equal "$output" "$expected"
}

@test '27 is XXVII' {
    run jq -r -f roman-numerals.jq <<<'{"number": 27}'
    assert_success
    expected='XXVII'
    assert_equal "$output" "$expected"
}

@test '48 is XLVIII' {
    run jq -r -f roman-numerals.jq <<<'{"number": 48}'
    assert_success
    expected='XLVIII'
    assert_equal "$output" "$expected"
}

@test '49 is XLIX' {
    run jq -r -f roman-numerals.jq <<<'{"number": 49}'
    assert_success
    expected='XLIX'
    assert_equal "$output" "$expected"
}

@test '59 is LIX' {
    run jq -r -f roman-numerals.jq <<<'{"number": 59}'
    assert_success
    expected='LIX'
    assert_equal "$output" "$expected"
}

@test '66 is LXVI' {
    run jq -r -f roman-numerals.jq <<<'{"number": 66}'
    assert_success
    expected='LXVI'
    assert_equal "$output" "$expected"
}

@test '93 is XCIII' {
    run jq -r -f roman-numerals.jq <<<'{"number": 93}'
    assert_success
    expected='XCIII'
    assert_equal "$output" "$expected"
}

@test '141 is CXLI' {
    run jq -r -f roman-numerals.jq <<<'{"number": 141}'
    assert_success
    expected='CXLI'
    assert_equal "$output" "$expected"
}

@test '163 is CLXIII' {
    run jq -r -f roman-numerals.jq <<<'{"number": 163}'
    assert_success
    expected='CLXIII'
    assert_equal "$output" "$expected"
}

@test '166 is CLXVI' {
    run jq -r -f roman-numerals.jq <<<'{"number": 166}'
    assert_success
    expected='CLXVI'
    assert_equal "$output" "$expected"
}

@test '402 is CDII' {
    run jq -r -f roman-numerals.jq <<<'{"number": 402}'
    assert_success
    expected='CDII'
    assert_equal "$output" "$expected"
}

@test '575 is DLXXV' {
    run jq -r -f roman-numerals.jq <<<'{"number": 575}'
    assert_success
    expected='DLXXV'
    assert_equal "$output" "$expected"
}

@test '666 is DCLXVI' {
    run jq -r -f roman-numerals.jq <<<'{"number": 666}'
    assert_success
    expected='DCLXVI'
    assert_equal "$output" "$expected"
}

@test '911 is CMXI' {
    run jq -r -f roman-numerals.jq <<<'{"number": 911}'
    assert_success
    expected='CMXI'
    assert_equal "$output" "$expected"
}

@test '1024 is MXXIV' {
    run jq -r -f roman-numerals.jq <<<'{"number": 1024}'
    assert_success
    expected='MXXIV'
    assert_equal "$output" "$expected"
}

@test '1666 is MDCLXVI' {
    run jq -r -f roman-numerals.jq <<<'{"number": 1666}'
    assert_success
    expected='MDCLXVI'
    assert_equal "$output" "$expected"
}

@test '3000 is MMM' {
    run jq -r -f roman-numerals.jq <<<'{"number": 3000}'
    assert_success
    expected='MMM'
    assert_equal "$output" "$expected"
}

@test '3001 is MMMI' {
    run jq -r -f roman-numerals.jq <<<'{"number": 3001}'
    assert_success
    expected='MMMI'
    assert_equal "$output" "$expected"
}

@test '3999 is MMMCMXCIX' {
    run jq -r -f roman-numerals.jq <<<'{"number": 3999}'
    assert_success
    expected='MMMCMXCIX'
    assert_equal "$output" "$expected"
}