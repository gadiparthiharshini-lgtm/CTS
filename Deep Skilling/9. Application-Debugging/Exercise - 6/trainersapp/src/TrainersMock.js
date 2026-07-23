import Trainer from "./trainer";

const trainers = [
    new Trainer(
        1,
        "John",
        "john@gmail.com",
        "9876543210",
        "React",
        ["React", "JavaScript", "HTML", "CSS"]
    ),

    new Trainer(
        2,
        "David",
        "david@gmail.com",
        "9876543211",
        "Angular",
        ["Angular", "TypeScript", "HTML"]
    ),

    new Trainer(
        3,
        "Smith",
        "smith@gmail.com",
        "9876543212",
        ".NET",
        ["C#", "ASP.NET Core", "SQL Server"]
    )
];

export default trainers;