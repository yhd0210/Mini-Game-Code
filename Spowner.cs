using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Tilemaps;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spowner : MonoBehaviour
{
    private Transform target;
    public GameObject enemy;
    private float realTime, randomx, randomy;
    [SerializeField] private float MaxTime;
    void Start()
    {
        realTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        realTime += Time.deltaTime;
        if (MaxTime <= realTime)
        {
            realTime = 0;
            RandomSelect();
        }
    }

    void RandomSelect()
    {
        target = GameObject.Find("player").transform;
        var vector3 = (Random.Range(0, 4)) switch
        {
            0 => new Vector2(target.position.x + 9.5f, target.position.y + Random.Range(-5.5f, 5.5f)),
            1 => new Vector2(target.position.x - 9.5f, target.position.y + Random.Range(-5.5f, 5.5f)),
            2 => new Vector2(target.position.x + Random.Range(-9.5f, 9.5f), target.position.y + 5),
            3 => new Vector2(target.position.x + Random.Range(-9.5f, 9.5f), target.position.y - 5),
            _ => Vector2.zero,
        };

        Instantiate(enemy, vector3, quaternion.identity);
    }
}
