using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveView : MonoBehaviour
{
    public float diffValue = 0.2f;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float diff = Camera.main.transform.position.y - this.transform.position.y;
        if (diff > diffValue)
        {
            anim.SetTrigger("Start");
        }
    }
}
