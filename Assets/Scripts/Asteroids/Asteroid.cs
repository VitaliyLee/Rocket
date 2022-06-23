using UnityEngine;

public class Asteroid
{
    private Movement movement;
    private Collider2D triggerCollider;
    private Transform transform;

    //? Set from ScriptableObject ?
    private Vector2 mediumScale = new Vector2(1, 1);
    private Vector2 minScale = new Vector2(0.5f, 0.5f);
    private int duplicateCount = 2;
    //?

    public Asteroid()
    {
        movement = new Movement();
    }

    public void MoveAsteroid(float Speed, GameObject gameObject)
    {
        if (gameObject != null)
        {
            transform = gameObject.transform;
            movement.Move(transform, Speed, transform.right);
        }
    }

    public void AsteroidTrigger(GameObject gameObject)
    {
        if(gameObject != null)
        {
            Trigger.ViewportTrigger(gameObject);
            triggerCollider = Trigger.OnTrigger(gameObject.GetComponent<Collider2D>());

            if (triggerCollider && triggerCollider.CompareTag("PlayerBullet"))
            {
                //? Projectile setActive(false) ?
                triggerCollider.gameObject.SetActive(false);
                //?

                SpawnDuplicate(gameObject);
                AsteroidDeath(gameObject);
            }
        }
    }

    public void CalculateStartTransform()
    {
        float randomViewportX = Random.Range(0f, 1f);
        float randomViewportY = Random.Range(0f, 1f);
        float randomRotation = Random.Range(0, 180);

        Vector2 asteroidPosition = Camera.main.ViewportToWorldPoint(new Vector2(randomViewportX, randomViewportY));

        Quaternion rotation = Quaternion.Euler(0, 0, randomRotation);

        AsteroidsPooler.SetTransform(asteroidPosition, rotation);
    }

    public void AsteroidDeath(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }

    public void SpawnDuplicate(GameObject parent)
    {
        float randomRotation;
        Quaternion rotation;

        for (int i = 0; i < duplicateCount; i++)
        {
            if (parent.transform.localScale.x > mediumScale.x)
            {
                randomRotation = Random.Range(30, 180);
                rotation = Quaternion.Euler(0, 0, randomRotation);

                AsteroidsPooler.SetTransform(parent.transform.position, rotation, mediumScale);
            }

            else if (parent.transform.localScale.x == mediumScale.x)
            {
                randomRotation = Random.Range(30, 180);
                rotation = Quaternion.Euler(0, 0, randomRotation);

                AsteroidsPooler.SetTransform(parent.transform.position, rotation, minScale);
            }
        }
    }
}
