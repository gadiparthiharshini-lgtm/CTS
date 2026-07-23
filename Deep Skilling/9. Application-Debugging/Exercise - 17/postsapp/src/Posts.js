import { useEffect, useState } from "react";

function Posts() {

    const [posts, setPosts] = useState([]);

    useEffect(() => {

        fetch("https://jsonplaceholder.typicode.com/posts")
            .then((response) => response.json())
            .then((data) => setPosts(data))
            .catch((error) => console.log(error));

    }, []);

    return (
        <div style={{ padding: "20px" }}>

            <h1>Blog Posts</h1>

            {
                posts.map((post) => (
                    <div
                        key={post.id}
                        style={{
                            borderBottom: "1px solid gray",
                            marginBottom: "20px",
                            paddingBottom: "10px"
                        }}
                    >
                        <h3>{post.title}</h3>
                        <p>{post.body}</p>
                    </div>
                ))
            }

        </div>
    );
}

export default Posts;