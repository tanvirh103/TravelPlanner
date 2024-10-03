using BLL.DTOs;
using BLL.Services;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace TravelPlanner.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("Trip")]
    public class TripController : ApiController
    {
        [HttpPost]
        [Route("Create")]
        public HttpResponseMessage Create(TripDTO t) {
            try
            {
                var data = TripService.Create(t);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex) {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Trip/Create" });
            }
        }
        [HttpPost]
        [Route("Update")]
        public HttpResponseMessage Update(TripDTO t) {
            try
            {
                var data = TripService.Update(t);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex) {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Trip/Update" });
            }
        }
        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage Get(int id) {
            try
            {
                var data = TripService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex) {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Trip/Get" });
            }
        }
        [HttpGet]
        [Route("Delete/{id}")]
        public HttpResponseMessage Delete(int id) {
            try
            {
                var data = TripService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Delete Done" });
            }
            catch (Exception ex) {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Trip/Delete" });
            }
        }
        [HttpGet]
        [Route("GetAll")]
        public HttpResponseMessage GetAll() {
            try
            {
                var data = TripService.GetAll();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex) {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Trip/GetAll" });
            }
        }
        [HttpGet]
        [Route("pdf/{id}")]
        public HttpResponseMessage GetPdf(int id) {
            try
            {
                var data = TripService.Get(id);
                if (data == null)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "No trip data found" });
                }
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    Document pdfDoc = new Document(PageSize.A4, 25, 25, 30, 30);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);

                    pdfDoc.Open();

                    
                    pdfDoc.Add(new Paragraph("Trip Details"));
                    pdfDoc.Add(new Paragraph("\n"));

                    pdfDoc.Add(new Paragraph($"Trip ID: {data.TripId}"));
                    pdfDoc.Add(new Paragraph($"Destination: {data.Destination}"));
                    pdfDoc.Add(new Paragraph($"Start Date: {data.StartDate}"));
                    pdfDoc.Add(new Paragraph($"End Date: {data.EndDate}"));
                    pdfDoc.Add(new Paragraph($"Itinerary: {data.Itinerary}"));
                    pdfDoc.Add(new Paragraph($"Created At: {data.CreateAt}"));
                    pdfDoc.Add(new Paragraph($"User ID: {data.UserId}"));

                    pdfDoc.Close();
                    writer.Close();

                    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new ByteArrayContent(memoryStream.ToArray());
                    response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/pdf");
                    response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
                    {
                        FileName = $"Trip_{data.TripId}.pdf"
                    };

                    return response;
                }


            }
            catch (Exception ex) {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }


    }
    } 
}
