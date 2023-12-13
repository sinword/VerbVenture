using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System;

public class ExitSettingMode : MonoBehaviour
{
    [SerializeField] private Button _exitBtn;
    private List<GameObject> _cubes = new List<GameObject>();
    void Start()
    {
        _cubes.Add(GameObject.Find("Umbrella Object"));
        _cubes.Add(GameObject.Find("Phone Object"));

        this._exitBtn.onClick.AddListener(delegate {
            // this._text1.SetActive(false);
            // this._text2.SetActive(false);
            // this._canvas.enabled = false;
            
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
            
            string path = Path.Combine(Application.persistentDataPath, "cubeInfo.json");
            FileHandler.SaveToJSON<CubeInfo>(cubeInfoList, path);
            
        });
    }
    
    
}
