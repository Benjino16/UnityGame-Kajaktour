using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnLikeCam : MonoBehaviour
{
    [SerializeField] Camera mainCam;
    void Awake()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = mainCam.transform.rotation;
    }
}
