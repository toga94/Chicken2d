using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

// Vibrasiya Android Handheld.Vibrate();


public class Controller : MonoBehaviour
{
    AudioSource asource;
    Animator anim;
    public GameObject eggParent;
    SpriteRenderer sprender;
    // Start is called before the first frame update
    private void Start()
    {
        sprender = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        asource = GetComponent<AudioSource>();
    }

    public void OnSwipeLeft()
    {
        if (transform.position.x > -1.8f) {
            transform.DOMove(new Vector2(transform.position.x - 1.8f,
               transform.position.y + jumpPower), 0f)
           .SetEase(Ease.Flash);
            sprender.flipX = false;
            asource.Play();
        }

    }
    public void OnSwipeRight()
    {
        if (transform.position.x < 1.8f)
        {
            transform.DOMove(new Vector2(transform.position.x + 1.8f,
transform.position.y + jumpPower), 0f)
.SetEase(Ease.Flash);
            // transform.DOShakeRotation(0.15f, 1, 100, 100).SetEase(Ease.OutElastic);
            sprender.flipX = true;
            asource.Play();
        }

    }

    private void InstanceEgg()
    {
        anim.SetTrigger("egg");
        eggGo = (GameObject) Instantiate(Resources.Load("egg"), transform.position - transform.up, Quaternion.identity);
        if (eggParent) eggGo.transform.parent = eggParent.transform;
        else {
            eggParent = new GameObject("_eggParent");
            GameObject spawnerObj = GameObject.Find("_Spawner");
            eggParent.transform.parent = spawnerObj.transform;
            eggGo.transform.parent = eggParent.transform;
        }
        
        Destroy(eggGo, 20);
    }

    public float updateTime = 1;
    private float curtime;    
    private float curtime_evi;

    public float jumpPower = 0.8f;

    // Update is called once per frame
    private void Update()
    {
        if (curtime < updateTime)
        {
            curtime += 1 * Time.deltaTime;
        }
        else {
            curtime = 0;
            transform.DOJump(new Vector2(transform.position.x,
               transform.position.y + jumpPower), 1,1,0.1f).SetEase(Ease.InBounce).OnComplete(InstanceEgg);
        }
    }

    public int heighBackup;
    GameObject plGo;
    GameObject eggGo;
    private void SpawnPlatforms() {
        int rand = UnityEngine.Random.Range(0, 3);
        switch (rand)
        {
            case 0:
                plGo = (GameObject)Instantiate(Resources.Load("Platform_small"), new Vector2(-1.8f, heighBackup + 3), Quaternion.identity);
                break;
            case 1:
                plGo = (GameObject)Instantiate(Resources.Load("Platform_small"), new Vector2(0, heighBackup + 3), Quaternion.identity);
                break;
            default:
                plGo = (GameObject)Instantiate(Resources.Load("Platform_small"), new Vector2(1.8f, heighBackup + 3), Quaternion.identity);
                break;
        }
        heighBackup = (int)plGo.transform.position.y;
    }


}
