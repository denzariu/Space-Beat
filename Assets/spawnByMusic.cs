using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnByMusic : MonoBehaviour
{
    // Spawn locations
    public spawnScript upL;
    public spawnScript upR;
    public spawnScript mid;
    public spawnScript L;
    public spawnScript R;

    public string upL_S;
    public string upR_S;
    public string mid_S;
    public string L_S;
    public string R_S;

    // Update is called once per frame
    void Update()
    {
        upL.changeString(upL_S);
        upR.changeString(upR_S);
        mid.changeString(mid_S);
        L.changeString(L_S);
        R.changeString(R_S);
    }
}
