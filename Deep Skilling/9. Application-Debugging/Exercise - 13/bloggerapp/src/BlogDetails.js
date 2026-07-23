function BlogDetails() {

    const blogs = [

        {
            id: 1,
            title: "Introduction to React",
            author: "John"
        },

        {
            id: 2,
            title: "Understanding JSX",
            author: "David"
        },

        {
            id: 3,
            title: "React Hooks",
            author: "Maria"
        }

    ];

    return (

        <div>

            <h2>Blog Details</h2>

            <ul>

                {

                    blogs.map(blog => (

                        <li key={blog.id}>

                            {blog.title} - {blog.author}

                        </li>

                    ))

                }

            </ul>

        </div>

    );

}

export default BlogDetails;