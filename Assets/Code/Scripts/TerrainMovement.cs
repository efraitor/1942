using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0f, 0.001f, 0f);
        if (transform.position.y < -3.84f)
            transform.position = new Vector2(0f, 15.36f);
    }
}
