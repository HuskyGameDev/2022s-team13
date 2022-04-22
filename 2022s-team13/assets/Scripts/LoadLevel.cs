using System.Collections;
using UnityEngine;
using System.IO;

public class LoadLevel : MonoBehaviour
{
    string lvlData;
    string trackNum;
    string carNum;
    string endNum;
    float lvlHeight;
    float lvlWidth;
    float placeX;
    float placeY;
    float trackYOffset;
    float trackXOffset;
    float originalX; // used for resetting placeX
    float trackHeight;
    float trackWidth;
    float currentRotation;
    ArrayList nums;
    ArrayList currentData;
    StreamReader stream;
    Camera mainCamera;
    Track currentTrack;
    GameObject currentTrain;
    GameObject currentObject;
    public GameObject tracksLR;  // must be initialized from unity itself, make sure is public
    public GameObject tracksSwitchLRToSE;
    public GameObject tracksCurveLToNE;
    public GameObject[] trains; // red green blue black
    public string filepath = "Assets/Resources/Levels/lvl2.txt";

    const float TRACKWHRATIO = 4.2f; // measured within track prefab


    // Start is called before the first frame update
    void Start()
    {
        filepath = "Assets/Resources/Levels/" + VarHolder.crossInformation + ".txt";
        mainCamera = Camera.main;
        
        stream = new StreamReader(@filepath);

        stream.ReadLine(); // reads level name
        stream.ReadLine(); // reads background image

        lvlHeight = float.Parse(stream.ReadLine());
        lvlWidth = float.Parse(stream.ReadLine());
        // this is assuming the width is going to be bigger than the height, I should change it to check but it likely wont be smaller
        trackWidth = mainCamera.orthographicSize * 2 / lvlWidth;
        trackWidth *= 3;
        trackHeight = trackWidth / TRACKWHRATIO;

        

        originalX = mainCamera.transform.position.x - mainCamera.orthographicSize - trackWidth * 3.5f;
        placeX = originalX;
        trackYOffset = trackHeight/2;
        placeY = mainCamera.transform.position.y + trackHeight * lvlHeight / 2.0f + trackYOffset * lvlHeight/ 2 - trackHeight/2;
        trackXOffset = 0;
        while (!stream.EndOfStream)
        {
            lvlData = stream.ReadLine();

            if (lvlData.StartsWith("//"))
            {
                print(lvlData);
                continue;
            }
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

                        trackNum = (string) nums[0];
                        carNum = (string) nums[1];
                        endNum = (string) nums[2];
                        print(trackNum);
                        // for placing tracks
                        switch (trackNum)
                        {
                            case "00":
                            case "0":
                                // l/r
                                currentRotation = 0;
                                currentTrack = new Track(placeX, placeY, trackWidth, trackHeight, tracksLR, 0f, endNum);
                                break;

                            case "01":
                            case "1":
                                // nw/se
                                currentRotation = -35;

                                currentTrack = new Track(placeX, placeY, trackWidth, trackHeight, tracksLR, -35f, endNum);
                                break;

                            case "02":
                            case "2":
                                // sw/ne
                                currentRotation = 35;

                                currentTrack = new Track(placeX, placeY, trackWidth, trackHeight, tracksLR, 35f, endNum);
                                break;
                            case "03":
                            case "3":
                                // curve l/ne
                                currentRotation = 0;

                                currentTrack = new Track(placeX, placeY, trackWidth, trackHeight, tracksCurveLToNE, 0f, endNum);

                                break;
                            case "04":
                            case "4":
                                // curve nw/r
                                currentRotation = -35;

                                currentTrack = new Track(placeX, placeY, trackWidth, trackHeight, tracksCurveLToNE, -35f, endNum);

                                break;
                            case "05":
                            case "5":
                                // curve ne/se
                                currentRotation = 0;

                                currentTrack = new Track(placeX, placeY, trackWidth, trackHeight, tracksCurveLToNE, 125f, endNum);

                                break;
                            case "06":
                            case "6":
                                // curve sw/right
                                currentRotation = 180;

                                currentTrack = new Track(placeX, placeY, trackWidth, trackHeight, tracksCurveLToNE, 180f, endNum, true);

                                break;
                            case "07":
                            case "7":
                                // curve l/se
                                currentRotation = 0;

                                currentTrack = new Track(placeX, placeY, trackWidth, trackHeight, tracksCurveLToNE, 0f, endNum, true);

                                break;
                            case "08":
                            case "8":
                                // curve nw/sw
                                currentRotation = 125;

                                currentTrack = new Track(placeX, placeY, trackWidth, trackHeight, tracksCurveLToNE, 125f, endNum);

                                break;
                            case "09":
                            case "9":
                                // l/r ne switch
                                currentRotation = 0;

                                currentTrack = new Track(placeX, placeY, trackWidth, trackHeight, tracksSwitchLRToSE, 0f, endNum, true);
                                break;
                            case "10":
                                // nw/se right switch
                                currentRotation = -35;

                                currentTrack = new Track(placeX, placeY, trackWidth, trackHeight, tracksSwitchLRToSE, -35f, endNum, true);
                                break;
                            case "11":
                                // ne/sw se switch
                                currentRotation = -145;

                                currentTrack = new Track(placeX, placeY, trackWidth, trackHeight, tracksSwitchLRToSE, -145f, endNum, true);
                                break;
                            case "12":
                                // r/l sw switch
                                currentRotation = -145;

                                currentTrack = new Track(placeX, placeY, trackWidth, trackHeight, tracksSwitchLRToSE, -145f, endNum);
                                break;
                            case "13":
                                // se/nw left switch
                                currentRotation = -35;

                                currentTrack = new Track(placeX, placeY, trackWidth, trackHeight, tracksSwitchLRToSE, -35f, endNum, true);
                                break;
                            case "14":
                                // sw/ne nw switch
                                currentRotation = 35;

                                currentTrack = new Track(placeX, placeY, trackWidth, trackHeight, tracksSwitchLRToSE, 35f, endNum, true);
                                break;
                            case "15":
                                // l/r se switch
                                currentRotation = 0;

                                currentTrack = new Track(placeX, placeY, trackWidth, trackHeight, tracksSwitchLRToSE, 0f, endNum);
                                break;
                            case "16":
                                // nw/se sw switch
                                currentRotation = 145;

                                currentTrack = new Track(placeX, placeY, trackWidth, trackHeight, tracksSwitchLRToSE, 145f, endNum, true);
                                break;
                            case "17":
                                // ne/sw left switch
                                currentRotation = 0;

                                currentTrack = new Track(placeX, placeY, trackWidth, trackHeight, tracksSwitchLRToSE, 0f, endNum);
                                break;
                            case "18":
                                // r/l nw switch
                                currentRotation = 180;

                                currentTrack = new Track(placeX, placeY, trackWidth, trackHeight, tracksSwitchLRToSE, 180f, endNum);
                                break;
                            case "19":
                                // se/nw ne switch
                                currentRotation = 145;

                                currentTrack = new Track(placeX, placeY, trackWidth, trackHeight, tracksSwitchLRToSE, 145f, endNum);
                                break;
                            case "20":
                                // sw/ne right switch
                                currentRotation = 35;

                                currentTrack = new Track(placeX, placeY, trackWidth, trackHeight, tracksSwitchLRToSE, 35f, endNum, true);
                                break;
                            default:
                                break;
                        }

                        // for placing cars on tracks
                        if (carNum.StartsWith("0"))
                        {
                            carNum = carNum.Substring(1, 1);
                        }
                        if (carNum != "")
                        {
                            if (trains[int.Parse(carNum)] != null)
                            {
                                currentTrain = Instantiate(trains[int.Parse(carNum)]);

                                currentTrain.transform.position = new Vector3(placeX, placeY, -2f);
                                currentTrain.transform.Rotate(new Vector3(0, 0, 10), currentRotation + 180);  // when you rotate something it will rotate 

                                currentTrain.transform.localScale = new Vector3(trackWidth / 7.88f, trackHeight / 3.14f);
                                
                            }
                        }

                    } 
                    placeX += trackWidth;

                }
            }
            trackXOffset = (trackXOffset + (trackWidth / 2)) % trackWidth;
            placeX = originalX + trackXOffset;
            placeY -= trackHeight + trackYOffset;
        }

    }

}
