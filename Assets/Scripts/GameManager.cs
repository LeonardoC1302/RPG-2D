using System.Collections;
using System.Collections.Generic;
using TMPro;
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
}
