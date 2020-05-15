using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeControlRight : MonoBehaviour {

    GameObject spikeClone;

    public GameObject spikePrefabRight;

    public GameObject spike_Right_Point;

    public GameObject spikeParent;

    PlayerControl player;

    public List<GameObject> spikes;
    public List<float> ranges;

    int range;
    int tempA = 0;

    private void Start()
    {
        player = FindObjectOfType<PlayerControl>();
    }

    private void Update()
    {
        if (player.variables.hitEdgeLeft)
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

                    GameObject clone = (GameObject)Instantiate(spikePrefabRight, spike_Right_Point.transform.position + Vector3.up * range * player.variables.offset, spikePrefabRight.transform.rotation);

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
