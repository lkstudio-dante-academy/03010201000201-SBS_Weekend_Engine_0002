using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** �ػ� ó���� */
public class CResolutionHandler : CComponent
{
    #region ����
    private Camera m_oCamera = null;
    [SerializeField] private EProjection m_eProjection = EProjection._3D;
    #endregion // ����

    #region ������Ƽ
    public float Distance
    {
        get
        {
            float fAngle = this.FOV / 2.0f;
            float fHeight = KDefine.G_DESIGN_SCREEN_HEIGHT / 2.0f;

            return fHeight / Mathf.Tan(fAngle);
        }
    }

    public float FOV => Mathf.PI / 4.0f;
    #endregion // ������Ƽ

    #region �Լ�
    /** �ʱ�ȭ */
    public override void Awake()
    {
        base.Awake();
        m_oCamera = this.GetComponent<Camera>();

        this.SetupResolution();
    }

    /** ���¸� �����Ѵ� */
    public override void Reset()
    {
        base.Reset();
        m_oCamera = this.GetComponent<Camera>();

        this.SetupResolution();
    }

    /** �ػ󵵸� �����Ѵ� */
    private void SetupResolution()
    {
        var oCamera = m_oCamera ?? this.GetComponent<Camera>();
        oCamera.nearClipPlane = 0.1f;
        oCamera.farClipPlane = 25000.0f;

        oCamera.orthographic = m_eProjection != EProjection._3D;
        oCamera.orthographicSize = KDefine.G_DESIGN_SCREEN_HEIGHT / 2.0f;

        oCamera.fieldOfView = this.FOV * Mathf.Rad2Deg;
        oCamera.transform.position = new Vector3(0.0f, 0.0f, -this.Distance);
    }
    #endregion // �Լ�
}
