using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using TrueOrFalse.StatementNS.Model;

namespace TrueOrFalse.StatementNS.Repository
{
    class StatementXmlFileRepository
    {
        public string FilePath { get; }
        public IList<Statement> Statements { get; private set; }

        public StatementXmlFileRepository(string filePath)
        {
            FilePath = filePath;
            Statements = new List<Statement>();
        }

        public void Add(Statement statement)
        {
            Statements.Add(statement);
        }

        public void Remove(int index)
        {
            Statements.RemoveAt(index);
        }

        public Statement this[int index] => Statements[index];

        public void Save()
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Statement>));
            Stream fileStream = new FileStream(FilePath, FileMode.Create, FileAccess.Write);
            xmlFormat.Serialize(fileStream, Statements);
            fileStream.Close();
        }

        public void Load()
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Statement>));
            Stream fileStream = new FileStream(FilePath, FileMode.Open, FileAccess.Read);
            Statements = (List<Statement>)xmlFormat.Deserialize(fileStream);
            fileStream.Close();
        }

        public int Count => Statements.Count;


    }
}
