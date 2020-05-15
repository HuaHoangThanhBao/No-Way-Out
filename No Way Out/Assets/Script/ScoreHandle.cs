using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreHandle : MonoBehaviour {

    PlayerControl playerControl;
    PlayerProcess playerProcess;

    public Text [] text_Lst;
    public GameObject[] but_lst;

    Text scoreInGame_txt;
    Text guide_txt;
    Text title_txt;
    Text highScore_txt;
    Text scoreEndGame_txt;

    GameObject replayButton_IMG;
    GameObject scoreEndGame_IMG;

    int scoreInGame = 0;

    int temp = 0;

    private void Awake()
    {
        Find();
        CreateArray();
    }

    void CreateArray()
    {
        text_Lst = new Text[5];
        but_lst = new GameObject[2];
    }

    void Find()
    {
        replayButton_IMG = GameObject.Find("Replay Button IMG");
        scoreEndGame_IMG = GameObject.Find("Score End Game IMG");

        playerControl = FindObjectOfType<PlayerControl>();
        guide_txt = GameObject.Find("Guide").GetComponent<Text>();
        title_txt = GameObject.Find("Title").GetComponent<Text>();
        highScore_txt = GameObject.Find("High Score").GetComponent<Text>();
        scoreInGame_txt = GameObject.Find("Score In Game").GetComponent<Text>();
        scoreEndGame_txt = GameObject.Find("Score End Game").GetComponent<Text>();
    }

    void AddObj()
    {
        text_Lst[0] = (scoreInGame_txt);
        text_Lst[1] = (guide_txt);
        text_Lst[2] = (title_txt);
        text_Lst[3] = (highScore_txt);
        text_Lst[4] = (scoreEndGame_txt);

        but_lst[0] = (replayButton_IMG);
        but_lst[1] = (scoreEndGame_IMG);
    }

    private void Start()
    {
        AddObj();

        LoadScore();

        SetScoreWhenBegin();
    }

    void SetScoreWhenBegin()
    {
        replayButton_IMG.SetActive(false);

        scoreEndGame_IMG.SetActive(false);

        text_Lst[0].enabled = false;

        text_Lst[3].enabled = true;

        text_Lst[3].text = "BEST SCORE : " + getHighScore().ToString();
    }

    void ScoreHandler()
    {
        if (!playerControl.variables.death)
        {
            if (playerControl.keyDown())
            {
                SetUIWhenPlaying();
            }

            if (playerControl.variables.hitEdgeLeft || playerControl.variables.hitEdgeRight)
            {
                if (temp == 0)
                {
                    scoreInGame++;

                    text_Lst[0].text = scoreInGame.ToString();

                    temp++;
                }
            }
            else temp = 0;
        }
        else
        {
            SetUIWhenEndGame();

            SubmitHighScore(scoreInGame);

            text_Lst[0].text = "0".ToString();

            text_Lst[4].text = scoreInGame.ToString();

            text_Lst[3].text = "BEST SCORE : " + getHighScore().ToString();
        }
    }

    void SetUIWhenPlaying()
    {
        text_Lst[0].enabled = true;
        text_Lst[1].enabled = false;
        text_Lst[2].enabled = false;
        text_Lst[3].enabled = false;
    }

    void SetUIWhenEndGame()
    {
        text_Lst[2].enabled = true;
        text_Lst[3].enabled = true;
        replayButton_IMG.SetActive(true);
        scoreEndGame_IMG.SetActive(true);
    }

    int getHighScore()
    {
        return playerProcess.highScore;
    }

    void LoadScore()
    {
        playerProcess = new PlayerProcess();

        if(PlayerPrefs.HasKey("highScore"))
        {
            playerProcess.highScore = PlayerPrefs.GetInt("highScore");
        }
    }

    void SubmitHighScore(int newScore)
    {
        if(playerProcess.highScore < newScore)
        {
            playerProcess.highScore = newScore;

            PlayerPrefs.SetInt("highScore", playerProcess.highScore);
        }
    }

    public void LoadSceneAction()
    {
        SceneManager.LoadScene("NoWayOut");
    }

    private void Update()
    {
        ScoreHandler();
    }
}
