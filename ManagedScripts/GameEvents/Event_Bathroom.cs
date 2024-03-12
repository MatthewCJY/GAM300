﻿using ScriptAPI;
using System;

public class EventBathroom : Script
{

    public bool doOnce = true;
    public GameObject? bathroomLight;
    

    public override void Update()
    {
        // Check for Battery pick up, play audio
        // Martin (Internal): At least this will help.
    }

    public override void OnTriggerEnter(ColliderComponent collider)
    {
        if (doOnce)
        {
            Console.WriteLine("Martin (Internal): The tub is still wet, but there’s no one...");
            AudioComponent audio = gameObject.GetComponent<AudioComponent>();
            audio.play("shower_running"); //it runs even when player is a distance away from shower
            bathroomLight.SetActive(true);
            doOnce = false;
            gameObject.GetComponent<ColliderComponent>().SetEnabled(false);
        }
    }
}