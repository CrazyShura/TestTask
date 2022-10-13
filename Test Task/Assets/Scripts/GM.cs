using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GM : MonoBehaviour
{
	#region Fields
	[SerializeField]
	Spawner spawner;
	[SerializeField]
	GameObject settingsMenue;
	[SerializeField]
	TMP_InputField sD,speed,distance;
	[SerializeField]
	Scrollbar sDSlider, speedSlider, distanceSlider;
	#endregion

	#region Propreties

	#endregion

	#region Methods
	private void Start()
	{
		SlidersUpdated();
	}
	void SpawnerUpdate(float SpawnDelay, float Speed, float Distance)
	{
		spawner.SpawnTime = SpawnDelay;
		spawner.Speed = Speed;
		spawner.Distance = Distance;
		sD.text = spawner.SpawnTime.ToString();
		speed.text = spawner.Speed.ToString();
		distance.text = spawner.Distance.ToString();
	}

	public void ValuesUpdated()
	{
		SpawnerUpdate(float.Parse(sD.text), float.Parse(speed.text), float.Parse(distance.text));
		sDSlider.value = float.Parse(sD.text) / 10;
		speedSlider.value = float.Parse(speed.text) / 100;
		distanceSlider.value = float.Parse(distance.text) / 50;
	}
	public void SlidersUpdated()
	{
		if((sDSlider.value * 10) > 0.1f)
		{
			sD.text = (sDSlider.value * 10).ToString("F3");
		}
		else
		{
			sD.text = "0.1";
		}
		if((speedSlider.value * 100) > 0.1f)
		{
			speed.text = (speedSlider.value * 100).ToString("F3");
		}
		else
		{
			speed.text = "0.1";
		}
		if((distanceSlider.value * 50) > 0.1f)
		{
			distance.text = (distanceSlider.value * 50).ToString("F3");
		}
		else
		{
			distance.text = "0.1";
		}
		SpawnerUpdate(float.Parse(sD.text), float.Parse(speed.text), float.Parse(distance.text));
	}
	public void SettingsMenueUp()
	{
		if(settingsMenue.activeSelf)
		{
			settingsMenue.SetActive(false);
		}
		else
		{
			settingsMenue.SetActive(true);
		}
	}
	public void Quit()
	{
		Application.Quit();
	}
	#endregion
}
