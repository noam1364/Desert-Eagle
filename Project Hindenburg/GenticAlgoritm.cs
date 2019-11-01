using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using Project_Hindenburg;
using static Service;
using static Global;
public static class GeneticAlgorithm
{
    private static string outputUrl = "C://Workspaces//C# workspace//Project Hindenburg//Project Hindenburg//geneticModel//output.txt",
        modelUrl = "C://Workspaces//C# workspace//Project Hindenburg//Project Hindenburg//geneticModel//runModel2.py",
        pythonUrl = @"C://Users//USER//AppData//Local//Programs//Python//Python36//python.exe";
    private static Process p;
    public static void Initiate(string args = "")
    {
        ///launch the procces of the model in python
        p = new Process();
        p.StartInfo = new ProcessStartInfo(pythonUrl, @modelUrl+args)
        {
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };
        p.Start();
    }
    private static int[] getClosestRock()
    {
        int[] d = new int[2] { 2000,2000}; ///d[0] = dx | d[1] = dy
        int temp;
        foreach(Obsticle rock in rock)
        {
            temp = rock.X() - bird.X();
            if(temp < d[0] && temp > 0) ///if closest rock yet
            {
                d[0] = temp;
                d[1] = bird.YCenter() - rock.YCenter();
            }
        }
        return d;
    }
    public static bool feedModel()
    {
        ///get the bird data and feed it to the model through a txt file
        int[] arr = getClosestRock();
        string input = "["+arr[0]+","+arr[1]+"]";
        DataHandler.WriteToTxt<string>(outputUrl, input);
        ///recive the output from the model
        string output = "";
        while(output != "True" && output != "False")    ///wait for the model to return a result
            output = DataHandler.ReadFromText(outputUrl);
        if(output == "True") return true;
        else return false;
    }
}
