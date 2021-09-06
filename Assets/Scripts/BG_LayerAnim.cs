using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
[Serializable]
public class BgLayer {
    public Transform layerSprite;
    public float _toY;
    public float _speed;
    public DOTweenAnimation tweenComponent;
}

public class BG_LayerAnim : MonoBehaviour
{
    public BgLayer[] bg_layers;
    Transform _player;
    float backupY;
    float posY;
    public float dirY;
    public float _velocity;
    public float _velocity2;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        backupY = _player.transform.position.y;
        posY = _player.transform.position.y;
        foreach (var go in bg_layers)
        {
            //go.layerSprite.DOLocalMoveY(go._toY, go._speed * _velocity * 1000).SetUpdate(UpdateType.Normal).SetSpeedBased(true);
            go.tweenComponent = go.layerSprite.GetComponent<DOTweenAnimation>();
            go.tweenComponent.DOPlay();
        }


    }


    float _t;
    public float refreshtime = 1;

    // Update is called once per frame
    void Update()
    {
        posY = _player.transform.position.y;
        if (refreshtime > _t) _t += 1 * Time.deltaTime;
        else {
            if (backupY != posY)
            {
                dirY = (posY - backupY);
                _velocity = dirY;
                backupY = _player.transform.position.y;
            }
            _t = 0;
        }
        foreach (var go in bg_layers)
        {
            go.tweenComponent.duration = _velocity/ 5;

        }



    }
}
