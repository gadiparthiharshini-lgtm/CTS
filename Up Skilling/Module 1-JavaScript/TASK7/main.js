const events = [
    { name: "Music Night", seats: 5 },
    { name: "Baking Workshop", seats: 3 }
];

const container = document.querySelector("#eventContainer");

function displayEvents() {
    container.innerHTML = "";

    events.forEach((event, index) => {
        const card = document.createElement("div");

        card.innerHTML = `
            <h3>${event.name}</h3>
            <p>Available Seats: ${event.seats}</p>
            <button onclick="register(${index})">Register</button>
            <button onclick="cancelRegistration(${index})">Cancel</button>
            <hr>
        `;

        container.appendChild(card);
    });
}

function register(index) {
    if (events[index].seats > 0) {
        events[index].seats--;
        displayEvents();
    }
}

function cancelRegistration(index) {
    events[index].seats++;
    displayEvents();
}

displayEvents();