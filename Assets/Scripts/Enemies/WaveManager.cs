using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    [System.Serializable]
    public class Wave {
        public Enemy[] enemies;
        public int count;
        public float timeBetweenSpawns;
    }

    public Wave[] waves;
    public Transform[] spawnPoints;
    public float timeBetweenWaves;
    private bool finishedSpawning;

    private Wave currentWave;
    private int currentWaveIndex;
    private Transform gem; // Change to defenses
    public TextMeshProUGUI waveText;

    private void Start(){
        gem = GameObject.FindGameObjectWithTag("Gem").transform; // Change to defenses
        waveText.text = "Wave " + (currentWaveIndex + 1).ToString();
        StartCoroutine(StartNextWave(currentWaveIndex));
    }

    IEnumerator StartNextWave(int index){
        yield return new WaitForSeconds(timeBetweenWaves);
        StartCoroutine(SpawnWave(index));
    }

    IEnumerator SpawnWave(int index){
        currentWave = waves[index];
        for (int i = 0; i < currentWave.count; i++){
            if(gem == null){
                yield break;
            }
            Enemy randomEnemy = currentWave.enemies[Random.Range(0, currentWave.enemies.Length)];
            Transform randomSpot = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(randomEnemy, randomSpot.position, randomSpot.rotation);
            if(i == currentWave.count - 1){
                finishedSpawning = true;
            } else {
                finishedSpawning = false;
            }
            yield return new WaitForSeconds(currentWave.timeBetweenSpawns);
        }
    }

    private void Update(){
        if(finishedSpawning == true && GameObject.FindGameObjectsWithTag("Enemy").Length == 0){
            finishedSpawning = false;
            if(currentWaveIndex + 1 < waves.Length){
                Defense[] defenses = FindObjectsOfType<Defense>();
                foreach(Defense defense in defenses){
                    if(defense.GetComponent<GemScript>() != null) continue;
                    defense.increaseLevel();
                }
                currentWaveIndex++;
                waveText.text = "Wave " + (currentWaveIndex + 1).ToString();
                Debug.Log("Wave Completed!");
                StartCoroutine(StartNextWave(currentWaveIndex));
            } else {
                Debug.Log("You win!");
                // Change to win screen
            }
        }
    }
}
