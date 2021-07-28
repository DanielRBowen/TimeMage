# TimeMage
A Blazor PWA which has Timers, a Stopwatch, and Interval Timers.

I made this to learn Blazor and make a multiple timer application and interval timer to do High-Intensity Interval Training (HIIT) workouts 
without having to pay $5 for an interval timer app or see ads on a multiple timer app.

This project uses [Azure Cognitive Speech Services](https://docs.microsoft.com/en-us/azure/cognitive-services/speech-service/)
which you can see a quick start [here](https://docs.microsoft.com/en-us/azure/cognitive-services/speech-service/text-to-speech-basics?tabs=import&pivots=programming-language-csharp).

Also, uses [BlazorAudioPlayer](https://github.com/soend/BlazorAudioPlayer)
You will need to install [node.js](https://nodejs.org/en/download/) and then in a cli (ctrl + ` to open in Visual Studio) navigate to the BlazorAudioPlayer and to run "npm install" before running the TimeMage.Server as startup project.

I stored the subscription key and region of the Azure Cognitive Speech Services as [user-secrets](https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-6.0&tabs=windows).
I placed them in appsettings.json when publishing to Azure.

## [Demo](https://timemage.azurewebsites.net/)