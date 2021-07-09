using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    [SerializeField] Health player;


    private void Update()
    {
        transform.localScale = new Vector2(player.GetHealthFraction(), transform.localScale.y);
    }
}
