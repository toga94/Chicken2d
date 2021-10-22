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
    _GameManager gm;
    // Start is called before the first frame update
    private void Start()
    {
        sprender = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        asource = GetComponent<AudioSource>();
        gm = GameObject.FindGameObjectWithTag("gm").GetComponent<_GameManager>();
    }


    /// <summary>
    /// Swipe Start
    /// </summary>
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
            sprender.flipX = true;
            asource.Play();
        }
    }
    /// <summary>
    /// Swipe End
    /// </summary>


    private void InstanceEgg()
    {
        anim.SetTrigger("egg");
        eggGo = (GameObject)Instantiate(Resources.Load("egg"), transform.position - transform.up, Quaternion.identity);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Portal")) {
            Destroy(collision.gameObject);
            gm.LoadLevel();
        }
        if (collision.gameObject.CompareTag("bricks"))
        {
            Destroy(collision.gameObject);
            gm.toasty = true;
            Debug.Log("Toasty!!!!!!");
            StartCoroutine(ShowStarts());
        }
        if (collision.gameObject.CompareTag("coin"))
        {
           DOTweenAnimation coinAnim = collision.gameObject.GetComponent<DOTweenAnimation>();
            collision.transform.DOLocalMove(targetCoins.transform.position, 1).OnComplete(() =>Destroy(collision.gameObject));
        }
    }
    public GameObject targetCoins;
    public GameObject startsObject;
    IEnumerator ShowStarts() {
        startsObject.SetActive(true);
        yield return new WaitForSeconds(4f);
        startsObject.SetActive(false);
    }

}
