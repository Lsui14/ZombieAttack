using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FText : MonoBehaviour
{

    public float DestroyTime = 3f;
    public Vector3 Offset = new Vector3 (-0.5f, 2, 0);
    public Vector3 RandomizeX = new Vector3(0.5f, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, DestroyTime);
        transform.localPosition += Offset;
        transform.localPosition += new Vector3(Random.Range(-RandomizeX.x, RandomizeX.x), Random.Range(-RandomizeX.y, RandomizeX.y), Random.Range(-RandomizeX.z, RandomizeX.z));
    }

}
