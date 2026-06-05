using UnityEngine;
using UnityEngine.UI;

public class EmoteManager : MonoBehaviour
{
    public Animator anim;
    public string[] emotes;
    public int activeEmote;

    public Text activeEmoteText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        activeEmote = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("tab"))
        {
            if (activeEmote < emotes.Length-1)

                activeEmote++;
            else
                activeEmote = 0;
        }
        updateGui();
        Actions();
    }

    private void Actions()
    {
        if (Input.GetKeyDown("e"))
        {
            anim.SetBool(emotes[activeEmote], true);
        }
        else if (Input.GetKeyUp("e"))
        {
            anim.SetBool(emotes[activeEmote], false);
        }
    }
    private void updateGui()
    {
        activeEmoteText.text = "Current Emote: " + emotes[activeEmote];
    }
}
