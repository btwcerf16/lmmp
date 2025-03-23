using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Parametrs")]

    [SerializeField] private Transform followTransform;
    [SerializeField] private string followTag;
    [SerializeField] private float cameraSpeed;
    [SerializeField] private float yOffset;

    private void Awake()
    {
        if(followTransform == null)
        {
            if(followTag == "")
            {
                followTag = "Player";
            }

            followTransform = GameObject.FindGameObjectWithTag(followTag).transform;
        }

        transform.position = new Vector3()
        {
            x = followTransform.position.x,
            y = followTransform.position.y,
            z = followTransform.position.z - 10.0f
        };
    }
    private void Update()
    {
        if (followTransform)
        {
            Vector3 target = new Vector3()
            {
                x = followTransform.position.x,
                y = followTransform.position.y + yOffset,
                z = followTransform.position.z - 10.0f

            };

            Vector3 pos = Vector3.Lerp(transform.position, target, cameraSpeed * Time.deltaTime);
            transform.position = pos;
        }
    }
}
