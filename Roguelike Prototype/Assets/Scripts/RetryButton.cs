using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetryButton : MonoBehaviour
{
    public void Retry()
    {
        FindObjectOfType<SceneChanger>().ChangeScene(0);
    }
}
