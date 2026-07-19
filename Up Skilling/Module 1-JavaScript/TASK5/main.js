// Event constructor function
function Event(name, date, seats) {

    this.name = name;
    this.date = date;
    this.seats = seats;
}

// Prototype method
Event.prototype.checkAvailability = function () {

    if (this.seats > 0) {
        return `${this.name} has ${this.seats} seats available.`;
    }

    return `${this.name} is fully booked.`;
};

// Create objects
const event1 = new Event(
    "Community Meetup",
    "2026-07-20",
    30
);

const event2 = new Event(
    "Photography Workshop",
    "2026-08-05",
    0
);

// Check availability
console.log(event1.checkAvailability());
console.log(event2.checkAvailability());

// List keys and values
Object.entries(event1).forEach(([key, value]) => {

    console.log(`${key}: ${value}`);
});