using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    void Start() 
    {
        CreateTableForScore();
        // GetData();
        // InsertScore(30);
        UpdateScore(2, 40);
        GetData();
    }
    string dbFile = "URI=file:SqliteTest.db";

    private void CreateTableForScore()
    {
        using(var connection = new SqliteConnection(dbFile))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = 
                "create table if not exists PlayerScore(id INTEGER PRIMARY KEY AUTOINCREMENT, score VARCHAR(30))";
                command.ExecuteNonQuery();
                Debug.Log("New table created");
            }
            connection.Close();
        }
    }

    public void InsertScore(int score)
    {
        using(var connection = new SqliteConnection(dbFile))
        {
            connection.Open();
            string query = "Insert into PlayerScore(score) values(@score)";
            using(var cmd = connection.CreateCommand())
            {
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@score", score);
                cmd.ExecuteReader();
                Debug.Log("Data inserted");
            }
        }
    }
    public void UpdateScore(int id,int score)
    {
        using(var connection = new SqliteConnection(dbFile))
        {
            connection.Open();
            string query = "update PlayerScore set score=@score where id =@id";
            using(var cmd = connection.CreateCommand())
            {
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@score", score);
                cmd.ExecuteReader();
                Debug.Log("Data updated");
            }
        }
    }
    public void DeleteScore(int id)
    {
        using(var connection = new SqliteConnection(dbFile))
        {
            connection.Open();
            string query = "delete from PlayerScore where id =@id";
            using(var cmd = connection.CreateCommand())
            {
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteReader();
                Debug.Log("Data deleted");
            }
        }
    }
    public void GetData()
    {
        using(var connection = new SqliteConnection(dbFile))
        {
            connection.Open();
            string query = "select * from PlayerScore";
            using(var cmd = connection.CreateCommand())
            {
                cmd.CommandText = query;
                SqliteDataReader reader = cmd.ExecuteReader();
                while( reader.Read())
                {
                    Debug.Log(reader["id"]); // associative array
                    Debug.Log(reader["score"]);
                }
                
            }
        }
    }
}
