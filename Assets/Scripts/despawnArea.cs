using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class despawnArea : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);
        Destroy(collision.gameObject);
    }
}
