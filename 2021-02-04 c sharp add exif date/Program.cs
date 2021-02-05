using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Text;

string oldFile = args[0];
string newFile = args[1];
DateTime theDate = DateTime.Parse(args[2]);

using var image = Image.FromFile(oldFile);
foreach (int propertyID in new[] { 0x9003, 0x9004, 0x0132 })
{
    if (image.PropertyIdList.Contains(propertyID))
    {
        image.RemovePropertyItem(propertyID);
    }
    PropertyItem propertyItem;

    // No public constructor, but it's a simple data type, so we'll cheat and use reflection
    propertyItem = (PropertyItem)typeof(PropertyItem).Assembly.CreateInstance(typeof(PropertyItem).FullName,
        ignoreCase: false,
        bindingAttr: BindingFlags.Instance | BindingFlags.NonPublic,
        binder: null,
        args: null,
        culture: null,
        activationAttributes: null);

    propertyItem.Id = propertyID;
    propertyItem.Len = 20;
    propertyItem.Type = 2;
    Console.WriteLine("Creating new property");
    // }

    propertyItem.Value = Encoding.UTF8.GetBytes(theDate.ToString("yyyy\\:MM\\:dd HH\\:mm\\:ss") + "\0");
    image.SetPropertyItem(propertyItem);
}

image.Save(newFile, ImageFormat.Jpeg);
