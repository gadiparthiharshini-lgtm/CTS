const url = "https://jsonplaceholder.typicode.com/users";

fetch(url)
    .then(response => response.json())
    .then(data => {
        console.log("Using .then()");
        console.log(data);
    })
    .catch(error => {
        console.error("Error:", error);
    });

async function fetchEvents() {

    const loading = document.getElementById("loading");

    try {
        loading.style.display = "block";

        const response = await fetch(url);

        const data = await response.json();

        const list = document.getElementById("events");

        data.slice(0, 5).forEach(event => {
            list.innerHTML += `<li>${event.name}</li>`;
        });

    } catch (error) {
        console.error(error);
    } finally {
        loading.style.display = "none";
    }
}

fetchEvents();