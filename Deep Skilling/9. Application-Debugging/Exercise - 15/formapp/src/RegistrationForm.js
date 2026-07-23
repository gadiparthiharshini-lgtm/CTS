import { useState } from "react";

function RegistrationForm() {

    const [name, setName] = useState("");
    const [email, setEmail] = useState("");
    const [mobile, setMobile] = useState("");

    const handleSubmit = (event) => {
        event.preventDefault();

        alert(
            `Registration Successful!\n\nName: ${name}\nEmail: ${email}\nMobile: ${mobile}`
        );
    };

    return (
        <div style={{ padding: "20px" }}>

            <h2>Student Registration Form</h2>

            <form onSubmit={handleSubmit}>

                <div>
                    <label>Name:</label><br />

                    <input
                        type="text"
                        value={name}
                        onChange={(e) => setName(e.target.value)}
                    />
                </div>

                <br />

                <div>
                    <label>Email:</label><br />

                    <input
                        type="email"
                        value={email}
                        onChange={(e) => setEmail(e.target.value)}
                    />
                </div>

                <br />

                <div>
                    <label>Mobile:</label><br />

                    <input
                        type="text"
                        value={mobile}
                        onChange={(e) => setMobile(e.target.value)}
                    />
                </div>

                <br />

                <button type="submit">
                    Register
                </button>

            </form>

        </div>
    );
}

export default RegistrationForm;