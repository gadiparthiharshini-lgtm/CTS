using System;
using System.Data.SqlClient;

class Program
{
    static string connectionString =
        @"Server=localhost;
          Database=StudentDB;
          Trusted_Connection=True;";

    static void InsertStudent()
    {
        using SqlConnection con =
            new SqlConnection(
                connectionString
            );

        string query =
            "INSERT INTO Students(Name,Age) " +
            "VALUES(@Name,@Age)";

        SqlCommand cmd =
            new SqlCommand(
                query,
                con
            );

        cmd.Parameters.AddWithValue(
            "@Name",
            "Vardhan"
        );

        cmd.Parameters.AddWithValue(
            "@Age",
            21
        );

        con.Open();

        cmd.ExecuteNonQuery();
    }

    static void ReadStudents()
    {
        using SqlConnection con =
            new SqlConnection(
                connectionString
            );

        string query =
            "SELECT * FROM Students";

        SqlCommand cmd =
            new SqlCommand(
                query,
                con
            );

        con.Open();

        SqlDataReader reader =
            cmd.ExecuteReader();

        while (reader.Read())
        {
            Console.WriteLine(
                $"{reader["Id"]} " +
                $"{reader["Name"]} " +
                $"{reader["Age"]}"
            );
        }
    }

    static void UpdateStudent()
    {
        using SqlConnection con =
            new SqlConnection(
                connectionString
            );

        string query =
            "UPDATE Students " +
            "SET Age=@Age " +
            "WHERE Name=@Name";

        SqlCommand cmd =
            new SqlCommand(
                query,
                con
            );

        cmd.Parameters.AddWithValue(
            "@Age",
            22
        );

        cmd.Parameters.AddWithValue(
            "@Name",
            "Vardhan"
        );

        con.Open();

        cmd.ExecuteNonQuery();
    }

    static void DeleteStudent()
    {
        using SqlConnection con =
            new SqlConnection(
                connectionString
            );

        string query =
            "DELETE FROM Students " +
            "WHERE Name=@Name";

        SqlCommand cmd =
            new SqlCommand(
                query,
                con
            );

        cmd.Parameters.AddWithValue(
            "@Name",
            "Vardhan"
        );

        con.Open();

        cmd.ExecuteNonQuery();
    }

    static void Main()
    {
        InsertStudent();
        ReadStudents();
        UpdateStudent();
        DeleteStudent();
    }
}