using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float coinspeed;

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 15) * Time.deltaTime * coinspeed);
    }
}
