using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float diff = Camera.main.transform.position.y - this.transform.position.y;
        if (diff > 25f)
        {
            Destroy(this.gameObject, 5);
        }
    }
}
