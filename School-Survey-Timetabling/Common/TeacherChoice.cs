using System.Collections.Generic;

namespace Common
{
    public class TeacherChoice
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Alternative> Alternatives { get; set; }
    }
}
