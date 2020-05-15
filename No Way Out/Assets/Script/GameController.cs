using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public enum BackgroundStyle
    {
        gameplayBackground,
        startUpBackground
    }

    public BackgroundStyle style;

    GameObject gamePlayBackground;
    GameObject startUpBackground;

    private void Awake()
    {
        gamePlayBackground = Resources.Load("Prefab/Gameplay Background") as GameObject;
        startUpBackground = Resources.Load("Prefab/StartUp Background") as GameObject;
    }

    private void Start()
    {
        switch(style)
        {
            case BackgroundStyle.gameplayBackground:
                gamePlayBackground = (GameObject)Instantiate(gamePlayBackground, Vector3.zero, Quaternion.identity);
                gamePlayBackground.transform.parent = transform;
                break;
            case BackgroundStyle.startUpBackground:
                startUpBackground = (GameObject)Instantiate(startUpBackground, Vector3.zero, Quaternion.identity);
                startUpBackground.transform.parent = transform;
                break;
        }
    }
}
