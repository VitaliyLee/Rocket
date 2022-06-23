using UnityEngine;

public class Projectile
{
    private Movement movement;
    private Transform transform;
    private Collider2D triggerCollider;

    public Projectile()
    {
        movement = new Movement();
    }

    public void MoveProjectile(float Speed, GameObject gameObject)
    {
        if (gameObject != null)
        {
            transform = gameObject.transform;
            movement.Move(transform, Speed, transform.right);
        }
    }
}
