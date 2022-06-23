using System.Collections.Generic;
using UnityEngine;

public static class UFOPooler
{
    public static List<GameObject> objectList;
    private static int index = 0;

    public static void Warm(GameObject gameObject, int count)
    {
        objectList = new List<GameObject>();

        for (int i = 0; i < count; i++)
        {
            GameObject _object = Object.Instantiate(gameObject);
            _object.gameObject.SetActive(false);
            objectList.Add(_object);
        }
    }

    public static void SetTransform(Vector2 asteroidPosition, Quaternion quaternion)
    {
        index %= objectList.Count;
        Transform objectTransform = objectList[index].transform;

        objectList[index].gameObject.SetActive(true);
        
        objectTransform.position = asteroidPosition;
        objectTransform.rotation = quaternion;

        index++;
    }
}
