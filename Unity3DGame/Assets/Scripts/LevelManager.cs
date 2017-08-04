using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    private Player player;
	// Use this for initialization
	void Start () {
        string playerResPath = string.Empty;
        CharacterType type = GameManager.getInstance.GetCharacterType;
        if (type == CharacterType.ZHAN)
        {
            playerResPath = GameConst.Resource.zhanPath;
        }
        else if (type == CharacterType.FA)
        {
            playerResPath = GameConst.Resource.faPath;
        }
        else if (type == CharacterType.DAO) {
            playerResPath = GameConst.Resource.daoPath;
        }

        player = EntityManager.getInstance().CreateEntity<Player>(playerResPath,new Vector3(1,1,1),Vector3.forward) ;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
