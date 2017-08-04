using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConst {

    public class Animate {
        public const string IDEL = "IDEL";
        public const string RUN = "RUN";
        public const string DEATH = "DEATH";
        public const string ATTACK = "ATTACK";
        public const string HIT = "HIT";
    }





    /// <summary>
    /// 资源
    /// </summary>
    public class Resource
    {
        public const string zhanPath = "Prefabs/Cube";
        public const string faPath = "Prefabs/Sphere";
        public const string daoPath = "Prefabs/Capsule";
    }

    /// <summary>
    /// 场景
    /// </summary>
    public class Scene
    {
        public const string LoadingScene = "LoadingScene";
        public const string LoginScene = "LoginScene";
        public const string CreateCharacter = "CreateCharacter";
        public const string MainScene = "MainScene";
    }


    public class User {
        public const string username = "username";
    }
}



public enum CharacterType
{
    ZHAN,
    FA,
    DAO
}


