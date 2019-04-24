﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class WeaponController : MonoBehaviour
{

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate=1;
    public float delay=1;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("Fire", delay, fireRate);
    }

    void Fire()
    {
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        audioSource.Play();
    }




}
