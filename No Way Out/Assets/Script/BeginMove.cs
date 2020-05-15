using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginMove : MonoBehaviour {

    public enum BeginState
    {
        MoveDown,
        MoveUp,
    }

    bool changeState;

    float time;
    float speed = 0.5f;
    float deltaTime = 0.5f;
    float timeChange = 0.5f;

    public BeginState beginMove;

    private void Update()
    {
        HandleState();
        Ter();
    }

    void HandleState()
    {
        time += Time.deltaTime;

        if (time < timeChange)
        {
            changeState = true;
        }
        else if (time >= timeChange && time < timeChange + deltaTime)
        {
            changeState = false;
        }
        else time = 0;
    }

    void Ter()
    {
        if (changeState)
        {
            beginMove = BeginState.MoveUp;

            this.transform.position = Vector3.Lerp(transform.position, new Vector3(0, 3, 0), Time.deltaTime * speed);
        }
        else
        {
            beginMove = BeginState.MoveDown;

            this.transform.position = Vector3.Lerp(transform.position, new Vector3(0, -1, 0), Time.deltaTime * speed);
        }
    }
}
