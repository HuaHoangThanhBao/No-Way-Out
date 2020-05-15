using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMoveRight : MonoBehaviour {

    public float speed = 2;

    float time;
    float time1;

    PlayerControl player;
    SpikeControlRight spikeControl;

    private void Start()
    {
        time = 0;
        time1 = 0;
        spikeControl = FindObjectOfType<SpikeControlRight>();
        player = FindObjectOfType<PlayerControl>();
    }

    int number = 0;
    int temp = 0;

    void MoveBack()
    {
        if (player.variables.hitCollisionEdgeRight)
        {
            time1 += Time.deltaTime;

            if (time1 < 0.35f)
                this.transform.position = Vector3.Lerp(transform.position, transform.position + Vector3.right, Time.deltaTime * speed);
            else
            {
                time1 = 0;
                player.variables.hitCollisionEdgeRight = false;
                spikeControl.DestroyClone();
            }
        }
        else temp = 0;
    }

    void MoveOut()
    {
        time += Time.deltaTime;

        if (time < 0.35f)
            this.transform.position = Vector3.Lerp(transform.position, transform.position - Vector3.right, Time.deltaTime * speed);
    }

    private void Update()
    {
        MoveBack();
        MoveOut();
    }
}
