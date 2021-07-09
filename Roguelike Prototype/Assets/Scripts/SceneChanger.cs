using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] float fadeTime;
    [SerializeField] Weapon pistol;
    [SerializeField] Weapon shotgun;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(canvasGroup);
    }


    public void ChoosePistol(int scene)
    {
        StartCoroutine(ChoosePistolCoroutine(scene));

    }

    public void ChooseShotgun(int scene)
    {
        StartCoroutine(ChooseShotgunCoroutine(scene));

    }



    private IEnumerator ChoosePistolCoroutine(int scene)
    {
        yield return ChangeSceneWithFade(scene);
        SetGame(pistol);
    }

    private IEnumerator ChooseShotgunCoroutine(int scene)
    {
        yield return ChangeSceneWithFade(scene);
        SetGame(shotgun);
    }

    public IEnumerator ChangeSceneWithFade(int scene)
    {
        float startTime = Time.time;
        canvasGroup.blocksRaycasts = true;
        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha = (Time.time - startTime) / fadeTime;
            yield return null;
        }
        yield return SceneManager.LoadSceneAsync(scene);
        startTime = Time.time;
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha = 1 - ((Time.time - startTime) / fadeTime);
            yield return null;
        }
        canvasGroup.blocksRaycasts = false;
    }

    public void ChangeScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    private static void SetGame(Weapon weapon)
    {
        PlayerController playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        playerController.enabled = true;
        playerController.SetWeapon(weapon);
    }
}
