using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Menu : MonoBehaviour
{

    [Header("Command List")]
    public string[] key;
    [Header("Level Speak Confidence")]
    public ConfidenceLevel confidence = ConfidenceLevel.Medium;
    [Header("Text Result")]
    public Text Result;
    [Header("Transitions Animation")]
    public Animator anim;
    [Header("Sound ")]
    public AudioSource audio;
    public AudioClip PlayClip;

    protected PhraseRecognizer Recognizer;
    protected string word;

    private void Start()
    {
        if (key != null)
        {
            Recognizer = new KeywordRecognizer(key, confidence);
            Recognizer.OnPhraseRecognized += OnPhraseRecognized;
            Recognizer.Start();
        }
    }
    void OnPhraseRecognized(PhraseRecognizedEventArgs Sound)
    {
        word = Sound.text;

        if (word == "training")
        {
            SceneController.MyScore = 0;
            SceneController.TheInstanceOfSceneController.JumlahSemuaPertanyaan = 5;
            SceneController.TheInstanceOfSceneController.PertanyaanYgDitampilkan = 5;
            SceneController.TheInstanceOfSceneController.SisaPertanyaan = 5;
            SceneController.TheInstanceOfSceneController.WhatSceneToLoad = 0;
            StartCoroutine(playGame());
        }
        else
       if (word == "example")
        {
            SceneController.MyScore = 0;
            SceneController.TheInstanceOfSceneController.JumlahSemuaPertanyaan = 5;
            SceneController.TheInstanceOfSceneController.PertanyaanYgDitampilkan = 5;
            SceneController.TheInstanceOfSceneController.SisaPertanyaan = 5;
            SceneController.TheInstanceOfSceneController.WhatSceneToLoad = 5;
            StartCoroutine(playGame());
        }
        else
         if (word == "test")
        {
            SceneController.MyScore = 0;
            SceneController.TheInstanceOfSceneController.JumlahSemuaPertanyaan = 10;
            SceneController.TheInstanceOfSceneController.PertanyaanYgDitampilkan = 10;
            SceneController.TheInstanceOfSceneController.SisaPertanyaan = 10;
            SceneController.TheInstanceOfSceneController.WhatSceneToLoad = 6;
            StartCoroutine(playGame());
        }
        else
        // for exiting application
        if (word == "exit")
        {
            Debug.Log("Quit Game");
            Application.Quit();
        }
        // display your voice in game 
        Result.text = "You Say :<b> " + word + "</b> ";
    }// end of functions OnPhraseRecognized
    IEnumerator playGame()
    {
        anim.SetTrigger("end");
        audio.PlayOneShot(PlayClip);
        yield return new WaitForSeconds(1.6f);
        //SceneManager.LoadScene("Game_1");
        //SceneController.TheInstanceOfSceneController.WhatSceneToLoad = 3;

        var test = SceneController.TheInstanceOfSceneController.WhatSceneToLoad == 6;
        SceneController.TheInstanceOfSceneController.LoadNewScene(test);

        Destroy(this.gameObject);
    }
    // check if application quit
    private void OnApplicationQuit()
    {
        stopRecognizer();
    }
    // to Stop recognizer detection
    public void stopRecognizer()
    {
        if (Recognizer != null && Recognizer.IsRunning)
        {
            Recognizer.OnPhraseRecognized -= OnPhraseRecognized;
            Recognizer.Stop();
        }
    }
}// end of Class