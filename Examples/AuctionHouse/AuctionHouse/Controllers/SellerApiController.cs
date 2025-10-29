using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AuctionHouse.Models;
using AuctionHouse.DAL.Abstract;

namespace AuctionHouse.Controllers
{
    [Route("api/seller")]
    [ApiController]
    public class SellerAPIController : ControllerBase
    {
        private readonly ISellerRepository _sellerRepository;

        public SellerAPIController(ISellerRepository sellerRepo)
        {
            _sellerRepository = sellerRepo;
        }

        // GET: api/seller/sellers
        [HttpGet("sellers")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Seller>))]
        public ActionResult<IEnumerable<Seller>> GetSellers()
        {
            var sellers = _sellerRepository.GetAll().ToList();
            return sellers;
        }

        // GET: api/seller/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Seller))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Seller> GetSeller(int id)
        {


            var seller = _sellerRepository.FindById(id);
            if (seller == null)
            {
                return NotFound();
            }
            return seller;
        }

        // PUT acts as CREATE and UPDATE ALL, i.e. replace; PATCH means update some (see: https://developer.mozilla.org/en-US/docs/Web/HTTP/Methods/PUT)
        // PUT: api/SellerApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK), ProducesResponseType(StatusCodes.Status201Created), ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult PutSeller(int id, Seller seller)
        {
            // Model validation is applied automatically inside ApiController's and result in an automatic 400 (BadRequest) response
            if (id != seller.Id)
            {
                return Problem(detail: "Invalid ID", statusCode: 400);
            }

            if (_sellerRepository.TaxIdAlreadyInUse(seller.TaxIdnumber))
            {
                return Problem(detail: "The Tax ID entered is invalid.  Please enter your correct ID.",statusCode: 400);
            }
            try
            {
                _sellerRepository.AddOrUpdate(seller);
            }
            catch (DbUpdateConcurrencyException e)
            {
                
                return Problem(detail: "The server experienced a problem.  Please try again.", statusCode: 500);

            }
            catch (DbUpdateException e)
            {
                return Problem(detail: "The server experienced a problem.  Please try again.", statusCode: 500);
            }
            // Return accepted status codes depending on Create or Update
            if(id == 0)
            {
                return CreatedAtAction("GetSeller", new { id = seller.Id }, seller);
            }
            else
            {
                return NoContent();
            }   
        }

        // POSTing a Seller makes no sense, so remove it
        
        // DELETE: api/SellerAPI/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteSeller(int id)
        {
            var seller = _sellerRepository.FindById(id);
            if (seller == null)
            {
                return NotFound();
            }

            try
            {
                _sellerRepository.Delete(seller);
            }
            catch (Exception e)
            {
                return Problem(detail: "The server experienced a problem.  Please try again.", statusCode: 500);
            }

            return NoContent();
        }
    }
}
