using System;

namespace Project_Hindenburg
{
#if WINDOWS || LINUX
   
    public static class Program
    {
    
        [STAThread]
        static void Main()
        {
            using (var game = new DesertEagle())
                game.Run();
           
        }
    }
#endif
}
