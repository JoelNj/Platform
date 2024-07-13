using System.ComponentModel.DataAnnotations;

namespace PlatformService.DTOS
{

    public class PlatformReadDto
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Publisher { get; set; }

        public double Cost { get; set; }



    }


}