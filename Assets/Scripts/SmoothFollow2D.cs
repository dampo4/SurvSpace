using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow2D : MonoBehaviour
{
    public Transform target;
    public float smoothing = 5.0f;
    public Vector3 minCamPos;
    public Vector3 maxCamPos;
    void FixedUpdate()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, newPos, (smoothing * 0.001f));
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCamPos.x, maxCamPos.x),
            Mathf.Clamp(transform.position.y, minCamPos.y, maxCamPos.y),
            Mathf.Clamp(transform.position.z, minCamPos.z, maxCamPos.z));
    }
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
