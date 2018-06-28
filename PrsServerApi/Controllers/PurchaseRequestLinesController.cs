using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PrsServerApi.Models;

namespace PrsServerApi.Controllers
{
    public class PurchaseRequestLinesController : ApiController
    {
        private CapstoneApiContext db = new CapstoneApiContext();

        // GET: api/PurchaseRequestLines
        public IQueryable<PurchaseRequestLine> GetPurchaseRequestLines()
        {
            return db.PurchaseRequestLines;
        }

        // GET: api/PurchaseRequestLines/5
        [ResponseType(typeof(PurchaseRequestLine))]
        public IHttpActionResult GetPurchaseRequestLine(int id)
        {
            PurchaseRequestLine purchaseRequestLine = db.PurchaseRequestLines.Find(id);
            if (purchaseRequestLine == null)
            {
                return NotFound();
            }

            return Ok(purchaseRequestLine);
        }

        // PUT: api/PurchaseRequestLines/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPurchaseRequestLine(int id, PurchaseRequestLine purchaseRequestLine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != purchaseRequestLine.Id)
            {
                return BadRequest();
            }

            db.Entry(purchaseRequestLine).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PurchaseRequestLineExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/PurchaseRequestLines
        [ResponseType(typeof(PurchaseRequestLine))]
        public IHttpActionResult PostPurchaseRequestLine(PurchaseRequestLine purchaseRequestLine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PurchaseRequestLines.Add(purchaseRequestLine);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = purchaseRequestLine.Id }, purchaseRequestLine);
        }

        // DELETE: api/PurchaseRequestLines/5
        [ResponseType(typeof(PurchaseRequestLine))]
        public IHttpActionResult DeletePurchaseRequestLine(int id)
        {
            PurchaseRequestLine purchaseRequestLine = db.PurchaseRequestLines.Find(id);
            if (purchaseRequestLine == null)
            {
                return NotFound();
            }

            db.PurchaseRequestLines.Remove(purchaseRequestLine);
            db.SaveChanges();

            return Ok(purchaseRequestLine);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PurchaseRequestLineExists(int id)
        {
            return db.PurchaseRequestLines.Count(e => e.Id == id) > 0;
        }
    }
}