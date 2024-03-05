#!/usr/bin/env bats
# generated on 2022-11-02T20:59:34Z
load bats-extra

@test 'Empty RNA sequence results in no proteins' {

  run jq -c -f protein-translation.jq <<'END_INPUT'
        {
          "strand": ""
        }
END_INPUT

  assert_success
  expected='[]'
  assert_equal "$output" "$expected"
}

@test 'Methionine RNA sequence' {

  run jq -c -f protein-translation.jq <<'END_INPUT'
        {
          "strand": "AUG"
        }
END_INPUT

  assert_success
  expected='["Methionine"]'
  assert_equal "$output" "$expected"
}

@test 'Phenylalanine RNA sequence 1' {

  run jq -c -f protein-translation.jq <<'END_INPUT'
        {
          "strand": "UUU"
        }
END_INPUT

  assert_success
  expected='["Phenylalanine"]'
  assert_equal "$output" "$expected"
}

@test 'Phenylalanine RNA sequence 2' {

  run jq -c -f protein-translation.jq <<'END_INPUT'
        {
          "strand": "UUC"
        }
END_INPUT

  assert_success
  expected='["Phenylalanine"]'
  assert_equal "$output" "$expected"
}

@test 'Leucine RNA sequence 1' {

  run jq -c -f protein-translation.jq <<'END_INPUT'
        {
          "strand": "UUA"
        }
END_INPUT

  assert_success
  expected='["Leucine"]'
  assert_equal "$output" "$expected"
}

@test 'Leucine RNA sequence 2' {

  run jq -c -f protein-translation.jq <<'END_INPUT'
        {
          "strand": "UUG"
        }
END_INPUT

  assert_success
  expected='["Leucine"]'
  assert_equal "$output" "$expected"
}

@test 'Serine RNA sequence 1' {

  run jq -c -f protein-translation.jq <<'END_INPUT'
        {
          "strand": "UCU"
        }
END_INPUT

  assert_success
  expected='["Serine"]'
  assert_equal "$output" "$expected"
}

@test 'Serine RNA sequence 2' {

  run jq -c -f protein-translation.jq <<'END_INPUT'
        {
          "strand": "UCC"
        }
END_INPUT

  assert_success
  expected='["Serine"]'
  assert_equal "$output" "$expected"
}

@test 'Serine RNA sequence 3' {

  run jq -c -f protein-translation.jq <<'END_INPUT'
        {
          "strand": "UCA"
        }
END_INPUT

  assert_success
  expected='["Serine"]'
  assert_equal "$output" "$expected"
}

@test 'Serine RNA sequence 4' {

  run jq -c -f protein-translation.jq <<'END_INPUT'
        {
          "strand": "UCG"
        }
END_INPUT

  assert_success
  expected='["Serine"]'
  assert_equal "$output" "$expected"
}

@test 'Tyrosine RNA sequence 1' {

  run jq -c -f protein-translation.jq <<'END_INPUT'
        {
          "strand": "UAU"
        }
END_INPUT

  assert_success
  expected='["Tyrosine"]'
  assert_equal "$output" "$expected"
}

@test 'Tyrosine RNA sequence 2' {

  run jq -c -f protein-translation.jq <<'END_INPUT'
        {
          "strand": "UAC"
        }
END_INPUT

  assert_success
  expected='["Tyrosine"]'
  assert_equal "$output" "$expected"
}

@test 'Cysteine RNA sequence 1' {

  run jq -c -f protein-translation.jq <<'END_INPUT'
        {
          "strand": "UGU"
        }
END_INPUT

  assert_success
  expected='["Cysteine"]'
  assert_equal "$output" "$expected"
}

@test 'Cysteine RNA sequence 2' {

  run jq -c -f protein-translation.jq <<'END_INPUT'
        {
          "strand": "UGC"
        }
END_INPUT

  assert_success
  expected='["Cysteine"]'
  assert_equal "$output" "$expected"
}

@test 'Tryptophan RNA sequence' {

  run jq -c -f protein-translation.jq <<'END_INPUT'
        {
          "strand": "UGG"
        }
END_INPUT

  assert_success
  expected='["Tryptophan"]'
  assert_equal "$output" "$expected"
}

@test 'STOP codon RNA sequence 1' {

  run jq -c -f protein-translation.jq <<'END_INPUT'
        {
          "strand": "UAA"
        }
END_INPUT

  assert_success
  expected='[]'
  assert_equal "$output" "$expected"
}

