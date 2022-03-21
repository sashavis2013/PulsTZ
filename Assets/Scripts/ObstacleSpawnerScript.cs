using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnerScript : MonoBehaviour
{
   
    public List<Transform> SpawnPointsList;

    void Start()
    {
        StartCoroutine(SpawnerCoroutine());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator SpawnerCoroutine()
    {
        while (Time.timeScale == 1)
        {
            SpawnObstacle();
            yield return new WaitForSeconds(Random.Range(1f, 2f));
        }
        
    }

    private void SpawnObstacle()
    {
        GameObject obstacle = ObjectPool.SharedInstance.GetPooledObject();
        if (obstacle != null)
        {
            int randomSpawnPoint = Random.Range(0, SpawnPointsList.Count);
            obstacle.transform.position = SpawnPointsList[randomSpawnPoint].position;
            obstacle.SetActive(true);
        }
    }


}
