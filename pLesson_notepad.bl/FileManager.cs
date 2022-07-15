using System;
using System.IO;
using System.Text;

namespace pLesson_notepad.bl
{
    public class FileManager
    {
        private readonly Encoding _defaultEncoding = Encoding.GetEncoding(1251);
        public bool IsExist(string filePath)
        {
            return File.Exists(filePath);
        }
        public int GetSymbolCount(string content)
        {
            return content.Length;
        }
        public string GetContent(string filePath)
        {
            return GetContent(filePath, _defaultEncoding);
        }
        public string GetContent(string filePath, Encoding encoding)
        {
            string content = File.ReadAllText(filePath, encoding);
            return content;
        }
        public void SaveContent(string content, string filePath)
        {
            SaveContent(filePath, content, _defaultEncoding);
        }
        public void SaveContent(string content, string filePath, Encoding encoding)
        {
            File.WriteAllText(filePath, content, encoding);
        }

    }

}
