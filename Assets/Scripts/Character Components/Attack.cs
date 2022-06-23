using UnityEngine;

public class Attack
{
    private Transform transform;

    public Attack(Transform ShootTransform)
    {
        transform = ShootTransform;
    }

    public virtual void Shoot()
    {
        ProjectilePooler.SetPosition(transform.position, transform.rotation);
    }
}
