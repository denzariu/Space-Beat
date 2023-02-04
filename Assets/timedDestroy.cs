using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timedDestroy : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem particles;
    // Start is called before the first frame update
    /*void Start()
    {
        Destroy(this.gameObject, 1.5f);
    }*/


    private void Update()
    {
        if (!particles.IsAlive())
            Destroy(gameObject);
    }



}
