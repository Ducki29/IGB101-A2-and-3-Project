using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour{


    public GameObject[] cameraNodes;
    private int cameraIndex = 0;

    public GameObject[] objects;

    private float proximity = 0.1f;
    public float moveSpeed = 5.0f;
    public float rotSpeed = 5.0f;
    private float adjRotSpeed;
    private Quaternion targetRotation;


    // Start is called before the first frame update
    void Start(){
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update(){

        Inputs();
        Movement();
    }



    private void Inputs() {

        //Increment or Decrement Camera Position Index
        if (Vector3.Distance(transform.position, cameraNodes[cameraIndex].transform.position) < proximity) {

            if (Input.GetKeyDown("w")) {
                cameraIndex++;

                if (cameraIndex >= cameraNodes.Length - 1)
                    cameraIndex = cameraNodes.Length - 1;
            }
            else if (Input.GetKeyDown("s")) {
                    cameraIndex--;
                    if (cameraIndex <= 0)
                        cameraIndex = 0;
            }
        }


    }

    private void Movement()
    {

        if (Vector3.Distance(transform.position, cameraNodes[cameraIndex].transform.position) > proximity)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                cameraNodes[cameraIndex].transform.position,
                moveSpeed * Time.deltaTime
            );
        }


        if (objects[cameraIndex] != null)
        {
            Vector3 direction = objects[cameraIndex].transform.position - transform.position;
            if (direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(
                    transform.rotation,
                    targetRotation,
                    rotSpeed * Time.deltaTime
                );
            }
        }

        AudioSource source = objects[cameraIndex].GetComponent<AudioSource>();
        if (source != null && !source.isPlaying)
        {
            source.Play();
        }
    }

}
