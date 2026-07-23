import ListofPlayers from "./ListofPlayers";
import IndianPlayers from "./IndianPlayers";

function App() {

    const flag = false; 

    return (

        <div>

            <h1>Cricket App</h1>

            {

                flag

                    ? <ListofPlayers />

                    : <IndianPlayers />

            }

        </div>

    );

}

export default App;