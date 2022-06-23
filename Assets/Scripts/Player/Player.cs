using UnityEngine;

public class Player
{
    private Attack attack;

    private Movement movement;
    private GameObject playerModel;

    //Movement
    private float moveSpeed;
    private float inertiaValue;
    private bool isMove;

    //Rotation
    private float rotateSpeed;
    private float rotateDirection;

    public Player(ActorStats PlayerStats, GameObject PlayerModel)
    {
        //Movement
        moveSpeed = PlayerStats.MoveSpeed;
        inertiaValue = PlayerStats.InertiaValue;
        rotateSpeed = PlayerStats.RotateSpeed;
        playerModel = PlayerModel;

        movement = new Movement();

        //Attack
        attack = new Attack(playerModel.transform);
    }

    public void PlayerMove(Controls Inputs)
    {
        isMove = Inputs.PlayerControl.Move.IsPressed();
        movement.Move(playerModel.transform, moveSpeed, inertiaValue, isMove);

        rotateDirection = Inputs.PlayerControl.Rotation.ReadValue<float>();
        movement.Rotation(playerModel.transform, rotateDirection, rotateSpeed);
    }

    public void PlayerAttack(Controls Inputs)
    {
        Inputs.PlayerControl.Attack.performed += _ => attack.Shoot();
    }

    public void PlayerTrigger()
    {
        Trigger.ViewportTrigger(playerModel);
    }
}
