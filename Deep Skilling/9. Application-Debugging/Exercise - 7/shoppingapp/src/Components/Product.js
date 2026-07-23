function Product(props) {
    return (
        <div style={{
            border: "1px solid gray",
            padding: "15px",
            margin: "10px",
            width: "300px"
        }}>
            <h2>{props.name}</h2>

            <h3>Price: ₹{props.price}</h3>

            <h4>Features:</h4>

            <ul>
                {props.features.map((feature, index) => (
                    <li key={index}>{feature}</li>
                ))}
            </ul>
        </div>
    );
}

export default Product;