import XCTest
@testable import spg

class spgTests: XCTestCase {
    func testExample() {
        // This is an example of a functional test case.
        // Use XCTAssert and related functions to verify your tests produce the correct results.
        XCTAssertEqual(Spg().text, "Hello, World!")
    }


    static var allTests : [(String, (spgTests) -> () throws -> Void)] {
        return [
            ("testExample", testExample),
        ]
    }
}
