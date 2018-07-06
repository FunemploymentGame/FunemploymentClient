# Funemployment
Deployed using Azure:
[Funemployment](http://funemployment.azurewebsites.net/)

## Introduction
Looking for a job can be strenuous and the impact of the preparation is rarely felt 
immediately. "Funemployement, the Game" creates scoring incentives for interview prepping 
where the user can measure their progress against other unemployed users. 
 
No longer will it feel like pulling teeth to update resumes or reviewing interview questions. 

This product encourages it's users to stay active in their job hunt while having fun!

## Page Preview
Enter Screenshots of what our project looks like
![documentation](https://i.pinimg.com/736x/5e/db/29/5edb2981ac2f117f5516c8dc57b5520b.jpg) 

## API
Deployed using Azure: [Funemployment API](http://funemploymentapi.azurewebsites.net)

For an interactive OpenAPI documentation, please visit [here](http://funemploymentapi.azurewebsites.net/swagger/index.html)

Our Interview Question API is custom made by the Funemployment team.

Here is all of our endpoints.
![APIendpoints](https://github.com/FunemploymentGame/FunemploymentClient/blob/readme/Funemployment/Funemployment/wwwroot/readme_assets/swagger_endpoints.PNG)

An example to get one by specific ID
![get1byID](https://github.com/FunemploymentGame/FunemploymentClient/blob/readme/Funemployment/Funemployment/wwwroot/readme_assets/getbyidExample.PNG)

## Database Schema
Overall Data Schema
![overall](https://github.com/FunemploymentGame/FunemploymentClient/blob/readme/Funemployment/Funemployment/wwwroot/readme_assets/overallDataSchema.PNG)
Data Schema for frontend 
![frontData](https://github.com/FunemploymentGame/FunemploymentClient/blob/readme/Funemployment/Funemployment/wwwroot/readme_assets/frontendDataSchema.PNG)
Data Schema for API
![apiData](https://github.com/FunemploymentGame/FunemploymentClient/blob/readme/Funemployment/Funemployment/wwwroot/readme_assets/apiDataSchema.PNG)


## Database Schema Explanation
Front-end Data Schema
* PlayerTable holds information about each player. 
* AnswerTable holds information about each answer submitted
  * PID refers to the ID of PlayerTable
  * BQID refers to the ID of BehaviorQuestions
  * TQID refers to the ID of TechnicalQuestions

API Data Schema
* BehaviorQuestions hold information about each behavioral interview questions
* TechnicalQuestions hold information about each technical interview questions

## Wire Frames
![landing](https://github.com/FunemploymentGame/FunemploymentClient/blob/readme/Funemployment/Funemployment/wwwroot/WireFrames/Funemployment-LandingPage.jpg)
![newUser](https://github.com/FunemploymentGame/FunemploymentClient/blob/readme/Funemployment/Funemployment/wwwroot/WireFrames/Funemployment-NewUserForm.jpg)
![profPage](https://github.com/FunemploymentGame/FunemploymentClient/blob/readme/Funemployment/Funemployment/wwwroot/WireFrames/Funemployment-ProfilePage.jpg)
![BehavQ](https://github.com/FunemploymentGame/FunemploymentClient/blob/readme/Funemployment/Funemployment/wwwroot/WireFrames/Funemployment-BehavioralQList.jpg)
![TechQ](https://github.com/FunemploymentGame/FunemploymentClient/blob/readme/Funemployment/Funemployment/wwwroot/WireFrames/Funemployment-TechnicalQList.jpg)
![SingleA](https://github.com/FunemploymentGame/FunemploymentClient/blob/readme/Funemployment/Funemployment/wwwroot/WireFrames/Funemployment-SingleQPage.jpg)


## Tools Used
* Visual Studio
* Visual Studio Team Services
* Swagger
* Azure

## Contributors
* Jermaine Walker
* Mario Nishio
* Max Suman
* Anthony Green
