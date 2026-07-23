import { add, subtract, multiply, divide } from "./Calculator";

describe("Calculator Tests", () => {

    test("should add two numbers", () => {
        expect(add(10, 5)).toBe(15);
    });

    test("should subtract two numbers", () => {
        expect(subtract(10, 5)).toBe(5);
    });

    test("should multiply two numbers", () => {
        expect(multiply(10, 5)).toBe(50);
    });

    test("should divide two numbers", () => {
        expect(divide(10, 5)).toBe(2);
    });

    test("should handle divide by zero", () => {
        expect(divide(10, 0)).toBe("Cannot divide by zero");
    });

});