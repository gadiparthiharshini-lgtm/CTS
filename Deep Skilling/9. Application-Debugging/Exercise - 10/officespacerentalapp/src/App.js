import officeImage from "./Images/office.jpg";

function App() {

    const office = {
        Name: "Sky Tower Office",
        Rent: 55000,
        Address: "Madhapur, Hyderabad"
    };

    const officeSpaces = [

        {
            Name: "Sky Tower Office",
            Rent: 55000,
            Address: "Madhapur, Hyderabad"
        },

        {
            Name: "Tech Park",
            Rent: 75000,
            Address: "Hitech City, Hyderabad"
        },

        {
            Name: "Business Hub",
            Rent: 45000,
            Address: "Gachibowli, Hyderabad"
        }

    ];

    return (

        <div style={{ padding: "20px" }}>

            <h1>Office Space Rental App</h1>

            <img
                src={officeImage}
                alt="Office"
                width="500"
            />

            <hr />

            <h2>Featured Office</h2>

            <p>
                <b>Name:</b> {office.Name}
            </p>

            <p
                style={{
                    color:
                        office.Rent < 60000
                            ? "red"
                            : "green"
                }}
            >
                <b>Rent:</b> ₹{office.Rent}
            </p>

            <p>
                <b>Address:</b> {office.Address}
            </p>

            <hr />

            <h2>Office List</h2>

            {

                officeSpaces.map((item, index) => (

                    <div
                        key={index}
                        style={{
                            border: "1px solid gray",
                            padding: "10px",
                            marginBottom: "15px"
                        }}
                    >

                        <h3>{item.Name}</h3>

                        <p
                            style={{
                                color:
                                    item.Rent < 60000
                                        ? "red"
                                        : "green"
                            }}
                        >
                            <b>Rent:</b> ₹{item.Rent}
                        </p>

                        <p>
                            <b>Address:</b> {item.Address}
                        </p>

                    </div>

                ))

            }

        </div>

    );

}

export default App;