import XCTest

@testable import CircularBuffer

class CircularBufferTests: XCTestCase {
  let runAll = Bool(ProcessInfo.processInfo.environment["RUNALL", default: "false"]) ?? false

  func testReadingEmptyBufferShouldFail() {
    var buffer = CircularBuffer(capacity: 1)

    XCTAssertThrowsError(try buffer.read()) { error in
      XCTAssertEqual(error as? CircularBufferError, .bufferEmpty)
    }
  }

  func testCanReadAnItemJustWritten() throws {
    var buffer = CircularBuffer(capacity: 1)

    try! buffer.write(1)
    XCTAssertEqual(try! buffer.read(), 1)
  }

  func testEachItemMayOnlyBeReadOnce() throws {
    var buffer = CircularBuffer(capacity: 1)

    try! buffer.write(1)
    XCTAssertEqual(try! buffer.read(), 1)
    XCTAssertThrowsError(try buffer.read()) { error in
      XCTAssertEqual(error as? CircularBufferError, .bufferEmpty)
    }
  }

  func testItemsAreReadInTheOrderTheyAreWritten() throws {
    var buffer = CircularBuffer(capacity: 2)

    try! buffer.write(1)
    try! buffer.write(2)
    XCTAssertEqual(try! buffer.read(), 1)
    XCTAssertEqual(try! buffer.read(), 2)
  }

  func testFullBufferCantBeWrittenTo() throws {
    var buffer = CircularBuffer(capacity: 1)

    try! buffer.write(1)
    XCTAssertThrowsError(try buffer.write(2)) { error in
      XCTAssertEqual(error as? CircularBufferError, .bufferFull)
    }
  }

  func testAReadFreesUpCapacityForAnotherWrite() throws {
    var buffer = CircularBuffer(capacity: 1)

    try! buffer.write(1)
    XCTAssertEqual(try! buffer.read(), 1)
    try! buffer.write(2)
    XCTAssertEqual(try! buffer.read(), 2)
  }

  func testReadPositionIsMaintainedEvenAcrossMultipleWrites() throws {
    var buffer = CircularBuffer(capacity: 3)

    try! buffer.write(1)
    try! buffer.write(2)
    XCTAssertEqual(try! buffer.read(), 1)
    try! buffer.write(3)
    XCTAssertEqual(try! buffer.read(), 2)
    XCTAssertEqual(try! buffer.read(), 3)
  }

  func testItemsClearedOutOfBufferCantBeRead() throws {
    var buffer = CircularBuffer(capacity: 1)

    try! buffer.write(1)
    buffer.clear()
    XCTAssertThrowsError(try buffer.read()) { error in
      XCTAssertEqual(error as? CircularBufferError, .bufferEmpty)
    }
  }

  func testClearFreesUpCapacityForAnotherWrite() throws {
    var buffer = CircularBuffer(capacity: 1)

    try! buffer.write(1)
    buffer.clear()
    try! buffer.write(2)
    XCTAssertEqual(try! buffer.read(), 2)
  }

  func testClearDoesNothingOnEmptyBuffer() throws {
    var buffer = CircularBuffer(capacity: 1)

    buffer.clear()
    try! buffer.write(1)
    XCTAssertEqual(try! buffer.read(), 1)
  }

  func testOverwriteActsLikeWriteOnNonFullBuffer() throws {
    var buffer = CircularBuffer(capacity: 2)

    try! buffer.write(1)
    buffer.overwrite(2)
    XCTAssertEqual(try! buffer.read(), 1)
    XCTAssertEqual(try! buffer.read(), 2)
  }

  func testOverwriteReplacesTheOldestItemOnFullBuffer() throws {
    var buffer = CircularBuffer(capacity: 2)

    try! buffer.write(1)
    try! buffer.write(2)
    buffer.overwrite(3)
    XCTAssertEqual(try! buffer.read(), 2)
    XCTAssertEqual(try! buffer.read(), 3)
  }

  func testOverwriteReplacesTheOldestItemRemainingInBufferFollowingARead() throws {
    var buffer = CircularBuffer(capacity: 3)

    try! buffer.write(1)
    try! buffer.write(2)
    try! buffer.write(3)
    XCTAssertEqual(try! buffer.read(), 1)
    try! buffer.write(4)
    buffer.overwrite(5)
    XCTAssertEqual(try! buffer.read(), 3)
    XCTAssertEqual(try! buffer.read(), 4)
    XCTAssertEqual(try! buffer.read(), 5)
  }

  func testInitialClearDoesNotAffectWrappingAround() throws {
    var buffer = CircularBuffer(capacity: 2)

    buffer.clear()
    try! buffer.write(1)
    try! buffer.write(2)
    buffer.overwrite(3)
    buffer.overwrite(4)
    XCTAssertEqual(try! buffer.read(), 3)
    XCTAssertEqual(try! buffer.read(), 4)
    XCTAssertThrowsError(try buffer.read()) { error in
      XCTAssertEqual(error as? CircularBufferError, .bufferEmpty)
    }
  }
}
