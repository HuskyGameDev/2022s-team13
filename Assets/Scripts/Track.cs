using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour
{

    //public Sprite sprite;

    
    public GameObject tracks;  
    public Vector3 forward;
    public float speed = .01f;
    public float rotation;

    public Track(float x, float y, GameObject track, float zRotate)
    {
        // the sprite in question must be part of the Resources folder, drop the file type
        //sprite = Resources.Load("Sprites/tracks", typeof(Sprite)) as Sprite;
        //this.GetComponent<SpriteRenderer>().sprite = sprite;


        tracks = track; // track should be a track prefab
        tracks = Instantiate(tracks);
        tracks.transform.position = new Vector3(x, y, 0);

        tracks.transform.Rotate(new Vector3(0, 0, 10), zRotate);  // when you rotate something it will rotate 
        rotation = zRotate;


        forward.x = roundTo2(speed * Mathf.Cos(rotation * Mathf.Deg2Rad));
        forward.y = roundTo2(speed * Mathf.Sin(rotation * Mathf.Deg2Rad));
    }

    // Update is called once per frame
    void Update()
    {        

    }


    // this just rounds certain float to two decimal places
    private float roundTo2(float num)
    {
        num *= 100;
        int newNum = (int) num;
        return ((float) newNum)/100;
    }
}


