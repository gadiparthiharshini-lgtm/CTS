document.getElementById("registrationForm")
    .addEventListener("submit", function (event) {

        event.preventDefault();

        console.log("Step 1: Form submission started");

        const formData = {
            name: document.getElementById("name").value,
            email: document.getElementById("email").value,
            event: document.getElementById("event").value
        };

        // Pause execution here for debugging
        debugger;

        console.log("Step 2: Form Data Collected");
        console.log(formData);

        fetch("https://jsonplaceholder.typicode.com/posts", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(formData)
        })
            .then(response => {
                console.log("Step 3: Fetch request sent");

                return response.json();
            })
            .then(data => {
                console.log("Step 4: Registration successful");

                console.log("Payload sent:");
                console.log(formData);

                console.log("Server Response:");
                console.log(data);

                alert("Registration Successful!");
            })
            .catch(error => {
                console.error("Step 5: Error occurred");

                console.error(error);

                alert("Registration Failed!");
            });
    });