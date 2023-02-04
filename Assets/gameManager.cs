using MilkShake;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    [SerializeField]
    private Transform mainParent;
    [SerializeField]
    private float rotationSpeedY;
    [SerializeField] 
    private float rotationSpeedZ;

    [SerializeField]
    private GameObject pauseMenuObj;
    [SerializeField]
    private GameObject scoreTextObj;
    [SerializeField]
    private GameObject spreeLowObj;
    [SerializeField]
    private GameObject spreeMidObj;
    [SerializeField]
    private GameObject spreeHighObj;
    [SerializeField]
    private GameObject spreeLowEnvObj;
    [SerializeField]
    private GameObject spreeMidEnvObj;
    [SerializeField]
    private GameObject spreeHighEnvObj;
    [SerializeField]
    private GameObject spreeLowWaveObj;
    [SerializeField]
    private GameObject spreeMidWaveObj;
    [SerializeField]
    private GameObject spreeHighWaveObj;


    // Camera Shake
    [SerializeField]
    private Shaker MyShaker;
    [SerializeField]
    private ShakePreset ShakePresetHard;
    [SerializeField]
    private ShakePreset ShakePresetLight;
    [SerializeField]
    private ShakePreset ShakePresetSustained;


    [SerializeField]
    private static GameObject pauseMenu;
    [SerializeField]
    private static GameObject scoreMenu;

    private static int lives = 3;

    private static bool isPaused = false;

    public static Spree scoreBoard;
    

    // Score Manager
    public static int GetScore() { return scoreBoard.getCurrentScore(); }
    public static void IncrementScore (int increment)
    {
        scoreBoard.updateScore(increment);
    }

    public void ShakeCameraHard() { MyShaker.Shake(ShakePresetHard); }
    public void ShakeCameraLight() { MyShaker.Shake(ShakePresetLight); }

    public static void ResetSpree () { scoreBoard.updateScore(-scoreBoard.getCurrentScore()); }
    
    // Lives manager
    public static int GetLives()
    { return lives; }
    public static bool CheckIfDead()
    { return lives == 0 ? true : false; }
    public static void DecrementLives()
    {
        lives = lives - 1;
        if (CheckIfDead())
        { 
            Time.timeScale = 0;
        }
    }

    // Menu manager
    public static void pauseMode()
    {
        if (isPaused)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1.0f;
        }
        else
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0.0f;
        }
        isPaused = !isPaused;
        JoyconDemo.pausePressed = false;
    }


   

    // Start is called before the first frame update
    void Start()
    {
        
        pauseMenu = pauseMenuObj;
        pauseMenu.SetActive(false);
        scoreMenu = scoreTextObj;

        MyShaker.Shake(ShakePresetSustained);

       /* spreeLowObjS = spreeLowObj;
        spreeMidObjS = spreeMidObj;
        spreeHighObjs = spreeHighObj;*/

        scoreBoard = new Spree(spreeLowObj, spreeMidObj, spreeHighObj, scoreTextObj, spreeLowEnvObj, spreeMidEnvObj, spreeHighEnvObj, spreeLowWaveObj, spreeMidWaveObj, spreeHighWaveObj);
    }

    // Update is called once per frame
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * rotationSpeedY);
    }
}
