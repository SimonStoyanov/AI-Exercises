using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

// TODO 1: Create a simple class to contain one entry in the blackboard
// should at least contain the gameobject, position, timestamp and a bool
// to know if it is in the past memory

public class BlackboardEntry
{
    public BlackboardEntry() { }
    public BlackboardEntry(GameObject gameobject_, Vector3 position_)
    {
        gameobject = gameobject_;
        position = position_;
    }

    public GameObject gameobject= null;
    public Vector3 position = Vector3.zero;
    public float timestamp = 0.0f;
    public bool is_inmemory = false;
}


public class AIMemory : MonoBehaviour {

	public GameObject Cube;
	public Text Output;
    AIPerceptionManager perceptionManager = null;
    GameObject player = null;

    // TODO 2: Declare and allocate a dictionary with a string as a key and
    // your previous class as value
    Dictionary<string, BlackboardEntry> memory;

    // TODO 3: Capture perception events and add an entry if the player is detected
    // if the player stop from being seen, the entry should be "in the past memory"

	// Use this for initialization
	void Start () {
        perceptionManager = gameObject.GetComponent<AIPerceptionManager>();
        memory = new Dictionary<string, BlackboardEntry>();
        player = GameObject.FindGameObjectWithTag("Visual Emitter");
	}
	
	// Update is called once per frame
	void Update () 
	{
        // TODO 4: Add text output to the bottom-left panel with the information
        // of the elements in the Knowledge base
        //Output.text = "test";

        BlackboardEntry entry = null;
        if (memory.TryGetValue("blackboard", out entry))
        {
            if (entry.is_inmemory)
            {
                Cube.transform.position = entry.position;

                Output.text = "BLACBOARD";
            }
            else
            {
                Cube.transform.position = player.transform.position;

                Output.text = "Time: " + (Time.time - entry.timestamp).ToString();
            }
        }
        else
        {
            Cube.transform.position = player.transform.position;
        }

        
	}

    void PerceptionEvent(PerceptionEvent ev)
    {
        if (ev.type == global::PerceptionEvent.types.NEW)
        {
            BlackboardEntry entry = null;
            if (memory.TryGetValue("blackboard", out entry))
            {
                entry.timestamp = Time.time;
                entry.is_inmemory = false;
            }
            else
            {
                entry = new BlackboardEntry(ev.go, ev.go.transform.position);
                memory.Add("blackboard", entry);
            }
        }
        else if (ev.type == global::PerceptionEvent.types.LOST)
        {
            BlackboardEntry entry = null;
            if (memory.TryGetValue("blackboard", out entry))
            {
                entry.timestamp = Time.time;
                entry.is_inmemory = true;
                entry.position = ev.go.transform.position;
            }
        }
    }
}
