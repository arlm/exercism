import ballerina/test;

@test:Config
function testEmptyRNASequenceResultsInNoProteins() {
    string[]|error result = proteins("");
    string[] expected = [];
    test:assertEquals(result, expected);
}

@test:Config {}
function testMethionineRNASequence() {
    string[]|error result = proteins("AUG");
    string[] expected = ["Methionine"];
    test:assertEquals(result, expected);
}

@test:Config {}
function testPhenylalanineRNASequence1() {
    string[]|error result = proteins("UUU");
    string[] expected = ["Phenylalanine"];
    test:assertEquals(result, expected);
}

@test:Config {}
function testPhenylalanineRNASequence2() {
    string[]|error result = proteins("UUC");
    string[] expected = ["Phenylalanine"];
    test:assertEquals(result, expected);
}

@test:Config {}
function testLeucineRNASequence1() {
    string[]|error result = proteins("UUA");
    string[] expected = ["Leucine"];
    test:assertEquals(result, expected);
}

@test:Config {}
function testLeucineRNASequence2() {
    string[]|error result = proteins("UUG");
    string[] expected = ["Leucine"];
    test:assertEquals(result, expected);
}

@test:Config {}
function testSerineRNASequence1() {
    string[]|error result = proteins("UCU");
    string[] expected = ["Serine"];
    test:assertEquals(result, expected);
}

@test:Config {}
function testSerineRNASequence2() {
    string[]|error result = proteins("UCC");
    string[] expected = ["Serine"];
    test:assertEquals(result, expected);
}

@test:Config {}
function testSerineRNASequence3() {
    string[]|error result = proteins("UCA");
    string[] expected = ["Serine"];
    test:assertEquals(result, expected);
}

@test:Config {}
function testSerineRNASequence4() {
    string[]|error result = proteins("UCG");
    string[] expected = ["Serine"];
    test:assertEquals(result, expected);
}

@test:Config {}
function testTyrosineRNASequence1() {
    string[]|error result = proteins("UAU");
    string[] expected = ["Tyrosine"];
    test:assertEquals(result, expected);
}

@test:Config {}
function testTyrosineRNASequence2() {
    string[]|error result = proteins("UAC");
    string[] expected = ["Tyrosine"];
    test:assertEquals(result, expected);
}

@test:Config {}
function testCysteineRNASequence1() {
    string[]|error result = proteins("UGU");
    string[] expected = ["Cysteine"];
    test:assertEquals(result, expected);
}

@test:Config {}
function testCysteineRNASequence2() {
    string[]|error result = proteins("UGC");
    string[] expected = ["Cysteine"];
    test:assertEquals(result, expected);
}

@test:Config {}
function testTryptophanRNASequence() {
    string[]|error result = proteins("UGG");
    string[] expected = ["Tryptophan"];
    test:assertEquals(result, expected);
}

@test:Config {}
function testSTOPCodonRNASequence1() {
    string[]|error result = proteins("UAA");
    string[] expected = [];
    test:assertEquals(result, expected);
}

@test:Config {}
function testSTOPCodonRNASequence2() {
    string[]|error result = proteins("UAG");
    string[] expected = [];
    test:assertEquals(result, expected);
}

@test:Config {}
function testSTOPCodonRNASequence3() {
    string[]|error result = proteins("UGA");
    string[] expected = [];
    test:assertEquals(result, expected);
}

@test:Config {}
function testSequenceOfTwoProteinCodonsTranslatesIntoProteins() {
    string[]|error result = proteins("UUUUUU");
    string[] expected = ["Phenylalanine", "Phenylalanine"];
    test:assertEquals(result, expected);
}

@test:Config {}
function testSequenceOfTwoDifferentProteinCodonsTranslatesIntoProteins() {
    string[]|error result = proteins("UUAUUG");
    string[] expected = ["Leucine", "Leucine"];
    test:assertEquals(result, expected);
}

@test:Config {}
function testTranslateRNAStrandIntoCorrectProteinList() {
    string[]|error result = proteins("AUGUUUUGG");
    string[] expected = ["Methionine", "Phenylalanine", "Tryptophan"];
    test:assertEquals(result, expected);
}

@test:Config {}
function testTranslationStopsIfSTOPCodonAtBeginningOfSequence() {
    string[]|error result = proteins("UAGUGG");
    string[] expected = [];
    test:assertEquals(result, expected);
}

@test:Config {}
function testTranslationStopsIfSTOPCodonAtEndOfTwoCodonSequence() {
    string[]|error result = proteins("UGGUAG");
    string[] expected = ["Tryptophan"];
    test:assertEquals(result, expected);
}

@test:Config {}
function testTranslationStopsIfSTOPCodonAtEndOfThreeCodonSequence() {
    string[]|error result = proteins("AUGUUUUAA");
    string[] expected = ["Methionine", "Phenylalanine"];
    test:assertEquals(result, expected);
}

@test:Config {}
function testTranslationStopsIfSTOPCodonInMiddleOfThreeCodonSequence() {
    string[]|error result = proteins("UGGUAGUGG");
    string[] expected = ["Tryptophan"];
    test:assertEquals(result, expected);
}

@test:Config {}
function testTranslationStopsIfSTOPCodonInMiddleOfSixCodonSequence() {
    string[]|error result = proteins("UGGUGUUAUUAAUGGUUU");
    string[] expected = ["Tryptophan", "Cysteine", "Tyrosine"];
    test:assertEquals(result, expected);
}

@test:Config {}
function testNonExistingCodonCannotTranslate() {
    string[]|error result = proteins("AAA");
    if result is error {
        test:assertEquals(result.message(), "Invalid codon");
    } else {
        test:assertFail("Expected an error");
    }
}

@test:Config {}
function testUnknownAminoAcidsNotPartOfACodonCannotTranslate() {
    string[]|error result = proteins("XYZ");
    if result is error {
        test:assertEquals(result.message(), "Invalid codon");
    } else {
        test:assertFail("Expected an error");
    }
}

@test:Config {}
function testIncompleteRNASequenceCannotTranslate() {
    string[]|error result = proteins("AUGU");
    if result is error {
        test:assertEquals(result.message(), "Invalid codon");
    } else {
        test:assertFail("Expected an error");
    }
}

@test:Config {}
function testIncompleteRNASequenceCanTranslateIfValidUntilASTOPCodon() {
    string[]|error result = proteins("UUCUUCUAAUGGU");
    string[] expected = ["Phenylalanine", "Phenylalanine"];
    test:assertEquals(result, expected);
}
