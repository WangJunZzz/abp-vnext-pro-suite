namespace Lion.AbpSuite.Files;

public class FileHelper : ISingletonDependency
{
    /// <summary>
    /// 创建文件夹
    /// </summary>
    /// <param name="path"></param>
    public void CreateDirectory(string path)
    {
        Check.NotNullOrWhiteSpace(path, nameof(path));
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
    }

    /// <summary>
    /// 创建文件夹
    /// </summary>
    public void DeleteDirectory(string path)
    {
        Check.NotNullOrWhiteSpace(path, nameof(path));
        if (Directory.Exists(path))
        {
            Directory.Delete(path, true);
        }
    }

    /// <summary>
    /// 创建文件
    /// </summary>
    public void DeleteFile(string path)
    {
        Check.NotNullOrWhiteSpace(path, nameof(path));
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }

    /// <summary>
    /// 创建文件
    /// </summary>
    public async Task CreateFileAsync(string path, string content)
    {
        Check.NotNullOrWhiteSpace(path, nameof(path));
        if (!File.Exists(path))
        {
            using (var fs = File.Open(path, FileMode.Create, FileAccess.ReadWrite))
            {
                await fs.WriteAsync(Encoding.UTF8.GetBytes(content));
            }
        }
    }
}