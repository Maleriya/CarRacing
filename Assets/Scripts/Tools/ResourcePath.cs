using System;

namespace Tools
{
    internal class ResourcePath
    {
        public string Path;

        public ResourcePath(string path)
        {
            _ = path ?? throw new Exception("Для загрузки путь не может быть пустым");
            Path = path;
        }
    }
}
