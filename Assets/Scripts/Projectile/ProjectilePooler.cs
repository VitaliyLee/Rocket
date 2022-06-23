using System.Collections.Generic;
using UnityEngine;

public static class ProjectilePooler
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

    public static void SetPosition(Vector2 objectPosition, Quaternion quaternion)
    {
        index %= objectList.Count;

        objectList[index].gameObject.SetActive(true);

        objectList[index].transform.position = objectPosition;

        objectList[index].transform.rotation = quaternion;

        index++;
    }
}
