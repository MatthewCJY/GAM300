﻿using System;
using System.ComponentModel.DataAnnotations;
using ScriptAPI;

public class LockPick1 : Script
{
    [Header("Tutorial UI Variables")]
/*    public Image _TutorialImage;
    public Sprite[] _TutorialImgSprites;
    public Text _Press2Continue;*/
    [SerializeField] int _TutorialStep;

/*    public Text mySubtitles;
    public Image mySubtitlesBG;
    public AudioSource myVOSource;*/
    public bool _TutorialCompleted;

    [Header("Lockpick Variables")]
    public GameDataManager myGameDataManager;
    public GameObject Door_UI;
    public CameraComponent cam;
    public CameraComponent playerCam;
    public TransformComponent innerLock;
    public TransformComponent pickPosition;
    public FPS_Controller_Script playerController;
    public GameObject lockObject;
    public string difficultyLvl;
    public float maxAngle = 90;
    public float lockSpeed = 10;
    public bool unlocked;
    //public AudioClip[] lockSoundEffects;
    //public AudioClip[] rattleSoundEffects;
    float delay = 0.4f;
    public GameObject _NumOfTries;
    //public Text _AmtOfTries;

    [Range(1, 25)]
    public float lockRange = 10;

    [SerializeField] private int numOfTries;
    private float percentage;
    private float eulerAngle;
    private float unlockAngle;
    private Vector3 unlockRange;
    private float keyPressTime;
    private bool movePick;
    private bool deduct;
    private bool displayTutorial;
    [SerializeField] bool played;

    // Start is called before the first frame update
    override public void Awake() 
    {
        newLock();
    }

