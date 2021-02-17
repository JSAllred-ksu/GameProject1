using System;

namespace PhysicsExampleB
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new PhysicsExampleBGame())
                game.Run();
        }
    }
}
