using PlatformService.Models;

namespace PlatformService.Data
{


    public class PlatformRepo : IPlatformRepo
    {

        private readonly AppDbContext _context;


        public PlatformRepo(AppDbContext context)
        {
            _context = context;
        }
        public void createPlateform(Platform platform)
        {
            if (platform == null)
            {
                throw new ArgumentException(nameof(platform));
            }
            _context.Platforms.Add(platform);
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
            return _context.Platforms.ToList();
        }

        public Platform GetPlatformById(int id)
        {
            return _context.Platforms.FirstOrDefault(P => P.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }



}