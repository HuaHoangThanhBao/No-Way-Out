using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeControlLeft : MonoBehaviour {

    GameObject spikeClone;

    public GameObject spikePrefabLeft;

    public GameObject spike_Left_Point;

    public GameObject spikeParent;

    PlayerControl player;

    public List<GameObject> spikes;
    public List<float> ranges;

    int range;
    int tempA = 0;
    int tempB = 0;

    private void Start()
    {
        player = FindObjectOfType<PlayerControl>();
    }

    private void Update()
    {
        if (player.variables.hitEdgeRight)
        {
            ranges.Clear();

            if (tempA == 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    range = Random.Range(-3, 3);

                    do
                    {
                        range = Random.Range(-4, 4);
                    }
                    while (ranges.Contains(range));

                    ranges.Add(range);

                    GameObject clone = (GameObject)Instantiate(spikePrefabLeft, spike_Left_Point.transform.position + Vector3.up * range * player.variables.offset, Quaternion.identity);

                    clone.transform.parent = spikeParent.transform;

                    spikes.Add(clone);
                }
            }
        }
    }

    public void DestroyClone()
    {
        foreach (GameObject a in spikes)
        {
            GameObject.Destroy(a);
        }
    }
}
