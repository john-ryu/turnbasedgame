using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GMLogic : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject swordAction;
    public GameObject defenseAction;
    public GameObject magicAction;
    public SwordActionScript swordActionScript;
    public DefenseActionScript defenseActionScript;

    public GameObject gem;
    public float xMinSpawn = 0;
    public float xMaxSpawn = 8;
    public float yMinSpawn = -4;
    public float yMaxSpawn = 0;
    private int playerHealth = 20;
    public TextMeshProUGUI playerHealthText;
    public float enemyHealth = 10;
    public GameObject enemy;
    private EnemyScript enemyScript;
    public TextMeshProUGUI enemyHealthText;
    void Start()
    {
        swordActionScript = swordAction.GetComponent<SwordActionScript>();
        defenseActionScript = defenseAction.GetComponent<DefenseActionScript>();
        enemyScript = enemy.GetComponent<EnemyScript>();
        spawnGems(5);
    }

    void Update()
    {
        
    }

    void executeSwordAttack(int e){
        switch(e){
            case 0:
                return;
            case 1:
                enemyHealth--;
                break;
            case 2:
                enemyHealth -= 3;
                break;
            case 3:
                enemyHealth -= 7;
                break;
            default:
                return;
        }
    }

    private int executeDefenseMove(int e){
        switch(e){
            case 0:
                return 0;
            case 1:
                return 2;
                break;
            case 2:
                return 4;
                break;
            case 3:
                return 5;
                break;
            default:
                return 5;
        }
    }

    [ContextMenu("Execute Battle Actions")]
    public void executeBattleActions(){
        executeSwordAttack(swordActionScript.energyCount);
        if (enemyHealth <=0) {
            enemyScript.enemyDie();
        } else {
            enemyScript.takeHit();
        }

        dealPlayerDamage(3, executeDefenseMove(defenseActionScript.energyCount));
        enemyHealthText.text = enemyHealth.ToString() + "/10";
        playerHealthText.text = playerHealth.ToString() + "/20";
        if (enemyHealth <=0) {
            enemyScript.enemyDie();
        }
        spawnGems(5);
    }

    void dealPlayerDamage(int count, int block){
        playerHealth -= Mathf.Max(0, count - block);
    }
    void spawnGems(int count){
        GameObject[] gems = GameObject.FindGameObjectsWithTag("Gem");
        foreach(GameObject g in gems){
            Destroy(g);
        }
        for (int i = 0; i < count; i++){
            GameObject newGem = Instantiate(gem, new Vector3(Random.Range(xMinSpawn, xMaxSpawn), Random.Range(yMinSpawn, yMaxSpawn), -5), Quaternion.identity);
            SpriteRenderer sr = newGem.GetComponent<SpriteRenderer>();
            sr.color = Color.yellow;
        }
    }
}
