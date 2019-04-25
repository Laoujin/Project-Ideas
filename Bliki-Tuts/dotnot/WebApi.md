
[HttpPut]
[Route("api/dossier/{id:int}")]
public IHttpActionResult Put([FromBody]Model model, int id)

CORS
----
Install-Package Microsoft.AspNet.WebApi.Cors

public static void Register(HttpConfiguration config) {
	var cors = new EnableCorsAttribute(origins: "*", headers: "*", methods: "*");
	config.EnableCors(cors);
}