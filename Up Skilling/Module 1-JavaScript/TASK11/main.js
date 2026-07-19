document.getElementById("registrationForm")
    .addEventListener("submit", function (event) {

        event.preventDefault();

        const form = event.target;

        const name = form.elements["name"].value.trim();
        const email = form.elements["email"].value.trim();
        const selectedEvent =
            form.elements["event"].value;

        document.getElementById("nameError").textContent = "";
        document.getElementById("emailError").textContent = "";
        document.getElementById("eventError").textContent = "";

        let valid = true;

        if (name === "") {
            document.getElementById("nameError")
                .textContent = "Name is required";
            valid = false;
        }

        if (email === "") {
            document.getElementById("emailError")
                .textContent = "Email is required";
            valid = false;
        }

        if (selectedEvent === "") {
            document.getElementById("eventError")
                .textContent = "Select an event";
            valid = false;
        }

        if (valid) {
            alert("Registration Successful!");
        }
    });