using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductCatalogApplication.Controllers
{
    [Route("api/ProductImage")]
    public class ProductImageController : Controller
    {

        //public HttpResponseMessage Get(int id)
        //{
        //    var result = new HttpResponseMessage(HttpStatusCode.OK);
        //    String filePath = HostingEnvironment.("~/Images/HT.jpg");
        //    FileStream fileStream = new FileStream(filePath, FileMode.Open);
        //    Image image = Image.FromStream(fileStream);
        //    MemoryStream memoryStream = new MemoryStream();
        //    image.Save(memoryStream, ImageFormat.Jpeg);
        //    result.Content = new ByteArrayContent(memoryStream.ToArray());
        //    result.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");

        //    return result;
        //}

        //public HttpResponseMessage Post()
        //{
        //    var result = new HttpResponseMessage(HttpStatusCode.OK);
        //    if (Request.Content.IsMimeMultipartContent())
        //    {
        //        //For larger files, this might need to be added:
        //        //Request.Content.LoadIntoBufferAsync().Wait();
        //        Request.Content.ReadAsMultipartAsync<MultipartMemoryStreamProvider>(
        //                new MultipartMemoryStreamProvider()).ContinueWith((task) =>
        //                {
        //                    MultipartMemoryStreamProvider provider = task.Result;
        //                    foreach (HttpContent content in provider.Contents)
        //                    {
        //                        Stream stream = content.ReadAsStreamAsync().Result;
        //                        Image image = Image.FromStream(stream);
        //                        var testName = content.Headers.ContentDisposition.Name;
        //                        String filePath = HostingEnvironment.MapPath("~/Images/");
        //                        //Note that the ID is pushed to the request header,
        //                        //not the content header:
        //                        String[] headerValues = (String[])Request.Headers.GetValues("UniqueId");
        //                        String fileName = headerValues[0] + ".jpg";
        //                        String fullPath = Path.Combine(filePath, fileName);
        //                        image.Save(fullPath);
        //                    }
        //                });
        //        return result;
        //    }
        //    else
        //    {
        //        throw new HttpResponseException(Request.CreateResponse(
        //                HttpStatusCode.NotAcceptable,
        //                "This request is not properly formatted"));
        //    }
        //}

        //public void Delete(int id)
        //{
        //    String filePath = HostingEnvironment.MapPath("~/Images/HT.jpg");
        //    File.Delete(filePath);
        //}
    }
}