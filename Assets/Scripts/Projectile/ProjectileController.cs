using UnityEngine;

public class ProjectileController
{
    private float speed;
    private Projectile projectile;

    public ProjectileController(ActorStats ProjectileStats)
    {
        projectile = new Projectile();
        speed = ProjectileStats.MoveSpeed;
        ProjectilePooler.Warm(ProjectileStats.ActorModel, 15);
    }

    public void Move()
    {
        for (int i = 0; i < ProjectilePooler.objectList.Count; i++)
        {
            projectile.MoveProjectile(speed, ProjectilePooler.objectList[i]);
        }
    }
}
