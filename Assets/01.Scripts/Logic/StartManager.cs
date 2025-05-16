public class StartManager
{
    private event Void load;
    private event Void awake;
    private event Void start;

    public void Add(ILoad _loadScript) => load += _loadScript.OnLoad;
    public void Add(IAwake _awakeScript) => awake += _awakeScript.OnAwake;
    public void Add(IStart _startScript) => start += _startScript.OnStart;

    /// <summary>
    /// �����ֱ⿡ ��ϵ� ��� �޼��带 ȣ���ϴ� �޼���
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
