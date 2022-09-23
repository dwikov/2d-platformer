using Entitas;
using UnityEngine;

public class InitializePigSystem : IInitializeSystem
{
    private Contexts _contexts;
    public InitializePigSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Initialize()
    {
        var entity = _contexts.game.CreateEntity();
        entity.AddResource(_contexts.game.gameSetup.value.pig);
        entity.AddInitialPosition(new Vector3(3, -5.15f, 0));
        entity.AddVelocity(0f);
        entity.isPig = true;
        entity.AddHealth(100);
        entity.AddPigDirection(0);
    }
}
