﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorControllerPooled : MonoBehaviour
{
    public int poolInitSize = 20;
    public GameObject meteor;
    public float frequency = 0.5f;
    public Transform[] instantiationPositionTransforms;

    public float[] forces;

    private void Awake()
	{
        SimplePool.Preload(meteor, poolInitSize);
    }

    private void Start()
    {
		//Invoke example
        InvokeRepeating("InstantiateMeteor", 0f, frequency);
    }

    private void InstantiateMeteor()
    {
		//Random example randomization example
        int positionIndex = Random.Range(0,instantiationPositionTransforms.Length);
        int forceIndex = Random.Range(0,forces.Length);

        GameObject go = SimplePool.Spawn(meteor, instantiationPositionTransforms[positionIndex].position, Quaternion.identity);
        go.GetComponent<Rigidbody>().AddForce(instantiationPositionTransforms[positionIndex].forward * forces[forceIndex], ForceMode.VelocityChange);
    }
}
