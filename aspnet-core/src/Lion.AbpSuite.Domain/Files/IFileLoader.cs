namespace Lion.AbpSuite.Files;

public interface IFileLoader
{
    Task<string> LoadAsync(string sqlPath);
}