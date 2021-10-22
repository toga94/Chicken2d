using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class _GameManager : MonoBehaviour
{
    private PlayableDirector danforde;
    public bool toasty;
    private GameObject levelLoader;
    public GameObject onStartObj;

    private void Awake()
    {
        levelLoader = (GameObject)Instantiate(Resources.Load("LevelLoaderEnd"), Vector3.zero, Quaternion.identity);
    }

    // Start is called before the first frame update
    void Start()
    {

        danforde = GameObject.Find("_DanForden").GetComponent<PlayableDirector>();
        Debug.Log("Toasty Start");
    }
    public void PlayToasty() {
        danforde.Play();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (toasty) {
            toasty = false;
            danforde.Play();
        }
    }
    public int nextLevel = 1;
    public void LoadLevel() {
        StartCoroutine(Loading(nextLevel));
    }
    IEnumerator Loading(int levelIndex) {
        Destroy(levelLoader);
        levelLoader = (GameObject)Instantiate(Resources.Load("LevelLoaderStart"), Vector3.zero, Quaternion.identity);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(levelIndex);
    }

}
