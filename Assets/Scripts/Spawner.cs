using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _border;
    [SerializeField] private GameObject _obstacle;
    [SerializeField] private GameObject _gold;


    [SerializeField] private float _distanceBetweenSpawns;
    [SerializeField] private float _spawnTimeBoost;

    [SerializeField] private Vector2 _timeBetweenObstacleSpawns;
    [SerializeField] private Vector2 _timeBetweenGoldSpawns;

    public bool shouldSpawn=true;

    

    private void Start()
    {
        StartCoroutine(StartSpawningObstacle());
        StartCoroutine(StartSpawningGold());
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Border")
        {
            var collidedBorder = collision.gameObject.transform;

            Instantiate(_border
                , new Vector3(collidedBorder.position.x, collidedBorder.position.y + _distanceBetweenSpawns, collidedBorder.position.z)
                , Quaternion.identity);

            Destroy(collision.gameObject);
        }
    }

    IEnumerator StartSpawningObstacle()
    {
        while (true && _obstacle!=null && shouldSpawn)
        {
            _spawnTimeBoost -= Time.deltaTime;
            yield return new WaitForSeconds(Random.Range(_timeBetweenObstacleSpawns.x + _spawnTimeBoost, _timeBetweenObstacleSpawns.y + _spawnTimeBoost));
            Transform cam = Camera.main.transform.GetChild(0).transform;
            var obstacle = Instantiate(_obstacle, new Vector3(Random.Range(-3.558f, -1.5f), cam.position.y, 0), Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(_timeBetweenObstacleSpawns.x + _spawnTimeBoost, _timeBetweenObstacleSpawns.y + _spawnTimeBoost));
        }
    }

    IEnumerator StartSpawningGold()
    {
        while(true && _gold!=null && shouldSpawn)
        {
            yield return new WaitForSeconds(Random.Range(_timeBetweenGoldSpawns.x, _timeBetweenGoldSpawns.y));
            Transform cam = Camera.main.transform.GetChild(0).transform;
            int random = Random.Range(0, 5);

            if (random >= 2) {
                var gold = Instantiate(_gold, new Vector3(-0.406f, cam.position.y, 0), Quaternion.identity);
            }
            else
            {
                var gold = Instantiate(_gold, new Vector3(-4.53f, cam.position.y, 0), Quaternion.identity);
            }
            yield return new WaitForSeconds(Random.Range(_timeBetweenGoldSpawns.x, _timeBetweenGoldSpawns.y));
        }
    }
}
