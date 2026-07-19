const userData = {
    name: "John",
    email: "john@example.com",
    event: "Music Night"
};

document.getElementById("submitBtn").addEventListener("click", () => {

    document.getElementById("message").textContent =
        "Submitting registration...";

    // Simulate delayed server response
    setTimeout(() => {

        fetch("https://jsonplaceholder.typicode.com/posts", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(userData)
        })
            .then(response => {
                if (!response.ok) {
                    throw new Error("Request failed");
                }

                return response.json();
            })
            .then(data => {
                document.getElementById("message").textContent =
                    "Registration submitted successfully!";

                console.log("Success:", data);
            })
            .catch(error => {
                document.getElementById("message").textContent =
                    "Registration failed. Please try again.";

                console.error("Error:", error);
            });

    }, 2000);
});