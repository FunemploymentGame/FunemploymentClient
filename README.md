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
![APIendpoints]()

An example to get one by specific ID
![get1byID]()

## Database Schema
Overall Data Schema
![overall]()
Data Schema for frontend 
![frontData]()
Data Schema for API
![apiData]()


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
![landing]()
![newUser]()
![profPage]()
![BehavQ]()
![TechQ]()
![SingleA]()


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
