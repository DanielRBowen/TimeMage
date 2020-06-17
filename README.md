# TimeMage
A Blazor PWA which has Timers, a Stopwatche, and Interval Timers.

I made this to learn Blazor and make a multiple timer application and interval timer to do High-Intensity Interval Training (HIIT) workouts 
without having to pay $5 for an interval timer app or see ads on a multiple timer app. The app works well on Edge on a Windows machine but
doesn't work so well on a Safari PWA on my iPhone 6s. Please fork it and do a pull request if you know how to make it look nicer and perform better.

This project uses [Azure Cognitive Speech Services](https://docs.microsoft.com/en-us/azure/cognitive-services/speech-service/)
which you can see a quick start [here](https://docs.microsoft.com/en-us/azure/cognitive-services/speech-service/text-to-speech-basics?tabs=import&pivots=programming-language-csharp).

I stored the subscription key and region as [user-secrets](https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-3.1&tabs=windows).
I placed them in appsettings.json when publishing to Azure.

## [Demo](https://timemage.azurewebsites.net/)


