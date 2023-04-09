public class TViewManager : TypedStateMachine <TView>
{
    public static TViewManager Singleton { get; private set; }

    private void Awake()
    {
        Singleton = this;

        InitStates();
    }
}
