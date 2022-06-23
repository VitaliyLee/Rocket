using UnityEngine;

public static class Trigger
{
    public static void ViewportTrigger(GameObject Actor)
    {
        Transform actorTransform = Actor.transform; 
        //? "/20" - WTF ?
        Vector3 viewportScale = actorTransform.localScale / 20;
        //?
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(actorTransform.position);

        if (viewportPosition.x < (0.0f - viewportScale.x))
            viewportPosition = new Vector3(1.0f + viewportScale.x, viewportPosition.y, viewportPosition.z);

        else if (viewportPosition.x >= (1.0f + viewportScale.x))
            viewportPosition = new Vector3(0.0f - viewportScale.x, viewportPosition.y, viewportPosition.z);

        if (viewportPosition.y < (0.0f - viewportScale.y))
            viewportPosition = new Vector3(viewportPosition.x, 1.0f + viewportScale.y, viewportPosition.z);

        else if (viewportPosition.y >= (1.0f + viewportScale.y))
            viewportPosition = new Vector3(viewportPosition.x, 0.0f - viewportScale.y, viewportPosition.z);
        
        actorTransform.position = Camera.main.ViewportToWorldPoint(viewportPosition);
    }
    
    public static Collider2D OnTrigger(Collider2D collider)
    {
        ContactFilter2D contactFilter2D = new ContactFilter2D();
        Collider2D[] colliders = new Collider2D[1];
        collider.OverlapCollider(contactFilter2D, colliders);

        if (colliders[0] != null)
        {
            return colliders[0];
        }

        return null;
    }
}
