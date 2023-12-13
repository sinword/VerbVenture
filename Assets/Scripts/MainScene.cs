using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System;
using TMPro;

public class MainScene : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private KeyCode _resetHotKey = KeyCode.R;
    
    void Start()
    {
        string path = Path.Combine(Application.persistentDataPath, "cubeInfo.json");
        List<CubeInfo> cubeInfoList = FileHandler.ReadFromJSON<CubeInfo>(path);
        Debug.Log("MainScene CubeInfoList Read Count: " + cubeInfoList.Count);
        foreach (CubeInfo cubeInfo in cubeInfoList)
        {
            GameObject cube = Instantiate(_cubePrefab, cubeInfo.position, Quaternion.identity);
            cube.name = cubeInfo.cubeName;
        }
        
        TextMeshProUGUI textComponent = GameObject.Find("WordsSpaceCanvas/HitInfo").GetComponent<TextMeshProUGUI>();
        if (textComponent != null)
        {
            textComponent.text = "NULL";
        }
        else
        {
            Debug.LogError("TextMeshProUGUI component not found!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(_resetHotKey)) {
            RestartScene();
        }
    }

    void RestartScene() {
        SceneManager.LoadScene("MainScene");
    }
}
