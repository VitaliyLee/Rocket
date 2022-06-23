using UnityEngine;

public class Movement
{
    private float velocity;
    private float angle = 0;

    private Vector3 direction;

    public virtual void Move(Transform objectTransform, float Speed, float InertiaValue, bool isMove)
    {
        if (isMove)
        {
            velocity = Speed;
            direction = objectTransform.right;
        }
        objectTransform.position += direction * velocity * Time.fixedDeltaTime;
        
        Inertia(velocity, InertiaValue);
    }

    public virtual void Move(Transform objectTransform, float Speed, Vector3 Direction)
    {
        velocity = Speed;

        objectTransform.position += Direction * velocity * Time.fixedDeltaTime;
    }

    public virtual void Rotation(Transform objectTransform, float RotateDirection, float Speed)
    {
        angle -= RotateDirection * Speed;
        objectTransform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void Inertia(float Velocity, float InertiaValue)
    {
        velocity -= Velocity / InertiaValue;
    }
}
