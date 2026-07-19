const events = [
    { name: "Music Night", category: "Music" },
    { name: "Baking Workshop", category: "Workshop" },
    { name: "Jazz Concert", category: "Music" }
];

function displayEvents(eventArray) {
    const list = document.getElementById("eventList");

    list.innerHTML = "";

    eventArray.forEach(event => {
        list.innerHTML += `
            <p>
                ${event.name}
                <button onclick="alert('Registered for ${event.name}')">
                    Register
                </button>
            </p>
        `;
    });
}

function filterEvents() {
    const category =
        document.getElementById("categoryFilter").value;

    if (category === "All") {
        displayEvents(events);
    } else {
        displayEvents(
            events.filter(event => event.category === category)
        );
    }
}

document.getElementById("searchBox")
    .addEventListener("keydown", function () {

        const keyword = this.value.toLowerCase();

        const filtered = events.filter(event =>
            event.name.toLowerCase().includes(keyword)
        );

        displayEvents(filtered);
    });

displayEvents(events);