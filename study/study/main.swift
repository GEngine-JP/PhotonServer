//
//  main.swift
//  study
//
//  Created by xiaomo on 2017/04/08.
//  Copyright (c) 2017 xiaomo. All rights reserved.
//

import Foundation

// swift3的新特性

// 1. 弃用i++ ++i 改用 i+=1
var i = 1;
i += 1;

// 2. 弃用c风格的for循环 (for var =1; i< 10; i++){}
for item in 1...10 {
    print(item)
}

// 3. 反向循环
for j in (1...10).reversed() {
    print(j);
}

// 4. 设置步长 stride  from...to 开区间   from...through 闭区间
for t in stride(from: 0, through: 10, by: 2) {
    print(t)
}

// 反向步长
for t in stride(from: 10, through: 0, by: -2) {
    print(t)
}

// 5. 元组(相同类型的比较:默认从左到右)
let score1 = (chinese: 90, math: 95)
let score2 = (chinese: 90, math: 100)
let score3 = (chinese: 100, math: 90)
print(score1 > score2)

// 如果自定义 要重载函数

func <(t1: (Int, Int), t2: (Int, Int)) -> Bool {
    if t1.1 != t2.1 {
        return t1.1 < t2.1
    }
    return t1.0 < t2.0
}

print(score3 < score2)

// 6. #selector 的改动 比较复杂

// 7. api命名规则
var arr = [0, 1, 2, 3]
// arr.removeAtIndex(1)
arr.remove(at: 1)
// arr.indexOf(1)
var result = arr.index(of: 1)

// UIColor.blueColor()
//UIColor.blue


// 8. 函数 func xxx( out in : param) ->{} 外部名 内部名
func add( _ a:Int, with b:Int) -> Int{
    return a + b;
}
add(1, with: 3)

// 9. 默认参数
func helloFuc( name:String = "xiaomo", message: String = "hello world") ->String{
    return name + message;
}

helloFuc(name: "bbbb");
