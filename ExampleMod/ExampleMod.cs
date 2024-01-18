using Railloader;
using Serilog;
using UI.Builder;

namespace ExampleMod
{
    public class ExampleMod : PluginBase, IUpdateHandler, IModTabHandler
    {
        ILogger logger = Log.ForContext<ExampleMod>();

        static ExampleMod()
        {
            Log.Information("Hello! Static Constructor was called!");
        }

        public ExampleMod(IModdingContext moddingContext, IModDefinition self)
        {
            logger.Information("Hello! Constructor was called for {modId}/{modVersion}!", self.Id, self.Version);

            moddingContext.RegisterConsoleCommand(new EchoCommand());
        }

        public override void OnEnable()
        {
            logger.Information("OnEnable() was called!");
        }

        public void Update()
        {
            logger.Verbose("UPDATE()");
        }

        public void ModTabDidOpen(UIPanelBuilder builder)
        {
            logger.Information("Daytime!");
            builder.AddLabel("Hello World!");
        }

        public void ModTabDidClose()
        {
            logger.Information("Nighttime...");
        }
    }
}
