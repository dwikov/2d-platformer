using Entitas;
using UnityEngine;

public class PlayerDirectionSystem : IExecuteSystem
{
    private Contexts _contexts;

    public PlayerDirectionSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Execute()
    {
        var facingRight = _contexts.game.direction.value == 1;
        var input = _contexts.game.input.value.x;
        var transform = _contexts.game.playerEntity.view.value.transform;
        if (input == -1 && facingRight) {
            transform.Rotate(0, 180, 0);
            _contexts.game.ReplaceDirection(-1);
        }
        if (input == 1 && !facingRight)
        {
            transform.Rotate(0, 180, 0);
            _contexts.game.ReplaceDirection(1);
        }
    }

}
