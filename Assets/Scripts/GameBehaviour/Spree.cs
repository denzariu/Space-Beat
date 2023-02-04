using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System;
using System.Threading;
using UnityEngine;
using TMPro;

public class Spree
{
    private int score;
    private short spreeLow = 10;
    private short spreeMid = 25;
    private short spreeHigh = 50;
    private short spreePos = 0;

    private GameObject scoreTextObj;

    private GameObject spreeLowObj;
    private GameObject spreeMidObj;
    private GameObject spreeHighObj;
    private GameObject spreeLowEnvObj;
    private GameObject spreeMidEnvObj;
    private GameObject spreeHighEnvObj;
    private GameObject spreeLowWaveObj;
    private GameObject spreeMidWaveObj;
    private GameObject spreeHighWaveObj;

    public Spree() { }
    public Spree(GameObject go1, GameObject go2, GameObject go3, GameObject scoreText, GameObject lowEnvObj, GameObject midEnvObj, GameObject highEnvObj, GameObject lowWave, GameObject midWave, GameObject highWave) 
    {
        spreeLowObj  = go1;
        spreeMidObj  = go2;
        spreeHighObj = go3;
        scoreTextObj = scoreText;
        spreeLowEnvObj = lowEnvObj;
        spreeMidEnvObj = midEnvObj;
        spreeHighEnvObj = highEnvObj;
        spreeLowWaveObj = lowWave;
        spreeMidWaveObj = midWave;
        spreeHighWaveObj = highWave;


    }
    public short getSpreeLow() { return spreeLow; }
    public short getSpreeMid() { return spreeMid; }
    public short getSpreeHigh() { return spreeHigh; }
    public int getCurrentScore() { return score; }
    public void resetCurrentScore() { score = 0; }
    public void updateScore(int increment)
    {
        this.score += increment;

        if (spreePos != 0 && score < spreeLow)
        {
            spreePos = 0;
            spreeLowObj.SetActive(false);
            spreeMidObj.SetActive(false);
            spreeHighObj.SetActive(false);

            spreeLowEnvObj.SetActive(false);
            spreeMidEnvObj.SetActive(false);
            spreeHighEnvObj.SetActive(false);

            spreeLowWaveObj.SetActive(false);
            spreeMidWaveObj.SetActive(false);
            spreeHighWaveObj.SetActive(false);
        }
        else if (spreePos != 1 && score >= spreeLow && score < spreeMid)
        {
            spreePos = 1;
            spreeLowObj.SetActive(true);
            spreeMidObj.SetActive(false);
            spreeHighObj.SetActive(false);

            spreeLowEnvObj.SetActive(true);
            spreeMidEnvObj.SetActive(false);
            spreeHighEnvObj.SetActive(false);

            spreeLowWaveObj.SetActive(true);
            spreeMidWaveObj.SetActive(false);
            spreeHighWaveObj.SetActive(false);
        }
        else if (spreePos != 2 && score >= spreeMid && score < spreeHigh)
        {
            spreePos = 2;
            spreeLowObj.SetActive(false);
            spreeMidObj.SetActive(true);
            spreeHighObj.SetActive(false);

            spreeLowEnvObj.SetActive(false);
            spreeMidEnvObj.SetActive(true);
            spreeHighEnvObj.SetActive(false);

            spreeLowWaveObj.SetActive(false);
            spreeMidWaveObj.SetActive(true);
            spreeHighWaveObj.SetActive(false);
        }
        else if (spreePos != 3 && score >= spreeHigh)
        {
            spreePos = 3;
            spreeLowObj.SetActive(false);
            spreeMidObj.SetActive(false);
            spreeHighObj.SetActive(true);

            spreeLowEnvObj.SetActive(false);
            spreeMidEnvObj.SetActive(false);
            spreeHighEnvObj.SetActive(true);

            spreeLowWaveObj.SetActive(false);
            spreeMidWaveObj.SetActive(false);
            spreeHighWaveObj.SetActive(true);
        }

        scoreTextObj.GetComponent<TextMeshProUGUI>().text = score.ToString();
    }
}