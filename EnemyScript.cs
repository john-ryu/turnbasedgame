using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Sprite hitSprite;
    public Sprite normalSprite;
    public Sprite deadSprite;
    private SpriteRenderer spriteRenderer;

    void Start(){
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = normalSprite;
    }
    
    void Update(){

    }

    [ContextMenu("Take Hit")]
    public void takeHit(){
        spriteRenderer.sprite = hitSprite;
        Invoke("returnToNormal", 0.5f);
    }

    void returnToNormal(){
        spriteRenderer.sprite = normalSprite;
    }

    public void enemyDie(){
        spriteRenderer.sprite = deadSprite;
    }
}
