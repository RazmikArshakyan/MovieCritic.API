using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCritic.Core.Services
{
    public interface IGptService
    {
        // interface which our gptservice inherits
        public string Request(string wantedMovie);
    }
}
