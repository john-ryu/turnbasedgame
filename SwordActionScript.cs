using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordActionScript : MonoBehaviour
{

    public int energyCount = 0;
    public GameObject energySlot1;
    private SpriteRenderer energySlot1Sprite;
    public GameObject energySlot2;
    private SpriteRenderer energySlot2Sprite;
    public GameObject energySlot3;
    private SpriteRenderer energySlot3Sprite;
    public Sprite energyEmpty;
    public Sprite energyFull;
    
    public GameObject intent;
    private SpriteRenderer intentSpriteRenderer;
    public Sprite attack1;
    public Sprite attack3;
    public Sprite attack7;
    void Start(){
        energySlot1Sprite = energySlot1.GetComponent<SpriteRenderer>();
        energySlot2Sprite = energySlot2.GetComponent<SpriteRenderer>();
        energySlot3Sprite = energySlot3.GetComponent<SpriteRenderer>();
        intentSpriteRenderer = intent.GetComponent<SpriteRenderer>();
        intentSpriteRenderer.color = new Color(1f,1f,1f,0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter2D (Collider2D col) {
        energyCount++;
        UpdateEnergySlots(energyCount);
    }

    void OnTriggerExit2D (Collider2D col) {
        energyCount--;
        UpdateEnergySlots(energyCount);
    }

    void UpdateEnergySlots(int count){
        switch(count){
            case 0:
                energySlot1Sprite.sprite = energyEmpty;
                energySlot2Sprite.sprite = energyEmpty;
                energySlot3Sprite.sprite = energyEmpty;
                intentSpriteRenderer.color = new Color(1f,1f,1f,0f);
                break;
            case 1:
                energySlot1Sprite.sprite = energyFull;
                energySlot2Sprite.sprite = energyEmpty;
                energySlot3Sprite.sprite = energyEmpty;
                intentSpriteRenderer.color = new Color(1f,1f,1f,1f);
                intentSpriteRenderer.sprite = attack1;
                break;
            case 2:
                energySlot1Sprite.sprite = energyFull;
                energySlot2Sprite.sprite = energyFull;
                energySlot3Sprite.sprite = energyEmpty;
                intentSpriteRenderer.color = new Color(1f,1f,1f,1f);
                intentSpriteRenderer.sprite = attack3;
                break;
            case 3:
                energySlot1Sprite.sprite = energyFull;
                energySlot2Sprite.sprite = energyFull;
                energySlot3Sprite.sprite = energyFull;
                intentSpriteRenderer.color = new Color(1f,1f,1f,1f);
                intentSpriteRenderer.sprite = attack7;
                break;
            default: //more than 3
                energySlot1Sprite.sprite = energyFull;
                energySlot2Sprite.sprite = energyFull;
                energySlot3Sprite.sprite = energyFull;
                intentSpriteRenderer.color = new Color(1f,1f,1f,1f);
                intentSpriteRenderer.sprite = attack7;
                break;
        }
    }
}