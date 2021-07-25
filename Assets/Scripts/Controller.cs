using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class Controller : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    public void OnSwipeLeft()
    {
        if(transform.position.x > -1.8f)
            transform.DOMove(new Vector2(transform.position.x - 1.8f,
               transform.position.y + jumpPower), 0f)
           .SetEase(Ease.OutElastic);
    }
    public void OnSwipeRight()
    {
        if (transform.position.x < 1.8f)
            transform.DOMove(new Vector2(transform.position.x + 1.8f,
           transform.position.y + jumpPower), 0f)
       .SetEase(Ease.OutElastic);
    }
    void InstanceEgg() {
        anim.SetTrigger("egg");
        eggGo = (GameObject) Instantiate(Resources.Load("egg"), transform.position - transform.up, Quaternion.identity);
        Destroy(eggGo, 20);
    }

    public float updateTime = 1;
    private float curtime;    
    private float curtime_evi;

    public float jumpPower = 0.8f;
    // Update is called once per frame
    void Update()
    {
        if (curtime < updateTime)
        {
            curtime += 1 * Time.deltaTime;
        }
        else {
            curtime = 0;
            transform.DOMove(new Vector2(transform.position.x,
               transform.position.y + jumpPower), 0.1f)
           .SetEase(Ease.OutElastic).OnComplete(InstanceEgg);
        }

        if (transform.position.y > heighBackup / 1.3f)
        {
            //SpawnPlatforms();
        }
        
    }

    public int heighBackup;
    GameObject plGo;
    GameObject eggGo;
    void SpawnPlatforms() {
        int rand = UnityEngine.Random.Range(0, 3);
        if(rand == 0)
        {
            plGo = (GameObject) Instantiate(Resources.Load("Platform_small"), new Vector2(-1.8f, heighBackup + 3) , Quaternion.identity);
        }
        else if (rand == 1)
        {
            plGo = (GameObject)Instantiate(Resources.Load("Platform_small"), new Vector2(0, heighBackup + 3), Quaternion.identity);
        }
        else
        {
            plGo = (GameObject)Instantiate(Resources.Load("Platform_small"), new Vector2(1.8f, heighBackup + 3), Quaternion.identity);
        }
        heighBackup = (int)plGo.transform.position.y;
    }


}
