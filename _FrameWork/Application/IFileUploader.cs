using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

namespace _FrameWork.Application
{
    public interface IFileUploader
    {
        string Upload(IFormFile file, string path);
    }
}
