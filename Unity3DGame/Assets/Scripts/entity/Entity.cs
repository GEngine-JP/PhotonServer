using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum EntityState {
    IDEL,
    RUN,
    ATTACK,
    HIT,
    DEATH
}






public class Entity : MonoBehaviour {
    private Animator animator;
    private Transform mRoot;
    private EntityState myState;


    private void Awake()
    {
        mRoot = transform;
        animator = mRoot.GetComponent<Animator>() as Animator;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// 初始化实体类
    /// </summary>
    /// <param name="pos"></param>
    /// <param name="dir"></param>
    public void InitEntity(Vector3 pos, Vector3 dir) {
        mRoot.position = pos;
        mRoot.rotation = Quaternion.LookRotation(dir);
    }


    public void PlayerAnimation(string animationName) {
        if (animationName == string.Empty) {
            Debug.Log("传入的动画为空 " + animationName);
        }
        animator.Play(animationName);
    }

    /// <summary>
    /// 进入站立动作
    /// </summary>
    protected void EnterIdel() {
        myState = EntityState.IDEL;
        PlayerAnimation(GameConst.Animate.IDEL);
    }

    /// <summary>
    /// 进入跳步动作
    /// </summary>
    protected void EnterRun() {
        myState = EntityState.RUN;
        PlayerAnimation(GameConst.Animate.RUN);
    }

    /// <summary>
    /// 被攻击
    /// </summary>
    protected void EnterHit() {
        myState = EntityState.HIT;
        PlayerAnimation(GameConst.Animate.HIT);
    }

    /// <summary>
    /// 进入攻击状态
    /// </summary>
    protected void EnterAttack() {
        myState = EntityState.ATTACK;
        PlayerAnimation(GameConst.Animate.ATTACK);
    }

    /// <summary>
    /// 进入死亡状态
    /// </summary>
    protected void EnterDeath()
    {
        myState = EntityState.DEATH;
        PlayerAnimation(GameConst.Animate.DEATH);
    }
}
