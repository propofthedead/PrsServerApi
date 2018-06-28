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
    public class PurchaseRequestsController : ApiController
    {
        private CapstoneApiContext db = new CapstoneApiContext();

        // GET: api/PurchaseRequests
        public IQueryable<PurchaseRequest> GetPurchaseRequests()
        {
            return db.PurchaseRequests;
        }

        // GET: api/PurchaseRequests/5
        [ResponseType(typeof(PurchaseRequest))]
        public IHttpActionResult GetPurchaseRequest(int id)
        {
            PurchaseRequest purchaseRequest = db.PurchaseRequests.Find(id);
            if (purchaseRequest == null)
            {
                return NotFound();
            }

            return Ok(purchaseRequest);
        }

        // PUT: api/PurchaseRequests/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPurchaseRequest(int id, PurchaseRequest purchaseRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != purchaseRequest.Id)
            {
                return BadRequest();
            }

            db.Entry(purchaseRequest).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PurchaseRequestExists(id))
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

        // POST: api/PurchaseRequests
        [ResponseType(typeof(PurchaseRequest))]
        public IHttpActionResult PostPurchaseRequest(PurchaseRequest purchaseRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PurchaseRequests.Add(purchaseRequest);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = purchaseRequest.Id }, purchaseRequest);
        }

        // DELETE: api/PurchaseRequests/5
        [ResponseType(typeof(PurchaseRequest))]
        public IHttpActionResult DeletePurchaseRequest(int id)
        {
            PurchaseRequest purchaseRequest = db.PurchaseRequests.Find(id);
            if (purchaseRequest == null)
            {
                return NotFound();
            }

            db.PurchaseRequests.Remove(purchaseRequest);
            db.SaveChanges();

            return Ok(purchaseRequest);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PurchaseRequestExists(int id)
        {
            return db.PurchaseRequests.Count(e => e.Id == id) > 0;
        }
    }
}