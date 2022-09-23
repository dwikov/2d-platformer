using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D hit) {
        if (hit.tag.Equals("Player")) return;

        var entity = Contexts.sharedInstance.game.CreateEntity();
        entity.AddCollision(gameObject);
        
        Destroy(gameObject);
    }
}
