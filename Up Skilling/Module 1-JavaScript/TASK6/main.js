const communityEvents = [
    {
        name: "Classical Music Concert",
        category: "Music"
    },
    {
        name: "Baking Workshop",
        category: "Workshop"
    }
];

// Add new events
communityEvents.push({
    name: "Jazz Festival",
    category: "Music"
});

communityEvents.push({
    name: "Art Exhibition",
    category: "Art"
});

console.log("All Events:");
console.log(communityEvents);

// Filter only music events
const musicEvents = communityEvents.filter(
    event => event.category === "Music"
);

console.log("Music Events:");
console.log(musicEvents);

// Format display cards
const displayCards = communityEvents.map(
    event => `${event.name}`
);

console.log("Display Cards:");
displayCards.forEach(card => console.log(card));