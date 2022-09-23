using Entitas;
using UnityEngine;

public class InitializeFireSystem : IExecuteSystem
{
    private Contexts _contexts;
    public InitializeFireSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Execute()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            var entity = _contexts.game.CreateEntity();
            entity.AddResource(_contexts.game.gameSetup.value.fire);
            var playerTransfrom = _contexts.game.playerEntity.view.value.transform;
            var playerDirection = _contexts.game.playerEntity.direction.value; 
            entity.AddInitialPosition(playerTransfrom.position);
            entity.AddVelocity(30f * playerDirection);
        }

    }
}
