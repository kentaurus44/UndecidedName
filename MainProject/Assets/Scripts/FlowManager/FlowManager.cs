using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class FlowManager : SingletonComponent<FlowManager>
{
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }

    public void GoTo(string scene)
    {
        StartCoroutine(LoadScene(scene));
    }

    private IEnumerator LoadScene(string scene)
    {
        yield return SceneManager.LoadSceneAsync(scene);
    }
}
