using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickDrop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject.Find("_GameManager").GetComponent<_GameManager>().toasty = true;
            Debug.Log("Toasty!!!!!!");
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
