import UserContext from "./UserContext";
import ComponentA from "./ComponentA";

function App() {

    const user = "Prahllad";

    return (

        <UserContext.Provider value={user}>

            <div style={{ padding: "20px" }}>

                <h1>React Context API Example</h1>

                <ComponentA />

            </div>

        </UserContext.Provider>

    );

}

export default App;