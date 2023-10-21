#define E04_PHYSICS_01
#define E04_PHYSICS_02

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * 물리 엔진이란?
 * - 현실과 같은 물체의 상호 작용을 처리해주는 기능을 의미한다. (즉, Unity 는
 * 물리 엔진을 탑재하고 있기 때문에 해당 엔진을 활용하면 현실에 가까운 물리
 * 작용을 간단하게 처리하는 것이 가능하다.)
 * 
 * Unity 물리 엔진 종류
 * - Box2D
 * - PhysicX
 * - Havok
 * 
 * Box2D 물리 엔진이란?
 * - 2 차원 물체에 대한 물리 상호 작용을 처리해주는 엔진을 의미한다. (즉, 해당
 * 엔진은 2 차원 전용이라는 것을 알 수 있다.)
 * 
 * PhysicX 물리 엔진이란?
 * - 3 차원 물체에 대한 물리 상호 작용을 처리해주는 엔진을 의미한다. (즉, 해당
 * 엔진을 활용하면 2 차원과 3 차원 물체에 모두 물리 작용을 처리하는 것이 가능하다.)
 * 
 * 단, 2 차원 물체에 PhysicX 물리 엔진을 사용할 경우 불필요한 연산이 발생하기
 * 때문에 2 차원 게임을 개발 할 경우에는 Box2D 물리 엔진만을 사용하는 것을
 * 추천한다.
 * 
 * Unity 물리 관련 컴포넌트 종류
 * - Collider
 * - Rigidbody
 * 
 * Collider 컴포넌트란?
 * - 물리 엔진이 식별하는 물체의 형태를 나타내는 컴포넌트를 의미한다. (즉, Unity
 * 물리 엔진은 Collider 컴포넌트를 기반으로 물체의 형태를 식별하기 때문에 실제
 * 화면 출력되는 물체의 형태와 물리 엔진이 인식하는 물체의 형태가 다를 수 있다.)
 * 
 * Collider 컴포넌트 종류
 * - Box
 * - Sphere
 * - Capsule
 * - Mesh
 * 
 * 위와 같이 Mesh Collider 를 제외하고는 단순한 형태를 지니고 있는 것을 알 수
 * 있으며 이는 물리 엔진은 물체의 상호 작용을 연산하기 위한 연산량을 줄이기
 * 위함이라는 것을 알 수 있다. (즉, 물체의 형태를 단순화 시킴으로 물리 연산
 * 처리를 빠르게 수행할 수 있다는 것을 알 수 있다.)
 * 
 * Rigidbody 컴포넌트란?
 * - 물리 엔진에 의해서 실질적으로 상호 작용 여부를 처리하는 컴포넌트를 의미한다.
 * (즉, Unity 씬 상에 배치 된 게임 객체가 Rigidbody 컴포넌트를 지니고 있다면
 * 물리 엔진에 의해 물리 연산이 처리 된다는 것을 알 수 있다.)
 */
/** Example 4 */
public class CExample_04 : CSceneManager
{
	#region 변수
	private float m_fShootPower = 0.0f;
	[SerializeField] private Image m_oPhysics01GaugeImg = null;
	[SerializeField] private Rigidbody m_oPhysics01Target = null;
	[SerializeField] private List<Rigidbody> m_oPhysics01ObstacleList = new List<Rigidbody>();
	#endregion // 변수

	#region 프로퍼티
	public override string SceneName => KDefine.G_SCENE_N_EXAMPLE_04;
	#endregion // 프로퍼티

	#region 함수
	/** 초기화 */
	public override void Awake()
	{
		base.Awake();

#if E04_PHYSICS_01
		this.SetupGravity(false);
#elif E04_PHYSICS_02

#endif
	}

	/** 중력 여부를 변경한다 */
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

	/** 상태를 갱신한다 */
	public void Update()
	{
#if E04_PHYSICS_01
		// 회전 키를 눌렀을 경우
		if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            float fDirection = Input.GetKey(KeyCode.UpArrow) ? 1.0f : -1.0f;
			var stAngle = new Vector3(0.0f, 0.0f, 90.0f * fDirection * Time.deltaTime);

			var stFinalAngle = m_oPhysics01Target.transform.localEulerAngles + stAngle;
			stFinalAngle.z = Mathf.Clamp(stFinalAngle.z, 0.0f, 80.0f);

			m_oPhysics01Target.transform.localEulerAngles = stFinalAngle;
        }

		// 발사 키를 눌렀을 경우
		if (Input.GetKey(KeyCode.Space))
		{
			m_fShootPower = Mathf.Clamp01(m_fShootPower + Time.deltaTime);
		}
		// 발사 키 입력이 종료 되었을 경우
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

	/** UI 상태를 갱신한다 */
	private void UpdateUIsState()
    {
		float fPosX = m_oPhysics01GaugeImg.rectTransform.sizeDelta.x * m_fShootPower;
		m_oPhysics01GaugeImg.rectTransform.anchoredPosition = new Vector2(fPosX, 0.0f);
    }
#endregion // 함수
}
