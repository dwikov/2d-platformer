using Entitas;
using UnityEngine;

public class PlayerJumpSystem : IExecuteSystem
{
    private Contexts _contexts;

    public PlayerJumpSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Execute()
    {
        if (Input.GetButtonDown("Jump"))
        {
            var rb = _contexts.game.playerEntity.view.value.GetComponent<Rigidbody2D>();
            var doubleJump = _contexts.game.doubleJump.value;
            if (grounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, 25.0f);
                _contexts.game.ReplaceDoubleJump(true);
            }
            else if (doubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, 25.0f);
                _contexts.game.ReplaceDoubleJump(false);
            }
        }
    }

    private bool grounded()
    {
        var boxCollider = _contexts.game.playerEntity.view.value.GetComponent<BoxCollider2D>();
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, .1f, LayerMask.GetMask("Front"));
        return hit.collider != null;
    }
}