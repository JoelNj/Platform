using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.DTOS;
using PlatformService.Models;

namespace PlatformService.Controller
{

    [Route("/api/[controller]")]
    [ApiController]
    public class PlatformController : ControllerBase
    {

        private readonly IPlatformRepo _platformRepo;
        private readonly IMapper _mapper;

        public PlatformController(IPlatformRepo repository, IMapper mapper)
        {
            this._platformRepo = repository;
            this._mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
        {

            Console.WriteLine("Getting Plateforms");
            var platforms = _platformRepo.GetAllPlatforms();
            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platforms));
        }


        [HttpGet("{id}", Name = "GetPlatformById")]
        public ActionResult<PlatformReadDto> GetPlatformById(int id)
        {
            Console.WriteLine("Get one platform");
            var platform = _platformRepo.GetPlatformById(id);
            return Ok(_mapper.Map<PlatformReadDto>(platform));
        }

        [HttpPost]

        public ActionResult<PlatformCreateDto> CreatePlatform(PlatformCreateDto plateforn)
        {
            var plateformModel = _mapper.Map<Platform>(plateforn);
            _platformRepo.createPlateform(plateformModel);
            _platformRepo.SaveChanges();


            var platformReadDto = _mapper.Map<PlatformReadDto>(plateformModel);
            return CreatedAtRoute(nameof(GetPlatformById),
                new {Id=platformReadDto.Id},platformReadDto);
        }
    }





}