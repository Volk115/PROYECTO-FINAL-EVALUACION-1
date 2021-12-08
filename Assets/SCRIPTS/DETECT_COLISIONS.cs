using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DETECT_COLISIONS : MonoBehaviour
{
    private void OnTriggerEnter(Collider otherTrigger)
    {
        Destroy(otherTrigger.gameObject);
        Destroy(gameObject);
    }
}
