using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour {
    private Button startButton;
	// Use this for initialization
	void Start () {
        startButton = transform.GetComponent<Button>();
        startButton.onClick.AddListener(StartClick);
	}
	
	// Update is called once per frame
	void Update () {
	}


    private void StartClick() {
        GameManager.getInstance.LoadScence("CreateCharacter");
    }
}
