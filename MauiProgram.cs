using Microsoft.Extensions.Logging;
using Wizardry.Data;
using Wizardry.Pages;

namespace Wizardry
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddDbContext<ContextDb>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<NewPerson>();

            builder.Services.AddScoped<IDataManager, DataManager>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
