using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player;

    public int currentPickups = 0;
    public int maxPickups = 0;
    public bool levelComplete = false;

    public Text pickupText;

    public AudioSource[] audioSources;
    public float audioProximity = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FindPickups();
    }

    // Update is called once per frame
    void Update()
    {
        levelCompleteCheck();
        updateGUI();
        playAudio();
    }

    private void FindPickups()
    {
        GameObject[] pickups = GameObject.FindGameObjectsWithTag("Pickup");
        maxPickups = pickups.Length;
    }
    private void levelCompleteCheck()
    {
        if (currentPickups >= maxPickups)
            levelComplete = true;
        else
            levelComplete = false;


    }

    private void updateGUI()
    {
        pickupText.text = "Pickups: " + currentPickups + "/" + maxPickups;
    }

    private void playAudio()
    {
        for (int i = 0; i < audioSources.Length; i++)
        {
            if (Vector3.Distance(player.transform.position, audioSources[i].transform.position) <= audioProximity)
                {
                if (!audioSources[i].isPlaying)
                {
                    audioSources[i].Play();
                }

            }
           
        }
    }
}
