#########################################
# ASP_API Backend RESTful application.  #
# Author : Dylan Fox                    #
#########################################
Executable is located at "./executable/ASP_API.exe"
	* port can be changed in the file "./executable/appsettings.json" on line 5
Source Code is located at "./source/..."
	* Created with Visual Studio Community Edition 2022

Application exposes the following functionality.

GET Request /api/supervisors
	https://localhost:7158/api/supervisors

POST Request /api/submit
	curl -X POST https://localhost:7158/api/submit -H "Content-Type:application/json" -d "{\"firstName\":\"John\",\"lastName\":\"Doe\",\"supervisor\":\"Danny\"}"
	curl -X POST https://localhost:7183/api/submit -H "Content-Type:application/json" -d "{\"firstName\":\"John\",\"lastName\":\"Doe\",\"supervisor\":\"Danny\",\"phoneNumber\":\"111-111-1111\"}"
	curl -X POST https://localhost:7183/api/submit -H "Content-Type:application/json" -d "{\"firstName\":\"John\",\"lastName\":\"Doe\",\"supervisor\":\"Danny\",\"email\":\"johndoe@email.com\",\"phoneNumber\":\"111-111-1111\"}"
