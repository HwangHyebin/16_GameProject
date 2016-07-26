using UnityEngine;
using System.Collections;

public class PlayerStateMachine 
{
    public  PlayerState     player_state;
    private Player          player;

    public void Init(Player _player)
    {
        player_state    = PlayerIdle.Instance;
        player          = _player;
    }
    public void ChangeState(PlayerState nextState)
    {
        if (player_state == null)
            player_state = PlayerIdle.Instance;
        if (player_state == nextState)
            return;
        player_state.Exit(player);
        player_state = nextState;
        player_state.Enter(player);

        switch (player.player_anim)
        {
            case Player.PLAYER_ANIMATOR.IDLE:
                player.anim.SetInteger("animation", 0);
                break;
            case Player.PLAYER_ANIMATOR.RUN:
                player.anim.SetInteger("animation", 1);
                break;
            case Player.PLAYER_ANIMATOR.ATTACK:
                player.anim.SetInteger("animation", 2);
                break;
            case Player.PLAYER_ANIMATOR.DEAD:
                player.anim.SetInteger("animation", 3);
                break;
        }
    }
    public void Update()
    {
        player_state.Execute(player);
    }
}
