using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class EggScript : MonoBehaviour
{
    Rigidbody2D rig;
    public int animid;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();

        if (animid > 0) {
            DOTween.Play(animid);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float diff = Camera.main.transform.position.y - this.transform.position.y;
        if (diff > 5f)
        {
            rig.isKinematic = true;
            rig.Sleep();
        }
    }
}
