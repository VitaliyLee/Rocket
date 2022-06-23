using UnityEngine;

public class UFOController
{
    private ActorStats ufoStats;
    private int maxAsteroids;

    private float speed;
    private UFO ufo;

    private int warmCount;

    public UFOController(ActorStats UFOStats, int UFOCount)
    {
        ufoStats = UFOStats;
        warmCount = UFOCount;
        WarmPooler();
    }

    public void Move()
    {
        for (int i = 0; i < UFOPooler.objectList.Count; i++)
        {
            ufo.MoveUFO(speed, UFOPooler.objectList[i]);
        }
    }

    public void Trigger()
    {
        for (int i = 0; i < UFOPooler.objectList.Count; i++)
        {
            ufo.UFOTrigger(UFOPooler.objectList[i]);
        }
    }

    public void WarmPooler()
    {
        ufo = new UFO();
        speed = ufoStats.MoveSpeed;
        UFOPooler.Warm(ufoStats.ActorModel, warmCount);

        for (int i = 0; i < warmCount; i++)
        {
            Debug.Log("Huita");
            ufo.CalculateStartTransform(UFOPooler.objectList[i].transform);
        }
    }
}
