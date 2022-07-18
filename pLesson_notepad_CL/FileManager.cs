using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace pLesson_notepad_CL
{
    public interface IFileManager
    {
        string GetContent(string filePath);
        string GetContent(string filePath, Encoding encoding);
        void SaveContent(string filePath, string content);
        void SaveContent(string filePath, string content, Encoding encoding);
        void CreateFile(string filePath);
        void CreateFile(string filePath, Encoding encoding);
        int GetSymbolCount(string content);
        bool IsExist(string filePath);
    }
    public class FileManager : IFileManager
    {
        private readonly Encoding _defaultEncoding = Encoding.GetEncoding(1251);
        public string GetContent(string filePath)
        {
            return GetContent(filePath, _defaultEncoding);
        }
        public string GetContent(string filePath, Encoding encoding)
        {
            string content = File.ReadAllText(filePath, encoding);
            return content;
        }
        public void SaveContent(string filePath, string content)
        {
            SaveContent(filePath, content, _defaultEncoding);
        }
        public void SaveContent(string filePath, string content, Encoding encoding)
        {
            File.WriteAllText(filePath, content, encoding);
        }
        public int GetSymbolCount(string content)
        {
            return content.Length;
        }
        public bool IsExist(string filePath)
        {
            return File.Exists(filePath);
        }

        public void CreateFile(string filePath)
        {
            CreateFile(filePath, _defaultEncoding);
        }
        public void CreateFile(string filePath, Encoding encoding)
        {
            SaveContent(filePath, string.Empty, encoding);
        }
    }

}