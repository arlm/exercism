import XCTest

@testable import ReverseString

class ReverseStringTests: XCTestCase {
  let runAll = Bool(ProcessInfo.processInfo.environment["RUNALL", default: "false"]) ?? false

  func testAnEmptyString() {
    XCTAssertEqual(reverseString(""), "")
  }

  func testAWord() throws {
    XCTAssertEqual(reverseString("robot"), "tobor")
  }

  func testACapitalizedWord() throws {
    XCTAssertEqual(reverseString("Ramen"), "nemaR")
  }

  func testASentenceWithPunctuation() throws {
    XCTAssertEqual(reverseString("I'm hungry!"), "!yrgnuh m'I")
  }

  func testAPalindrome() throws {
    XCTAssertEqual(reverseString("racecar"), "racecar")
  }

  func testAnEvenSizedWord() throws {
    XCTAssertEqual(reverseString("drawer"), "reward")
  }
}
