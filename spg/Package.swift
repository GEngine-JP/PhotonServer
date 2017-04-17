import PackageDescription

let package = Package(
    name: "spg",
    dependencies: [
        .Package(url: "https://github.com/Alamofire/Alamofire.git", majorVersion: 4)
    ]
)
