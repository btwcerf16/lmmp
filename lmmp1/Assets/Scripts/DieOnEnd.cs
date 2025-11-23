using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieOnEnd : MonoBehaviour
{
    private void DestroyOnEnd()
    {
        Destroy(gameObject);
    }
}
