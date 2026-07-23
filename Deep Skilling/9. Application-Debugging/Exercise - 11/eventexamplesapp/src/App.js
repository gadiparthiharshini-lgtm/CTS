import { useState } from "react";
import CurrencyConverter from "./CurrencyConverter";

function App() {

    const [count, setCount] = useState(0);

    const increment = () => {
        setCount(count + 1);
    };

    const decrement = () => {
        setCount(count - 1);
    };

    const sayHello = () => {
        alert("Hello! This is a static message.");
    };

    const incrementAndHello = () => {
        increment();
        sayHello();
    };

    const sayWelcome = (message) => {
        alert(message);
    };

    const onPress = () => {
        alert("I was clicked");
    };

    return (
        <div style={{ padding: "20px" }}>

            <h2>{count}</h2>

            <button onClick={incrementAndHello}>
                Increment
            </button>

            <br /><br />

            <button onClick={decrement}>
                Decrement
            </button>

            <br /><br />

            <button onClick={() => sayWelcome("Welcome")}>
                Say Welcome
            </button>

            <br /><br />

            <button onClick={onPress}>
                Click on me
            </button>

            <CurrencyConverter />

        </div>
    );
}

export default App;