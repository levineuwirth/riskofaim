using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {
    private void Start() {
        DontDestroyOnLoad(this.gameObject);
    }
    public void LoadScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }
    public void LoadNextScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ReloadScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}