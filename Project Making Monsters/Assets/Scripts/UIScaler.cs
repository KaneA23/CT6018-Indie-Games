using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScaler : MonoBehaviour
{
    public float resX;
    public float resY;

    private CanvasScaler _canvasScale;

    private void Awake()
    {
        _canvasScale = GetComponent<CanvasScaler>();
    }

    // Start is called before the first frame update
    void Start()
    {
        SetInfo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetInfo()
    {
        resX = Screen.currentResolution.width;
        resY = Screen.currentResolution.height;

        _canvasScale.referenceResolution = new Vector2(resX, resY);
    }
}
