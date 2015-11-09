namespace Kong.Plugins
{
    public interface IPluginSchemaRequestFactory
    {
        dynamic Get(string name);
    }
}
