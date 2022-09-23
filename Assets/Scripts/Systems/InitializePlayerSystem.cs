using Entitas;
using UnityEngine;

public class InitializePlayerSystem : IInitializeSystem
{
    private Contexts _contexts;
    public InitializePlayerSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Initialize()
    {
        var entity = _contexts.game.CreateEntity();
        entity.isPlayer = true;
        entity.AddResource(_contexts.game.gameSetup.value.character);
        entity.AddInitialPosition(new Vector3(0, -5.15f, 0));
        entity.AddDirection(1);
        entity.AddVelocity(0f);
        entity.AddDoubleJump(false);
    }
}
