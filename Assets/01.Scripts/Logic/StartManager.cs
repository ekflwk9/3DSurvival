public class StartManager
{
    private event Void load;
    private event Void awake;
    private event Void start;

    public void Add(ILoad _loadScript) => load += _loadScript.OnLoad;
    public void Add(IAwake _awakeScript) => awake += _awakeScript.OnAwake;
    public void Add(IStart _startScript) => start += _startScript.OnStart;

    /// <summary>
    /// 생명주기에 등록된 모든 메서드를 호출하는 메서드
    /// </summary>
    public void OnEvent()
    {
        load?.Invoke();
        awake?.Invoke();
        start?.Invoke();

        load = null;
        awake = null;
        start = null;
    }
}
