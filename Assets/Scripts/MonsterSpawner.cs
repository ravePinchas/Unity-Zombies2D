using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] monsterReference;

    [SerializeField]
    private Transform leftPos, rightPos;

    private GameObject spawnMonster;

    private int randomIndex, randomSide;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpwanMonsters());
    }

    IEnumerator SpwanMonsters()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));

            randomIndex = Random.Range(0, monsterReference.Length);
            randomSide = Random.Range(0, 2);

            spawnMonster = Instantiate(monsterReference[randomIndex]);

            if (randomSide == 0)
            {
                spawnMonster.transform.position = leftPos.position;
                spawnMonster.GetComponent<Monsters>().speed = Random.Range(4, 10);

            }
            else
            {
                spawnMonster.transform.position = rightPos.position;
                spawnMonster.GetComponent<Monsters>().speed = -Random.Range(4, 10);
                spawnMonster.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }
    }
}
