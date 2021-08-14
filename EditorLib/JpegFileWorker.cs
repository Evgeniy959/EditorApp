using System;
using System.IO;

namespace EditorLib
{
    public class JpegFileWorker : IFileWorker
    {
        public Document Create()
        {
            return new JpegDocument();
        }

        public Document Open(string path)
        {
            using var file = File.OpenRead(path);
            var array = new byte[file.Length];
            file.Read(array, 0, array.Length);
            var content = System.Text.Encoding.Default.GetString(array);
            
            return new JpegDocument(path, content);
        }

        public void SaveAs(string path, Document document)
        {
            using var file = new FileStream(path, FileMode.OpenOrCreate);
            var array = System.Text.Encoding.Default.GetBytes(document.Content);
            file.Write(array, 0, array.Length);
        }

        public void Save(Document document)
        {
            SaveAs(document.Path, document);
        }
    }
}