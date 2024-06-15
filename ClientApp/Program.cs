
using ClientApp;
using System.Xml;
using System.Xml.Linq;

Console.WriteLine("Receive data from Server");

// This is a technical task for an interview.
// Range, port and multicast group  config

try
{
    string? path = Environment.CurrentDirectory;

    // Find the file in the local directories
    DirectoryInfo directory = new DirectoryInfo(path);
    DirectoryInfo? parentDirectory = directory.Parent;
    DirectoryInfo? projectDirectory = parentDirectory?.Parent;
    DirectoryInfo? xmlLocation = projectDirectory?.Parent;


    if (xmlLocation == null)
    {
        Console.WriteLine("Can't to find the XML location.");
        return;
    }

    XDocument document = XDocument.Load(Path.Combine(xmlLocation.FullName, "config.xml"));

    XElement? root = document.Root;
    if (root == null)
    {
        Console.WriteLine("Element not found in XML.");
        return;
    }

    string? multicastAddress = root.Element("multicastAddress")?.Value;

    if (!int.TryParse(root.Element("port")?.Value, out int port))
    {
        Console.WriteLine("Invalid port number.");
        return;
    }


    Client.Receiver(multicastAddress, port);


}
catch (IOException ex)
{
    Console.WriteLine($"IO Exception: {ex.Message}");
}
catch (XmlException ex)
{
    Console.WriteLine($"XML Exception: {ex.Message}");
}


