using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** �ֻ��� ������Ʈ */
public abstract class CComponent : MonoBehaviour
{
    #region �Լ�
    /*
     * �̺�Ʈ �޼����?
     * - Unity �� ���� �߿� �߻��ϴ� ���� ��ȭ�� �����ϰ� ó�� �� �� �ִ�
     * �޼��带 �ǹ��Ѵ�. (��, Unity �� ���� �̺�Ʈ �޼��带 �����ϸ� �ش�
     * �޼��带 Ȱ���ϸ� Ư�� ��Ȳ�� ���� ���� ó���� �����ϴ� ���� �����ϴ�.)
     * 
     * Unity �ֿ� �̺�Ʈ �޼���
     * - Awake
     * - Start
     * - Update
     * - LateUpdate
     * - OnDestroy
     * 
     * Awake �޼��� vs Start �޼���
     * - �� �޼��� ��� Ư�� Game Object �� �ʱ�ȭ�ϱ� ���� �뵵�� Ȱ��ȴ�.
     * 
     * Awake �޼���� Game Object �� Ȱ�� ���°� �Ǵ� ��� ȣ��Ǵ� �ݸ�
     * Start �޼���� Ȱ�� ���°� �ǰ� ���� �����ӿ� ȣ��Ǵ� �������� ����
     * �Ѵ�.
     * 
     * ����, Ư�� Game Object �� ������ ���ÿ� �ش� Game Object ���ϰ�
     * �ִ� ������Ʈ�� Ȱ���ϰ� �ʹٸ� Awake �޼��� �����ϴٴ� ���� �� ��
     * �ִ�.
     * 
     * Update �޼����?
     * - �� �����Ӹ��� ȣ��Ǵ� �޼��带 �ǹ��ϸ� �ش� �޼��带 Ȱ���ϸ�
     * �ǽð����� ���°� ���ϴ� ��ü�� �����ϴ� ���� �����ϴ�. (��, Update
     * �޼���� Unity �� �����ϴ� �̺�Ʈ �޼��� �� ���� ȣ�� �󵵰� ���ٴ�
     * ���� �� �� �ִ�.
     * 
     * ����, Unity �� LateUpdate �޼��带 �����ϸ� �ش� �޼���� �ٸ� 
     * Game Object �� Update �޼��尡 ��� ȣ�� �� �� ȣ��Ǵ� Ư¡�� 
     * �����Ѵ�. (��, Ư�� Game Object �� ��� ���� ������ ���� �ش� ��ü�� 
     * �����ϰ� �ʹٸ� LateUpdate �޼��带 Ȱ���ϸ� �ȴ�.)
     */
    /** �ʱ�ȭ */
    public virtual void Awake()
    {
        // Do Something
    }

    /** �ʱ�ȭ */
    public virtual void Start()
    {
        // Do Something
    }

    /** ���¸� �����Ѵ� */
    public virtual void Reset()
    {
        // Do Something
    }

    /** ���� �Ǿ��� ��� */
    public virtual void OnDestroy()
    {
        // Do Something
    }
    #endregion // �Լ�
}
