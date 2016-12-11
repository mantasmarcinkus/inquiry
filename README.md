### Questionnaire Project
Project backend (API). For future creation of the front end part. Will be used for rewriting and reworking with different technologies and frameworks.
Initial checkin and master branch should be written as follows:
Backend - .NET Core (WebAPI(REST), EF7(InMemory database))
Frontend - React, Redux, Typescript

http://localhost:3200/api/inquiry/get/{id}
{id} - inquiry id
Returns inquiry by id


http://localhost:3200/api/inquiry
Returns test inquiry


http://localhost:3200/api/response
{
	"recipientId":"{Guid}",
	"responseId":"{Guid}"
}
Post a response (recipientId;responseId) - can happen only once


http://localhost:3200/api/inquiry/{token}/recycle
{token} - administrator token
Deletes inquiries (which lifecycles already ended) and sends the results to the authors email


TO DO:
React, Redux, Typescript
Creating inquiries
Make EF7.InMemory static (so that it would work on instance of application, not class)
Make EF7 simple integration to database and test it (MSSQL Express)
Design basic administration panel
Generate tokens (DB, email to administrator, auth somehow)
