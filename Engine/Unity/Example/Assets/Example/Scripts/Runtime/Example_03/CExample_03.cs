using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Example 3 */
public class CExample_03 : CSceneManager
{
	#region ����
	[SerializeField] private Light m_oLight = null;
	#endregion // ����

	#region ������Ƽ
	public override string SceneName => KDefine.G_SCENE_N_EXAMPLE_03;
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
		// ��/�� ���� Ű�� ������ ���
		if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
		{
			float fDirection = Input.GetKey(KeyCode.LeftArrow) ? 
				-1.0f : 1.0f;

			/*
			 * Unity ��ü ȸ�� ǥ�� ���
			 * - ���Ϸ� ȸ��
			 * - ����� ȸ��
			 * 
			 * ���Ϸ� ȸ���̶�?
			 * - ��ü�� �� ���� ���͸� ȸ���ϴ� 3 ���� ���� ���ļ� ����������
			 * ��ü�� ȸ�� ������ ǥ���ϴ� ����� �ǹ��Ѵ�.
			 * 
			 * ����, ���Ϸ� ȸ���� ��ü�� �ܼ��� ȸ���� ǥ���ϴµ� �����ϸ�
			 * ��ü�� ȸ�� ���� ������ ���� ���������� ���� ������ �ʿ��ϴ�.
			 * 
			 * �̴� ���Ϸ� ȸ���� �� �࿡ ���� ȸ���� ����� ���� ǥ���ϱ� ������
			 * ��Ŀ� Ư¡ �� ���� ������ ���� ��� ���� �޶����� �����̴�.
			 * 
			 * ����, ���Ϸ� ȸ���� ��ü�� ȸ�� ���¸� ǥ���ϱ� ���ؼ� �׻� 
			 * Y (Yaw), X (Pitch), Z (Roll) ������ �� ���� ȸ�� ���� �����Ѵٴ� 
			 * ���� �� �� �ִ�.
			 * 
			 * ����� ȸ���̶�?
			 * - ��ü�� ȸ�� ���¸� ��Ÿ���� ���ؼ� ȸ���� �Ǵ� ��� ������ ���ļ�
			 * 4 ���� �������� ��ü�� ȸ�� ������ ǥ���ϴ� ����� �ǹ��Ѵ�.
			 * 
			 * ����, ����� ȸ���� ���Ϸ� ȸ���� ���� ���� �������� ��ü�� ȸ����
			 * ǥ�� �� �� �ֱ� ������ Unity �� ����� ���� ���� �������� �⺻������
			 * �����ϴ� ����̴�.
			 * 
			 * ����, ������� ���Ϸ� ȸ���� ���� ���� ������ �������� �ʱ� ������
			 * ������ ��ü�� ȸ�� ������ ���� �����ϰ� ǥ���ϴ� ���� �����ϴ�.
			 */
			m_oLight.transform.Rotate(Vector3.up, 
				90.0f * fDirection * Time.deltaTime, Space.World);
		}
	}
	#endregion // �Լ�
}
