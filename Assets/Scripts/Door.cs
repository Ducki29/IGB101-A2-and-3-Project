using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject player;
    private Animation anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) <= 5f)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                anim.Play();
            }
        }
    }
}
