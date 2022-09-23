using Entitas;
using UnityEngine;

public class PlayerMovementSystem : IExecuteSystem
{
    private Contexts _contexts;

    public PlayerMovementSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Execute()
    {
        var input = _contexts.game.input.value.x;
        var rb = _contexts.game.playerEntity.view.value.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(10f * input, rb.velocity.y);
    }
}
