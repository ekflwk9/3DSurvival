public class LifeCycle
{
    private event Void load;
    private event Void awake;
    private event Void start;
    private event Void end;

    public void Add<T>(T _component) where T : class
    {
        if (_component is ILoad loadScript) load += loadScript.OnLoad;
        else if (_component is IAwake awakeScript) awake += awakeScript.OnAwake;
        else if (_component is IStart startScript) start += startScript.OnStart;
        if (_component is IEnd endScript) end += endScript.OnEnd;
    }

    /// <summary>
    /// 커스텀 생명주기에 등록된 모든 메서드를 호출하는 메서드
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

    /// <summary>
    /// 씬을 전활할때 한번 호출
    /// </summary>
    public void OnEndEvent()
    {
        end?.Invoke();
        end = null;
    }
}