using UnityEngine;

public class AsteroidController
{
    private ActorStats asteroidStats;
    private int maxAsteroids;

    private float speed;
    private Asteroid asteroid;
    //? Set from ScriptableObject ?
    private int duplicateCount = 2;
    //?
    private int warmCount;

    public AsteroidController(ActorStats AsteroidStats, int MaxAsteroids)
    {
        asteroidStats = AsteroidStats;
        maxAsteroids = MaxAsteroids;

        WarmPooler();
    }

    public void Move()
    {
        for (int i = 0; i < AsteroidsPooler.objectList.Count; i++)
        {
            asteroid.MoveAsteroid(speed, AsteroidsPooler.objectList[i]);
        }
    }

    public void Trigger()
    {
        for (int i = 0; i < AsteroidsPooler.objectList.Count; i++)
        {
            asteroid.AsteroidTrigger(AsteroidsPooler.objectList[i]);
        }
    }

    public void WarmPooler()
    {
        warmCount = (duplicateCount + (duplicateCount * duplicateCount) + 1) * maxAsteroids;
        Debug.Log(warmCount);
        asteroid = new Asteroid();
        speed = asteroidStats.MoveSpeed;
        AsteroidsPooler.Warm(asteroidStats.ActorModel, warmCount);

        for (int i = 0; i < maxAsteroids; i++)
        {
            asteroid.CalculateStartTransform();
        }
    }
}
