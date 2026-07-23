import Product from "./Product";

function Products() {

    const products = [

        {
            name: "Laptop",
            price: 65000,
            features: [
                "16GB RAM",
                "512GB SSD",
                "Intel i5"
            ]
        },

        {
            name: "Mobile",
            price: 30000,
            features: [
                "8GB RAM",
                "128GB Storage",
                "5G"
            ]
        },

        {
            name: "Headphones",
            price: 2500,
            features: [
                "Bluetooth",
                "Noise Cancellation"
            ]
        }

    ];

    return (
        <div>
            {products.map((item, index) => (
                <Product
                    key={index}
                    name={item.name}
                    price={item.price}
                    features={item.features}
                />
            ))}
        </div>
    );
}

export default Products;