namespace Lion.AbpSuite.Files;

public class DefaultFileLoader : AbpSuiteDomainService, IFileLoader
{
    private readonly IVirtualFileProvider _virtualFileProvider;

    public DefaultFileLoader(IVirtualFileProvider virtualFileProvider)
    {
        _virtualFileProvider = virtualFileProvider;
    }

    public async Task<string> LoadAsync(string sqlPath)
    {
        return await _virtualFileProvider.GetFileInfo(sqlPath).ReadAsStringAsync();
    }
}