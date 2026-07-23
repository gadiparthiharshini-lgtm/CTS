function ListofPlayers() {

    const players = [

        { name: "Virat", score: 95 },
        { name: "Rohit", score: 82 },
        { name: "Gill", score: 65 },
        { name: "KL Rahul", score: 58 },
        { name: "Hardik", score: 77 },
        { name: "Jadeja", score: 61 },
        { name: "Surya", score: 88 },
        { name: "Pant", score: 45 },
        { name: "Shami", score: 22 },
        { name: "Bumrah", score: 31 },
        { name: "Siraj", score: 15 }

    ];

    const lowScorePlayers =
        players.filter(player => player.score < 70);

    return (

        <div>

            <h2>List of Players</h2>

            <ul>

                {players.map((player, index) => (

                    <li key={index}>
                        {player.name} - {player.score}
                    </li>

                ))}

            </ul>

            <h2>Players with Score Below 70</h2>

            <ul>

                {lowScorePlayers.map((player, index) => (

                    <li key={index}>
                        {player.name} - {player.score}
                    </li>

                ))}

            </ul>

        </div>

    );

}

export default ListofPlayers;