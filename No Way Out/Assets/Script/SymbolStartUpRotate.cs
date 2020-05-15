using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymbolStartUpRotate : MonoBehaviour {
    private void Update()
    {
        this.transform.Rotate(new Vector3(0, 0, -45) * Time.deltaTime * 4);
    }
}
