# BWAF (Basic WebAPI Framework - .NET 5)

This project wants to help WebAPI developers to make a project setup as fast and easy as posible. The project contains also some dummy data that is necesarry for end-to-end tests and serves as an example for users on how things are supposed to work.

For more information about what is already implemented or what is in the pipeline you can look [here](https://trello.com/b/t7llAWem/bwaf).

Added a new tool to easy development (Development Script):
This tool consists from 2 file:
  - Configuration.csv
  
| Configuration name | Old name | New name |
| ------- | ------- | ------- |
| API Name | BWAF-API | BWAF.Api |
| API Namespace | BWAF_API | BWAF.Api |
| Core Name |BWAF-Core | BWAF.Core |
| Core Namespace | BWAF_Core | BWAF.Core |
| Business Name | BWAF-Business | BWAF.Business |
| Business Namespace | BWAF_Business | BWAF.Business |
| Data Access Layer Name | BWAF-DAL | BWAF.Data |
| Data Access Layer Namespace | BWAF_DAL | BWAF.Data |
| Integration Name | BWAF-IntegrationTest | BWAF.Test |
| Integration Namespace | BWAF_IntegrationTest | BWAF.Test |
| Project Name | BWAF | BWAF |

Before starting development on your own project, you need to update the New name column with the name that you want for your new project.
E.g. You can have different names for your files and namespaces. You can choose for API files: YOUR.PROJECT.API and for your namespaces YOUR.NAMESPACE.API
The project name is for renaming the .sln with the new project name.

  - RenameApplication.exe
  This is a single file console application that will load the configuration, will parse the application and will rename the content, files and folders. After you run this application you should be all good to start development.

For anything related to this project you can drop me a message at: __alexandru[at]oprean.net__
