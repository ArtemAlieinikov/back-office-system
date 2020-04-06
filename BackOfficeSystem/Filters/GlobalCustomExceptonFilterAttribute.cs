using BackOfficeSystem.Exceptions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BackOfficeSystem.Filters
{
    /// <summary>
    /// Represents global custom exception filter
    /// </summary>
    public class GlobalCustomExceptonFilterAttribute : ExceptionFilterAttribute
	{
        private readonly IHostingEnvironment _hostingEnvironment;

        /// <summary>
        /// Initializes <seealso cref="GlobalCustomExceptonFilterAttribute"></seealso> type
        /// </summary>
        /// <param name="hostingEnvironment">Hosting environment</param>
        public GlobalCustomExceptonFilterAttribute(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is ValidatonException ex)
            {
                if (ex is EntityDoesNotExistsException)
                    context.Result = new NotFoundObjectResult(ex.Message);

                if (ex is UnsupportedValueException || ex is UnsupportedAggregationActionException)
                    context.Result = new BadRequestObjectResult(ex.Message);
            }

            if (!_hostingEnvironment.IsDevelopment())
            {
                context.Result = new StatusCodeResult(500);
            }
        }
    }
}
