using UnityEngine;

public class PlayerController
{
    private Player player;
    private ActorStats playerStats;
    Controls inputs;

    public PlayerController(ActorStats PlayerStats, Controls Inputs, GameObject PlayerModel)
    {
        inputs = Inputs;
        playerStats = PlayerStats;

        player = new Player(playerStats, PlayerModel);
    }

    public void Move()
    {
        player.PlayerMove(inputs);
        player.PlayerAttack(inputs);
    }

    public void Trigger()
    {
        player.PlayerTrigger();
    }
}
