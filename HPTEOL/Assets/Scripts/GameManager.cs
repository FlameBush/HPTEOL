using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] private GameObject menusCanvas;
	[SerializeField] private GameObject gameCanvas;

	private void Awake()
	{
		DontDestroyOnLoad(transform.gameObject);
	}

	private void Update()
	{
		if (menusCanvas.transform.GetChild(0).gameObject.activeSelf ||
			menusCanvas.transform.GetChild(1).gameObject.activeSelf)
		{
			gameCanvas.SetActive(false);
		}
		else
		{
			gameCanvas.SetActive(true);
		}
	}
}
