using System.Management;
using System.Text;

namespace SystemInfo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder processorInfo = new StringBuilder(string.Empty);
            ManagementClass mgmntClass = new ManagementClass("Win32_OperatingSystem");
            ManagementObjectCollection mgmntObj = mgmntClass.GetInstances();
            PropertyDataCollection properties = mgmntClass.Properties;
            foreach (ManagementObject obj in mgmntObj)
            {
                foreach (PropertyData property in properties)
                {
                    try
                    {
                        processorInfo.AppendLine(property.Name + ":  " +
                            obj.Properties[property.Name].Value.ToString());
                    }
                    catch
                    {
                    }
                }
                processorInfo.AppendLine();
            }
            Console.WriteLine(processorInfo);
            Console.ReadKey();
        }
    }
}