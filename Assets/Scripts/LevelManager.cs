﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    /// <summary>
    /// Obtiene el indice de la escena actual y carga la siguiente
    /// </summary>
    public void LoadNextScene() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    /// <summary>
    /// Cierra el juego
    /// </summary>
    public void Quit() {
        Application.Quit();
    }

}
