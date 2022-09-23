using Entitas;
using UnityEngine;

public class PlayerAnimationSystem : IExecuteSystem
{
    private Contexts _contexts;

    public PlayerAnimationSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Execute()
    {
        var input = _contexts.game.input.value.x;
        if(input == 1 || input == -1)
        {
            playAnim("mask_run");
        }
        else
        {
            playAnim("mask_idle");
        }
        
    }

    private void playAnim(string type)
    {
        var animator = _contexts.game.playerEntity.view.value.GetComponent<Animator>();
        var doubleJump = _contexts.game.doubleJump.value;
        if (falling())
        {
            animator.Play("mask_fall");
        }
        else if (!grounded())
        {
            if (doubleJump)
            {
                animator.Play("mask_jump");
            }
            else
            {
                animator.Play("mask_djump");
            }
        }
        else
        {
            animator.Play(type);
        }
    }

    private bool grounded()
    {
        var boxCollider = _contexts.game.playerEntity.view.value.GetComponent<BoxCollider2D>();
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, .1f, LayerMask.GetMask("Front"));
        return hit.collider != null;
    }

    private bool falling()
    {
        var rb = _contexts.game.playerEntity.view.value.GetComponent<Rigidbody2D>();
        return rb.velocity.y < -0.1;
    }
}
