using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

    public Timer m_Timer;
    private Text text;

	// Use this for initialization
	void Start () {

        text = gameObject.GetComponent<Text>();
        m_Timer.OnTimerTick += m_Timer_OnTimerTick;
        m_Timer.StartTimer();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void m_Timer_OnTimerTick(object sender, TimerTickEventArgs e)
    {
        text.text = string.Format("{0}:{1}", (e.Ticks / 60).ToString("00"), (e.Ticks % 60).ToString("00"));
    }
}
