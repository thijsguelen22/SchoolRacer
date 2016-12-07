﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject[] TrackList;
    public int currentTrack = 0;
    public int ResetAfterTrack = 0;
    GameObject Track;

    public float Lap = 1f;
    public float AmountOfLaps = 3f;
    public AudioSource Music;
    public GameObject player;
    public GameObject npc1;
    public GameObject npc2;
    public GameObject npc3;
    public GameObject npc4;
    public GameObject koos;
    public int MaxSections;
    
    public int trackCounterTotal = 0;
    private int trackCounter = 0;
    public Text winText;
    public Text TimerTxt;
    public Text CountdownTxt;
    public Text RankTxt;
    //public AudioClip yay;
    //private AudioSource source;

    private float Timer = 0f;
    private int round = -1;
    private int finish = -1;
    private int checkpoint = 0;
    //private int TimeRnd = 0;
    //private float countdown = 0f;
    //private float min = 0;
    //private float sec = 0;
    private bool runshit;
    private float PlayerTrackCounter;
    private float NPC1TrackCounter;
    private float NPC2TrackCounter;
    private float NPC3TrackCounter;
    private float NPC4TrackCounter;
    private float PlayerPos = 0.0f;

    private string str = "";

    public enum EngineAudioOptions // Options for the engine audio
    {
        Simple, // Simple style audio
        FourChannel // four Channel audio
    }

    //public EngineAudioOptions engineSoundStyle = EngineAudioOptions.FourChannel;// Set the default audio options to be four channel
    // Use this for initialization
    void Start()
    {
        MaxSections = this.TrackList.Length;
        //source = GetComponent<AudioSource>();
        winText.text = "Lap 1/3";
        TimerTxt.text = "";
        CountdownTxt.text = "";
        Music = GetComponent<AudioSource>();
        Debug.Log("kek");
        Music.Play();
        runshit = true;

        player.GetComponent<UnityUIController>().ready = false;
        npc1.GetComponent<Patrol>().ready = false;
        npc2.GetComponent<Patrol>().ready = false;
        npc3.GetComponent<Patrol>().ready = false;
        npc4.GetComponent<Patrol>().ready = false;
        koos.GetComponent<Patrol2>().ready = false;
        koos.GetComponent<VillainSoundFX>().start = false;


        // accesses the bool named "isOnFire" and changed it's value.
        //boolBoy.ready = false;
    }

    void Update()
    {
        Timer += Time.deltaTime;
        //min = (Timer / 60f);
        //sec = (Timer % 60f);

        if (runshit == true)
        {
            if (Timer > 3 || Timer < 10)
            {
                CountdownTxt.text = "";
                player.GetComponent<UnityUIController>().ready = true;
                npc1.GetComponent<Patrol>().ready = true;
                npc2.GetComponent<Patrol>().ready = true;
                npc3.GetComponent<Patrol>().ready = true;
                npc4.GetComponent<Patrol>().ready = true;
            }
            if (Timer < 4)
            {
                if (Timer < 4)
                {
                    CountdownTxt.text = "" + (4 - Mathf.Round(Timer));
                    player.GetComponent<UnityUIController>().ready = false;
                    npc1.GetComponent<Patrol>().ready = false;
                    npc2.GetComponent<Patrol>().ready = false;
                    npc3.GetComponent<Patrol>().ready = false;
                    npc4.GetComponent<Patrol>().ready = false;
                    Debug.Log("nope");
                }
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {

        if (currentTrack == ResetAfterTrack)
        {
            currentTrack = 1;
            Debug.Log("the new round number is " + round);
            round++;
        }
            
            if (col.gameObject.name == "col" + (currentTrack + 1))
            {
            Debug.Log("BOOP! on col" + (currentTrack + 1));
            trackCounterTotal++;
                currentTrack++;                //Debug.Log("Booped track with name " + Track.name);
                PlayerTrackCounter++;
                NPC1TrackCounter = npc1.GetComponent<NPCLapCounter>().trackCounterTotal;
                NPC2TrackCounter = npc2.GetComponent<NPCLapCounter>().trackCounterTotal;
                NPC3TrackCounter = npc3.GetComponent<NPCLapCounter>().trackCounterTotal;
                NPC4TrackCounter = npc4.GetComponent<NPCLapCounter>().trackCounterTotal;
                PlayerPos = 5;
                if (PlayerTrackCounter > NPC1TrackCounter)
                {
                    PlayerPos = PlayerPos - 0.5f;
                }
                else
                {
                    PlayerPos = PlayerPos + 0.5f;
                }
                if (PlayerTrackCounter > NPC2TrackCounter)
                {
                    PlayerPos = PlayerPos - 0.5f;
                }
                else
                {
                    PlayerPos = PlayerPos + 0.5f;
                }
                if (PlayerTrackCounter > NPC3TrackCounter)
                {
                    PlayerPos = PlayerPos - 0.5f;
                }
                else
                {
                    PlayerPos = PlayerPos + 0.5f;
                }
                if (PlayerTrackCounter > NPC4TrackCounter)
                {
                    PlayerPos = PlayerPos - 0.5f;
                }
                else
                {
                    PlayerPos = PlayerPos + 0.5f;
                }
            PlayerPos = PlayerPos - 2;
                UpdateStat();
                Debug.Log("player position: " + PlayerPos);
            }
        
        /*if (col.gameObject.name == "finish")
        {
            Debug.Log("booped da finish");
            finish++;
        }
        if (col.gameObject.name == "checkpoint1")
        {
            Debug.Log("booped da shagpoint");
            checkpoint++;
        }*/
        if(trackCounter == ResetAfterTrack)
        {
            //round++;
            //trackCounter = 1;
            //Debug.Log("the new round number is " + round);
        }
        if (col.gameObject.name == "villainPoint")
        {
            //Debug.Log("booped da shagpoint");
            koos.GetComponent<Patrol2>().ready = true;
            koos.GetComponent<VillainSoundFX>().start = true;

        }
        if(round > 2)
        {
            str = "";
            TimerTxt.text = "Time: " + Mathf.Round(Timer) + " seconds";
            runshit = false;
            player.GetComponent<UnityUIController>().ready = false;
            npc1.GetComponent<Patrol>().ready = false;
            npc2.GetComponent<Patrol>().ready = false;
            npc3.GetComponent<Patrol>().ready = false;
            npc4.GetComponent<Patrol>().ready = false;
            //TimerTxt.text = "Time: " + Mathf.Round(Timer) + " seconds";
            //Debug.Log(Timer);
        } else
        {
            str = "Lap " + (round + 1) + "/3";
            TimerTxt.text = "";
        }
        //Debug.Log(checkpoint);
        //Debug.Log(finish);
        winText.text = str;
    }
    void UpdateStat()
    {
        if(PlayerPos == 1)
        {
            RankTxt.text = "1st";
            RankTxt.color = new Color(255,255,0,1);
        }
        if (PlayerPos == 2)
        {
            RankTxt.text = "2nd";
            RankTxt.color = new Color(179, 179, 179, 1);
        }
        if (PlayerPos == 3)
        {
            RankTxt.text = "3rd";
            RankTxt.color = new Color(153, 0, 0, 1);
        }
        if (PlayerPos > 3)
        {
            RankTxt.text = PlayerPos + "th";
            RankTxt.color = new Color(255, 153, 51, 1);
        }
    }
}