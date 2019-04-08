
public class ContextFactory
{
    public MyDataContext BuildContext() => MyDataContextBuilder.BuildDataContext();
}