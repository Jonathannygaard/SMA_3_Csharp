// See https://aka.ms/new-console-template for more information
using Org.BouncyCastle.Asn1.Cms;
using System.Numerics;

// public class Enemy
// {
//     Vector3 m_position;
//
//     // 64 bytes of padding
//     Vector4 bar1;
//     Vector4 bar2;
//     Vector4 bar3;
//     Vector4 bar4;
//
//     Vector3 m_direction;
//
//     // 64 bytes of padding
//     Vector4 bar5;
//     Vector4 bar6;
//     Vector4 bar7;
//     Vector4 bar8;
//
//     float m_velocity;
//
//     // 64 bytes of padding
//     Vector4 bar9;
//     Vector4 bar10;
//     Vector4 bar11;
//     Vector4 bar12;
//
//     public void Move()
//     {
//         m_position += m_direction * m_velocity;
//     }
// }

public class Enemy
{
    public Vector3 m_position; // <---------------------------
    public Vector3 m_direction; // <--------------------------
    public float m_velocity; // <-----------------------------

    public void Move()
    {
        m_position += m_direction * m_velocity;
    }
}


public static class StaticClass
{

 

    public static Vector3 PopulateRandomVector(float minValue, float maxValue)
    {
        Vector3 randomVectors;
        Random random = new Random();

            float x = (float)(random.NextDouble() * (maxValue - minValue) + minValue);
            float y = (float)(random.NextDouble() * (maxValue - minValue) + minValue);
            float z = (float)(random.NextDouble() * (maxValue - minValue) + minValue);


        randomVectors = new Vector3(x, y, z);
        return randomVectors;
    }
    public static Vector3[] PopulateRandomVector3Array(int arraySize, float minValue, float maxValue)
    {
        Vector3[] randomVectors = new Vector3[arraySize];
        Random random = new Random();

        for (int i = 0; i < arraySize; i++)
        {
            float x = (float)(random.NextDouble() * (maxValue - minValue) + minValue);
            float y = (float)(random.NextDouble() * (maxValue - minValue) + minValue);
            float z = (float)(random.NextDouble() * (maxValue - minValue) + minValue);

            randomVectors[i] = new Vector3(x, y, z);
        }

        return randomVectors;
    }

 

    public static float PopulateRandomFloat(float minValue, float maxValue)
    {

        Random random = new Random();
        float randomFloat;
        randomFloat = (float)(random.NextDouble() * (maxValue - minValue) + minValue);

        return randomFloat;
    }
    public static float[] PopulateRandomFloatArray(int arraySize, float minValue, float maxValue)
    {
        float[] randomFloats = new float[arraySize];
        Random random = new Random();

        for (int i = 0; i < arraySize; i++)
        {
            randomFloats[i] = (float)(random.NextDouble() * (maxValue - minValue) + minValue);
        }

        return randomFloats;
    }

    public static void MoveAllEnemies(EnemyData enemyData)
    {
        for (int i = 0; i < enemyData.NumEnemies; i++)
            enemyData.Position[i] += enemyData.Direction[i] * enemyData.Velocity[i];
    }

}

// this class will hold all the data needed by enemies
public class EnemyData()
{
    public int NumEnemies; // how many enemies do we have?
    public Vector3[] Position; // position data for all enemies
    public Vector3[] Direction; // direction data for all enemies
    public float[] Velocity; // velocity data for all enemies
    //                         // other enemy variables
    // public float[] ShieldRadius;
    // public float[] HP;
    // public int[] PrimaryWeaponType;

    
}

 

class TestClass
{
    
    static void Main(string[] args)
    {
        int numberOfEnemies = 10000;

        // OOP
        Enemy[] enemyArray = new Enemy[numberOfEnemies];
        for (int enemyIdx = 0; enemyIdx < enemyArray.Length; enemyIdx++)
        {
            enemyArray[enemyIdx] = new Enemy();
            enemyArray[enemyIdx].m_position = StaticClass.PopulateRandomVector(1, 100);
            enemyArray[enemyIdx].m_direction = StaticClass.PopulateRandomVector(1, 100);
            enemyArray[enemyIdx].m_velocity = StaticClass.PopulateRandomFloat(1, 100);
        }

        Double startTime = DateTime.UtcNow.Ticks;
        for (int i = 0; i < numberOfEnemies; i++)
            for (int enemyIdx = 0; enemyIdx < enemyArray.Length; enemyIdx++)
                enemyArray[enemyIdx].Move();
        Double totalTime = DateTime.UtcNow.Ticks - startTime;


        /// DOD
        EnemyData EM = new EnemyData();
        EM.NumEnemies = numberOfEnemies;
        EM.Position = StaticClass.PopulateRandomVector3Array(numberOfEnemies, 1, 100);
        EM.Direction = StaticClass.PopulateRandomVector3Array(numberOfEnemies, 1, 100);
        EM.Velocity = StaticClass.PopulateRandomFloatArray(numberOfEnemies, 1, 100);


        Double startTime2 = DateTime.UtcNow.Ticks;
        for (int i = 0; i < EM.NumEnemies; i++)
            StaticClass.MoveAllEnemies(EM);
        Double totalTime2 = DateTime.UtcNow.Ticks - startTime;

        Console.WriteLine(totalTime);
        Console.WriteLine(totalTime2);
    }
}