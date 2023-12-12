using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System;

public class ExitSettingMode : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private Button _exitBtn;
    [SerializeField] private GameObject _text1;
    [SerializeField] private Material _blueMat;
    [SerializeField] private GameObject _text2;
    [SerializeField] private Material _greenMat;
    
    private List<GameObject> _cubes = new List<GameObject>();
    void Start()
    {
        _cubes.Add(GameObject.Find("Umbrella Object"));
        _cubes.Add(GameObject.Find("Phone Object"));

        this._exitBtn.onClick.AddListener(delegate {
            this._greenMat.SetColor("_BaseColor", new Color(0.4069019f, 1.0f, 0.2399999f, 0.0f));
            this._blueMat.SetColor("_BaseColor", new Color(0.2392156f, 0.8572884f, 1.0f, 0.0f));
            this._text1.SetActive(false);
            this._text2.SetActive(false);
            this._canvas.enabled = false;
            
            List<CubeInfo> cubeInfoList = new List<CubeInfo>();
            
            foreach (GameObject cube in _cubes) 
            {
                CubeInfo cubeInfo = new CubeInfo();
                Debug.Log("Cube Name: " + cube.name);
                Debug.Log("Cube Position: " + cube.transform.position);
                cubeInfo.cubeName = cube.name;
                cubeInfo.position = cube.transform.position;
                cubeInfoList.Add(cubeInfo);
            }

            Debug.Log("CubeInfoList Count: " + cubeInfoList.Count);
            FileHandler.SaveToJSON<CubeInfo>(cubeInfoList, "cubeInfo.json");
            // SceneManager.LoadScene("MainScene");
        });
        // this._outline_green.enabled = true;
        // this._outline_blue.enabled = true;
        //   _canvas.enabled = false;
    }

    
    void OnApplicationQuit()
    {
        _greenMat.SetColor("_BaseColor", new Color(0.4069019f, 1.0f, 0.2399999f, 1.0f));
        _blueMat.SetColor("_BaseColor", new Color(0.2392156f, 0.8572884f, 1.0f, 1.0f));
    }
}
