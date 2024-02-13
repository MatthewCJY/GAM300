﻿/*!*************************************************************************
****
\file ReturnToGame.cs
\author Matthew Cheung
\par DP email: j.cheung@digipen.edu
\par Course: csd3450
\date 20-1-2024
\brief  Script for pause menu continue game button
****************************************************************************
***/
using System;
using ScriptAPI;

public class ReturnToGame : Script
{
    UISpriteComponent buttonSprite;
    public override void Awake()
    {  
    }

    public override void Start()
    {
        buttonSprite = gameObject.GetComponent<UISpriteComponent>();
    }

    public override void Update()
    {
        if(PopupUI.isDisplayed)
        {
            buttonSprite.SetEnabled(true);
        }
        else
        {
            buttonSprite.SetEnabled(false);
        }
            
        if (Input.GetMouseButtonDown(Keycode.M1) && buttonSprite.IsMouseCollided())
        {
            Console.WriteLine("Continue Button Pressed");
            PopupUI.isDisplayed = false;
        }
    }
}