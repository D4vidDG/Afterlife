using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    [SerializeField] GameObject winCanvas;
    float enemies;
    private void Start()
    {
        enemies = transform.childCount;
    }
    public void EnemyKilled()
    {
        enemies--;
        print(enemies);
        if (enemies == 0)
        {
            winCanvas.SetActive(true);
        }
    }
}
