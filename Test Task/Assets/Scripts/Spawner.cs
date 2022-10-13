using UnityEngine;

public class Spawner : MonoBehaviour
{
	#region Fields
	[SerializeField]
	GameObject spawnObj;
	[SerializeField]
	float spawnTime = 1f, speed = 10f, distance = 5f;

	float timer = 0f;
	#endregion

	#region Properties
	public float SpawnTime
	{
		get => spawnTime;
		set
		{
			if (value >= 0.01f)
			{
				spawnTime = value;
			}
			else
			{
				spawnTime = 1f;
				Debug.LogWarning("wrong spawn time value, setting spawn time to 1");
			}
			timer = 0;
		}
	}
	public float Speed
	{
		get => speed;
		set
		{
			if (value >= 0.01f && value < 10000)
			{
				speed = value;
			}
			else
			{
				speed = 10f;
				Debug.LogWarning("wrong speed value, setting speed to 10");
			}
		}
	}
	public float Distance
	{
		get => distance;
		set
		{
			if (value > 0 && value < 1000)
			{
				distance = value;
			}
			else
			{
				distance = 10f;
				Debug.LogWarning("wrong distance value, setting distance to 10");
			}
		}
	}
	#endregion

	#region Methods
	private void Update()
	{
		timer += Time.deltaTime;
		if (timer >= spawnTime)
		{
			GameObject temp = Instantiate(spawnObj, transform.position, Quaternion.identity);
			MovingObj tempMove;
			if (!temp.TryGetComponent<MovingObj>(out tempMove))
			{
				tempMove = temp.AddComponent<MovingObj>();
			}
			tempMove.Initilize(speed, transform.forward);
			Destroy(temp, distance / speed);
			timer = 0f;
		}
	}
	#endregion
}
