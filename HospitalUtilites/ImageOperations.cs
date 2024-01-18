﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalUtilites
{
    public class ImageOperations
    {
        IWebHostEnvironment _env;

        public ImageOperations(IWebHostEnvironment env)
        {
            _env = env;
        }
        public string ImageUpload(IFormFile file)
        {
            string filename = null;
            if(file != null)
            {
                string fileDirectory = Path.Combine(_env.WebRootPath, "Images");
                filename = Guid.NewGuid() + "-" + file.FileName;
                string filepath = Path.Combine(fileDirectory, filename);
                
                if (!Directory.Exists(fileDirectory))
                {
                    Directory.CreateDirectory(fileDirectory);
                }

                using (FileStream fs = new FileStream(filepath, FileMode.Create))

                {
                    file.CopyToAsync(fs);
                }
            }
            return filename;
        }
    }
}
