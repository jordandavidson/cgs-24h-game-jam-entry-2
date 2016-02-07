using UnityEngine;

public class TimerTickEventArgs : System.EventArgs
{
    public int Ticks { get; set; }
    public float DeltaTime { get; set; }
}

public class Timer : MonoBehaviour {

    public float gameTime;

    private float sec;
    private int min;

    public event System.EventHandler<TimerTickEventArgs> OnTimerTick;
    
    private TimerTickEventArgs m_EventArgs = null;

    [SerializeField]
    private float m_TickPeriod = 1.0f;
    public float TickPeriod { get { return m_TickPeriod; } private set { m_TickPeriod = value; } }

    [SerializeField]
    private bool m_Repeating = true;
    public bool Repeating { get { return m_Repeating; } private set { m_Repeating = value; } }

    private bool m_TimerEnabled = false;
    public bool TimerEnabled { get { return m_TimerEnabled; } private set { m_TimerEnabled = value; } }

    public void StartTimer(float TickPeriod, bool Repeating)
    {
        this.TickPeriod = TickPeriod;
        this.Repeating = Repeating;

        TimerEnabled = true;

        m_EventArgs = new TimerTickEventArgs();
    }

    public void StartTimer(float TickPeriod)
    {
        StartTimer(TickPeriod, Repeating);
    }

    public void StartTimer()
    {
        StartTimer(TickPeriod);
    }

    public void StopTimer()
    {
        TimerEnabled = false;
        m_EventArgs = new TimerTickEventArgs();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!TimerEnabled)
            return;
        m_EventArgs.DeltaTime += Time.deltaTime;

        if (m_EventArgs.DeltaTime >= TickPeriod)
        {
            ++m_EventArgs.Ticks;
            gameTime++;

            if (OnTimerTick != null)
            {
                TimerTickEventArgs CurEventArgs = m_EventArgs;
                OnTimerTick((object)this, CurEventArgs);
            }

            m_EventArgs.DeltaTime = 0.0f;
        }
    }
}
