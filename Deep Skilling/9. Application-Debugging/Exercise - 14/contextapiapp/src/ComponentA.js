import ComponentB from "./ComponentB";

function ComponentA() {

    return (
        <div
            style={{
                border: "1px solid green",
                padding: "15px",
                marginTop: "10px"
            }}
        >
            <h2>Component A</h2>

            <ComponentB />

        </div>
    );
}

export default ComponentA;