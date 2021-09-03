using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class _GameManager : MonoBehaviour
{
    public PlayableDirector danforde;
    public bool toasty;
    // Start is called before the first frame update
    void Start()
    {
        danforde = GameObject.Find("_DanForden").GetComponent<PlayableDirector>();
        Debug.Log("Toasty Start");
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (toasty) {
            toasty = false;
            danforde.Play();
        }

    }
}
