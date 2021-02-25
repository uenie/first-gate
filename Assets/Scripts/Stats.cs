using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour
{
    public bool testStats = false;
    public bool showStats = false;
    public Rect statsRect;
    public Rect labelsRect;
    public int killed;
    public int life;
    public int stealth;
    public int completedMissions;
    public bool testAdd = false;
    public Rect rectAddLife, rectKillLife;

	void Start () {
        killed = 0;
        life = 100;
        stealth = 100;
        completedMissions = 0;
	}
	void Update () 
    {
	    
	}
    void OnGUI()
    {
        if (testAdd)
        {
            if (GUI.Button(rectAddLife, "AddLife(10)"))
            {
                AddLife(10);
            }
            if (GUI.Button(rectKillLife, "AddLife(-10)"))
            {
                AddLife(-10);
            }
        }
        if (testStats)
        {
            // if (GUI.Button(statsRect, "ShowStats(!showStats); (now " + showStats+")"))
            // {
            //     ShowStats(!showStats);
            // }
            if (showStats)
            {
                GUI.Label(labelsRect, "killed: " + killed + ", life: " + life + ", stealth: " + stealth + ", completedMissions: " + completedMissions);
            }
        }
    }
    public void AddLife(int lifeCount)
    {
        if (life + lifeCount >= 100)
        {
            life = 100;
        }
        else if (life + lifeCount <= 0)
        {
            life = 0;
        }
        else
        {
            life += lifeCount;
        }
    }
    public void AddStealth(int someStealth)
    {
        if (stealth + someStealth >= 100)
        {
            stealth = 100;
        }
        else if (stealth + someStealth <= 0)
        {
            stealth = 0;
        }
        else
        {
            stealth += someStealth;
        }
    }
    public void IncCompletedMissions(int missions)
    {
        completedMissions += missions;
    }
    public void IncKilled(int killedAdd)
    {
        killed += killedAdd;
    }
    public void ShowStats(bool b)
    {
        showStats = b;
    }

}
