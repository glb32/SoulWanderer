using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharonDeathTrigger : MonoBehaviour
{
	public Transform prefab;
    void SummonCharon(Transform DeathPosition)
	{
		Instantiate(prefab, DeathPosition.position, Quaternion.identity);

	}
}
