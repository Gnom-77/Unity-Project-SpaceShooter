using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    GameObject[] Enemy_Prefab;
    [SerializeField]
    float Tiem_Spawn = 0.5f;
    [SerializeField] float minDistance, maxDistance;

    private void Start()
    {
        StartCoroutine(Enemy_Spawn());
    }

    IEnumerator Enemy_Spawn()
    {
        while (true) 
        {
            var wanted = Random.Range(minDistance, maxDistance);
            var position = new Vector2 (wanted, transform.position.y);
            GameObject gameObject = Instantiate(Enemy_Prefab[Random.Range(0, Enemy_Prefab.Length)], position, Quaternion.identity);
            yield return new WaitForSeconds(Tiem_Spawn);
            Destroy(gameObject, 5f);
        }
    }
}
