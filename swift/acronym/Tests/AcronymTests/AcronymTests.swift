import XCTest

@testable import Acronym

class AcronymTests: XCTestCase {
  let runAll = Bool(ProcessInfo.processInfo.environment["RUNALL", default: "false"]) ?? false

  func testBasic() {
    XCTAssertEqual("PNG", Acronym.abbreviate("Portable Network Graphics"))
  }

  func testLowercaseWords() throws {
    XCTAssertEqual("ROR", Acronym.abbreviate("Ruby on Rails"))
  }

  func testPunctuation() throws {
    XCTAssertEqual("FIFO", Acronym.abbreviate("First In, First Out"))
  }

  func testAllCapsWord() throws {
    XCTAssertEqual("GIMP", Acronym.abbreviate("GNU Image Manipulation Program"))
  }

  func testPunctuationWithoutWhitespace() throws {
    XCTAssertEqual("CMOS", Acronym.abbreviate("Complementary metal-oxide semiconductor"))
  }

  func testVeryLongAbbreviation() throws {
    XCTAssertEqual(
      "ROTFLSHTMDCOALM",
      Acronym.abbreviate(
        "Rolling On The Floor Laughing So Hard That My Dogs Came Over And Licked Me"))
  }

  func testConsecutiveDelimiters() throws {
    XCTAssertEqual("SIMUFTA", Acronym.abbreviate("Something - I made up from thin air"))
  }

  func testApostrophes() throws {
    XCTAssertEqual("HC", Acronym.abbreviate("Halley's Comet"))
  }

  func testUnderscoreEmphasis() throws {
    XCTAssertEqual("TRNT", Acronym.abbreviate("The Road _Not_ Taken"))
  }
}
