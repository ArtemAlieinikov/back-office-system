using BackOfficeSystem.BLL;
using BackOfficeSystem.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BackOfficeSystem.Controllers
{
	/// <summary>
	/// Handle API calls for Brand manipulations
	/// </summary>
	[Route("api/brands")]
	[ApiController]
	public class BrandsController : ControllerBase
	{
		/// <summary>
		/// Instance of <seealso cref="IBrandService"></seealso> type
		/// </summary>
		public readonly IBrandService _brandService;

		/// <summary>
		/// Initializes <seealso cref="BrandsController"></seealso> type
		/// </summary>
		/// <param name="brandService"></param>
		public BrandsController(IBrandService brandService)
		{
			_brandService = brandService;
		}

		/// <summary>
		/// Returns brand by id
		/// </summary>
		/// <param name="id">Id of brand</param>
		/// <returns>Returns <seealso cref="BrandDto"></seealso> type</returns>
		[HttpGet("{id}")]
		public ActionResult<BrandDto> Get(int id)
		{
			var result = _brandService.Get(id);
			return Ok(result);
		}

		/// <summary>
		/// Deletes brand by id
		/// </summary>
		/// <param name="id">Id of brand</param>
		/// <returns>Returns <seealso cref="ActionResult"></seealso> type</returns>
		[HttpDelete("{id}")]
		public ActionResult Delete(int id)
		{
			_brandService.Delete(id);
			return NoContent();
		}

		/// <summary>
		/// Creates brand
		/// </summary>
		/// <param name="brand">Brand to create</param>
		/// <returns>Returns <seealso cref="BrandDto"></seealso> type</returns>
		[HttpPost]
		public ActionResult Post([FromBody] BrandDto brand)
		{
			_brandService.Create(brand);
			return NoContent();
		}

		/// <summary>
		/// Updates brand
		/// </summary>
		/// <param name="id">Id of brand</param>
		/// <param name="brand">Brand data</param>
		/// <returns>Returns <seealso cref="ActionResult"></seealso> type</returns>
		[HttpPut("{id}")]
		public ActionResult Put(int id, [FromBody] BrandDto brand)
		{
			_brandService.Update(id, brand);
			return NoContent();
		}
	}
}
