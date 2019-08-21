using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;
using GoogleARCoreInternal;
using UnityEngine.UI;

public class GunBehaviour : MonoBehaviour
{
    public GameObject _bullet;
    public GameObject _fireslot;    
    public AudioSource[] _audio;
    public Text _ammocount;
    

    public int _bullets;
    private float _coolDown = 0.75f;
    private float _canFire = 0f;


    void Start()
    {
        _bullet.GetComponent<BulletBehaviour>();
        _bullets = 6;
        
        _ammocount = GameObject.Find("AmmoCount").GetComponent<Text>();
    }

    void Update()
    {
        _ammocount.text = "Ammo: " + _bullets;
    }
    public void Shoot()
    {
        if (_bullets > 0)
        {
            if (Time.time > _canFire)
            {
                Instantiate(_bullet, _fireslot.transform.position, _fireslot.transform.rotation);
                _bullets--;
                _canFire = Time.time + _coolDown;
                _audio[2].Play();
            }
        }
        else
        {
            _audio[0].Play();
            return;
        }
    }
    public void Reload()
    {
        StartCoroutine(ReloadCoroutine());
    }
    IEnumerator ReloadCoroutine()
    {
        _audio[1].Play();
        yield return new WaitForSeconds(3f);
        _bullets = 6;
    }
    
}
//_audioReload = GetComponent<AudioSource>();
//_audioClick = GetComponent<AudioSource>();
//_empty = GetComponent<AudioClip>();
//_audioReload = GetComponent<AudioClip>();


//public void PlayerDamage()
//{

//}