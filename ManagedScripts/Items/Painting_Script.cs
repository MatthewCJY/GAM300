﻿/*!*************************************************************************
****
\file Painting_Script.cs
\author Celine Leong
\par DP email: jiayiceline.leong@digipen.edu
\par Course: csd3450
\date 15-1-2024
\brief  Gameplay script for player interaction with paintings
****************************************************************************
***/
using ScriptAPI;
using System;

public class Painting_Script : Script
{
    private GameObject playerObject;
    //RigidBodyComponent rigidBodyComponent; //for raycast?

    [SerializeField]
    public string Painting_Name;
    public string Painting_Texture;
    public bool opened;
    public GameObject? _InteractUI;

    //public Animator _PaintingAnimator;
    //public Flashlight_Script _FlashlightScript;
    //private GraphicComponent _color;

    [Header("AudioStuff")]
    public AudioComponent AudioPlayer;
    public String voClip;

    public float timer;

    override public void Awake()
    {
        voClip = "pc_stealpainting1";
        AudioPlayer = gameObject.GetComponent<AudioComponent>();
        //_color.a = 1;
        //timer = 1.0f;
        //Console.WriteLine("Painting script");
    }

    public override void Start()
    {
        playerObject = GameObjectScriptFind("player");
        //rigidBodyComponent = gameObject.GetComponent<RigidBodyComponent>();
    }

    // Update is called once per frame
    override public void Update()
    {
        if (isWithinRange())
        {
            _InteractUI.SetActive(true);
            if (Input.GetKeyDown(Keycode.E) /*&& isWithinRange() && rigidBodyComponent.IsRayHit()*/)
            {
                Console.WriteLine("Picked up painting");
                InventoryScript.addPaintingIntoInventory(Painting_Name, Painting_Texture);
                gameObject.GetComponent<GraphicComponent>().SetView2D(true);
                gameObject.SetActive(false);
                AudioPlayer.play(voClip);
            }
        }
        else
        {
            _InteractUI.SetActive(false);
        }
    }

    public bool isWithinRange()
    {
        Vector3 itemPos = gameObject.transform.GetPosition();
        Vector3 playerPos = playerObject.transform.GetPosition();
        float distance = Vector3.Distance(itemPos, playerPos);
        Console.WriteLine(distance);
        return distance < 100.0;
    }
}
