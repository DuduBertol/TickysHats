using UnityEngine;
using System.Collections;
using System.IO;
using System;
public class Screenshot : MonoBehaviour
{
    private string _caminho;

    private void Start()
    {
        _caminho = Application.dataPath + "/capturas/";

        if (!Directory.Exists(_caminho))
        {
            Directory.CreateDirectory(_caminho);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            string nomeImagem = _caminho + DateTime.Now.Ticks.ToString() + ".png";
            ScreenCapture.CaptureScreenshot(nomeImagem, 2);
            Debug.Log("CAPUTURA TIRADA");
        }
    }
}