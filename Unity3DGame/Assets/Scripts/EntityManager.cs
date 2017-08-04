using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager {
    private static EntityManager instance = new EntityManager();

    public static EntityManager getInstance() {
        if (instance == null) {
            instance = new EntityManager();
        }
        return instance;
    }

    /// <summary>
    /// 创建一个实体类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entityName"></param>
    /// <returns></returns>
    public T CreateEntity<T>(string entityName,Vector3 pos,Vector3 dir) where T:Entity{
        GameObject loadObj = GameManager.getInstance.LoadResources<GameObject>(entityName);
        GameObject obj = GameObject.Instantiate(loadObj);
        Entity entity = obj.GetComponent<Entity>();
        if (entity = null) {
            obj.AddComponent<Entity>();
        }
        entity.InitEntity(pos, dir);
        return (T)entity;
    } 

}
