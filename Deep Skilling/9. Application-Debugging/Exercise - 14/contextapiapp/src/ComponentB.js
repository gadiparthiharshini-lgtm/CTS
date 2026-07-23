import ComponentC from "./ComponentC";

function ComponentB() {

    return (
        <div
            style={{
                border: "1px solid blue",
                padding: "15px",
                marginTop: "10px"
            }}
        >
            <h2>Component B</h2>

            <ComponentC />

        </div>
    );
}

export default ComponentB;