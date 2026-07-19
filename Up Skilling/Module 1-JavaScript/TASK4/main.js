const eventList = [];

// Add event
function addEvent(name, category) {
    eventList.push({ name, category });

    console.log(`${name} added successfully.`);
}

// Register user
function registerUser(eventName) {
    console.log(`User registered for ${eventName}`);
}

// Filter events by category
function filterEventsByCategory(category, callback) {

    const filteredEvents = eventList.filter(
        event => event.category === category
    );

    callback(filteredEvents);
}

// Closure to track registrations
function registrationTracker(category) {

    let totalRegistrations = 0;

    return function () {
        totalRegistrations++;

        console.log(
            `${category} registrations: ${totalRegistrations}`
        );
    };
}

// Callback function
function displayEvents(events) {

    if (events.length === 0) {
        console.log("No events found.");
        return;
    }

    events.forEach(event => {
        console.log(`${event.name} - ${event.category}`);
    });
}

// Testing
addEvent("Rock Concert", "Music");
addEvent("Baking Workshop", "Workshop");
addEvent("Jazz Evening", "Music");

registerUser("Rock Concert");

filterEventsByCategory("Music", displayEvents);

const musicCounter = registrationTracker("Music");

musicCounter();
musicCounter();
musicCounter();