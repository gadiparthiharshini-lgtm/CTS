const events = [
    {
        name: "Music Night",
        date: "2026-08-15",
        seats: 20
    },
    {
        name: "Past Workshop",
        date: "2025-01-10",
        seats: 15
    },
    {
        name: "Cooking Class",
        date: "2026-09-05",
        seats: 0
    }
];

const currentDate = new Date();

console.log("Available Upcoming Events:");

events.forEach(event => {
    const eventDate = new Date(event.date);

    if (eventDate > currentDate && event.seats > 0) {
        console.log(`${event.name} - Seats Available: ${event.seats}`);
    } else {
        console.log(`${event.name} is hidden (Past event or Fully booked).`);
    }
});

function registerUser(event) {
    try {
        if (event.seats <= 0) {
            throw new Error("Registration failed: No seats available.");
        }

        event.seats--;
        console.log(`Successfully registered for ${event.name}`);
        console.log(`Remaining Seats: ${event.seats}`);

    } catch (error) {
        console.error(error.message);
    }
}

registerUser(events[0]);
registerUser(events[2]);