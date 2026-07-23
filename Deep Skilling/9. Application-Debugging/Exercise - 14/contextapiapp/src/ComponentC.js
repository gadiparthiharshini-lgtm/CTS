import { useContext } from "react";
import UserContext from "./UserContext";

function ComponentC() {

    const user = useContext(UserContext);

    return (
        <div
            style={{
                border: "1px solid black",
                padding: "15px",
                marginTop: "10px"
            }}
        >
            <h2>Component C</h2>
            <h3>Welcome {user}</h3>
        </div>
    );
}

export default ComponentC;