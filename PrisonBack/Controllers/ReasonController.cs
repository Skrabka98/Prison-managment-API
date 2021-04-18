using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PrisonBack.Domain.Models;
using PrisonBack.Domain.Services;
using PrisonBack.Resources.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrisonBack.Controllers
{
    [Route("/api/[controller]")]
    public class ReasonController : Controller
    {
		private readonly IReasonService _reasonService;
        private readonly IMapper _mapper;
        public ReasonController(IReasonService reasonService, IMapper mapper)
        {
            _reasonService = reasonService;
            _mapper = mapper;
        }

		[HttpGet]
		public async Task<IEnumerable<Reason>> AllReason()
		{
			var reason = _reasonService.AllReasons();
			return await reason;
		}
        [HttpGet("{id}")]
        public ActionResult<ReasonVM> SelectedReason(int id)
        {
            var reason = _reasonService.SelectedReason(id);
            return Ok(_mapper.Map<ReasonVM>(reason));
        }
    }
}
