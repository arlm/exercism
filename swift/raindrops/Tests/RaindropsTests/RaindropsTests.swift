import XCTest

@testable import Raindrops

class RaindropsTests: XCTestCase {
  let runAll = Bool(ProcessInfo.processInfo.environment["RUNALL", default: "false"]) ?? false

  func testTheSoundFor1Is1() {
    XCTAssertEqual(raindrops(1), "1")
  }

  func testTheSoundFor3IsPling() throws {
    XCTAssertEqual(raindrops(3), "Pling")
  }

  func testTheSoundFor5IsPlang() throws {
    XCTAssertEqual(raindrops(5), "Plang")
  }

  func testTheSoundFor7IsPlong() throws {
    XCTAssertEqual(raindrops(7), "Plong")
  }

  func testTheSoundFor6IsPlingAsItHasAFactor3() throws {
    XCTAssertEqual(raindrops(6), "Pling")
  }

  func test2ToThePower3DoesNotMakeARaindropSoundAs3IsTheExponentNotTheBase() throws {
    XCTAssertEqual(raindrops(8), "8")
  }

  func testTheSoundFor9IsPlingAsItHasAFactor3() throws {
    XCTAssertEqual(raindrops(9), "Pling")
  }

  func testTheSoundFor10IsPlangAsItHasAFactor5() throws {
    XCTAssertEqual(raindrops(10), "Plang")
  }

  func testTheSoundFor14IsPlongAsItHasAFactorOf7() throws {
    XCTAssertEqual(raindrops(14), "Plong")
  }

  func testTheSoundFor15IsPlingplangAsItHasFactors3And5() throws {
    XCTAssertEqual(raindrops(15), "PlingPlang")
  }

  func testTheSoundFor21IsPlingplongAsItHasFactors3And7() throws {
    XCTAssertEqual(raindrops(21), "PlingPlong")
  }

  func testTheSoundFor25IsPlangAsItHasAFactor5() throws {
    XCTAssertEqual(raindrops(25), "Plang")
  }

  func testTheSoundFor27IsPlingAsItHasAFactor3() throws {
    XCTAssertEqual(raindrops(27), "Pling")
  }

  func testTheSoundFor35IsPlangplongAsItHasFactors5And7() throws {
    XCTAssertEqual(raindrops(35), "PlangPlong")
  }

  func testTheSoundFor49IsPlongAsItHasAFactor7() throws {
    XCTAssertEqual(raindrops(49), "Plong")
  }

  func testTheSoundFor52Is52() throws {
    XCTAssertEqual(raindrops(52), "52")
  }

  func testTheSoundFor105IsPlingplangplongAsItHasFactors35And7() throws {
    XCTAssertEqual(raindrops(105), "PlingPlangPlong")
  }

  func testTheSoundFor3125IsPlangAsItHasAFactor5() throws {
    XCTAssertEqual(raindrops(3125), "Plang")
  }
}
