using Entitas;
using UnityEngine;

public class PigAnimationSystem : IExecuteSystem
{
    private Contexts _contexts;

    public PigAnimationSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Execute()
    {
        var health = _contexts.game.pigEntity.health.value;
        var transform = _contexts.game.pigEntity.view.value.transform;
        var animator = _contexts.game.pigEntity.view.value.GetComponent<Animator>();
        var bc = _contexts.game.pigEntity.view.value.GetComponent<BoxCollider2D>();
        if (health <= 0)
        {
            mobDeath(transform, animator, bc);
        }
        else if(health < 100 && health > 0)
        {
           animator.Play("pig_run");
        }
    }


    private void mobDeath(Transform transform, Animator animator, BoxCollider2D bc)
    {
         
        if (transform.tag.Equals("PigMob"))
        {
            animator.Play("pig_hit2");
        }

        transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, transform.position.y + 15), 15 * Time.deltaTime);
        bc.enabled = false;
    }
}
