using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

[ServiceContract]
public class UploadService
{
    [WebInvoke(Method = "POST", UriTemplate = "Upload")]
    public void UploadFile(Stream stream)
    {
        // Intentionally do nothing
    }
}
