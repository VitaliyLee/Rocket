using UnityEngine;

public class UFO
{
    private Movement movement;
    private Collider2D triggerCollider;
    private Transform transform;

    public UFO()
    {
        movement = new Movement();
    }

    public void MoveUFO(float Speed, GameObject gameObject)
    {
        if (gameObject != null)
        {
            transform = gameObject.transform;
            movement.Move(transform, Speed, transform.up);
        }
    }

    public void UFOTrigger(GameObject gameObject)
    {
        if (gameObject != null)
        {
            Trigger.ViewportTrigger(gameObject);
            triggerCollider = Trigger.OnTrigger(gameObject.GetComponent<Collider2D>());

            if (triggerCollider && triggerCollider.CompareTag("PlayerBullet"))
            {
                //? Projectile setActive(false) ?
                triggerCollider.gameObject.SetActive(false);
                //?

                UFODeath(gameObject);
            }
        }
    }

    public void CalculateStartTransform(Transform objectTransform)
    {
        float randomViewportX = 1 + (objectTransform.localScale.x / 20) * RandomSign();
        float randomViewportY = Random.Range(0.2f, 0.8f);

        Vector2 asteroidPosition = Camera.main.ViewportToWorldPoint(new Vector2(randomViewportX, randomViewportY));

        Quaternion rotation;

        AsteroidsPooler.SetTransform(asteroidPosition, rotation);

        int RandomSign()
        {
            int random = Random.Range(0, 2);
            if (random == 0)
            {
                rotation = Quaternion.Euler(0, 180, 0);
                return 1;
            }
            rotation = Quaternion.Euler(0, 0, 0);
            return -1;
        }
    }

    public void UFODeath(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }
}
