import { useState } from "react";

import Greeting from "./Greeting";
import LoginButton from "./LoginButton";
import LogoutButton from "./LogoutButton";

function App() {

    const [isLoggedIn, setIsLoggedIn] = useState(false);

    const handleLogin = () => {
        setIsLoggedIn(true);
    };

    const handleLogout = () => {
        setIsLoggedIn(false);
    };

    return (

        <div style={{ padding: "20px" }}>

            <Greeting isLoggedIn={isLoggedIn} />

            <br />

            {
                isLoggedIn

                    ? <LogoutButton onClick={handleLogout} />

                    : <LoginButton onClick={handleLogin} />

            }

        </div>

    );
}

export default App;