using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMoveLeft : MonoBehaviour {

    public float speed = 2;

    float time;
    float time1;

    PlayerControl player;
    SpikeControlLeft spikeControl;

    private void Start()
    {
        spikeControl = FindObjectOfType<SpikeControlLeft>();
        player = FindObjectOfType<PlayerControl>();
    }

    void MoveBack()
    {
        if (player.variables.hitCollisionEdgeLeft)
        {
            time1 += Time.deltaTime;

            if (time1 < 0.35f)
                this.transform.position = Vector3.Lerp(transform.position, transform.position - Vector3.right, Time.deltaTime * speed);
            else
            {
                time1 = 0;
                player.variables.hitCollisionEdgeLeft = false;
                spikeControl.DestroyClone();
            }
        }
    }

    void MoveOut()
    {
        time += Time.deltaTime;

        if (time < 0.35f)
            this.transform.position = Vector3.Lerp(transform.position, transform.position + Vector3.right, Time.deltaTime * speed);
    }

    private void Update()
    {
        MoveBack();
        MoveOut();
    }
}
