function add(a, b) {
    return a + b;
}

function subtract(a, b) {
    return a - b;
}

function multiply(a, b) {
    return a * b;
}

function divide(a, b) {
    if (b === 0) {
        return "Cannot divide by zero";
    }

    return a / b;
}

export { add, subtract, multiply, divide };

function Calculator() {
    return (
        <div style={{ padding: "20px" }}>
            <h2>Calculator Utility</h2>
            <p>Open the test runner to verify the calculator functions.</p>
        </div>
    );
}

export default Calculator;