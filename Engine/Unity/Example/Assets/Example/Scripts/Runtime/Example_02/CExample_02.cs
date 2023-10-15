using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * �������̶�?
 * - Ư�� Game Object �� ���¿� ���·� ���� �� �� �ִ� ����� �ǹ��Ѵ�.
 * (��, �������� Ȱ���ϸ� Game Object �� ������ ���·� ���������μ� ���ο�
 * �纻 ��ü�� �ս��� �����ϴ� ���� �����ϴ�.)
 * 
 * ����, �������� ���� ���� �� �纻 Game Object �� ���� �����հ� ���� ������
 * �����ϱ� ������ ���� ������ or �纻 Game Object �� ���� ������ �ս���
 * ����ȭ�ϴ� ���� �����ϴ�.
 * 
 * Unity �� ������Ʈ ��� ���α׷��� ����� ä���ϰ� �ֱ� ������ Ư�� ������
 * �����ϴ� �繰�� �����ϱ� ���ؼ��� �繰�� �ش��ϴ� Game Object �� ���� ��
 * ������ ������Ʈ�� �߰��ϴ� ������ ������ �ʿ��ϴ�.
 * 
 * ����, Unity ���� ���ο� Game Object �� �����ϰ� �ʹٸ� �̸�
 * ���� �Ǿ��ִ� ���� Game Object �� ������� �纻 Game Object �� �����ϴ�
 * ����� �ַ� ����Ѵ�. (��, new GameObject ��ɹ��� ���� ���ο� 
 * Game Object �� �����ϴ� �͵� ���������� �ش� ����� �� Ȱ����� �ʴ´ٴ�
 * ���� �� �� �ִ�.)
 * 
 * ��ũ��Ʈ��?
 * - Unity �� �������ִ� ������Ʈ �̿ܿ� ����� (���α׷���) �� �ʿ信 ����
 * ���� �����ؼ� ����ϴ� ������Ʈ�� �ǹ��Ѵ�. (��, ��ũ��Ʈ�� Ȱ���ϸ�
 * �����ϴ� ������Ʈ�� ���� ���ϴ� ����� �����Ӱ� �����ϴ� ���� �����ϴ�.)
 * 
 * Unity ��ũ��Ʈ ���� ��Ģ
 * - C# Ŭ���� �̸��� ���ϸ� ��ġ (2021 ���� ����)
 * - ��/���������� MonoBehaviour Ŭ���� ���
 * 
 * ���� ��Ģ�� ������ ���� ��� �ش� Ŭ������ ��ũ��Ʈ ������Ʈ�� �ƴ� �ܼ���
 * C# �� Ŭ������� ���� �� �� �ִ�. (��, new Ű���带 ���ؼ� ��ü�� 
 * �����ϴ� ���� ���������� Game Object �� ������Ʈ ���·� �߰���Ű�� ����
 * �Ұ����ϴٴ� ���� �ǹ��Ѵ�.)
 */
/** Example 2 */
public partial class CExample_02 : CSceneManager
{
    #region ����
    /*
     * SerializeField �Ӽ��� Ȱ���ϸ� protected ��ȣ ���� �̻����� ��� ��
     * ����� Unity ������ �󿡼� ���� �� �� �ֵ��� �Է� �ʵ带 ���� ��Ű��
     * ���� �����ϴ�. (��, �ش� �Ӽ��� Ȱ������ ������ public ��ȣ ������
     * �����ϰ�� Unity ������ �󿡼� �ش� ������ ���� �����ϴ� ���� �Ұ���
     * �ϴٴ� ���� �� �� �ִ�.)
     */
    [SerializeField] private GameObject m_oTargetRoot = null;
    [SerializeField] private GameObject m_oOriginTarget = null;
    #endregion // ����

    #region ������Ƽ
    public override string SceneName => KDefine.G_SCENE_N_EXAMPLE_02;
    #endregion // ������Ƽ

    #region �Լ�
    /** �ʱ�ȭ */
    public override void Awake()
    {
        base.Awake();
    }

    /** ���¸� �����Ѵ� */
    public void Update()
    {
        /*
         * Input Ŭ������?
         * - �پ��� �Է� ��ġ�� ���� ó�� ����� �����ϴ� Ŭ������ �ǹ��Ѵ�.
         * (��, �ش� Ŭ������ �̿��ϸ� Ű���� �� ���콺�� ���� �Է� ��ġ��
         * �Է� ���� ���� �پ��� ����� ������ ���α׷��� �����ϴ� ����
         * �����ϴ�.)
         */
        // �����̽� Ű�� ������ ���
        if (Input.GetKeyDown(KeyCode.Space))
        {
            /*
             * Instantiate �޼��带 Ȱ���ϸ� ���� Game Object �� �������
             * �纻 Game Object �� �����ϴ� ���� �����ϴ�. (��, �ش�
             * �޼��带 Ȱ���ϸ� ���ο� Game Object �ս��� �����ϴ� ����
             * �����ϴ�.)
             */
            var oTarget = Instantiate(m_oOriginTarget, 
                Vector3.zero, Quaternion.identity);
            
            /*
             * Transform ������Ʈ�� SetParent �޼��带 Ȱ���ϸ� Ư�� ��ü��
             * �ڽ����� �߰��ϴ� ���� �����ϴ�. (��, �ش� �޼��带 Ȱ�������μ�
             * Game Object ���� �������� ������ ���� ��ų �� �ִ�.)
             */
            oTarget.transform.SetParent(m_oTargetRoot.transform, false);
        }
    }
    #endregion // �Լ�
}
