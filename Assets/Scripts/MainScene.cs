using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScene : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private KeyCode _resetHotKey = KeyCode.R;
    private string _cubeInfoFileName = "cubeInfo.json";
    void Start()
    {
        List<CubeInfo> cubeInfoList = FileHandler.ReadFromJSON<CubeInfo>(_cubeInfoFileName);
        Debug.Log("MainScene CubeInfoList Read Count: " + cubeInfoList.Count);
        foreach (CubeInfo cubeInfo in cubeInfoList)
        {
            GameObject cube = Instantiate(_cubePrefab, cubeInfo.position, Quaternion.identity);
            cube.name = cubeInfo.cubeName;
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
