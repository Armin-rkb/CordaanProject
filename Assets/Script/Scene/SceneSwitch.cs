using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneSwitch : MonoBehaviour
{
    // This is for Debugging. (Will get removed later)
    [SerializeField]
    private PlayerData playerData;

    [SerializeField]
    private Image fadeScreen;
    private Color fadeColor;

    void Start()
    {
        fadeColor = fadeScreen.color;
    }

    public void TransitionToScene(string sceneName, bool fade = false, bool delay = false, float seconds = 0)
    {
        if (!delay && !fade)
            SceneManager.LoadScene(sceneName);
        else if (delay && !fade)
            StartCoroutine(DelayFunction(sceneName, seconds));
        else if (fade && !delay)
            StartCoroutine(FadeToNextScene(sceneName, seconds));

    }

    IEnumerator FadeToNextScene(string sceneName, float seconds)
    {
        while (true)
        {
            if (fadeScreen.color.a < 1)
            {
                fadeColor.a += 0.01f;
                fadeScreen.color = fadeColor;
            }

            else if (fadeScreen.color.a >= 1)
                SceneManager.LoadScene(sceneName);

            yield return new WaitForSeconds(0.025f);
        }
    }


    IEnumerator DelayFunction(string sceneName, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(sceneName);
        StopAllCoroutines();
    }

    // This is for Debugging. (Will get removed later)
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)){
            NextSceneArmin();
        }
        if (Input.GetKeyDown(KeyCode.R)){
            NextSceneRaymon();
        }
    }

    // This is for Debugging. (Will get removed later)
    public void NextSceneArmin()
    {
        playerData.ActiveUser = NameData.armin;
        SceneManager.LoadScene("Scene1");
    }

    // This is for Debugging. (Will get removed later)
    public void NextSceneRaymon()
    {
        playerData.ActiveUser = NameData.raymon;
        SceneManager.LoadScene("Scene1");
    }
}