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
        zhanButton = mRoot.Find("zhan").GetComponent<Button>() as Button;
        faButton = mRoot.Find("fa").GetComponent<Button>() as Button;
        daoButton = mRoot.Find("dao").GetComponent<Button>() as Button;
        createButton = mRoot.Find("create").GetComponent<Button>() as Button;
        nameInput = mRoot.Find("inputName").GetComponent<InputField>() as InputField;

        zhanButton.onClick.AddListener(ZhanClicked);
        faButton.onClick.AddListener(FaClicked);
        daoButton.onClick.AddListener(DaoClicked);
        createButton.onClick.AddListener(CreateClicked);
    }

 

    void Update () {
		
	}


    /// <summary>
    /// 战士
    /// </summary>
    private void ZhanClicked() {
        if (zhanObj == null)
        {
            GameObject obj = GameManager.getInstance.LoadResources<GameObject>(GameConst.Resource.zhanPath);
            zhanObj = GameObject.Instantiate(obj);
            zhanObj.transform.position = Vector3.zero;
        }
        else
        {
            zhanObj.SetActive(true);
        }

        GameManager.getInstance.HideGameObject(faObj);
        GameManager.getInstance.HideGameObject(daoObj);
    }

    /// <summary>
    /// 法师
    /// </summary>
    private void FaClicked()
    {
        if (faObj == null)
        {
            GameObject obj = GameManager.getInstance.LoadResources<GameObject>(GameConst.Resource.faPath);
            faObj = GameObject.Instantiate(obj);
            faObj.transform.position = Vector3.zero;
        }
        else {
            faObj.SetActive(true);
        }

        GameManager.getInstance.HideGameObject(zhanObj);
        GameManager.getInstance.HideGameObject(daoObj);

    }

    /// <summary>
    /// 道士
    /// </summary>
    private void DaoClicked()
    {
        if (daoObj == null)
        {
            GameObject obj = GameManager.getInstance.LoadResources<GameObject>(GameConst.Resource.faPath);
            daoObj = GameObject.Instantiate(obj);
            daoObj.transform.position = Vector3.zero;
        }
        else
        {
            daoObj.SetActive(true);
        }

        GameManager.getInstance.HideGameObject(zhanObj);
        GameManager.getInstance.HideGameObject(faObj);
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
