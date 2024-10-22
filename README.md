# Tariff Comparison
Tariff Comparison demo project. A mockup for calculating the annual cost of several services based on the data gathered from different service providers  
  
## Dependencies  
.NET 8 Runtime or SDK is required to run the app. For installation instructions please refer to the following sources where you can download an installation script:  
> For Linux: https://learn.microsoft.com/en-us/dotnet/core/install/linux-scripted-manual#scripted-install  
> For Windows:  https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-install-script#examples  

  
## How to use  
1. Clone this Github repository:  
        https://github.com/georgggg/tariffcomparison.git  
2. Change directory into the './tariffcomparison' folder  
3. Run the following command to start the app:  
        dotnet run ./tariffcomparison.csproj  

The application will start and enable the following URLs on the host environment:  
        
        https://localhost:7054 & http://localhost:5026  

![image](https://github.com/user-attachments/assets/3d5901f0-9c9c-4d21-ac81-6f77cd4ff85b)


## Test  
Using any of the above URls you can call the service by appending "/Compare/" + the number of KWh consumed in a year as input:  
  
  I.e. http://localhost:5026/Compare/4000  

  ![image](https://github.com/user-attachments/assets/88993e71-e3e3-4009-a66f-05855b05ef0f)


If the input number is invalid then a 400 HTTP Response is returned:  

  ![image](https://github.com/user-attachments/assets/9ae0b408-3d81-4e79-a910-2b3ba0541d79)
