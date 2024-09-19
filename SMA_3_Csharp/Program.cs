// See https://aka.ms/new-console-template for more information
using System.Numerics;



public class Enemy
{
    public Vector3 m_position;
    public Vector3 m_direction;
    public float m_velosity;

    public void Move()
    {
        m_position += m_direction * m_velosity;
    }
}

public class EnemyData()
{
    public int NumEnemies;
    public Vector3[] Positions;
    public Vector3[] Directions;
    public float[] Velocities;

    public void MoveAllEnemies()
    {
        for(int i = 0; i < NumEnemies; i++)
        {
            Positions[i] += Directions[i] * Velocities[i];
        }
    }
}
public class Programs
 {
     public static void Main(string[] args)
     {
         Console.WriteLine("Hello, World!");
     }
 }