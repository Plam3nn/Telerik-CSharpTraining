using Cosmetics.Core;
using Cosmetics.Core.Contracts;
using System.Collections.Generic;
using System.Text;

namespace Cosmetics
{
    public class Startup
    {
        static void Main()
        {
            IRepository repository = new Repository();
            ICommandFactory commandFactory = new CommandFactory(repository);
            IEngine cosmeticsEngine = new Engine(commandFactory);
            cosmeticsEngine.Start();
        }
    }
}
