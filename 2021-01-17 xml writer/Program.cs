using System;
using System.IO;
using System.Xml;

if (File.Exists("output.xml")) { File.Delete("output.xml"); }
using (var file = File.OpenWrite("output.xml"))
{
    var settings = new XmlWriterSettings
    {
        Indent = true
    };
    using (var writer = XmlWriter.Create(file, settings))
    {
        const string FICTION = "http://example.com/fiction";
        const string NONFICTION = "http://example.com/nonfiction";
        writer.WriteStartDocument();
        writer.WriteStartElement("library");
        {
            writer.WriteAttributeString("xmlns", "nf", null, NONFICTION);
            writer.WriteStartElement("books");
            {
                writer.WriteStartElement("book", FICTION);
                {
                    writer.WriteAttributeString("id", "1");
                    writer.WriteElementString("author", "John Doe");
                    writer.WriteElementString("title", "Adventures of Billy Bonka");
                    writer.WriteElementString("plot", "Billy's journey to avoid diabetes");
                    writer.WriteStartElement("contents");
                    {
                        writer.WriteCData("Once upon a time...");
                    }
                    writer.WriteEndElement(); // contents
                }
                writer.WriteEndElement(); // book

                writer.WriteStartElement("book", NONFICTION);
                {
                    writer.WriteAttributeString("id", "2");
                    writer.WriteElementString("author", "Jane Smith");
                    writer.WriteElementString("title", "How to Make a Grilled Cheese Sandwich");
                    writer.WriteElementString("category", "Cookbooks");
                    writer.WriteStartElement("contents");
                    {
                        writer.WriteCData("Start with lots of limburger...");
                    }
                    writer.WriteEndElement(); // contents
                }
                writer.WriteEndElement(); // book
            }
            writer.WriteEndElement(); // books
        }
        writer.WriteEndElement(); // library
    }
}

Console.WriteLine(File.ReadAllText("output.xml"));

/*
<?xml version="1.0" encoding="utf-8"?>
<library
    xmlns:nf="http://example.com/nonfiction">
    <books>
        <book id="1" xmlns="http://example.com/fiction">
            <author>John Doe</author>
            <title>Adventures of Billy Bonka</title>
            <plot>Billy's journey to avoid diabetes</plot>
            <contents><![CDATA[Once upon a time...]]></contents>
        </book>
        <nf:book id="2">
            <author>Jane Smith</author>
            <title>How to Make a Grilled Cheese Sandwich</title>
            <category>Cookbooks</category>
            <contents><![CDATA[Start with lots of limburger...]]></contents>
        </nf:book>
    </books>
</library>
*/