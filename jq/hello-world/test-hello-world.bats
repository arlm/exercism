#!/usr/bin/env bats
# generated on 2022-11-02T20:59:14Z
load bats-extra

@test 'Say Hi!' {
    run jq -r -f hello-world.jq << 'END_INPUT'
        {}
END_INPUT

    assert_success
    expected='Hello, World!'
    assert_equal "$output" "$expected"
}

