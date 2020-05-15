using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSceneOnStartUpScene : MonoBehaviour {

    private void Start()
    {
        StartCoroutine(ChangeScene());
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(4f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("NoWayOut");
    }
}
