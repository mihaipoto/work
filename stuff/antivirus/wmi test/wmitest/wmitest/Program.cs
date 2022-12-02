using System;
using System.Management;



[assembly: CLSCompliant(true)]






internal class Program
{
    public ManagementScope Connect()
    {
        try
        {
            return new ManagementScope(@"root\ccm");
        }
        catch (System.Management.ManagementException e)
        {
            Console.WriteLine("Failed to connect", e.Message);
            throw;
        }
    }

    public static void CallMethod(ManagementScope scope)
    {
        try// Get the client's SMS_Client class.  
        {
            ManagementClass cls = new ManagementClass(@"Root\Microsoft\Windows\Defender:MSFT_MpScan");

            object[] argumente = new object[2];
            argumente[0] = 2;
            argumente[1] = @"D:\work";

            // Get current site code.  
            ManagementBaseObject outSiteParams = (ManagementBaseObject) cls.InvokeMethod("Start", argumente);

            // Display current site code.  
            Console.WriteLine(outSiteParams["sSiteCode"].ToString());

            // Set up current site code as input parameter for SetAssignedSite.  
            ManagementBaseObject inParams = cls.GetMethodParameters("SetAssignedSite");
            inParams["sSiteCode"] = outSiteParams["sSiteCode"].ToString();

            // Assign the Site code.  
            ManagementBaseObject outMPParams = cls.InvokeMethod("SetAssignedSite", inParams, null);
        }
        catch (ManagementException e)
        {
            throw new Exception("Failed to execute method", e);
        }
    }

    private static void Main(string[] args)
    {
#pragma warning disable CA1416

        const string WmiNamespace = @"Root\Microsoft\Windows\Defender";
        var scope = new ManagementScope(WmiNamespace);
        scope.Connect();
        CallMethod(scope);



        const string WmiRSClass =  @"Root\Microsoft\Windows\Defender:MSFT_MpComputerStatus";
        ManagementClass serverClass;
        

       


        // Connect to the Reporting Services namespace.  
         
        // Create the server class.  
        serverClass = new ManagementClass(WmiRSClass);
        // Connect to the management object.  
        serverClass.Get();
        if (serverClass == null)
            throw new Exception("No class found");

        // Loop through the instances of the server class.  
        ManagementObjectCollection instances = serverClass.GetInstances();

        foreach (ManagementObject instance in instances)
        {
            Console.Out.WriteLine("Instance Detected");
            PropertyDataCollection instProps = instance.Properties;
            foreach (PropertyData prop in instProps)
            {
                string name = prop.Name;
                object val = prop.Value;
                Console.Out.Write("Property Name: " + name);
                if (val != null)
                    Console.Out.WriteLine("     Value: " + val.ToString());
                else
                    Console.Out.WriteLine("     Value: <null>");
            }
        }
        Console.WriteLine("\n--- Press any key ---");
        Console.ReadKey();
    }



}

#pragma warning restore CA1416 // Validate platform compatibility