    // Update is called once per frame
    override public void Update()
    {
        if (!_TutorialCompleted)
        {
            //if (!myVOSource.isPlaying && !played)
            //{
            //    myVOSource.Play();
            //    mySubtitlesBG.enabled = true;
            //    mySubtitles.text = "Martin (Internal): Hopefully, I won’t forget how to do this.";
            //    played = true;

            //}
            //else if (!myVOSource.isPlaying && played)
            //{
            //    mySubtitles.text = "";
            //    mySubtitlesBG.enabled = false;
            //    _NumOfTries.SetActive(true);
            //    movePick = true;
            //    _TutorialCompleted = true;
            //}
        }
        else if (_TutorialCompleted)
        {
            _NumOfTries.SetActive(_NumOfTries.GetEntityID(),true);

            #region Move Pick
            if (movePick)
            {
                Vector3 dir = Input.GetMousePosition() - transform.GetPosition();
                //Vector3 dir = Input.mousePosition - cam.WorldToScreenPoint(transform.position);

                eulerAngle = Vector3.Angle(dir, new Vector3(0, 1, 0));

                Vector3 cross = Vector3.Cross(new Vector3(0, 1, 0), dir);
                if (cross.Z < 0) { eulerAngle = -eulerAngle; }

                eulerAngle = Mathf.Clamp(eulerAngle, -maxAngle, maxAngle);

                Quaternion rotateTo = Quaternion.AngleAxis(eulerAngle, new Vector3(0, 0, 1));
                transform.SetRotation(new Vector3(rotateTo.X, rotateTo.Y, rotateTo.Z));
            }

            if (Input.GetKeyDown(Keycode.E))
            {
                movePick = false;
                keyPressTime = 1;
               /* GetComponent<AudioSource>().clip = lockSoundEffects[0];
                GetComponent<AudioSource>().Play();*/
            }
            if (Input.GetKeyUp(Keycode.E))
            {
                movePick = true;
                keyPressTime = 0;
                deduct = true;
            }
            #endregion

            #region Check if pick is at correct position
            percentage = Mathf.Round(100 - Mathf.Abs(((eulerAngle - unlockAngle) / 100) * 100));
            float lockRotation = ((percentage / 100) * maxAngle) * keyPressTime;
            float maxRotation = (percentage / 100) * maxAngle;
            float lockLerp = Mathf.LerpAngle(innerLock.GetRotation().Z, lockRotation, Time.deltaTime * lockSpeed);
            innerLock.SetRotation(new Vector3(0, 0, lockLerp));

            if (lockLerp >= maxRotation - 1)
            {
                if (eulerAngle < unlockRange.Y && eulerAngle > unlockRange.X)
                {
                    movePick = true;
                    keyPressTime = 0;
                    /*GetComponent<AudioSource>().clip = lockSoundEffects[1];
                    GetComponent<AudioSource>().Play();*/

                    //Coroutine(StartDelay());
                    //async Task<int> StartDelay()
                    //IEnumerator StartDelay()
                    //{
                    //    yield return new WaitForSeconds(1.2f);
                    //    playerController.enabled = true;
                    //    playerController.lockCursor = true;
                    //    playerCam.enabled = true;
                    //    Door_UI.SetActive(false);
                    //    unlocked = true;
                    //    _NumOfTries.SetActive(false);
                    //    lockObject.SetActive(false);
                    //}
                }
                else
                {
                    //float randomRotation = Random.insideUnitCircle.x;
                    Vector3 rotation = transform.GetRotation();
                    //transform.SetRotation(rotation + new Vector3(0, 0, Random.Range((-randomRotation - 1), (randomRotation + 1))));

                    if (Input.GetKeyDown(Keycode.E) || Input.GetKey(Keycode.E))
                    {
                        //if (!GetComponents<AudioSource>()[1].isPlaying)
                        //{
                        //    delay -= Time.deltaTime;

                        //    if (delay <= 0)
                        //    {
                        //        GetComponents<AudioSource>()[1].clip = rattleSoundEffects[Random.Range(0, rattleSoundEffects.Length)];
                        //        GetComponents<AudioSource>()[1].Play();
                        //        delay = 0.2f;
                        //    }
                        //}
                    }

                    if (deduct == true)
                    {
                        numOfTries -= 1;
                        deduct = false;
                    }

                    if (numOfTries <= 0)
                    {
                        //GetComponent<AudioSource>().clip = lockSoundEffects[2];
                        //GetComponent<AudioSource>().volume = 0.5f;
                        //GetComponent<AudioSource>().Play();
                        //movePick = false;

                        //Coroutine(Deactivate(), 1);

                        //IEnumerator<int> Deactivate()
                        //{
                        //    _NumOfTries.SetActive(false);
                        //    playerController.enabled = true;
                        //    playerController.lockCursor = true;
                        //    playerCam.enabled = true;
                        //    Door_UI.SetActive(false);
                        //    lockObject.SetActive(false);
                        //}
                    }
                }
            }
            #endregion

            //_AmtOfTries.text = numOfTries.ToString();

            //if (numOfTries <= 1)
            //{
            //    _AmtOfTries.color = Color.red;
            //}
        }
    }

    public void newLock()
    {
        //Cursor.visible = false;
        //GetComponent<AudioSource>().volume = 1f;

        //Door_UI.SetActive(Door_UI.GetEntityID(), true);

        //_AmtOfTries.color = Color.white;
        keyPressTime = 0;
        unlocked = false;
        deduct = true;
        //playerController.is_Enabled = false;
        //playerCam. = false;
        //cam.transform.SetRotation(Quaternion(new))
        //unlockAngle = Random.Range(-maxAngle + lockRange, maxAngle - lockRange);
        //unlockRange = new Vector3(unlockAngle - lockRange, unlockAngle + lockRange, 0.0f);

        if (difficultyLvl == "Easy")
        {
            numOfTries = 10;
        }
        else if (difficultyLvl == "Normal")
        {
            numOfTries = 5;
        }
        else if (difficultyLvl == "Hard")
        {
            numOfTries = 3;
        }

        if (_TutorialCompleted)
        {
            movePick = true;
        }
    }
}
