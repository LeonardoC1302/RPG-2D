using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int gold;
    public TextMeshProUGUI goldText;
    private Defense defenseToPlace;
    public GameObject grid;
    public CustomCursor customCursor;
    public TileScript[] tiles;
    private int[] skillCosts = { 100, 200, 300, 400, 500, 600 };
    void Update()
    {
        goldText.text = gold.ToString();

        if(Input.GetMouseButtonDown(0) && defenseToPlace != null){
            TileScript nearestTile = null;
            float nearestDistance = float.MaxValue;

            foreach(TileScript tile in tiles){
                float distance = Vector2.Distance(tile.transform.position, customCursor.transform.position);
                if(distance < nearestDistance){
                    nearestDistance = distance;
                    nearestTile = tile;
                }
            }
            if(!nearestTile.isOccupied){
                Defense defensePlaced = Instantiate(defenseToPlace, nearestTile.transform.position, Quaternion.identity);
                defensePlaced.setTile(nearestTile);

                defenseToPlace = null;
                nearestTile.isOccupied = true;
                grid.SetActive(false);
                customCursor.gameObject.SetActive(false);
                Cursor.visible = true;
            }
        }   
    }

    public void buyDefense(Defense defense){
        if (gold >= defense.cost) {
            customCursor.gameObject.SetActive(true);
            customCursor.GetComponent<SpriteRenderer>().sprite = defense.GetComponent<SpriteRenderer>().sprite;
            Cursor.visible = false;

            gold -= defense.cost;
            defenseToPlace = defense;
            grid.SetActive(true);
        }
    }

    public void addGold(int goldToAdd){
        gold += goldToAdd;
    }

    public void useSkill(int skillIndex){
        if(gold < skillCosts[skillIndex]) return;
        switch(skillIndex){
            case 0:
                Debug.Log("Healing all allies");
                HealAll();
                break;
            case 1:
                Debug.Log("Increasing allies damage");
                IncreaseDamage();
                break;
            case 2:
                Debug.Log("Increasing allies speed");
                IncreaseSpeed();
                break;
            case 3:
                Debug.Log("Leveling up all allies");
                LevelUpAll();
                break;
            case 4:
                Debug.Log("Targeting one enemy");
                TargetEnemy();
                break;
            case 5:
                Debug.Log("Dealing damage to all enemies");
                DamageAll();
                break;
        }
        gold -= skillCosts[skillIndex];
    }

    private void HealAll(){
        Defense[] defenses = FindObjectsOfType<Defense>();
        foreach(Defense defense in defenses){
            if(defense.GetComponent<GemScript>() != null) continue;
            defense.Heal(defense.health/2);
        }
    }

    private void IncreaseDamage(){
        Defense[] defenses = FindObjectsOfType<Defense>();
        foreach(Defense defense in defenses){
            if(defense.GetComponent<GemScript>() != null) continue;
            defense.IncreaseDamage(defense.damage/2);
        }
    }

    private void IncreaseSpeed(){
        Defense[] defenses = FindObjectsOfType<Defense>();
        foreach(Defense defense in defenses){
            if(defense.GetComponent<GemScript>() != null) continue;
            defense.IncreaseSpeed(defense.timeBetweenAttacks/2);
        }
    }

    private void LevelUpAll(){
        Defense[] defenses = FindObjectsOfType<Defense>();
        foreach(Defense defense in defenses){
            if(defense.GetComponent<GemScript>() != null) continue;
            defense.increaseLevel(3); // Increase 3 levels
        }
    }

    private void TargetEnemy(){
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Enemy target = null;
        int maxHealth = 0;
        foreach(Enemy enemy in enemies){
            if(enemy.health > maxHealth){
                maxHealth = enemy.health;
                target = enemy;
            }
        }
        if(target != null){
            target.isTarget = true;
        }
    }

    private void DamageAll(){
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        foreach(Enemy enemy in enemies){
            enemy.takeDamage(enemy.health/2);
        }
    }

}
