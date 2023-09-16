using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextTurnScript : MonoBehaviour
{

    public GameObject gm;
    private GMLogic gmlogic;

    public Sprite nextPage;
    private SpriteRenderer sr;
    private bool isOver = false;
    void Start(){
        gmlogic = gm.GetComponent<GMLogic>();
        sr = GetComponent<SpriteRenderer>();
    }
    void OnMouseDown(){
        if (isOver) {
            GoToVictoryScreen();
        }
        gmlogic.executeBattleActions();
        if (gmlogic.enemyHealth <= 0){
            sr.sprite = nextPage;
            isOver = true;
        }
    }

    void GoToVictoryScreen(){
        SceneManager.LoadScene("VictoryScene");
    }
}
