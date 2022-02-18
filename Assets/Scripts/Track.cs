using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour
{

    //public Sprite sprite;

    
    public GameObject tracks;  // must be assinged in the inspector thing in unity itself
    public Vector3 forward;
    public float speed = .01f;
    public float rotation;

    public Track(float x, float y)
    {
        // the sprite in question must be part of the Resources folder, drop the file type
        //sprite = Resources.Load("Sprites/tracks", typeof(Sprite)) as Sprite;
        //this.GetComponent<SpriteRenderer>().sprite = sprite;

        tracks = Instantiate(tracks);
        //rotation = this.GetComponent<Transform>().rotation.eulerAngles.z;


        forward.x = roundTo2(speed * Mathf.Cos(rotation * Mathf.Deg2Rad));
        forward.y = roundTo2(speed * Mathf.Sin(rotation * Mathf.Deg2Rad));
    }

    // Update is called once per frame
    void Update()
    {
        //rotation = this.GetComponent<Transform>().rotation.eulerAngles.z;
        

    }


    // this just rounds certain float to two decimal places
    private float roundTo2(float num)
    {
        num *= 100;
        int newNum = (int) num;
        return ((float) newNum)/100;
    }
}


