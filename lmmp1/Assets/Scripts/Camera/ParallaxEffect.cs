using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ParallaxEffect : MonoBehaviour
{
    [SerializeField] private Transform followingTarget;
    [SerializeField, Range(0, 1)] private float parallaxStrength;
    [SerializeField] private bool disableVerticalParallax;
    public Vector3 targetPreviousPosition;


    private void Start()
    {
        if (!followingTarget) {

            followingTarget = Camera.main.transform;
        
        }

        targetPreviousPosition = followingTarget.position;
    }
    private void Update()
    {
        Vector3 delta = followingTarget.position - targetPreviousPosition;

        if (disableVerticalParallax)
        {
            delta.y = 0;
        }

        targetPreviousPosition = followingTarget.position;
        transform.position += delta * parallaxStrength;
    }
}
