using System;
using System.Xml;
using System.Xml.Serialization;

var foo = new Foo { Name = "John Doe", Age = 34 };

var settings = new XmlWriterSettings
{
    Indent = true,
    OmitXmlDeclaration = true
};
var ns = new XmlSerializerNamespaces();
ns.Add("", "");

using var writer = XmlWriter.Create(Console.Out, settings);
new XmlSerializer(typeof(Foo)).Serialize(writer, foo, ns);

