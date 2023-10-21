#define E04_PHYSICS_01
#define E04_PHYSICS_02

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * ���� �����̶�?
 * - ���ǰ� ���� ��ü�� ��ȣ �ۿ��� ó�����ִ� ����� �ǹ��Ѵ�. (��, Unity ��
 * ���� ������ ž���ϰ� �ֱ� ������ �ش� ������ Ȱ���ϸ� ���ǿ� ����� ����
 * �ۿ��� �����ϰ� ó���ϴ� ���� �����ϴ�.)
 * 
 * Unity ���� ���� ����
 * - Box2D
 * - PhysicX
 * - Havok
 * 
 * Box2D ���� �����̶�?
 * - 2 ���� ��ü�� ���� ���� ��ȣ �ۿ��� ó�����ִ� ������ �ǹ��Ѵ�. (��, �ش�
 * ������ 2 ���� �����̶�� ���� �� �� �ִ�.)
 * 
 * PhysicX ���� �����̶�?
 * - 3 ���� ��ü�� ���� ���� ��ȣ �ۿ��� ó�����ִ� ������ �ǹ��Ѵ�. (��, �ش�
 * ������ Ȱ���ϸ� 2 ������ 3 ���� ��ü�� ��� ���� �ۿ��� ó���ϴ� ���� �����ϴ�.)
 * 
 * ��, 2 ���� ��ü�� PhysicX ���� ������ ����� ��� ���ʿ��� ������ �߻��ϱ�
 * ������ 2 ���� ������ ���� �� ��쿡�� Box2D ���� �������� ����ϴ� ����
 * ��õ�Ѵ�.
 * 
 * Unity ���� ���� ������Ʈ ����
 * - Collider
 * - Rigidbody
 * 
 * Collider ������Ʈ��?
 * - ���� ������ �ĺ��ϴ� ��ü�� ���¸� ��Ÿ���� ������Ʈ�� �ǹ��Ѵ�. (��, Unity
 * ���� ������ Collider ������Ʈ�� ������� ��ü�� ���¸� �ĺ��ϱ� ������ ����
 * ȭ�� ��µǴ� ��ü�� ���¿� ���� ������ �ν��ϴ� ��ü�� ���°� �ٸ� �� �ִ�.)
 * 
 * Collider ������Ʈ ����
 * - Box
 * - Sphere
 * - Capsule
 * - Mesh
 * 
 * ���� ���� Mesh Collider �� �����ϰ�� �ܼ��� ���¸� ���ϰ� �ִ� ���� �� ��
 * ������ �̴� ���� ������ ��ü�� ��ȣ �ۿ��� �����ϱ� ���� ���귮�� ���̱�
 * �����̶�� ���� �� �� �ִ�. (��, ��ü�� ���¸� �ܼ�ȭ ��Ŵ���� ���� ����
 * ó���� ������ ������ �� �ִٴ� ���� �� �� �ִ�.)
 * 
 * Rigidbody ������Ʈ��?
 * - ���� ������ ���ؼ� ���������� ��ȣ �ۿ� ���θ� ó���ϴ� ������Ʈ�� �ǹ��Ѵ�.
 * (��, Unity �� �� ��ġ �� ���� ��ü�� Rigidbody ������Ʈ�� ���ϰ� �ִٸ�
 * ���� ������ ���� ���� ������ ó�� �ȴٴ� ���� �� �� �ִ�.)
 */
/** Example 4 */
public class CExample_04 : CSceneManager
{
	#region ����
	private float m_fShootPower = 0.0f;
	[SerializeField] private Image m_oPhysics01GaugeImg = null;
	[SerializeField] private Rigidbody m_oPhysics01Target = null;
	[SerializeField] private List<Rigidbody> m_oPhysics01ObstacleList = new List<Rigidbody>();
	#endregion // ����

	#region ������Ƽ
	public override string SceneName => KDefine.G_SCENE_N_EXAMPLE_04;
	#endregion // ������Ƽ

	#region �Լ�
	/** �ʱ�ȭ */
	public override void Awake()
	{
		base.Awake();

#if E04_PHYSICS_01
		this.SetupGravity(false);
#elif E04_PHYSICS_02

#endif
	}

	/** �߷� ���θ� �����Ѵ� */
	private void SetupGravity(bool a_bIsTrue)
	{
		m_oPhysics01Target.useGravity = a_bIsTrue;

		m_oPhysics01Target.constraints = a_bIsTrue ? 
			RigidbodyConstraints.None : RigidbodyConstraints.FreezeAll;

		for (int i = 0; i < m_oPhysics01ObstacleList.Count; ++i)
		{
			m_oPhysics01ObstacleList[i].useGravity = a_bIsTrue;

			m_oPhysics01ObstacleList[i].constraints = a_bIsTrue ?
				RigidbodyConstraints.None : RigidbodyConstraints.FreezeAll;
		}
	}

	/** ���¸� �����Ѵ� */
	public void Update()
	{
#if E04_PHYSICS_01
		// ȸ�� Ű�� ������ ���
		if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            float fDirection = Input.GetKey(KeyCode.UpArrow) ? 1.0f : -1.0f;
			var stAngle = new Vector3(0.0f, 0.0f, 90.0f * fDirection * Time.deltaTime);

			var stFinalAngle = m_oPhysics01Target.transform.localEulerAngles + stAngle;
			stFinalAngle.z = Mathf.Clamp(stFinalAngle.z, 0.0f, 80.0f);

			m_oPhysics01Target.transform.localEulerAngles = stFinalAngle;
        }

		// �߻� Ű�� ������ ���
		if (Input.GetKey(KeyCode.Space))
		{
			m_fShootPower = Mathf.Clamp01(m_fShootPower + Time.deltaTime);
		}
		// �߻� Ű �Է��� ���� �Ǿ��� ���
		else if (Input.GetKeyUp(KeyCode.Space))
		{
			this.SetupGravity(true);
			float fPower = 2000.0f * m_fShootPower;

			var stPos = m_oPhysics01Target.transform.position + (Vector3.up * 15.0f);
			var stDirection = m_oPhysics01Target.transform.right;
			
			m_oPhysics01Target.AddForceAtPosition(stDirection * fPower, 
				stPos, ForceMode.VelocityChange);
		}

		this.UpdateUIsState();
#elif E04_PHYSICS_02

#endif
    }

	/** UI ���¸� �����Ѵ� */
	private void UpdateUIsState()
    {
		float fPosX = m_oPhysics01GaugeImg.rectTransform.sizeDelta.x * m_fShootPower;
		m_oPhysics01GaugeImg.rectTransform.anchoredPosition = new Vector2(fPosX, 0.0f);
    }
#endregion // �Լ�
}
