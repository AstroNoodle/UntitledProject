using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Combat : MonoBehaviour
{

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public int attackDamage = 40;
    public int health = 100;
    public int experiance;
    public int gold;

    public float attackRate = 2f;
    private float nextAttackTime = 0f;

    public bool questOn = false;
    //public Quest quest;
    public GameObject QuestWindow;
    public Text whatQuest;
    public Text questReward;
    public Text questProg;
    public Text exp;
    public Text HPamount;

    public int enemiesKilled = 0;
    public int expValue;

    void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
        if(questOn && enemiesKilled == 0)
        {
            whatQuest.text = "Quest: Kill 3 enemies";
            questReward.text = "Reward: 20 exp";
            questProg.text = "Enemies: 0/3";
        }
        if(questOn && enemiesKilled >= 0)
        {
            whatQuest.text = "Quest: Kill 3 enemies";
            questReward.text = "Reward: 20 exp";
            questProg.text = "Enemies: " + enemiesKilled + "/3";
        }
        if(questOn && enemiesKilled == 3)
        {
            expValue += 20;
            questOn = false;
            enemiesKilled = 0;
            whatQuest.text = "";
            questReward.text = "";
            questProg.text = "";
            exp.text = "Experiance: " + expValue;
        }
        HPamount.text = "Health P1: " + health;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "QuestGiver" && !questOn)
        {
            Quest();
        }
        if (collision.tag == "Enemy")
        {
            health -= 20;
            Debug.Log(health);
        }
        if (health <= 0)
        {
            Application.LoadLevel(0);
        }
    }

    void Attack()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);
        foreach(Collider enemy in hitEnemies)
        {
            Debug.Log("Hit " + enemy.name);
            enemy.GetComponent<Enemy>().takeDamage(attackDamage);
            enemiesKilled += 1;
            Debug.Log(enemiesKilled);
        }
    }

    public void Quest()
    {
        enemiesKilled = 0;
        Debug.Log("Quest");
        questOn = true;
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
