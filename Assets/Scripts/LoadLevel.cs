using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScene : MonoBehaviour
{
    Camera mainCamera;
    float placeX;
    float placeY;
    float size;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        placeX = mainCamera.transform.position.x - mainCamera.pixelWidth / 2;
        placeY = mainCamera.transform.position.y - mainCamera.pixelHeight / 2;

        // this is assuming the width is going to be bigger than the height, I should change it to check but it likely wont be smaller
    }

}