@test 'STOP codon RNA sequence 2' {

  run jq -c -f protein-translation.jq <<'END_INPUT'
        {
          "strand": "UAG"
        }
END_INPUT

  assert_success
  expected='[]'
  assert_equal "$output" "$expected"
}

@test 'STOP codon RNA sequence 3' {

  run jq -c -f protein-translation.jq <<'END_INPUT'
        {
          "strand": "UGA"
        }
END_INPUT

  assert_success
  expected='[]'
  assert_equal "$output" "$expected"
}

@test 'Sequence of two protein codons translates into proteins' {

  run jq -c -f protein-translation.jq <<'END_INPUT'
        {
          "strand": "UUUUUU"
        }
END_INPUT

  assert_success
  expected='["Phenylalanine","Phenylalanine"]'
  assert_equal "$output" "$expected"
}

@test 'Sequence of two different protein codons translates into proteins' {

  run jq -c -f protein-translation.jq <<'END_INPUT'
        {
          "strand": "UUAUUG"
        }
END_INPUT

  assert_success
  expected='["Leucine","Leucine"]'
  assert_equal "$output" "$expected"
}

@test 'Translate RNA strand into correct protein list' {

  run jq -c -f protein-translation.jq <<'END_INPUT'
        {
          "strand": "AUGUUUUGG"
        }
END_INPUT

  assert_success
  expected='["Methionine","Phenylalanine","Tryptophan"]'
  assert_equal "$output" "$expected"
}

@test 'Translation stops if STOP codon at beginning of sequence' {

  run jq -c -f protein-translation.jq <<'END_INPUT'
        {
          "strand": "UAGUGG"
        }
END_INPUT

  assert_success
  expected='[]'
  assert_equal "$output" "$expected"
}

@test 'Translation stops if STOP codon at end of two-codon sequence' {

  run jq -c -f protein-translation.jq <<'END_INPUT'
        {
          "strand": "UGGUAG"
        }
END_INPUT

  assert_success
  expected='["Tryptophan"]'
  assert_equal "$output" "$expected"
}

@test 'Translation stops if STOP codon at end of three-codon sequence' {

  run jq -c -f protein-translation.jq <<'END_INPUT'
        {
          "strand": "AUGUUUUAA"
        }
END_INPUT

  assert_success
  expected='["Methionine","Phenylalanine"]'
  assert_equal "$output" "$expected"
}

@test 'Translation stops if STOP codon in middle of three-codon sequence' {

  run jq -c -f protein-translation.jq <<'END_INPUT'
        {
          "strand": "UGGUAGUGG"
        }
END_INPUT

  assert_success
  expected='["Tryptophan"]'
  assert_equal "$output" "$expected"
}

@test 'Translation stops if STOP codon in middle of six-codon sequence' {

  run jq -c -f protein-translation.jq <<'END_INPUT'
        {
          "strand": "UGGUGUUAUUAAUGGUUU"
        }
END_INPUT

  assert_success
  expected='["Tryptophan","Cysteine","Tyrosine"]'
  assert_equal "$output" "$expected"
}

@test 'Non-existing codon can'\''t translate' {

  run jq -c -f protein-translation.jq <<'END_INPUT'
        {
          "strand": "AAA"
        }
END_INPUT

  assert_failure
  expected='Invalid codon'
  assert_equal "$output" "$expected"
}

@test 'Unknown amino acids, not part of a codon, can'\''t translate' {

  run jq -c -f protein-translation.jq <<'END_INPUT'
        {
          "strand": "XYZ"
        }
END_INPUT

  assert_failure
  expected='Invalid codon'
  assert_equal "$output" "$expected"
}

@test 'Incomplete RNA sequence can'\''t translate' {

  run jq -c -f protein-translation.jq <<'END_INPUT'
        {
          "strand": "AUGU"
        }
END_INPUT

  assert_failure
  expected='Invalid codon'
  assert_equal "$output" "$expected"
}

@test 'Incomplete RNA sequence can translate if valid until a STOP codon' {

  run jq -c -f protein-translation.jq <<'END_INPUT'
        {
          "strand": "UUCUUCUAAUGGU"
        }
END_INPUT

  assert_success
  expected='["Phenylalanine","Phenylalanine"]'
  assert_equal "$output" "$expected"
}
