using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** �� ������ */
public abstract class CSceneManager : CComponent
{
    #region ������Ƽ
    public abstract string SceneName { get; }
    #endregion // ������Ƽ

    #region �Լ�
    /** �ʱ�ȭ */
    public override void Awake()
    {
        base.Awake();
    }
    #endregion // �Լ�
}
