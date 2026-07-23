import BookDetails from "./BookDetails";
import BlogDetails from "./BlogDetails";
import CourseDetails from "./CourseDetails";

function App() {

    const showBooks = true;
    const showBlogs = true;
    const showCourses = true;

    return (

        <div style={{ padding: "20px" }}>

            <h1>Blogger App</h1>

            <hr />

            {showBooks && <BookDetails />}

            <hr />

            {showBlogs && <BlogDetails />}

            <hr />

            {showCourses && <CourseDetails />}

        </div>

    );

}

export default App;