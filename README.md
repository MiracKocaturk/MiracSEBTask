# MiracSEBTask

<b>Notes About the Application</b> <br />
This Web API application has been developed with .NET 6.0 Core. The code has been developed in a way that it can be extensible and not only the web apis for Customer information but other information also can be added in the future. Models, controllers and repositories are seperated from each other where business logic related actions are seperated also. Besides that for the data confidentiality, the whole model itself is not exposed to web APIs. Instead Dtos used for that purpose. Some of the Dtos even seperated by name has the exact same fields and attributes, so it can seem to be redundant but it is good practice for the future.<br />

Repository of this project consists from a list of customers that is being created at run time. To have the dependency injection throughout the session i have implemented the repository as an interface and used the interface as the backbone of the repository. (Where it enables you to create a customer and query them afterwards in the same session)

Also there are some steps for validating the customer information where the validation rules are follows;<br />
1. Social Security Number can not be null.
2. If Social Security Number is not null it should be either 9 or 12 digits. (For simplicity we are not checking for a proper Swedish SSN, but there are some open source validation for Swedish SSN that can be integrated)
3. If email address is not null it should contain "@" sign to be a proper email address. (Again For simplicity we are not checking for a proper email address)
4. If phone number is not null it should be either 9 or 12 digits and if it is 12 digits it should start with optional (+46)

Because of the fact that there are so many steps needed to be tested in validation side I have added unit tests to the code. The unit tests are named and constructed as Arrange-Act-Assert schema. 

In my local environment because of the fact that I am using Windows 11, I could not able to run Docker working for the project to be docker container ready for deployment. But I am going to give every step needs to be taken to run this project testable on IIS.

<b>STEPS FOR HOW TO BUILD AND RUN THE MICROSERVICE</b> <br />
1. Go to https://github.com/MiracKocaturk/MiracSEBTask. <br />
2. In the upper right hand corner under the Code menu download the code as zip to a desired folder. <br />
3. Open Visual Studio 2022. In the File menu, select open project and go to the folder you saved the zip file. <br /> 
4. Click MiracSEBTask.sln to open the solution.
5. Solution is ready to be tested in your local with Swagger by pressing Run the Project. The code will open a browser page and run on  https://localhost:7073/swagger/index.html

<b>To deploy the code to IIS</b>
1. Right Click the Project MiracSEBTask and click Publish.
2. Choose Publish to a folder and select a desired folder.
3. Before start deploying to IIS make sure that the server you want to deploy, has the ASP.NET Core 6.0 Runtime Windows Hosting Bundle. If not sure go to https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-aspnetcore-6.0.10-windows-hosting-bundle-installer and start the executable that is downloaded.
4. Open the IIS Manager
5. From the Left Pane Under Sites Add Web Site
6. In Site Name write the hostname of the server. If you do not know what the hostname of the server is you can open a command prompt and type hostname to get.
7. In Physical Path choose the folder that you have published in Step 2.
8. For the Port select 8080. If that port is being used then choose another port like 8081 or 8082. (If the code is intended to be run on HTTPS, we need to create a certificate and assign it to the website which we skipped here)
9. In hostname section write the hostname again and click ok.
10. The web api is deployed to the server you can open a browser and go "hostname":"port"/customers to get all the customers.
  
<b>WEB APIS CREATED FOR THE TASK</b><br />
Here are the list of web apis created for this task. 

GET /customers (Gets all the customers response is a list of RetrieveCustomerDto objects)<br />
GET /customers/{id} (Get the customer with the provided id response is a RetrieveCustomerDto object)<br />
POST /customers (Create the customer with a given CreateCustomerDto object)<br />
PUT /customers/{id} (Update the customer with the provided id and a given UpdateCustomerDto)   <br />
DELETE /customers/{id} (Delete the customer with the provided id)<br />
  
DtoTypes
CreateCustomerDto{<br />
socialSecurityNumber*	string<br />
emailAddress	string<br />
nullable: true<br />
phoneNumber	string<br />
nullable: true<br />
}<br />
  
RetrieveCustomerDto{<br />
id	string($uuid)<br />
socialSecurityNumber*	string<br />
emailAddress	string<br />
nullable: true<br />
phoneNumber	string<br />
nullable: true<br />
}<br />
  
UpdateCustomerDto{<br />
socialSecurityNumber*	string<br />
emailAddress	string<br />
nullable: true<br />
phoneNumber	string<br />
nullable: true<br />
}<br />
