using Entitas;
using UnityEngine;

public class PigDirectionSystem : IExecuteSystem
{
    private Contexts _contexts;

    public PigDirectionSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Execute()
    {
        var facingRight = _contexts.game.pigDirection.value == 1;
        var transform = _contexts.game.pigEntity.view.value.transform;
        var target = _contexts.game.playerEntity.view.value.transform;

        if (transform.position.x - 1 > target.position.x && facingRight)
        {
            transform.Rotate(0, 180, 0);
            _contexts.game.pigEntity.ReplacePigDirection(0);
        }
        if (transform.position.x + 1 < target.position.x && !facingRight)
        {
            transform.Rotate(0, 180, 0);
            _contexts.game.pigEntity.ReplacePigDirection(1);

        }
    }

}
