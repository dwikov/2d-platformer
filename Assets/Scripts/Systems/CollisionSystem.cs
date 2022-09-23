using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;

public class CollisionSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
    public CollisionSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }
    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Collision);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasCollision;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        _contexts.game.pigEntity.health.value -= 25;
        var animator = _contexts.game.playerEntity.view.value.GetComponent<Animator>();
        animator.Play("pig_hit1");
    }
}
