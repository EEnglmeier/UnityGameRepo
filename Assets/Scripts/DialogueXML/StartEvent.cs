using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;


[XmlRoot("startEvent")]
public class StartEvent {
	
	[XmlElement("question")]
	public Question[] questions{ get; set; }

	public static StartEvent Load(string path)
	{
		var serializer = new XmlSerializer(typeof(StartEvent));
		using(var stream = new FileStream(path, FileMode.Open))
		{
			return serializer.Deserialize(stream) as StartEvent;
		}
	}
}

public class Question
{
	[XmlAttribute("id")]
	public int id { get; set; }

	[XmlElement("text")]
	public string text { get; set; }

	[XmlElement("response")]
	public Response[] responses { get; set; }
}

public class Response
{
	[XmlAttribute("triggerId")]
	public int nextQuestion { get; set; }

	[XmlElement("text")]
	public string text { get; set; }
}

