function BookDetails() {

    const books = [

        {
            id: 1,
            name: "React Explained",
            price: 550
        },

        {
            id: 2,
            name: "Learning JavaScript",
            price: 450
        },

        {
            id: 3,
            name: "Node.js Guide",
            price: 600
        }

    ];

    return (

        <div>

            <h2>Book Details</h2>

            <ul>

                {

                    books.map(book => (

                        <li key={book.id}>

                            {book.name} - ₹{book.price}

                        </li>

                    ))

                }

            </ul>

        </div>

    );

}

export default BookDetails;