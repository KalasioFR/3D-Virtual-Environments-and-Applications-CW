using UnityEngine;

public class FPSDisplay : MonoBehaviour
{
	private readonly int fontSize = 16;
	private readonly float updatePeriod = 0.25f;
	private float fpsAverage = 0f;
	private float latencyAverage = 0f;
	private float lastUpdated = 0f;

	void Start()
	{
		#if UNITY_EDITOR
		Application.targetFrameRate = 60;
		#endif

		QualitySettings.vSyncCount = 1;
	}

	void Update()
	{
		if (Time.time - lastUpdated > updatePeriod)
		{
			float fps = 1f / Time.unscaledDeltaTime;
			fpsAverage = (fpsAverage + fps) / 2;

			float latency = Time.unscaledDeltaTime * 1000f;
			latencyAverage = (latencyAverage + latency) / 2;
			lastUpdated = Time.time;
		}
	}

	void OnGUI()
	{
		int w = Screen.width;
		int h = Screen.height;

        GUIStyle style = new()
        {
            alignment = TextAnchor.UpperLeft,
            fontSize = fontSize,
        };

        style.normal.textColor = Color.green;

		Rect rect = new(5, 5, w, h);

		string text = $"{fpsAverage:0.} FPS ({latencyAverage:0.0}ms)";

		GUI.Label(rect, text, style);
	}
}