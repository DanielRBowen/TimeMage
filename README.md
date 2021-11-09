# TimeMage
A Blazor PWA which has Timers, a Stopwatch, and Interval Timers.

I made this to learn Blazor and make a multiple timer application and interval timer to do High-Intensity Interval Training (HIIT) workouts 
without having to pay $5 for an interval timer app or see ads on a multiple timer app.

You will need [.Net 6](https://dotnet.microsoft.com/download/dotnet/6.0) installed for this project. And the latest [Visual Studio 2022 Preview](https://visualstudio.microsoft.com/vs/preview/)

This project uses [Azure Cognitive Speech Services](https://docs.microsoft.com/en-us/azure/cognitive-services/speech-service/)
which you can see a quick start [here](https://docs.microsoft.com/en-us/azure/cognitive-services/speech-service/text-to-speech-basics?tabs=import&pivots=programming-language-csharp).

I stored the subscription key and region of the Azure Cognitive Speech Services as [user-secrets](https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-6.0&tabs=windows).
I placed them in appsettings.json when publishing to Azure.

Also, uses [BlazorAudioPlayer](https://github.com/soend/BlazorAudioPlayer)
You will need to install [node.js](https://nodejs.org/en/download/) and then in a cli (ctrl + ` to open in Visual Studio) navigate to the BlazorAudioPlayer and to run "npm install" before running the TimeMage.Server as startup project.

This uses [BlazorStrap](https://github.com/chanan/BlazorStrap) for modals.

Uses [NoSleep.js](https://richtr.github.io/NoSleep.js/) to make it so the display will not turn off when running an IntervalSet on a mobile device. 

It uses [DistributedCache](https://docs.microsoft.com/en-us/aspnet/core/performance/caching/distributed?view=aspnetcore-5.0) for caching the audio blob on the server and [Blazored.LocalStorage](https://github.com/blazored/LocalStorage) for caching on the client.

Preloaded IntervalSets are from [ATHLEAN-X™](https://www.youtube.com/user/JDCav24)

## [Demo](https://timemage.azurewebsites.net/)
