using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateCharacter : MonoBehaviour {
    public Button zhanButton;
    public Button faButton;
    public Button daoButton;
    public Button createButton;
    public InputField nameInput;
    public Transform mRoot;

    private GameObject zhanObj;
    private GameObject faObj;
    private GameObject daoObj;



    void Start () {
        mRoot = transform;
        createButton = mRoot.Find("create").GetComponent<Button>() as Button;
        nameInput = mRoot.Find("inputName").GetComponent<InputField>() as InputField;

        createButton.onClick.AddListener(CreateClicked);
    }



    /// <summary>
    /// 创角
    /// </summary>
    private void CreateClicked()
    {
        String name = nameInput.text;
        if (name == string.Empty) {
            return;
        }

        PlayerPrefs.SetString(GameConst.User.username, name);
        GameManager.getInstance.LoadScence(GameConst.Scene.MainScene);
    }

}
