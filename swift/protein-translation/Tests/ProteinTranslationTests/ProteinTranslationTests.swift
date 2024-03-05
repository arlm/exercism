import XCTest

@testable import ProteinTranslation

class ProteinTranslationTests: XCTestCase {
  let runAll = Bool(ProcessInfo.processInfo.environment["RUNALL", default: "false"]) ?? false

  func testEmptyRnaSequenceResultsInNoProteins() {
    XCTAssertEqual([], try! translationOfRNA(rna: ""))
  }

  func testMethionineRnaSequence() throws {
    XCTAssertEqual(["Methionine"], try! translationOfRNA(rna: "AUG"))
  }

  func testPhenylalanineRnaSequence1() throws {
    XCTAssertEqual(["Phenylalanine"], try! translationOfRNA(rna: "UUU"))
  }

  func testPhenylalanineRnaSequence2() throws {
    XCTAssertEqual(["Phenylalanine"], try! translationOfRNA(rna: "UUC"))
  }

  func testLeucineRnaSequence1() throws {
    XCTAssertEqual(["Leucine"], try! translationOfRNA(rna: "UUA"))
  }

  func testLeucineRnaSequence2() throws {
    XCTAssertEqual(["Leucine"], try! translationOfRNA(rna: "UUG"))
  }

  func testSerineRnaSequence1() throws {
    XCTAssertEqual(["Serine"], try! translationOfRNA(rna: "UCU"))
  }

  func testSerineRnaSequence2() throws {
    XCTAssertEqual(["Serine"], try! translationOfRNA(rna: "UCC"))
  }

  func testSerineRnaSequence3() throws {
    XCTAssertEqual(["Serine"], try! translationOfRNA(rna: "UCA"))
  }

  func testSerineRnaSequence4() throws {
    XCTAssertEqual(["Serine"], try! translationOfRNA(rna: "UCG"))
  }

  func testTyrosineRnaSequence1() throws {
    XCTAssertEqual(["Tyrosine"], try! translationOfRNA(rna: "UAU"))
  }

  func testTyrosineRnaSequence2() throws {
    XCTAssertEqual(["Tyrosine"], try! translationOfRNA(rna: "UAC"))
  }

  func testCysteineRnaSequence1() throws {
    XCTAssertEqual(["Cysteine"], try! translationOfRNA(rna: "UGU"))
  }

  func testCysteineRnaSequence2() throws {
    XCTAssertEqual(["Cysteine"], try! translationOfRNA(rna: "UGC"))
  }

  func testTryptophanRnaSequence() throws {
    XCTAssertEqual(["Tryptophan"], try! translationOfRNA(rna: "UGG"))
  }

  func testStopCodonRnaSequence1() throws {
    XCTAssertEqual([], try! translationOfRNA(rna: "UAA"))
  }

  func testStopCodonRnaSequence2() throws {
    XCTAssertEqual([], try! translationOfRNA(rna: "UAG"))
  }

  func testStopCodonRnaSequence3() throws {
    XCTAssertEqual([], try! translationOfRNA(rna: "UGA"))
  }

  func testSequenceOfTwoProteinCodonsTranslatesIntoProteins() throws {
    XCTAssertEqual(["Phenylalanine", "Phenylalanine"], try! translationOfRNA(rna: "UUUUUU"))
  }

  func testSequenceOfTwoDifferentProteinCodonsTranslatesIntoProteins() throws {
    XCTAssertEqual(["Leucine", "Leucine"], try! translationOfRNA(rna: "UUAUUG"))
  }

  func testTranslateRnaStrandIntoCorrectProteinList() throws {
    XCTAssertEqual(
      ["Methionine", "Phenylalanine", "Tryptophan"], try! translationOfRNA(rna: "AUGUUUUGG"))
  }

  func testTranslationStopsIfStopCodonAtBeginningOfSequence() throws {
    XCTAssertEqual([], try! translationOfRNA(rna: "UAGUGG"))
  }

  func testTranslationStopsIfStopCodonAtEndOfTwoCodonSequence() throws {
    XCTAssertEqual(["Tryptophan"], try! translationOfRNA(rna: "UGGUAG"))
  }

  func testTranslationStopsIfStopCodonAtEndOfThreeCodonSequence() throws {
    XCTAssertEqual(["Methionine", "Phenylalanine"], try! translationOfRNA(rna: "AUGUUUUAA"))
  }

  func testTranslationStopsIfStopCodonInMiddleOfThreeCodonSequence() throws {
    XCTAssertEqual(["Tryptophan"], try! translationOfRNA(rna: "UGGUAGUGG"))
  }

  func testTranslationStopsIfStopCodonInMiddleOfSixCodonSequence() throws {
    XCTAssertEqual(
      ["Tryptophan", "Cysteine", "Tyrosine"], try! translationOfRNA(rna: "UGGUGUUAUUAAUGGUUU"))
  }

  func testNonExistingCodonCantTranslate() throws {
    XCTAssertThrowsError(try translationOfRNA(rna: "AAA")) { error in
      XCTAssertEqual(error as? TranslationError, TranslationError.invalidCodon)
    }
  }

  func testUnknownAminoAcidsNotPartOfACodonCantTranslate() throws {
    XCTAssertThrowsError(try translationOfRNA(rna: "XYZ")) { error in
      XCTAssertEqual(error as? TranslationError, TranslationError.invalidCodon)
    }
  }

  func testIncompleteRnaSequenceCantTranslate() throws {
    XCTAssertThrowsError(try translationOfRNA(rna: "AUGU")) { error in
      XCTAssertEqual(error as? TranslationError, TranslationError.invalidCodon)
    }
  }

  func testIncompleteRnaSequenceCanTranslateIfValidUntilAStopCodon() throws {
    XCTAssertEqual(["Phenylalanine", "Phenylalanine"], try! translationOfRNA(rna: "UUCUUCUAAUGGU"))
  }
}
