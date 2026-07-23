import { useState } from "react";

function CurrencyConverter() {

    const [amount, setAmount] = useState("");
    const [currency, setCurrency] = useState("");

    const handleSubmit = (event) => {
        event.preventDefault();

        const euro = (parseFloat(amount) / 90).toFixed(2);

        alert(`Converting to Euro Amount is € ${euro}`);
    };

    return (
        <div style={{ marginTop: "30px" }}>
            <h1 style={{ color: "green" }}>
                Currency Convertor!!!
            </h1>

            <form onSubmit={handleSubmit}>

                <div>
                    <label>Amount </label>

                    <input
                        type="number"
                        value={amount}
                        onChange={(e) => setAmount(e.target.value)}
                    />
                </div>

                <br />

                <div>
                    <label>Currency </label>

                    <input
                        type="text"
                        value={currency}
                        onChange={(e) => setCurrency(e.target.value)}
                    />
                </div>

                <br />

                <button type="submit">
                    Submit
                </button>

            </form>
        </div>
    );
}

export default CurrencyConverter;