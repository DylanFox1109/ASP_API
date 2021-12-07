# ASP_API Backend RESTful application.  #
Author : Dylan Fox

<p>Executable is located at "./executable/ASP_API.exe"<br>
<i>port can be changed in the file "./executable/appsettings.json" on line 5 (default 7183)</i>
</p>
<p>Source Code is located at "./source/..." <br>
	<i>created with Visual Studio Community Edition 2022</i>
</p>
<hr><br>
Application exposes the following functionality.<br><br>
GET Request /api/supervisors<br>
<table>
  <tr>
    <td>https://localhost:7183/api/supervisors</td>
  </tr>	
</table>
<br>
POST Request /api/submit<br>
<table>
  <tr>
    <td>curl -X POST https://localhost:7183/api/submit -H "Content-Type:application/json" -d "{\"firstName\":\"John\",\"lastName\":\"Doe\",\"supervisor\":\"Danny\"}"</td>
  </tr>	
  <tr>
    <td>curl -X POST https://localhost:7183/api/submit -H "Content-Type:application/json" -d "{\"firstName\":\"John\",\"lastName\":\"Doe\",\"supervisor\":\"Danny\",\"phoneNumber\":\"111-111-1111\"}"</td>
  </tr>	
  <tr>
    <td>curl -X POST https://localhost:7183/api/submit -H "Content-Type:application/json" -d "{\"firstName\":\"John\",\"lastName\":\"Doe\",\"supervisor\":\"Danny\",\"email\":\"johndoe@email.com\",\"phoneNumber\":\"111-111-1111\"}"</td>
  </tr>		
	
	
