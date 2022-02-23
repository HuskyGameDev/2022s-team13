using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LoadLevel : MonoBehaviour
{
    string lvlData;
    int trackNum;
    int carNum;
    int endNum;
    float lvlHeight;
    float lvlWidth;
    float placeX;
    float placeY;
    float trackYOffset;
    float originalX; // used for resetting placeX
    public float trackSize;
    ArrayList nums;
    ArrayList currentData;
    StreamReader stream;
    Camera mainCamera;
    Track currentTrack;
    public GameObject tracksLR;  // must be initialized from unity itself, make sure is public



    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        
        stream = new StreamReader(@"Assets/Resources/Levels/lvl1.txt");

        stream.ReadLine(); // reads level name
        stream.ReadLine(); // reads background image
        lvlHeight = float.Parse(stream.ReadLine());
        lvlWidth = float.Parse(stream.ReadLine());

        // this is assuming the width is going to be bigger than the height, I should change it to check but it likely wont be smaller
        trackSize = mainCamera.orthographicSize * 2 / lvlWidth;
        tracksLR.transform.localScale = Vector3.one * trackSize;


        originalX = mainCamera.transform.position.x - mainCamera.orthographicSize + trackSize;
        placeX = originalX;
        placeY = mainCamera.transform.position.y + (mainCamera.aspect * mainCamera.orthographicSize) / 2 - trackSize * 2;  // aspect will get the ratio of h/w for camera
        trackYOffset = .1f;
        while (!stream.EndOfStream)
        {
            lvlData = stream.ReadLine();

            currentData = new ArrayList(lvlData.Split());


            for (int i = 0; i < currentData.Count; i ++)
            {
                if ((string) currentData[i] == "")
                {
                    currentData.RemoveAt(i);
                    i--;
                }
                else
                {
                    if ((string) currentData[i] != "*")
                    {

                        nums = new ArrayList(((string)currentData[i]).Split(':'));
                        
                        switch (nums[0])
                        {
                            case "00":
                            case "0":
                                currentTrack = new Track(placeX, placeY, tracksLR, 0f);
                                break;

                            case "01":
                            case "1":
                                currentTrack = new Track(placeX, placeY, tracksLR, -45f);
                                break;

                            case "02":
                            case "2":
                                currentTrack = new Track(placeX, placeY, tracksLR, 45f);
                                break;
                            default:
                                break;
                        }

                    }

                    placeX += trackSize;

                }
            }

            placeX = originalX;
            placeY -= trackSize - trackYOffset;
        }

    }

}
