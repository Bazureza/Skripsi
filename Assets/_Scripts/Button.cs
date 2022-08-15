using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    //public Button yourButton;
    // Start is called before the first frame update
    //void Start()
    //{
    //    Button btn = yourButton.GetComponent<Button>();
    //    btn.onClick.AddListener(TaskOnClick);
    //}

    // Update is called once per frame
    //void Update()
   // {
     
   //}

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
  