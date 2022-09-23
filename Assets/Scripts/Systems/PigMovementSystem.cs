using Entitas;
using UnityEngine;

public class PigMovementSystem : IExecuteSystem
{
    private Contexts _contexts;

    public PigMovementSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Execute()
    {
        var health = _contexts.game.pigEntity.health.value;
        var transform = _contexts.game.pigEntity.view.value.transform;
        var target = _contexts.game.playerEntity.view.value.transform;
        var collider = _contexts.game.pigEntity.view.value.GetComponent<BoxCollider2D>();
        var facingRight = _contexts.game.pigDirection.value == 1;

        if (health < 100 && health > 0)
        {

            if (transform.position.x - collider.bounds.extents.x > target.position.x && !facingRight)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x, transform.position.y), 4.0f * Time.deltaTime);

            }

            else if (transform.position.x + collider.bounds.extents.x < target.position.x && facingRight)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x, transform.position.y), 4.0f * Time.deltaTime);
            }
        }
    }
}
