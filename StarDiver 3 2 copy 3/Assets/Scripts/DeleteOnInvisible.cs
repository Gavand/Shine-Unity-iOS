using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteOnInvisible : MonoBehaviour {
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
