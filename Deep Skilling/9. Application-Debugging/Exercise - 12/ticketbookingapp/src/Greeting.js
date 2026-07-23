import GuestPage from "./GuestPage";
import UserPage from "./UserPage";

function Greeting(props) {

    if (props.isLoggedIn) {
        return <UserPage />;
    }

    return <GuestPage />;
}

export default Greeting;