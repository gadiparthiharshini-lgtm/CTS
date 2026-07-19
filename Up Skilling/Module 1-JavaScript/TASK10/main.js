const events = [
    {
        name: "Music Night",
        category: "Music",
        seats: 10
    },
    {
        name: "Baking Workshop",
        category: "Workshop",
        seats: 5
    }
];

function addEvent(
    name = "New Event",
    category = "General",
    seats = 20
) {
    return { name, category, seats };
}

const newEvent = addEvent();

console.log(newEvent);

events.forEach(event => {

    const { name, category, seats } = event;

    console.log(
        `${name} - ${category} - ${seats} seats`
    );
});

const copiedEvents = [...events];

const musicEvents = copiedEvents.filter(
    event => event.category === "Music"
);

console.log(musicEvents);