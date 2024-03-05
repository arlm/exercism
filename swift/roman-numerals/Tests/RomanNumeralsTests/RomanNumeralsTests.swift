import XCTest

@testable import RomanNumerals

class RomanNumeralsTests: XCTestCase {
  let runAll = Bool(ProcessInfo.processInfo.environment["RUNALL", default: "false"]) ?? false

  func test1IsI() {
    XCTAssertEqual(1.toRomanNumeral(), "I")
  }

  func test2IsIi() throws {
    XCTAssertEqual(2.toRomanNumeral(), "II")
  }

  func test3IsIii() throws {
    XCTAssertEqual(3.toRomanNumeral(), "III")
  }

  func test4IsIv() throws {
    XCTAssertEqual(4.toRomanNumeral(), "IV")
  }

  func test5IsV() throws {
    XCTAssertEqual(5.toRomanNumeral(), "V")
  }

  func test6IsVi() throws {
    XCTAssertEqual(6.toRomanNumeral(), "VI")
  }

  func test9IsIx() throws {
    XCTAssertEqual(9.toRomanNumeral(), "IX")
  }

  func test16IsXvi() throws {
    XCTAssertEqual(16.toRomanNumeral(), "XVI")
  }

  func test27IsXxvii() throws {
    XCTAssertEqual(27.toRomanNumeral(), "XXVII")
  }

  func test48IsXlviii() throws {
    XCTAssertEqual(48.toRomanNumeral(), "XLVIII")
  }

  func test49IsXlix() throws {
    XCTAssertEqual(49.toRomanNumeral(), "XLIX")
  }

  func test59IsLix() throws {
    XCTAssertEqual(59.toRomanNumeral(), "LIX")
  }

  func test66IsLxvi() throws {
    XCTAssertEqual(66.toRomanNumeral(), "LXVI")
  }

  func test93IsXciii() throws {
    XCTAssertEqual(93.toRomanNumeral(), "XCIII")
  }

  func test141IsCxli() throws {
    XCTAssertEqual(141.toRomanNumeral(), "CXLI")
  }

  func test163IsClxiii() throws {
    XCTAssertEqual(163.toRomanNumeral(), "CLXIII")
  }

  func test166IsClxvi() throws {
    XCTAssertEqual(166.toRomanNumeral(), "CLXVI")
  }

  func test402IsCdii() throws {
    XCTAssertEqual(402.toRomanNumeral(), "CDII")
  }

  func test575IsDlxxv() throws {
    XCTAssertEqual(575.toRomanNumeral(), "DLXXV")
  }

  func test666IsDclxvi() throws {
    XCTAssertEqual(666.toRomanNumeral(), "DCLXVI")
  }

  func test911IsCmxi() throws {
    XCTAssertEqual(911.toRomanNumeral(), "CMXI")
  }

  func test1024IsMxxiv() throws {
    XCTAssertEqual(1024.toRomanNumeral(), "MXXIV")
  }

  func test1666IsMdclxvi() throws {
    XCTAssertEqual(1666.toRomanNumeral(), "MDCLXVI")
  }

  func test3000IsMmm() throws {
    XCTAssertEqual(3000.toRomanNumeral(), "MMM")
  }

  func test3001IsMmmi() throws {
    XCTAssertEqual(3001.toRomanNumeral(), "MMMI")
  }

  func test3999IsMmmcmxcix() throws {
    XCTAssertEqual(3999.toRomanNumeral(), "MMMCMXCIX")
  }
}
