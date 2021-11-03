
using static System.Net.Mime.MediaTypeNames;

namespace BackEnd.Models
{
    public class photo
    {
        public int Id {  get; set; }
        public byte[] Image {  get; set; }
    }
}
